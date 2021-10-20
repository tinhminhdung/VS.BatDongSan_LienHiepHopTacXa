<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Advertisings_Screen_left_right.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Advertisings.Advertisings_Screen_left_right" %>
<div style="float: left; width: 100%">
    <div style="float: left; width: 700px">
        <div class='frm-add'>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 300px">
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
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />Quảng cáo Screen 2
                            bên web - bên trái</strong>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">
                        Link
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt" ID="txtlink" runat="server" Width="424px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">
                        Hình ảnh
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:FileUpload ID="flimg" CssClass="txt_css" runat="server" Width="243px" />
                        &nbsp;
                        <asp:LinkButton ID="lnkbannerdelete" CssClass="txt_css" runat="server" OnClick="lnkbannerdelete_Click">Delete</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">
                        Kích thước
                    </td>
                    <td>
                    </td>
                    <td style="padding-left: 15px;">
                        Rộng<asp:TextBox CssClass="txt" ID="txtbannerwidth" runat="server"
                            Width="45px">135</asp:TextBox>px&nbsp;&nbsp;
                        Cao<asp:TextBox CssClass="txt" ID="txtbannerheight" runat="server"
                            Width="45px">530</asp:TextBox>px<br />
                        <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh)
                            - Kích thước : chiều rông: 135px Cao: 530px)</em></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />Quảng cáo Screen 2
                            bên web- Bên phải</strong>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">
                        Link
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt" ID="txtlink2" runat="server" Width="424px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">
                        Hình ảnh
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:FileUpload ID="flimg2" CssClass="txt_css" runat="server" Width="243px" />
                        &nbsp;
                        <asp:LinkButton ID="lnkbannerdelete2" CssClass="txt_css" OnClick="lnkbannerdelete2_Click"
                            runat="server">Delete</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px;">
                        Kích thước
                    </td>
                    <td>
                    </td>
                    <td style="padding-left: 15px;">
                        Rộng<asp:TextBox CssClass="txt" ID="txtbannerwidth2" runat="server"
                            Width="45px">135</asp:TextBox>px&nbsp;&nbsp;
                        Cao<asp:TextBox CssClass="txt" ID="txtbannerheight2" runat="server"
                            Width="45px">530</asp:TextBox>px<br />
                        <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh)
                            - Kích thước : chiều rông: 135px Cao: 530px)</em></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            Kích hoạt hệ thống Email </strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px; width: 400px;">
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
                    <td style="padding-left: 15px; width: 400px;">
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
                    <td>
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
        <asp:HiddenField ID="hdimage2" runat="server" />
    </div>
    <div style="padding-left: 5px; float: left">
    </div>
    <div style="float: left; width: 200px; padding-left: 10px; border-left: 1px dashed #D7D7D7;
        padding-bottom: 5px; padding-top: 10px;">
        <span style="padding-left: 25px; font-weight: bold; color: #404040">Bên trái </span>
        <br />
        <asp:Literal ID="ltcurrentpic" runat="server"></asp:Literal></div>
    <div style="float: left; width: 200px; padding-left: 10px; border-left: 1px dashed #D7D7D7;
        padding-bottom: 5px; padding-top: 10px;">
        <span style="padding-left: 25px; font-weight: bold; color: #404040">Bên phải </span>
        <br />
        <asp:Literal ID="ltcurrentpic2" runat="server"></asp:Literal></div>
</div>