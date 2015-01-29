<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="AdministratorList.aspx.cs" Inherits="EvolveCentral.Administration.AdministratorList" %>

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
  

   <asp:Panel runat="server" ID="pnl" GroupingText="ADMINISTRATORS">
       
       
        <telerik:RadGrid ID="rgvData" runat="server" OnNeedDataSource="rgvData_NeedDataSource" AutoGenerateColumns="false"
                     AllowSorting="true"  AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand"
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
                <telerik:GridBoundColumn UniqueName="Username" HeaderText="USERNAME" DataField="Username">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Name" HeaderText="NAME" DataField="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Email" HeaderText="E-MAIL" DataField="Email">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Role" HeaderText="ROLE" DataField="RoleItem.Name">
                </telerik:GridBoundColumn>
           
                   <telerik:GridCheckBoxColumn  UniqueName="Active" HeaderText="ACTIVE" DataField="Active" DefaultInsertValue="True" />

                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ButtonType="ImageButton" ConfirmText="Do you really want to delete it?" />
                <telerik:GridButtonColumn Text="Change password" CommandName="ChangePassword" ButtonType="ImageButton" ImageUrl="~/Images/ChangePassword.png" />

            </Columns>
            <GroupByExpressions>
      <telerik:GridGroupByExpression>
        <SelectFields>
          <telerik:GridGroupByField FieldName="RoleItem.Name" HeaderText="ROLE" />        
        </SelectFields>
        <GroupByFields>
          <telerik:GridGroupByField FieldName="RoleItem.Name" SortOrder="Descending" />
        </GroupByFields>
      </telerik:GridGroupByExpression>
    </GroupByExpressions>
        </MasterTableView>

    </telerik:RadGrid>
</asp:Panel></asp:Content>
