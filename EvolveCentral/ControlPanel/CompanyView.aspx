 th<%@ Page Title="" Language="C#" MasterPageFile="~/ControlPanel/ControlPanel.Master" AutoEventWireup="true" CodeBehind="CompanyView.aspx.cs" Inherits="EvolveCentral.ControlPanel.CompanyView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

 <link href="../Styles/ControlPanel/FormView.css" rel="stylesheet" />

     <div class="ContentTitle">
        <table>
            <tr>
                <td>
                
                </td>
                <td>
                   Companies
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
                </tr>    <tr>
                    <td>
                        <asp:Label runat="server" ID="Label1" Text="Code:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtCode" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label2" Text="Name:" />
                    </td>
                    <td>
                         <asp:Label runat="server" ID="txtName" />
                    </td>
                    <td>
                      </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label3" Text="Contact:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtContact" />
                    </td>
                    <td>
                      </td>
                </tr>
                     
                <tr>
                    <td>
                        <asp:Label runat="server" ID="Label7" Text="Active:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="txtActive" />
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
