using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace EvolveCentralConsole
{
    class Program
    {
     static   DateTime syncstartdate = new DateTime();
     static int? CurrentLogId = null;
     static int? CurrentServiceId = null;
     static DAL.entitiesEvolveCentralConsole ctx = new DAL.entitiesEvolveCentralConsole();

        static void Main(string[] args)
        {
            bool isSuccessful = true;
            syncstartdate = DateTime.Now; 
           
            Console.Write("EVOLVE CENTRAL CONSOLE STARTED!");
            string filename = "Configuration.txt";
            Console.Write("READING CONFIGURATION FILE...");  

            string servicecode = GetServiceCode(filename);
            if (servicecode == null)
            {
                string message = "READING SERVICE CODE FROM CONFIGURATION FILE FAILED!";
                Console.Write(message);
                SendMail(message);
                isSuccessful = false;
                return;
            }
            Console.Write("READING CLIENT CODE FROM CONFIGURATION FILE WAS SUCCESSFUL! - SERVICE CODE: " + servicecode);
          


          


            Console.Write("READING SERVICE ITEM FROM THE DATABASE...");
            DAL.ServiceCrmEvolutionItem serviceitem = DAL.ServiceCrmEvolution.GetByCode(ctx, servicecode);
            
          

            if (serviceitem  == null)
            {
                string message = "READING SERVICE ITEM WITH CODE= " + servicecode + "FROM THE DATABASE FAILED!";
                LogMessage(message,false);
                SendMail(message);
                isSuccessful = false;
                return;
            }

            int serviceid = serviceitem.Id;
            CurrentServiceId = serviceid;

            CreateLogInTheDatabase();
            LogMessage("READING SERVICE ITEM FROM THE DATABASE WAS SUCESSFUL! - SERVICE ID: " + serviceid.ToString(),true);

            List<DAL.ServiceCrmEvolutionDetailItem> items = new List<DAL.ServiceCrmEvolutionDetailItem>();






            LogMessage("READING SQL COMMANDS FROM THE DATABASE...",true);
         
            items = DAL.ServiceCrmEvolutionDetail.GetByServiceID(ctx,Convert.ToInt32(serviceid));
            if (items.Count ==  0)
            {
                LogMessage("READING SQL COMMANDS FROM THE DATABASE WAS SUCCESSFUL! NUMBER OF ITEMS: " + items.Count.ToString(),false);
                return;
         
            }


            LogMessage("READING SQL COMMANDS FROM THE DATABASE WAS SUCCESSFUL! NUMBER OF ITEMS: " + items.Count.ToString(),true);
           

            string connstring = null;
       

            string databasename_source = null;
            string databasename_destination = null;


            connstring = "Server=[@DATABASESERVER];User Id=[@DATABASEUSERNAME];Password=[@DATABASEPASSWORD];DataBase=[@DATABASENAME];";
            connstring = connstring.Replace("[@DATABASESERVER]",  serviceitem.Connection_DatabaseServer);
            connstring = connstring.Replace("[@DATABASEUSERNAME]", serviceitem.Connection_DatabaseUserName);
            connstring = connstring.Replace("[@DATABASEPASSWORD]", serviceitem.Connection_DatabasePassword);
            connstring = connstring.Replace("[@DATABASENAME]", serviceitem.Connection_DatabaseName);
           
            LogMessage("CONNECTING TO THE DATABASE...",true);
            SqlConnection sqlconn = new SqlConnection(connstring);

            try
            {
           
                sqlconn.Open();
              string message = "CONNECTING TO THE DATABASE WAS SUCCESSFUL!";
                LogMessage(message,true);
               
            }
            catch (Exception ex)
            {
                LogException(ex,"CONNECTING TO THE DATABASE FAILED!");
                isSuccessful = false;  
            }

            LogMessage("EXECUTION OF SQL COMMANDS IS STARTING...",true);

            foreach (DAL.ServiceCrmEvolutionDetailItem item in items)
            {
               
                try
                {
                    string sqlcommand = item.Command;
                    sqlcommand = sqlcommand.Replace("[sourceDataBase]", "[" + serviceitem.DatabaseName_Source + "]");
                    sqlcommand = sqlcommand.Replace("[destinationDataBase]", "[" + serviceitem.DatabaseName_Destination + "]");
                 
   
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlconn;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandTimeout = 0;
                    if (!string.IsNullOrEmpty(sqlcommand))
                    {
                     //  LogMessage("EXECUTING SQL COMMAND... - " + item.Name + " ( " + item.Id.ToString() + " )");
                        cmd.CommandText = sqlcommand;
                        cmd.ExecuteNonQuery();
                        LogSqlCommand(item,"EXECUTING SQL COMMAND... - " + item.Name + " ( " + item.Id.ToString() + " ) WAS SUCCESSFUL!");
                      
                    }
             
                }
                catch (Exception ex)
                {
              LogSqlCommandException( item,ex, "EXECUTING SQL COMMAND... - " + item.Name + " ( " + item.Id.ToString() + " ) HAS FAILED!");
              isSuccessful = false; 
                }
                finally
                {
                    if (sqlconn != null)
                    {
                      //  ((IDisposable)sqlconn).Dispose();
                    }
                }

            }

            try
            {
                sqlconn.Close();
            }

            catch (Exception ex)
            {
                isSuccessful = false;
            }
            LogMessage("SYNCHRONIZATION FINISHED!",true);

            serviceitem.LastSyncDate = DateTime.Now;
            serviceitem.LastSyncSuccessful = Convert.ToBoolean(isSuccessful);
            DAL.ServiceCrmEvolution.Save(ctx, serviceitem);
        }

      static  void LogException(Exception ex, string message)
        {
            Console.WriteLine(ex.Message);
            LogExceptionToDatabase(ex, message);
        }

      static void LogSqlCommandException(DAL.ServiceCrmEvolutionDetailItem item, Exception ex, string message)
      {
          Console.WriteLine(ex.Message);
          
          LogSqlCommandExceptionToDatabase(item,ex, message);
          SendMail(item,ex);
      }
      static void LogSqlCommand(DAL.ServiceCrmEvolutionDetailItem item, string message)
      {
          Console.WriteLine(message);
          LogSqlCommandToDatabase(item, message);
      }
      static void LogMessage(string message,bool success)
        {
            Console.WriteLine(message);
            LogMessageToDatabase(message,success);
        }
      static void SendMail(DAL.ServiceCrmEvolutionDetailItem item, Exception ex)
     {
         try
         {
             string message = null;

             message = "EVOLVE CENTRAL EXCEPTION REPORT";
             message += Environment.NewLine;
             message += Environment.NewLine;
             message += "CLIENT: " + item.ServiceCrmEvolutionItem.CompanyItem.Name;
             message += Environment.NewLine;
             message += "SERVICE TYPE: " + item.ServiceCrmEvolutionItem.ServiceTemplateCrmEvolutionItem.ServiceTypeItem.Name;
             message += Environment.NewLine;
             message += "SERVICE: " + item.ServiceCrmEvolutionItem.Name + " ( " + item.ServiceCrmEvolutionItem.Code + " ) ";
             message += Environment.NewLine;
             message += "SERVICE COMMAND: " + item.Name + " (ID: " + item.Id.ToString() + " ) ";
             message += Environment.NewLine;
             message += Environment.NewLine;
             message += "EXCEPTION:";
             message += Environment.NewLine;
             message += Environment.NewLine;
             message += ex.Message;

             SendMail(message);
         }
         catch
         {

         }
     }
       
        static void LogMessageToDatabase(string message,bool success)
        {
            DAL.SyncLogCrmEvolutionDetailItem item = new DAL.SyncLogCrmEvolutionDetailItem();
            item.SyncLogCrmEvolutionId = CurrentLogId;
            item.Name = message;
            item.IsSuccessful = success;
            item.CreateDate = DateTime.Now;
            DAL.SyncLogCrmEvolutionDetail.Save(ctx, item);
           

        }

        static void LogSqlCommandToDatabase(DAL.ServiceCrmEvolutionDetailItem i, string message)
        {
            DAL.SyncLogCrmEvolutionDetailItem item = new DAL.SyncLogCrmEvolutionDetailItem();
            item.SyncLogCrmEvolutionId = CurrentLogId;
            item.Name = message;
            item.IsSuccessful = true;
            item.ExecutedCommand = i.Name;
            item.CreateDate = DateTime.Now;
            item.ErrorMessage = null;
            
            DAL.SyncLogCrmEvolutionDetail.Save(ctx, item);


        }

        static void LogSqlCommandExceptionToDatabase(DAL.ServiceCrmEvolutionDetailItem i, Exception ex, string message)
        {
            DAL.SyncLogCrmEvolutionDetailItem item = new DAL.SyncLogCrmEvolutionDetailItem();
            item.SyncLogCrmEvolutionId = CurrentLogId;
            item.Name = message;
            item.IsSuccessful = false;
            item.ExecutedCommand = i.Command;
            item.CreateDate = DateTime.Now;
            item.ErrorMessage = ex.Message;


         
            DAL.SyncLogCrmEvolutionDetail.Save(ctx, item);

            DAL.SyncLogCrmEvolutionItem litem = DAL.SyncLogCrmEvolution.GetById(ctx, Convert.ToInt32(item.SyncLogCrmEvolutionId));
            litem.IsSuccessful = false;
            DAL.SyncLogCrmEvolution.Save(ctx, litem);
        }
        static void LogExceptionToDatabase( Exception ex, string message)
        {
            DAL.SyncLogCrmEvolutionDetailItem item = new DAL.SyncLogCrmEvolutionDetailItem();
            item.SyncLogCrmEvolutionId = CurrentLogId;
            item.Name = message;
            item.IsSuccessful = false;
            item.ExecutedCommand = null;
            item.CreateDate = DateTime.Now;
            item.ErrorMessage = ex.Message;


            DAL.SyncLogCrmEvolutionDetail.Save(ctx, item);


            DAL.SyncLogCrmEvolutionItem litem = DAL.SyncLogCrmEvolution.GetById(ctx, Convert.ToInt32(item.SyncLogCrmEvolutionId));
            litem.IsSuccessful = false;
            DAL.SyncLogCrmEvolution.Save(ctx, litem);
    
        }
        static void CreateLogInTheDatabase()
        {
            DAL.SyncLogCrmEvolutionItem item = new DAL.SyncLogCrmEvolutionItem();
            item.CreateDate = syncstartdate;
            item.IsSuccessful = true;
            item.ServiceCrmEvolutionId = Convert.ToInt32(CurrentServiceId);
            DAL.SyncLogCrmEvolution.Save(ctx, item);
            CurrentLogId = item.Id;


        }

        static string ExtractConfigValue(List<DAL.ApplicationSettingsItem> configvalues, string code)
        {
            string retval = null;
            retval = (from i in configvalues where i.Code == code select i.Value).FirstOrDefault(); 

            return retval;


        }

        static void SendMail(string message)
        {
            try
            {

                List<DAL.ApplicationSettingsItem> configvalues = DAL.ApplicationSettings.GetAll(ctx);

                string Mail_SMTP_Server = ExtractConfigValue(configvalues, "Mail_SMTP_Server");
                string Mail_SMTP_Username = ExtractConfigValue(configvalues, "Mail_SMTP_Username");
                string Mail_SMTP_Password = ExtractConfigValue(configvalues, "Mail_SMTP_Password");
                string Mail_SMTP_FromEmailAddress = ExtractConfigValue(configvalues, "Mail_SMTP_FromEmailAddress");
                string Mail_SMTP_UserSSL = ExtractConfigValue(configvalues, "Mail_SMTP_UserSSL");
                string Mail_SMTP_Port = ExtractConfigValue(configvalues, "Mail_SMTP_Port");
                string Mail_SMTP_FromDisplayName = ExtractConfigValue(configvalues, "Mail_SMTP_FromDisplayName");
                string Mail_SMTP_MailTitle = ExtractConfigValue(configvalues, "Mail_SMTP_MailTitle");

                SmtpClient smtpClient = new SmtpClient(Mail_SMTP_Server, Convert.ToInt32(Mail_SMTP_Port));

                smtpClient.Credentials = new System.Net.NetworkCredential(Mail_SMTP_Username, Mail_SMTP_Password);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = Convert.ToBoolean(Mail_SMTP_UserSSL);

                //List<DAL.AlertItem> alerts = DAL.Alert.GetByService(ctx, Convert.ToInt32(CurrentServiceId));
                //foreach (DAL.AlertItem i in alerts)
                //{
                //    MailMessage mail = new MailMessage();


                //    mail.From = new MailAddress(Mail_SMTP_FromEmailAddress, Mail_SMTP_FromDisplayName);

                //    mail.To.Add(new MailAddress(i.Email));
                //    mail.Subject = Mail_SMTP_MailTitle;

                //    mail.Body = message;
                //    //"Last Synced Table: " + LastSyncedTable + "Last synced query type: " + LastSyncedQueryType + Environment.NewLine + Environment.NewLine + ex.Message;
                //    smtpClient.Send(mail);

                //}
            }
            catch (Exception ex)
            {


            }
          
        }
       static string GetClientCode(string filename)
        {

string code =  null;










try
{
string content = File.ReadAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\" + filename);
code = content.Split(';')[0];
}
catch (Exception ex)
{

    return null;
}

return code;
        }
       static string GetServiceCode(string filename)
        {

            string code = null;










            try
            {
                string content = File.ReadAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\" + filename);
                code = content;
            }
            catch (Exception ex)
            {

                return null;
            }

            return code;
        }

    
    }
}
