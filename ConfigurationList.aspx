<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="ConfigurationList.aspx.cs" Inherits="EvolveCentral.Administration.ConfigurationList" %>

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
  

   <asp:Panel runat="server" ID="pnl" GroupingText="CONFIGURATION">
       
       
        <telerik:RadGrid ID="rgvData" runat="server" OnNeedDataSource="rgvData_NeedDataSource" AutoGenerateColumns="false"
                      AllowSorting="true" AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand"
                   >

        <MasterTableView CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add new record" CommandItemSettings-RefreshText="Refresh"
                         DataKeyNames="Id">

            <Columns>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" >
                </telerik:GridEditCommandColumn>
                <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id">
                    <HeaderStyle ForeColor="Silver" Width="20px"></HeaderStyle>
                    <ItemStyle ForeColor="Gray"></ItemStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Code" HeaderText="CODE" DataField="Code">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Name" HeaderText="NAME" DataField="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Value" HeaderText="VALUE" DataField="Value">
                </telerik:GridBoundColumn>
                      
                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ButtonType="ImageButton" ConfirmText="Do you really want to delete it?" />
          
            </Columns>

        </MasterTableView>

    </telerik:RadGrid>
</asp:Panel></asp:Content>
