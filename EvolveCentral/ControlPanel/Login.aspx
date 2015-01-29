<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EvolveCentral.ControlPanel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/ControlPanel/Login.css" rel="stylesheet" />

    <style type="text/css">
        fieldset
        {
            
            width: 200px; /* or a percentage, or whatever */
            margin-bottom: auto;
            margin-left: auto;
            margin-right: auto;
        }
    </style>

</head>
<body>
        
        <form id="form1" runat="server"  style="text-align:center;vertical-align:middle;">
           
             <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>

          
               
           
                            
                            <fieldset>
                    <legend style="text-align:left;"><span><img src="../Images/Logo_ControlPanel_Login.png" width="200px" height="110px" /></span></legend>
<table>
<tr>
                       
                        <td style="text-align:left;">
                            <asp:Label CssClass="riLabel" runat="server" ID="lblEmail" Text="E-MAIL:"  />
                        </td>
                        <td>
                            <telerik:RadTextBox runat="server" ID="txtEmail" Width="190px" />
                        </td>
                    </tr>
                    <tr>                      
                     <td style="text-align:left;">
                        <asp:Label CssClass="riLabel" runat="server" ID="lblPassword" Text="PASSWORD:" />
                        </td>
                        <td style="width:100px;">
                            <telerik:RadTextBox runat="server" ID="txtPassword" TextMode="Password" Width="190px" />
                        </td>
                    </tr>
                    <tr>
                      
                        <td colspan="2" style="text-align:right">
                            <telerik:RadButton runat="server" ID="btnLogin" Text="LOGIN" OnClick="btnLogin_Click"  />
                        </td>
                    </tr>
</table>
                              
                       
                        </fieldset>
                          
        </form>
    </body>
</html>
