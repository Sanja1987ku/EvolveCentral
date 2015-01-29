<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/Administration.Master" AutoEventWireup="true" CodeBehind="AdministratorEdit.aspx.cs" Inherits="EvolveCentral.Administration.AdministratorEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />

<telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
       
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />

      <br />         
        <table style="width:100%;">
            <tr>
                <td colspan="2">

                    <asp:Panel runat="server" ID="pnl" GroupingText="CREATE/EDIT ADMINISTRATOR" Width="100%" >
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
                                              <asp:Label runat="server" ID="Label2" Text="USERNAME:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtUsername" runat="server" Text='<%# Bind("Code") %>' />                                            
                                      <asp:RequiredFieldValidator runat="server" ID="rfvUsername" ErrorMessage="Required field!" ControlToValidate="txtUsername" ForeColor="Red" />
                                              </td>
                                    </tr>  <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text="NAME:" Font-Bold="true" Font-Size="12px" />
                                       
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtName" runat="server"  />
                                           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage="Required field!" ControlToValidate="txtName" ForeColor="Red" />

                                        </td>
                                    </tr>  
                        <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" Text="PASSWORD:" Font-Bold="true" Font-Size="12px" />
                                     
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPassword" runat="server" />
                                             <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ErrorMessage="Required field!" ControlToValidate="txtPassword" ForeColor="Red" /> 

                                        </td>
                                    </tr>  
                        <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label5" Text="E-MAIL:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtEmail" runat="server"  />
                                                           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ErrorMessage="Required field!" ControlToValidate="txtEmail" ForeColor="Red" /> 
 
                                        </td>
                                    </tr>  
                       <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label11" Text="ROLE:" Font-Bold="true" Font-Size="12px" />
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddlRole" runat="server"  />
                                           
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
