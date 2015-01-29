<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="EvolveCentral.Administration.LogList" %>

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
  

   <asp:Panel runat="server" ID="pnl" GroupingText="LOG">
       
       
        <telerik:RadGrid ID="rgvData" runat="server" OnNeedDataSource="rgvData_NeedDataSource" AutoGenerateColumns="false"
                      AllowSorting="true" OnItemDataBound="rgvData_ItemDataBound"   AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand"
                      >

        <MasterTableView CommandItemSettings-RefreshText="Refresh"
                         DataKeyNames="Id">

            <Columns>
              
                <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id">
                    <HeaderStyle ForeColor="Silver" Width="20px"></HeaderStyle>
                    <ItemStyle ForeColor="Gray"></ItemStyle>
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn UniqueName="Code" HeaderText="SERVICE CODE" DataField="Code">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Service" HeaderText="SERVICE NAME" DataField="Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Client" HeaderText="CLIENT" DataField="ClientItem.Name">
                </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn UniqueName="LastSyncDate" HeaderText="LAST SYNCED ON" DataField="LastSyncDate">
                </telerik:GridBoundColumn>  
                       <telerik:GridCheckBoxColumn UniqueName="LastSyncSuccessful" HeaderText="LAST SYNC SUCCESSFUL" DataField="LastSyncSuccessful"   />

                  

                    <telerik:GridButtonColumn Text="DETAILS" CommandName="Details" ButtonType="ImageButton"  ImageUrl="~/Images/Details.png" />

               
            </Columns>

        </MasterTableView>

    </telerik:RadGrid>
</asp:Panel></asp:Content>
