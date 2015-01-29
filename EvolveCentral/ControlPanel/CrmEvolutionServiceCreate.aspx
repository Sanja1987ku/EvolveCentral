<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="CrmEvolutionServiceCreate.aspx.cs" Inherits="EvolveCentral.ControlPanel.CrmEvolutionServiceCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

    <link href="../Styles/ControlPanel/FormCreate.css" rel="stylesheet" />
    <link href="../Styles/ControlPanel/Messagebox.css" rel="stylesheet" />

    <telerik:RadScriptBlock runat="server"> 
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
                            <asp:LinkButton runat="server" ID="lnkCloseMessageBox" Text="Close" Font-Size="17px" OnClientClick="CloseMessageBox();" />
                            
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
                      Services - CRM & Evolution
                </td>
            </tr>
        </table>
        <hr />
    </div>
    
    <div class="Content">
         <telerik:RadAjaxLoadingPanel runat="server" ID="ralp" />
       <telerik:RadAjaxPanel runat="server" ID="rap" LoadingPanelID="ralp">
         <fieldset>
             <legend><span><img src="../Images/Fieldset_Create_16x16.png" /></span>&nbsp;CREATE</legend>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label1" Text="Code:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtCode" />
                    </td>
                  
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label2" Text="Name:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtName" />
                    </td>
                   
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label3" Text="Service Template:" />
                    </td>
                    <td>
                       <telerik:RadComboBox runat="server" ID="rcbServiceTemplate" DataValueField="Id" DataTextField="Name" />
                    </td>
                   
                </tr>
               <tr>
                    <td>
                        <asp:Label runat="server" ID="Label5" Text="Company:" />
                    </td>
                    <td>
                       <telerik:RadComboBox runat="server" ID="rcbCompany" DataValueField="Id" DataTextField="Name" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label6" Text="Connection - Server:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtConnectionServer" />
                    </td>
                   
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label8" Text="Connection - Database:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtConnectionDatabase" />
                    </td>
                   
                </tr>
                  <tr>
                    <td>
                        <asp:Label runat="server" ID="Label9" Text="Connection - Username:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtConnectionUsername" />
                    </td>
                   
                </tr>
                  <tr>
                    <td>
                        <asp:Label runat="server" ID="Label10" Text="Connection - Password:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtConnectionPassword" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label11" Text="Source Database:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtSourceDatabase" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label12" Text="Destination Database:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtDestinationDatabase" />
                    </td>
                   
                </tr>
                   <tr>
                    <td>
                        <asp:Label runat="server" ID="Label4" Text="Description:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtDescription" TextMode="MultiLine" Height="150px"  />
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
