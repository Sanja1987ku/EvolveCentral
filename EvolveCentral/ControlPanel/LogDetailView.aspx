<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="LogDetailView.aspx.cs" Inherits="EvolveCentral.Administration.LogDetailView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

<telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
       
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

      <br />         
        <table style="width:100%;">
            <tr>
                <td colspan="2">

                    <asp:Panel runat="server" ID="pnl" GroupingText="CREATE/EDIT CLIENT" Width="100%" >
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
                                              <asp:Label runat="server" ID="Label2" Text="NAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtName" runat="server" ReadOnly="true" />                                            
                                        </td>
                                    </tr>  <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text="DATE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                          <telerik:RadTextBox ID="txtDate" runat="server" ReadOnly="true" /> 
                                           
                                        </td>
                                    </tr>  
                        <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" Text="EXECUTED WITHOUT ERRORS:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                               <asp:CheckBox ID="chkExecutedWithoutErrors" runat="server" ReadOnly="true" /> 
                                           
                                        </td>
                                    </tr>  
                      
                          <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label3" Text="COMMAND:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                              <telerik:RadTextBox ID="txtCommand" runat="server" ReadOnly="true" TextMode="MultiLine" Height="700" Width="700" />
                                           
                                        </td>
                                    </tr>  
                              <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label5" Text="ERROR MESSAGE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                              <telerik:RadTextBox ID="txtErrorMessage" runat="server" ReadOnly="true" TextMode="MultiLine" Height="400" Width="700" />
                                           
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
            
                            
                
                </td>
                                        <td style="text-align:right">
                                             <asp:Button ID="btnCancel" Text="CANCEL" runat="server" CausesValidation="False" CommandName="Cancel"  OnClick="btnCancel_Click" />
                                        </td>
                                   


              

            </tr>

        </table>  
</asp:Content>
