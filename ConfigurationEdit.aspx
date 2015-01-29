﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="ConfigurationEdit.aspx.cs" Inherits="EvolveCentral.Administration.ConfigurationEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

<telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
       
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

      <br />         
        <table style="width:100%;">
            <tr>
                <td colspan="2">

                    <asp:Panel runat="server" ID="pnl" GroupingText="CREATE/EDIT CONFIGURATION" Width="100%" >
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
                                              <asp:Label runat="server" ID="Label2" Text="CODE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtCode" runat="server" Text='<%# Bind("Code") %>' />                                            
                                        </td>
                                    </tr>  <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text="NAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtName" runat="server"  />
                                           
                                        </td>
                                    </tr>  
                        <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" Text="VALUE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtValue" runat="server"  />
                                           
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