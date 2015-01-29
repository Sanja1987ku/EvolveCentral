<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="ServiceDetailList.aspx.cs" Inherits="EvolveCentral.Administration.ServiceDetailList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
     <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true" />
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
  

   <asp:Panel runat="server" ID="pnl" GroupingText="SERVICE DETAILS">
       
       
        <telerik:RadGrid ID="rgvData" runat="server" OnNeedDataSource="rgvData_NeedDataSource" AutoGenerateColumns="false"
                     AllowSorting="true"  AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand"
                    OnItemDataBound="rgvData_ItemDataBound"  OnUnload="rgvData_Unload" >

        <MasterTableView CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add new record" CommandItemSettings-RefreshText="Refresh"
                         DataKeyNames="Id">

            <Columns>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" >
                </telerik:GridEditCommandColumn>
                <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id">
                    <HeaderStyle ForeColor="Silver" Width="20px"></HeaderStyle>
                    <ItemStyle ForeColor="Gray"></ItemStyle>
                </telerik:GridBoundColumn>
                    <telerik:GridCheckBoxColumn  UniqueName="IsUnique" HeaderText="UNIQUE" DataField="IsUnique" DefaultInsertValue="True" />
                
                <telerik:GridBoundColumn UniqueName="Sequence" HeaderText="SEQUENCE" DataField="Sequence">
                </telerik:GridBoundColumn>
              <telerik:GridBoundColumn UniqueName="Code" HeaderText="CODE" DataField="Code" />
                     <telerik:GridBoundColumn UniqueName="Name" HeaderText="NAME" DataField="Name">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn UniqueName="CommandType" HeaderText="COMMAND TYPE" DataField="CommandType">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn UniqueName="SourceTable" HeaderText="SOURCE TABLE" DataField="SourceTable">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn UniqueName="DestinationTable" HeaderText="DESTINATION TABLE" DataField="DestinationTable">
                </telerik:GridBoundColumn>
                 
                       <telerik:GridCheckBoxColumn  UniqueName="Active" HeaderText="ACTIVE" DataField="Active" DefaultInsertValue="True" />
                  <telerik:GridButtonColumn Text="Execute" CommandName="Execute" ButtonType="ImageButton" ImageUrl="~/Images/Execute.png" />
                 <telerik:GridButtonColumn Text="Revert" CommandName="Revert" ButtonType="ImageButton" ImageUrl="~/Images/Undo.png" ConfirmText="Do you really want to revert it?" />

                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ButtonType="ImageButton" ConfirmText="Do you really want to delete it?" />
           
          
            </Columns>

        </MasterTableView>

    </telerik:RadGrid>
</asp:Panel></asp:Content>
