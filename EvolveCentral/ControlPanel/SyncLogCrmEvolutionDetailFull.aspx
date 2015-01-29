    <%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="SyncLogCrmEvolutionDetailFull.aspx.cs" Inherits="EvolveCentral.ControlPanel.SyncLogCrmEvolutionDetailFull" %>

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
            <asp:Label runat="server" ID="lblTitle" Text="Sync Log - CRM & Evolution" />
                      
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
                        
                        <telerik:GridBoundColumn UniqueName="CreateDate" HeaderText="CREATE DATE" DataField="CreateDate" />
                        
                            <telerik:GridBoundColumn UniqueName="Name" HeaderText="MESSAGE" DataField="Name" />
                      
                         <telerik:GridBoundColumn UniqueName="IsSuccessful" HeaderText="SUCCESSFUL" DataField="IsSuccessful" />
                            
                     
                            
                  
                        
                     

                    </Columns>

                </MasterTableView>

            </telerik:RadGrid>
          <table style="width:100%;">
            <tr>
                <td style="text-align:left;" colspan="2">
                    <telerik:RadButton runat="server" ID="btnBack" Text="BACK" Width="120px" Font-Bold="true"  CausesValidation="false" OnClick="btnBack_Click" Icon-PrimaryIconCssClass="rbPrevious"  />
                </td>
               
            </tr>
        </table>

        </telerik:RadAjaxPanel>
                
       <asp:EntityDataSource runat="server" ID="eds"  ConnectionString="name=entitiesEvolveCentral"  DefaultContainerName="entitiesEvolveCentral" EnableFlattening="False" EntitySetName="SyncLogCrmEvolutionDetailItems" OnSelecting="eds_Selecting" AutoGenerateWhereClause="false" />
          
    </div>
</asp:Content>
        