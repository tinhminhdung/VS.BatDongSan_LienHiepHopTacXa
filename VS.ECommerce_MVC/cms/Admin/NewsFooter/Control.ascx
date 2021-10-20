<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.NewsFooter.Control" %>
       <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                    <a class='linkmainmenu' style="<%=returnCSS("info") %>" href='?u=info&su=info'>Quản lý phân mục tin</a>&nbsp;|
                    <a class='linkmainmenu' style="<%=returnCSS("items") %>" href='?u=info&su=items'>Danh sách thông tin</a>&nbsp;|

                </div>
            </b>
        </td>
    </tr>
    <tr>
        <td height="1">
        </td>
    </tr>
    <tr>
        <td>
            <asp:PlaceHolder ID="phcontrol" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
</table>
