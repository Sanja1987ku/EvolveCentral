<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="AlertEdit.aspx.cs" Inherits="EvolveCentral.Administration.AlertEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

<telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
       
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

      <br />         
        <table style="width:100%;">
            <tr>
                <td colspan="2">

                    <asp:Panel runat="server" ID="pnl" GroupingText="CREATE/EDIT ALERT" Width="100%" >
                    <table>                       
                                    <tr>
                                        <td>
                                              <asp:Label runat="server" ID="lblId" Text="ID:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtId" runat="server" Text='<%# Bind("Id") %>' Enabled="false" />                                            
                                        </td>
                                    </tr>  
                                      <tr>
                                        <td>
                                              <asp:Label runat="server" ID="Label2" Text="SERVICE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbService" runat="server" />                                            
                                        </td>
                                    </tr>  <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text="USER:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                    <telerik:RadComboBox ID="rcbUser" runat="server" />
                                           
                                        </td>
                                    </tr>  
                       <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label5" Text="ADMINISTRATOR:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                    <telerik:RadComboBox ID="rcbAdministrator" runat="server" />
                                           
                                        </td>
                                    </tr>     <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" Text="E-MAIL:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtEmail" runat="server" />
                                           
                                        </td>
                                    </tr>  
                        <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label6" Text="CUSTOM NAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtName" runat="server" />
                                           
                                        </td>
                                    </tr>  
                          <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label3" Text="ACTIVE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Bind("Active") %>' />
                                           
                                        </td>
                                    </tr>  
                            
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label runat="server"  ID="lblError" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    
                                  
                    </table>
       </asp:Panel>   </td>

            </tr>
            <tr>
                <td>
                 <asp:Button ID="btnUpdate" Text="SAVE" runat="server" onclick="btnUpdate_Click" />
                            
                
                </td>
                                        <td style="text-align:right">
                                             <asp:Button ID="btnCancel" Text="CANCEL" runat="server" CausesValidation="False" CommandName="Cancel"  OnClick="btnCancel_Click" />
                                        </td>
                                   


              

            </tr>

        </table>  
</asp:Content>
