<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="AlertList.aspx.cs" Inherits="EvolveCentral.Administration.AlertList" %>

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
  

   <asp:Panel runat="server" ID="pnl" GroupingText="ALERTS">
       
       
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
                <telerik:GridBoundColumn UniqueName="User" HeaderText="USER" DataField="UserItem.Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Administrator" HeaderText="ADMINISTRATOR" DataField="AdministratorItem.Name">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn UniqueName="CustomName" HeaderText="CUSTOM NAME" DataField="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Email" HeaderText="EMAIL" DataField="Email">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn UniqueName="Service" HeaderText="SERVICE" DataField="ServiceItem.Name">
                </telerik:GridBoundColumn>
                       <telerik:GridCheckBoxColumn  UniqueName="Active" HeaderText="ACTIVE" DataField="Active" DefaultInsertValue="True" />

                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ButtonType="ImageButton" ConfirmText="Do you really want to delete it?" />
          
            </Columns>

        </MasterTableView>

    </telerik:RadGrid>
</asp:Panel></asp:Content>
