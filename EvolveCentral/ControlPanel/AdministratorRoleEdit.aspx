<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="AdministratorRoleEdit.aspx.cs" Inherits="EvolveCentral.ControlPanel.AdministratorRoleEdit" %>
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
                    Administrator Roles
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
                  <td>  <table>
             <tr>
                    <td>
                        <asp:Label runat="server" ID="Label11" Text="Id:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtId" />
                    </td>
                  
                </tr>      <tr>
                    <td>
                        <asp:Label runat="server" ID="Label1" Text="Code:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtCode" />
                    </td>
                    <td>
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
                        <asp:Label runat="server" ID="Label3" Text="Description:" />
                    </td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtDescription" TextMode="MultiLine" Height="100px" />
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
    </td>
             <td style="vertical-align:top;">
                     <table>
                        <tr>
                             <td style="vertical-align:top;">
<asp:Label runat="server" ID="lblPermission" Text="Permission:" /></td>
                            <td><telerik:RadTreeView runat="server" ID="rtvPermission" DataSourceID="edsAdministratorPermission" DataFieldParentID="ParentId" DataFieldID="Id" DataTextField="Name" CheckBoxes="true" CheckChildNodes="true" OnDataBound="rtvPermission_DataBound" DataValueField="Id"  /></td>
                        </tr>

                    </table>

                </td>
              </tr>
          </table>   </fieldset>
        
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

  <asp:EntityDataSource runat="server" ID="edsAdministratorPermission"  ConnectionString="name=entitiesEvolveCentral"  DefaultContainerName="entitiesEvolveCentral" EnableFlattening="False" EntitySetName="AdministratorPermissionItems" OnSelecting="edsAdministratorPermission_Selecting" AutoGenerateWhereClause="false" />
     </asp:Content>
