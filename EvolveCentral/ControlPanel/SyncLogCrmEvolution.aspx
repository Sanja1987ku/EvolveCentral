    <%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="SyncLogCrmEvolution.aspx.cs" Inherits="EvolveCentral.ControlPanel.SyncLogCrmEvolution" %>

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
                  Sync Log - CRM & Evolution
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
                                 
                       
                        <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id" HeaderStyle-Width="20px" />
                        
                        <telerik:GridBoundColumn UniqueName="Code" HeaderText="CODE" DataField="Code" />
                        
                        <telerik:GridBoundColumn UniqueName="Name" HeaderText="NAME" DataField="Name" />
                         
                             <telerik:GridBoundColumn UniqueName="LastSyncDate" HeaderText="LAST SYNC DATE" DataField="LastSyncDate" />
                        <telerik:GridBoundColumn UniqueName="LastSyncSuccessful" HeaderText="SUCCESSFUL" DataField="LastSyncSuccessful" />
                            
                     
                            
                  
                          <telerik:GridButtonColumn Text="DETAILS" CommandName="Details" ButtonType="ImageButton" ImageUrl="~/Images/Details.png" />

                     

                    </Columns>

                </MasterTableView>

            </telerik:RadGrid>
        </telerik:RadAjaxPanel>
                
       <asp:EntityDataSource runat="server" ID="eds"  ConnectionString="name=entitiesEvolveCentral"  DefaultContainerName="entitiesEvolveCentral" EnableFlattening="False" EntitySetName="ServiceCrmEvolutionItems" OnSelecting="eds_Selecting" AutoGenerateWhereClause="false" Include="CompanyItem,ServiceTemplateCrmEvolutionItem" />
          
    </div>
</asp:Content>
        