<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="SyncLogCrmEvolutionDetailFullView.aspx.cs" Inherits="EvolveCentral.ControlPanel.SyncLogCrmEvolutionDetailFullView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

 <link href="../Styles/ControlPanel/FormView.css" rel="stylesheet" />

     <div class="ContentTitle">
        <table>
            <tr>
                <td>
                
                </td>
                <td>
              <asp:Label runat="server" ID="lblTitle" Text="Sync Log - CRM & Evolution" />
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
                        <asp:Label runat="server" ID="Label1" Text="Create Date:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtCreateDate" />
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
                        <asp:Label runat="server" ID="Label8" Text="Error Message:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtErrorMessage" />
                    </td>
                   
                </tr>
                 <tr>
                    <td>
                        <asp:Label runat="server" ID="Label7" Text="Successful:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtSuccessful" Checked="true" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                 <td style="vertical-align:top;">
                        <asp:Label runat="server" ID="Label4" Text="Command:" />
                    </td>
                    <td>
                      <asp:Label runat="server" ID="txtCommand"  TextMode="MultiLine" Height="700" Width="700" />
                    </td>
                   
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
