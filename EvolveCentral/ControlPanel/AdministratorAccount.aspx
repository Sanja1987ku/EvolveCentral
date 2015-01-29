    <%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="AdministratorAccount.aspx.cs" Inherits="EvolveCentral.ControlPanel.AdministratorAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

    <link href="../Styles/ControlPanel/FormList.css" rel="stylesheet" />

    <script type="text/javascript">

        function ConfirmDelete(btn) {
            function CallbackFn(arg) {
                if (arg) {
                   eval(btn.href);
                }
            }
           radconfirm("Do you really want to delete this item?", CallbackFn, 370, 140, null, "DELETE ADMINISTRATOR ACCOUNT", "../Images/MessageBox_Question_32x32.png");
        }
    </script>
    <telerik:RadWindowManager ID="rwm" runat="server" EnableShadow="true" />
        
    <div class="ContentTitle">
        <table>
            <tr>
                <td>
                   
                </td>
                <td>
                   Administrator Accounts
                </td>
            </tr>
        </table>
        <hr />
    </div>
        
    <div class="Content">
    
        <telerik:RadAjaxLoadingPanel runat="server" ID="ralp" />
    
        <telerik:RadAjaxPanel runat="server" ID="rap" LoadingPanelID="ralp">
        
            <telerik:RadGrid ID="rgvData" runat="server" DataSourceId="eds" AutoGenerateColumns="false" AllowPaging="true" AllowFiltering="true"
                             AllowSorting="true"  AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand" OnDataBound="rgvData_DataBound" OnItemDataBound="rgvData_ItemDataBound" >

                <MasterTableView CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add new record" CommandItemSettings-RefreshText="Refresh"
                                 DataKeyNames="Id">

                    <Columns>
                                 
                        <telerik:GridButtonColumn UniqueName="View" Text="View" CommandName="View" HeaderTooltip="View" ButtonType="ImageButton"   ImageUrl= "~/Images/Grid_View_16x16.png" />
                    
                        <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id" HeaderStyle-Width="20px" />
                        
                        <telerik:GridBoundColumn UniqueName="FirstName" HeaderText="FIRST NAME" DataField="FirstName" />
                        
                        <telerik:GridBoundColumn UniqueName="LastName" HeaderText="LAST NAME" DataField="LastName" />
                        
                        <telerik:GridBoundColumn UniqueName="Email" HeaderText="E-MAIL" DataField="Email" />
                        
                        <telerik:GridBoundColumn UniqueName="Role" HeaderText="ROLE" DataField="AdministratorRoleItem.Name">
                            <FilterTemplate>
                                
                                <telerik:RadComboBox runat="server" ID="rcbAdministratorRole" DataSourceID="edsAdministratorRole" DataTextField="Name"
                                                     DataValueField="Name" AppendDataBoundItems="true" SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Role").CurrentFilterValue %>' OnClientSelectedIndexChanged=" Filter_Role_SelectedIndexChanged">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="All" />
                                    </Items>
                                </telerik:RadComboBox>
                                
                                <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                                    <script type="text/javascript">
                                        function Filter_Role_SelectedIndexChanged(sender, args) {
                                            var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                            tableView.filter("Role", args.get_item().get_value(), "EqualTo");
                                        }
                                    </script>
                                </telerik:RadScriptBlock>
                                        
                            </FilterTemplate>
                        </telerik:GridBoundColumn>
                                
                        <telerik:GridBoundColumn UniqueName="LastLogonOn" HeaderText="LAST LOGON" DataField="LastLogonOn" />
                            
                        <telerik:GridCheckBoxColumn  UniqueName="Active" HeaderText="ACTIVE" DataField="IsActive" />

                        <telerik:GridButtonColumn UniqueName="Edit" Text="Edit" CommandName="Edit" HeaderTooltip="Edit" ButtonType="ImageButton" ImageUrl= "~/Images/Grid_Edit_16x16.png" />
                     
                         <telerik:GridTemplateColumn AllowFiltering="false" UniqueName="Delete">
                            <ItemTemplate>
                           <asp:LinkButton runat="server" ID="btnDelete" OnClientClick="ConfirmDelete(this); return false;"  OnClick="btnDelete_Click">
 <asp:ImageButton runat="server" ID="imgDelete"    ImageUrl="~/Images/Grid_Delete_16x16.png" />
                         

                           </asp:LinkButton>       </ItemTemplate>
                            
                        </telerik:GridTemplateColumn>

                    </Columns>

                </MasterTableView>

            </telerik:RadGrid>
        </telerik:RadAjaxPanel>
                
        <asp:EntityDataSource runat="server" ID="eds"  ConnectionString="name=entitiesEvolveCentral"  DefaultContainerName="entitiesEvolveCentral" EnableFlattening="False" EntitySetName="AdministratorAccountItems" OnSelecting="eds_Selecting" AutoGenerateWhereClause="false" Include="AdministratorRoleItem" />
        <asp:EntityDataSource runat="server" ID="edsAdministratorRole"  ConnectionString="name=entitiesEvolveCentral"  DefaultContainerName="entitiesEvolveCentral" EnableFlattening="False" EntitySetName="AdministratorRoleItems" AutoGenerateWhereClause="false" />
        
    </div>
</asp:Content>
        