<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="ServiceList.aspx.cs" Inherits="EvolveCentral.Administration.ServiceList" %>

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
  

   <asp:Panel runat="server" ID="pnl" GroupingText="SERVICES">
       
       
        <telerik:RadGrid ID="rgvData" runat="server" OnNeedDataSource="rgvData_NeedDataSource" AutoGenerateColumns="false"
                  AllowSorting="true" AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand"
                     OnUnload="rgvData_Unload" >

        <MasterTableView CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add new record" CommandItemSettings-RefreshText="Refresh"
                         DataKeyNames="Id">

            <Columns>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" >
                </telerik:GridEditCommandColumn>
                <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id">
                    <HeaderStyle ForeColor="Silver" Width="20px"></HeaderStyle>
                    <ItemStyle ForeColor="Gray"></ItemStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Client" HeaderText="CLIENT" DataField="ClientItem.Name">
                </telerik:GridBoundColumn>
               <telerik:GridBoundColumn UniqueName="Code" HeaderText="CODE" DataField="Code">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn UniqueName="Name" HeaderText="NAME" DataField="Name">
                </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn UniqueName="ServiceTemplate" HeaderText="SERVICE TEMPLATE" DataField="ServiceTemplateItem.Name">
                </telerik:GridBoundColumn>
              <telerik:GridBoundColumn UniqueName="ServiceType" HeaderText="SERVICE TYPE" DataField="ServiceTemplateItem.ServiceTypeItem.Name">
                </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn  UniqueName="Active" HeaderText="ACTIVE" DataField="Active" DefaultInsertValue="True" />
                  <telerik:GridButtonColumn Text="DETAILS" CommandName="Details" ButtonType="ImageButton" ImageUrl="~/Images/Details.png" />
                 <telerik:GridButtonColumn Text="REVERT" CommandName="Revert" ButtonType="ImageButton" ImageUrl="~/Images/Undo.png" ConfirmText="Do you really want to revert it?" />

                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ButtonType="ImageButton" ConfirmText="Do you really want to delete it?" />
          
            </Columns>
              <GroupByExpressions>
      <telerik:GridGroupByExpression>
        <SelectFields>
          <telerik:GridGroupByField FieldName="ServiceTemplateItem.ServiceTypeItem.Name" HeaderText="SERVICE TYPE" />        
        </SelectFields>
        <GroupByFields>
          <telerik:GridGroupByField FieldName="ServiceTemplateItem.ServiceTypeItem.Name" SortOrder="Descending" />
        </GroupByFields>
      </telerik:GridGroupByExpression>
                   <telerik:GridGroupByExpression>
        <SelectFields>
          <telerik:GridGroupByField FieldName="ServiceTemplateItem.Name" HeaderText="SERVICE TEMPLATE" />        
        </SelectFields>
        <GroupByFields>
          <telerik:GridGroupByField FieldName="ServiceTemplateItem.Name" SortOrder="Descending" />
        </GroupByFields>
      </telerik:GridGroupByExpression>
                   </GroupByExpressions>
        </MasterTableView>

    </telerik:RadGrid>
</asp:Panel></asp:Content>
