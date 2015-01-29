﻿    <%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="CrmEvolutionService.aspx.cs" Inherits="EvolveCentral.ControlPanel.CrmEvolutionService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

    <link href="../Styles/ControlPanel/FormList.css" rel="stylesheet" />

    <script type="text/javascript">

        function ConfirmDelete(btn) {
            function CallbackFn(arg) {
                if (arg) {
                   eval(btn.href);
                }
            }
           radconfirm("Do you really want to delete this item?", CallbackFn, 370, 140, null, "DELETE SERVICE", "../Images/MessageBox_Question_32x32.png");
        }
    </script>
    <telerik:RadWindowManager ID="rwm" runat="server" EnableShadow="true" />
        
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
        
            <telerik:RadGrid ID="rgvData" runat="server" DataSourceId="eds" AutoGenerateColumns="false" AllowPaging="true" AllowFiltering="true"
                             AllowSorting="true"  AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand" OnDataBound="rgvData_DataBound" >

                <MasterTableView CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add new record" CommandItemSettings-RefreshText="Refresh"
                                 DataKeyNames="Id">

                    <Columns>
                                 
                        <telerik:GridButtonColumn UniqueName="View" Text="View" CommandName="View" HeaderTooltip="View" ButtonType="ImageButton"   ImageUrl= "~/Images/Grid_View_16x16.png" />
                    
                        <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id" HeaderStyle-Width="20px" />
                        
                        <telerik:GridBoundColumn UniqueName="Code" HeaderText="CODE" DataField="Code" />
                        
                        <telerik:GridBoundColumn UniqueName="Name" HeaderText="NAME" DataField="Name" />
                        
                        <telerik:GridBoundColumn UniqueName="ServiceTemplate" HeaderText="TEMPLATE" DataField="ServiceTemplateCrmEvolutionItem.Name" />
                        
                                 
                     
                            
                        <telerik:GridCheckBoxColumn  UniqueName="Active" HeaderText="ACTIVE" DataField="IsActive" />
                          <telerik:GridButtonColumn Text="DETAILS" CommandName="Details" ButtonType="ImageButton" ImageUrl="~/Images/Details.png" />

                        <telerik:GridButtonColumn UniqueName="Edit" Text="Edit" CommandName="Edit" HeaderTooltip="Edit" ButtonType="ImageButton" ImageUrl= "~/Images/Grid_Edit_16x16.png" />
                     <telerik:GridButtonColumn Text="EXECUTE" CommandName="Execute" ButtonType="ImageButton" ImageUrl="~/Images/Execute.png" ConfirmText="Do you really want to execute it?" />

     <telerik:GridButtonColumn Text="REVERT" CommandName="Revert" ButtonType="ImageButton" ImageUrl="~/Images/Undo.png" ConfirmText="Do you really want to revert it?" />

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
                
        <asp:EntityDataSource runat="server" ID="eds"  ConnectionString="name=entitiesEvolveCentral"  DefaultContainerName="entitiesEvolveCentral" EnableFlattening="False" EntitySetName="ServiceCrmEvolutionItems" OnSelecting="eds_Selecting" AutoGenerateWhereClause="false" Include="CompanyItem,ServiceTemplateCrmEvolutionItem" />
          
    </div>
</asp:Content>
        