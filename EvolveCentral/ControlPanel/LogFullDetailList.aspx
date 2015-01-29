<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="LogFullDetailList.aspx.cs" Inherits="EvolveCentral.Administration.LogFullDetailList" %>

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
                     AllowSorting="true"  AllowFilteringByColumn="true" OnItemCommand="rgvData_ItemCommand"
                   OnItemDataBound="rgvData_ItemDataBound"
               >

        <MasterTableView CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add new record" CommandItemSettings-RefreshText="Refresh"
                         DataKeyNames="Id">

            <Columns>
             
                <telerik:GridBoundColumn UniqueName="Id" HeaderText="ID" DataField="Id">
                    <HeaderStyle ForeColor="Silver" Width="20px"></HeaderStyle>
                    <ItemStyle ForeColor="Gray"></ItemStyle>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Date" HeaderText="DATE" DataField="Date">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Name" HeaderText="NAME" DataField="Name">
                </telerik:GridBoundColumn>
              
               
              
                  <telerik:GridCheckBoxColumn UniqueName="ExecutedWithoutErrors" HeaderText="Executed Without Errors" DataField="ExecutedWithoutErrors" />
             
                <telerik:GridButtonColumn Text="View" CommandName="View" ButtonType="ImageButton"  ImageUrl="~/Images/Details.png" />

            </Columns>

        </MasterTableView>

    </telerik:RadGrid>
</asp:Panel>
           <asp:Button ID="btnCancel" Text="CANCEL" runat="server" CausesValidation="False" CommandName="Cancel"  OnClick="btnCancel_Click" />
                                     
           <asp:EntityDataSource runat="server" ID="eds"  ConnectionString="name=entitiesEvolveCentral"  DefaultContainerName="entitiesEvolveCentral" EnableFlattening="False" EntitySetName="LogDetailItems" OnSelecting="eds_Selecting" AutoGenerateWhereClause="false" />
    
</asp:Content>
