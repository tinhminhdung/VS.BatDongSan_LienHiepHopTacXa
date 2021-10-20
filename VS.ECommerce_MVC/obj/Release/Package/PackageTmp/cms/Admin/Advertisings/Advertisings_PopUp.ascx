<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Advertisings_PopUp.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Advertisings.Advertisings_PopUp" %>
<div class='frm-add'>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 219px">
            </td>
            <td>
            </td>
            <td>
                <strong><font color="#ed1f27">
                    <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <strong style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />Cài Quảng cáo Popup</strong>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px; width: 219px;">
                Link
            </td>
            <td>
            </td>
            <td>
                <asp:TextBox CssClass="txt" ID="txtlink" runat="server" Width="424px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px; width: 219px;">
                Hình ảnh
            </td>
            <td>
            </td>
            <td>
                <asp:Literal ID="ltcurrentpic" runat="server"></asp:Literal><br />
                <asp:FileUpload ID="flimg" CssClass="txt_css" runat="server" Width="243px" />
                &nbsp;
                <asp:LinkButton ID="lnkbannerdelete" CssClass="txt_css" runat="server" OnClick="lnkbannerdelete_Click">Delete</asp:LinkButton>
                <span style="font-size: 8pt; color: #ed1c24"><em>(Chỉ hỗ trợ định dạng *.jpg,*.gif,*.bmp,*.png,*.swf)</em></span>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px; width: 219px;">
                Kích thước
            </td>
            <td>
            </td>
            <td style="padding-left: 15px;">
                Rộng<asp:TextBox CssClass="txt" ID="txtbannerwidth" runat="server"
                    Width="45px">1</asp:TextBox>px&nbsp;&nbsp;
                Cao<asp:TextBox CssClass="txt" ID="txtbannerheight" runat="server"
                    Width="45px">1</asp:TextBox>px <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh)
                        - Hình ảnh xuất hiện trang chủ khi vào trang web(Áp dụng cho trương trình khuyến
                        mại hay khai trương vv...))</em></span>
            </td>
        </tr>
        <tr>
            <td style="width: 219px">
                <strong style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                    Kích hoạt hệ thống </strong>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px; width: 219px;">
                Kiểu mở trang
            </td>
            <td>
            </td>
            <td>
                <asp:RadioButton ID="rdcommentoptioncheckcomments" runat="server" Checked="true"
                    GroupName="co" Text="Mở ra trang mới" />
                <asp:RadioButton ID="rdcommentoptionnotcheckcomments" runat="server" GroupName="co"
                    Text="Mở ra trang hiện tại" /><br />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 15px; width: 219px;">
                Trạng thái
            </td>
            <td>
            </td>
            <td>
                <asp:RadioButton ID="Radiomo" runat="server" Checked="true" GroupName="cos" Text="Mở" />
                <asp:RadioButton ID="Radiotat" runat="server" GroupName="cos" Text="Tắt" /><br />
            </td>
        </tr>
        <tr>
            <td style="width: 219px">
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnsetup" runat="server" OnClick="btnsetup_Click" Text="Cập nhật"
                    Width="150px" />
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hdimage" runat="server" />