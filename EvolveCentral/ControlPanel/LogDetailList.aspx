<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="LogDetailList.aspx.cs" Inherits="EvolveCentral.Administration.LogDetailList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="<%=rgvData.ClientID%>">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="<%=rgvData.ClientID%>" LoadingPanelID="<%=RadAjaxLoadingPanel1.ClientID%>">
                    </telerik:AjaxUpdatedControl>

                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

    <br />
  

   <asp:Panel runat="server" ID="pnl" GroupingText="LOG DETAILS">
       
       
        <telerik:RadGrid ID="rgvData" runat="server" OnNeedDataSource="rgvData_NeedDataSource" AutoGenerateColumns="false" DataSourceID="eds"
                     AllowSorting="true"  AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand" AllowPaging="true" PageSize="50"
                    OnItemDataBound="rgvData_ItemDataBound"
               >

        <MasterTableView CommandItemSettings-RefreshText="Refresh"
                         DataKeyNames="Id">

            <Columns>
               
                <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id">
                    <HeaderStyle ForeColor="Silver" Width="20px"></HeaderStyle>
                    <ItemStyle ForeColor="Gray"></ItemStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Date" HeaderText="DATE" DataField="Date">
                </telerik:GridBoundColumn>
             
              
                        <telerik:GridCheckBoxColumn UniqueName="ExecutedWithoutErrors" HeaderText="Executed Without Errors" DataField="ExecutedWithoutErrors" />
            
                <telerik:GridButtonColumn Text="Details" CommandName="Detail" ButtonType="ImageButton"  ImageUrl="~/Images/Details.png" />

            </Columns>

        </MasterTableView>

    </telerik:RadGrid>
</asp:Panel>

           <asp:EntityDataSource runat="server" ID="eds"  ConnectionString="name=entitiesEvolveCentral"  DefaultContainerName="entitiesEvolveCentral" EnableFlattening="False" EntitySetName="LogItems" OnSelecting="eds_Selecting" AutoGenerateWhereClause="false" OrderBy="it.Date DESC" />
         


</asp:Content>
