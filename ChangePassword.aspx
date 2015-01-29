<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="EvolveCentral.Administration.ChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

<telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
        <AjaxSettings>
         
        </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

      <asp:Panel runat="server" ID="pnl" GroupingText="CHANGE PASSWORD" >
                    <table>                       
                                   
                                      <tr>
                                        <td>
                                              <asp:Label runat="server" ID="Label2" Text="NEW PASSWORD:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtNewPassword1" runat="server"  />                                            
                                        </td>
                                    </tr>  <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text="NEW PASSWORD:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtNewPassword2" runat="server"  />
                                           
                                        </td>
                                    </tr>  
                     
                                    
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label runat="server"  ID="lblError" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="text-align:right" colspan="2">
                                            <asp:Button ID="btnUpdate" Text="SAVE" runat="server" onclick="btnUpdate_Click" />
                                            <asp:Button ID="btnCancel" Text="CANCEL" runat="server" CausesValidation="False" CommandName="Cancel"  OnClick="btnCancel_Click" />
                                        </td>
                                    </tr>
                    </table>

          </asp:Panel> 

</asp:Content>
