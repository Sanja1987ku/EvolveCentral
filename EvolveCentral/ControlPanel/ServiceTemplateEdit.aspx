<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="ServiceTemplateEdit.aspx.cs" Inherits="EvolveCentral.Administration.ServiceTemplateEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

<telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
       
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

      <br />         
        <table style="width:100%;">
            <tr>
                <td colspan="2">


                    <asp:Panel runat="server" ID="pnl" GroupingText="CREATE/EDIT SERVICE TEMPLATE " Width="100%" >
                <table>

              <tr>
                  <td>
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
                                            <asp:Label runat="server" ID="Label10" Text="CODE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtCode" runat="server"  />
                                           
                                        </td>
                                    </tr>    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text="NAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtName" runat="server"  />
                                           
                                        </td>
                                    </tr>  
                      
                       <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label5" Text="SERVICE TYPE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbServiceType" runat="server" />
                                           
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
                      </td>
                  <td style="vertical-align:top;">
  <table><tr>
                                        <td style="vertical-align:top;">
                                            <asp:Label runat="server" ID="Label8" Text="DESCRIPTION:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                         <td>
                                            <telerik:RadTextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="120px" Width="500px"  />
                                           
                                        </td>
                                    </tr> 
                </table>  </td>
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
