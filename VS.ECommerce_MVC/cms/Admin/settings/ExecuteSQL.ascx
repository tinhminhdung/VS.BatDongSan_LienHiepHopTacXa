<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExecuteSQL.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.settings.ExecuteSQL" %>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td style="height: 26px">
                    <strong><font color="#ed1f27">
                         <asp:Label ID="lbThongbao" runat="server" Text="" ForeColor="Red"></asp:Label></font></strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                 

                </td>
            </tr>
          <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                 Execute SQL
                </td>
                <td>
                   <asp:TextBox ID="txtCmd" runat="server" TextMode="MultiLine" Height="500" Width="800"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                       <asp:Button ID="btnExecute" runat="server" Text="Button" onclick="btnExecute_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>