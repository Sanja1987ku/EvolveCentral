﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="MemberAccountEdit.aspx.cs" Inherits="EvolveCentral.ControlPanel.MemberAccountEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

    <link href="../Styles/ControlPanel/FormEdit.css" rel="stylesheet" />
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
                    Member Accounts
                </td>
            </tr>
        </table>
        <hr />
    </div>
    
    <div class="Content">
         <telerik:RadAjaxLoadingPanel runat="server" ID="ralp" />
       <telerik:RadAjaxPanel runat="server" ID="rap" LoadingPanelID="ralp">
        <fieldset>
            <legend> <span><img src="../Images/Fieldset_Edit_16x16.png" /></span>&nbsp; EDIT</legend>
             <table>
             <tr>
                    <td>
                        <asp:Label runat="server" ID="Label11" Text="Id:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtId" />
                    </td>
                    <td>
                    </td>
                </tr>     <tr>
                    <td>
                        <asp:Label runat="server" ID="Label1" Text="First Name:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtFirstName" />
                    </td>
                  
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label2" Text="Last Name:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtLastName" />
                    </td>
                   
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label3" Text="E-mail:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtEmail" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label8" Text="Gender:" />
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rblGender" RepeatDirection="Horizontal" >
                        <asp:ListItem Selected="True" Text="Male" Value="MALE" />
                            <asp:ListItem Text="Female" Value="FEMALE" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label runat="server" ID="Label9" Text="Company:" />
                    </td>
                    <td>
                        <telerik:RadComboBox runat="server" ID="rcbCompany" DataValueField="Id" DataTextField="Name" />
                    </td>
                </tr>
               
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label5" Text="Password:" />
                    </td>
                    <td>
                        <asp:LinkButton runat="server" ID="lbChangePassword" text="Change" OnClick="lbChangePassword_Click" />
                    </td>
                    <td>
                      </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label7" Text="Active:" />
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="chkActive" Checked="true" />
                    </td>
                    <td></td>
                </tr>
            </table>
          </fieldset>
        
        <table style="width:100%;">
            <tr>
                <td style="text-align:left;">
                    <telerik:RadButton runat="server" ID="btnBack" Text="BACK" Width="120px" Font-Bold="true"  CausesValidation="false" OnClick="btnBack_Click" Icon-PrimaryIconCssClass="rbPrevious"  />
                </td>
                <td style="text-align:right;">
                    <telerik:RadButton runat="server" ID="btnSave" Text="SAVE" Width="120px" Font-Bold="true" CausesValidation="true" Icon-PrimaryIconCssClass="rbSave" OnClick="btnSave_Click" />
                            </td>
            </tr>
        </table>
        </telerik:RadAjaxPanel>
    </div>

</asp:Content>
