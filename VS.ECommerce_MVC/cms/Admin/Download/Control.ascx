<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Download.Control" %>
<table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
    <tr height="25" align="left">
        <td>
            <b>
                <div class="Sub_menu_top_right">
                    <a class='linkmainmenu' style="<%=returnCSS("Download") %>" href='?u=Download&su=Download'>
                        Danh sách thư viện file</a>&nbsp;| <a class='linkmainmenu' style="<%=returnCSS("set") %>"
                            href='?u=Download&su=set'>Cấu hình</a>&nbsp;| <a class='linkmainmenu' style="<%=returnCSS("Posts") %>"
                                href='?u=Download&su=Posts'>Hướng dẫn bài viết</a>
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
