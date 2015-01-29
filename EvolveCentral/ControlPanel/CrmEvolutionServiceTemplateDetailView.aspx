<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="CrmEvolutionServiceTemplateDetailView.aspx.cs" Inherits="EvolveCentral.ControlPanel.CrmEvolutionServiceTemplateDetailView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

 <link href="../Styles/ControlPanel/FormView.css" rel="stylesheet" />

     <div class="ContentTitle">
        <table>
            <tr>
                <td>
                
                </td>
                <td>
               <asp:Label runat="server" ID="lblTitle" Text="Service Template Detail - CRM & Evolution" />
                </td>
            </tr>
        </table>
        <hr />
    </div>
    
    <div class="Content">
            <fieldset>
             <legend><span><img src="../Images/Fieldset_View_16x16.png" /></span>&nbsp;VIEW</legend>
            <table>
              <tr>
                    <td>
                        <asp:Label runat="server" ID="Label11" Text="Id:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtId" />
                    </td>
                    <td>
                    </td>
                </tr>   <tr>
                    <td>
                        <asp:Label runat="server" ID="Label1" Text="Code:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtCode" />
                    </td>
                  
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label2" Text="Name:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtName" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label8" Text="Sequence:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtSequence" />
                    </td>
                   
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label3" Text="Source Table:" />
                    </td>
                    <td>
                      <asp:Label runat="server" ID="txtSourceTable" />
                    </td>
                   
                </tr>
               <tr>
                    <td>
                        <asp:Label runat="server" ID="Label5" Text="Destination Table:" />
                    </td>
                    <td>
                      <asp:Label runat="server" ID="txtDestinationTable" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label6" Text="Command Type:" />
                    </td>
                    <td>
                      <asp:Label runat="server" ID="txtCommandType" />
                    </td>
                   
                </tr>
                  <tr>
                    <td>
                        <asp:Label runat="server" ID="Label9" Text="Description:" />
                    </td>
                    <td>
                      <asp:Label runat="server" ID="txtDescription" TextMode="MultiLine" Height="100px" />
                    </td>
                   
                </tr>
                <tr>
                 <td style="vertical-align:top;">
                        <asp:Label runat="server" ID="Label4" Text="Command:" />
                    </td>
                    <td>
                      <asp:Label runat="server" ID="txtCommand"  TextMode="MultiLine" Height="700" Width="700" />
                    </td>
                   
                </tr>  
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label10" Text="Last modified by:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtLastModifiedAministratorAccount" />
                    </td>
                    <td></td>
                </tr>
               <tr>
                    <td>
                        <asp:Label runat="server" ID="Label12" Text="Last modified on:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtLastModifiedOn" Checked="true" />
                    </td>
                    <td></td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label7" Text="Active:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtActive" Checked="true" />
                    </td>
                    <td></td>
                </tr>
            </table>
          </fieldset>
        
        <table style="width:100%;">
            <tr>
                <td style="text-align:left;" colspan="2">
                    <telerik:RadButton runat="server" ID="btnBack" Text="BACK" Width="120px" Font-Bold="true"  CausesValidation="false" OnClick="btnBack_Click" Icon-PrimaryIconCssClass="rbPrevious"  />
                </td>
               
            </tr>
        </table>
    
    </div>
</asp:Content>
