<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="AdministratorAccountChangePassword.aspx.cs" Inherits="EvolveCentral.ControlPanel.AdministratorAccountChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

 <link href="../Styles/ControlPanel/FormView.css" rel="stylesheet" />
     <link href="../Styles/ControlPanel/Messagebox.css" rel="stylesheet" />

     <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server"> 
       <script type="text/javascript">
           function CloseMessageBox() {
               var oWnd = $find('<%= rwm.ClientID %>');
              oWnd.closeAll();
          }
            </script>
        </telerik:RadScriptBlock>
    
    <telerik:RadWindowManager ID="rwm" runat="server" EnableShadow="true" Modal="true" autosize="true" ClientIDMode="Static" >
        <AlertTemplate>
            <div  class="MessageBox">
                <table style="background-color:#3d4b5b;">
                    <tr>
                        <td>
                            <img src="../Images/MessageBox_Exclamation_32x32.png" />
                        </td>
                        <td>
                            <h1>VALIDATION ERROR</h1>
                        </td>
                    </tr>
                </table>
                <table style="background-color:#718CA2;">
                    <tr>
                        <td colspan="2">
                            {1}
                        </td>
                    </tr>
                </table>
                <table style="background-color:#3d4b5b;">
                    <tr>
                        <td colspan="2" style="text-align:right;">
                            <asp:LinkButton runat="server" ID="lnkCloseMessageBox" Text="Close" OnClientClick="CloseMessageBox();" />
                            
                        </td>
                    </tr>
                </table>
            </div>
        </AlertTemplate>
    </telerik:RadWindowManager>

     <div class="ContentTitle">
        <table>
            <tr>
                <td>
                 
                </td>
                <td>
                    Administrator Accounts - Change Password
                </td>
            </tr>
        </table>
        <hr />
    </div>
    
    <div class="Content">
            <fieldset>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label1" Text="New password:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtPassword" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label2" Text="New password again:" />
                    </td>
                    <td>
                     <telerik:RadTextBox runat="server" ID="txtPasswordAgain" />
                    </td>
                    <td>
                      </td>
                </tr>
               

            </table>
             </fieldset>
        
        <table style="width:100%;">
            <tr>
                <td style="text-align:left;" colspan="2">
                    <telerik:RadButton runat="server" ID="btnBack" Text="BACK" Width="120px" Font-Bold="true"  CausesValidation="false" OnClick="btnBack_Click" Icon-PrimaryIconCssClass="rbPrevious"  />
                </td>
            <td style="text-align:right;">
                    <telerik:RadButton runat="server" ID="btnSave" Text="SAVE" Width="120px" Font-Bold="true" CausesValidation="true" Icon-PrimaryIconCssClass="rbSave" OnClick="btnSave_Click" />
                            </td>
             
            </tr>
        </table>
    
    </div>
</asp:Content>
