<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="CrmEvolutionServiceView.aspx.cs" Inherits="EvolveCentral.ControlPanel.CrmEvolutionServiceView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

 <link href="../Styles/ControlPanel/FormView.css" rel="stylesheet" />

     <div class="ContentTitle">
        <table>
            <tr>
                <td>
                
                </td>
                <td>
                      Services - CRM & Evolution
                </td>
            </tr>
        </table>
        <hr />
    </div>
    
    <div class="Content">
            <fieldset>
             <legend><span><img src="../Images/Fieldset_View_16x16.png" /></span>&nbsp;VIEW</legend>
            <table>
          <tr>   <td>
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
                        <asp:Label runat="server" ID="Label3" Text="Service Template:" />
                    </td>
                    <td>
                         <asp:Label runat="server" ID="txtServiceTemplate"  />
                    </td>
                   
                </tr>
               <tr>
                    <td>
                        <asp:Label runat="server" ID="Label5" Text="Company:" />
                    </td>
                    <td>
                           <asp:Label runat="server" ID="txtCompany"  />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label6" Text="Connection - Server:" />
                    </td>
                    <td>
                           <asp:Label runat="server" ID="txtConnectionServer" />
                    </td>
                   
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label8" Text="Connection - Database:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtConnectionDatabase" />
                    </td>
                   
                </tr>
                  <tr>
                    <td>
                        <asp:Label runat="server" ID="Label9" Text="Connection - Username:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtConnectionUsername" />
                    </td>
                   
                </tr>
                  <tr>
                    <td>
                        <asp:Label runat="server" ID="Label10" Text="Connection - Password:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtConnectionPassword" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label4" Text="Source Database:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtSourceDatabase" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label12" Text="Destination Database:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtDestinationDatabase" />
                    </td>
                   
                </tr>
                   <tr>
                    <td>
                        <asp:Label runat="server" ID="Label7" Text="Description:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtDescription" TextMode="MultiLine" Height="150px"  />
                    </td>
                   
                </tr>
                
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label13" Text="Active:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtActive"  />
                    </td>
                    <td></td>
                </tr>
                   <tr>
                    <td>
                        <asp:Label runat="server" ID="Label14" Text="Last Sync Date:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtLastSyncDate" />
                    </td>
                    <td></td>
                </tr>
                   <tr>
                    <td>
                        <asp:Label runat="server" ID="Label16" Text="Last Sync Succesful:" />
                    </td>
                    <td>
                            <asp:Label runat="server" ID="txtLastSyncSuccesful" />
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
