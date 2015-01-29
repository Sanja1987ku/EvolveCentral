<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="ServiceEdit.aspx.cs" Inherits="EvolveCentral.Administration.ServiceEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

<telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
       
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

      <br />         
        <table style="width:100%;">
            <tr>
                <td colspan="2">

                    <asp:Panel runat="server" ID="pnl" GroupingText="CREATE/EDIT SERVICE" Width="100%" >
                    <table>                       
                                    <tr>
                                        <td>
 <asp:Panel runat="server" ID="Panel2" GroupingText="SERVICE DETAILS" Width="100%" >
                    <table>                       
                                    <tr>
                                        <td>
                                              <asp:Label runat="server" ID="lblId" Text="ID:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtId" runat="server" Text='<%# Bind("Id") %>' Enabled="false" />                                            
                                        </td>
                                      
                                    </tr>
                        <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label12" Text="CODE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtCode" runat="server"  />
                                           
                                        </td>
                                    </tr>    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text="NAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtName" runat="server"  />
                                           
                                        </td>
                                    </tr> 
                       <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" Text="CLIENT:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                             <telerik:RadComboBox ID="rcbClient" runat="server" />
                                           
                                        </td>
                                    </tr>  
                       <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label5" Text="SERVICE TEMPLATE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbServiceTemplate" runat="server" />
                                           
                                        </td>
                                    </tr>  
                     <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label8" Text="DESCRIPTION:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtDescription" runat="server" TextMode="MultiLine"  />
                                           
                                        </td>
                                    </tr> 
                            <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label3" Text="ACTIVE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Bind("Active") %>' />
                                           
                                        </td>
                                    </tr>      </table>
                        </asp:Panel>

                                        </td>
                                    <td style="vertical-align:top;">
<asp:Panel runat="server" ID="Panel3" GroupingText="CONNECTION DETAILS" Width="100%" >
                    <table>                       
                                     <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label6" Text="DATABASE SERVER:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtDatabaseServer" runat="server"  />
                                           
                                        </td>
                                    </tr> 
                          <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label2" Text="DATABASE NAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtDataBaseName" runat="server"  />
                                           
                                        </td>
                                    </tr> 
                          <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label7" Text="DATABASE USER:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtDatabaseUsername" runat="server"  />
                                           
                                        </td>
                                    </tr> 
                        <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label9" Text="DATABASE PASSWORD:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtDatabasePassword" runat="server" TextMode="MultiLine"  />
                                           
                                        </td>
                                    </tr> 
                      <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label10" Text="SOURCE DATABASE NAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtSourceDatabaseName" runat="server" TextMode="MultiLine"  />
                                           
                                        </td>
                                    </tr> 
                         <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label11" Text="DESTINATION DATABASE NAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtDestinationDatabaseName" runat="server" TextMode="MultiLine"  />
                                           
                                        </td>
                                    </tr> 
                    </table>
                        </asp:Panel>

                                    </td>    
                                    </tr>
                        </table>
                        </asp:Panel>
                            
                    
                   
                                      
                       
                       
                           
                            
                               
                                            <asp:Label runat="server"  ID="lblError" ForeColor="Red" />
                                  
                                    


                 <asp:Button ID="btnUpdate" Text="SAVE" runat="server" onclick="btnUpdate_Click" />
                            
                
       
                                       
                                             <asp:Button ID="btnCancel" Text="CANCEL" runat="server" CausesValidation="False" CommandName="Cancel"  OnClick="btnCancel_Click" />
                               
                                   


              

         
</asp:Content>
