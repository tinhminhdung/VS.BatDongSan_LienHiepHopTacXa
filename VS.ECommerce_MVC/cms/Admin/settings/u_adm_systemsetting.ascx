<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_adm_systemsetting.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.settings.u_adm_systemsetting" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>

<div id="cph_Main_ContentPane">
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Cài đặt thuộc tính</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">
        <div class="widget-title">
            <h4><i class="icon-list-alt"></i>&nbsp; Cài đặt thuộc tính</h4>
        </div>
        <div class="widget-body">

            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                <tr>
                    <td></td>
                    <td></td>
                    <td style="height: 26px">
                        <strong style="color:red; font-size:15px;">
                        <asp:Literal ID="ltmsg" runat="server"></asp:Literal></strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-transform: uppercase">
                        <img src="/Resources/admin/images/bullet-red.png" border="0" />
                        <strong>Cấu hình hệ thống</strong>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">
                        Tiêu đề trang
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtwebname" runat="server" TextMode="MultiLine"
                            Width="408px" Height="40px"></asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(được xuất hiện trên tiêu đều của trình duyệt người dùng)</em></span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">
                        Từ khóa trang web
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtsearchkeyword" runat="server" TextMode="MultiLine"
                            Width="408px" Height="40px"></asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(được sử dụng để hỗ trợ các công cụ tìm kiếm, cách nhau dấu ;)</em></span>
                    </td>
                </tr>
                <tr style="height: 7px;">
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">
                        Từ khóa mô tả
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtsitekeyworddescription" runat="server" TextMode="MultiLine"
                            Width="408px" Height="40px"></asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(được sử dụng để hỗ trợ các công cụ tìm kiếm, cách nhau dấu ;)</em></span>
                    </td>
                </tr>
                <tr style="height: 60px;">
                    <td colspan="3"></td>
                </tr>

                <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            Email hệ thống</strong> <span style="font-size: 8pt; color: #ed1c24"><em>(Hệ thống sử
                            dụng smtp.gmail.com của google)</em></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="30"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">SMTP Server
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtsmtp" runat="server" Enabled="false" Text="smtp.gmail.com" Width="250px">smtp.gmail.com</asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Cài đặt SMTP server - Ex:smtp.gmail.com)</em></span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">SmtpPort
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtsmtpport" Enabled="false" Text="587" runat="server" Width="250px">587</asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Cài đặt SMTP Port - Ex:587)</em></span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Email
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtsysemail" runat="server" Width="250px"></asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Tên đăng nhập email - Ex:abc@gmail.com)</em></span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Email nhận
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtEmailden" runat="server" Width="250px"></asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Email nhận thư từ giỏ hàng,liên hệ, Nhận tin khuyến mãi vv... - Ex:abc@gmail.com)</em></span>
                    </td>
                </tr>


                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Mật khẩu
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtsysemailpass" runat="server" Width="250px"></asp:TextBox>
                         <span style="font-size: 8pt; color: #ed1c24"><em>(Mật khẩu của email để gửi thư)</em></span>
                    </td>
                </tr>
                <tr style="height: 60px;">
                    <td colspan="3"></td>
                </tr>

                <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            Cấu hình logo</strong>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px; width: 143px;">Logo
                    </td>
                    <td>
                        <asp:TextBox ID="txtlogo" runat="server" CssClass="text image"></asp:TextBox>
                        <input id="btnlogo" type="button" onclick="BrowseServer('<%=txtlogo.ClientID %>','News');" value="Chọn ảnh" class="toolbar btns btn-info" />
                        <asp:Literal ID="ltcurrentpic" runat="server"></asp:Literal>
                        &nbsp;
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td style="padding-left: 15px; width: 143px;">
                        Kích thước
                    </td>
                    <td align="left">
                        Rộng
                        <asp:TextBox CssClass="txt_css" ID="txtbannerwidth" runat="server" Width="45px">1</asp:TextBox>px&nbsp;
                &nbsp;Cao<asp:TextBox CssClass="txt_css" ID="txtbannerheight"
                    runat="server" Width="45px">1</asp:TextBox>px <span style="font-size: 8pt; color: #ed1c24">
                        <em>(Để 0 px sẽ hiển thị kích thước thật của ảnh
                            - Thông tin chiều cao, rộng của logo)</em></span>
                    </td>
                </tr>
                <tr style="height: 60px;">
                    <td colspan="3"></td>
                </tr>

                 <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                           No Imgaes</strong>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px; width: 143px;">No Images
                    </td>
                    <td>
                        <asp:TextBox ID="txtnoimgaes" runat="server" CssClass="text image"></asp:TextBox>
                        <input id="btnnoimgaes" type="button" onclick="BrowseServer('<%=txtnoimgaes.ClientID %>','News');" value="Chọn ảnh" class="toolbar btns btn-info" />
                        <asp:Literal ID="ltnoimgaes" runat="server"></asp:Literal>
                        <div style="font-size: 8pt; color: #ed1c24"> <em>(Áp dụng cho tất cả trường hợp đăng bài viết lên mà không có ảnh, thì nó sẽ lấy ảnh này làm ảnh đại diện)</em></div>
                        &nbsp;
                    </td>
                </tr>
                  <tr style="height: 60px;">
                    <td colspan="3"></td>
                </tr>

                <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            Cấu hình favicon (Icon)</strong>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px; width: 143px;">
                        
                    </td>
                    <td>
                        <asp:TextBox ID="txticon" runat="server" CssClass="text image"></asp:TextBox>
                        <input id="btnicon" type="button" onclick="BrowseServer('<%=txticon.ClientID %>','News');" value="Chọn ảnh" class="toolbar btns btn-info" />
                        <asp:Literal ID="lticon" runat="server"></asp:Literal>
                       <div style="font-size: 8pt; color: #ed1c24"> (Sẽ hiển thị ở trên thanh toolbar của trang --> Default: 16px 16px OR 32px 32px)</div>
                    </td>
                </tr>

                <tr style="height: 60px;">
                    <td colspan="3"></td>
                </tr>

                <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />Cấu hình Facebook</strong> <span style="font-size: 8pt; color: #ed1c24"><em>(Phục vụ chia sẻ trang chủ website này lên facebook)</em></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="30"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Ảnh đại diện facebook:
                    </td>
                    <td>
                        <asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>
                        <input id="btnImage" type="button" onclick="BrowseServer('<%=txtImage.ClientID %>','News');" value="Chọn ảnh" class="toolbar btns btn-info" />
                        <asp:Literal ID="ltimgs" runat="server"></asp:Literal>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Ảnh đại diện khi chia sẻ website chính lên facebook)</em></span>
                    </td>
                </tr>
                    <tr>
                    <td colspan="3" height="30"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Fb:app_id
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtfbapp_id" runat="server" Width="200px"></asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Đăng ký <a href="https://developers.facebook.com/" target="_blank">https://developers.facebook.com</a> để lấy app_id)</em></span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">
                    </td>
                    <td>
                        <b><asp:Literal ID="ltshowfacebook" runat="server"></asp:Literal></b>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Link Fanpage Facebook 
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtfacebook" placeholder="(Plugin Fanpage Facebook)"  runat="server" Width="550px"></asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Link kênh Fanpage Ví dụ:https://www.facebook.com/adidaphat1504)</em></span>
                    </td>
                </tr>
                <tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Kích thước like box:
                    </td>
                    <td>
                        Rộng
                        <asp:TextBox CssClass="txt_css" ID="txtfbwidth" runat="server" Width="45px">1</asp:TextBox>px&nbsp;
                &nbsp;Cao<asp:TextBox CssClass="txt_css" ID="txtfbheight"
                    runat="server" Width="45px">1</asp:TextBox>px 
                    </td>
                </tr>
                <tr style="height: 60px;">
                    <td colspan="3"></td>
                </tr>

                <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />Cấu hình Khác</strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="30"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Hotline
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txthostline" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td style="padding-left: 15px">Livechat
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" placeholder="Dán mã livechat vào đây để chát hỗ trợ khách hàng" ID="txtLivechat" runat="server" Width="550px"
                            Height="46px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>


                 <tr style=" display:none">
                    <td></td>
                    <td style="padding-left: 15px">Google Plus
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtGooglePlus" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr style=" display:none">
                    <td></td>
                    <td style="padding-left: 15px">Twitter
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtTwitter" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr style=" display:none">
                    <td></td>
                    <td style="padding-left: 15px">Facebook page
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtFacebookpage" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
               <tr style=" display:none">
                    <td></td>
                    <td style="padding-left: 15px">Linkedin
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt_css" ID="txtLinkedin" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>

                <tr style="height: 60px;">
                    <td colspan="3"></td>
                </tr>

                <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />Cấu hình Sitemap.xml</strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="30"></td>
                </tr>

                 <tr>
                    <td></td>
                    <td style="padding-left: 15px">Link sitemap
                    </td>
                    <td>
                       <a href="sitemap.xml" target="_blank" style="color: red; font-size: 15px;">Click kiểm tra Sitemap.xml</a>
                    </td>
                </tr>
                  <tr>
                    <td colspan="3" height="30"></td>
                </tr>
                 <tr>
                    <td></td>
                    <td style="padding-left: 15px">Tự động cập nhật sitemap
                    </td>
                    <td>
                        <asp:RadioButton ID="Radio_Bat" runat="server" Checked="true" GroupName="page" Text="Bật" />
                        <asp:RadioButton ID="Radio_Tat" runat="server" GroupName="page" Text="Tắt" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="3" height="30"></td>
                </tr>

                 <tr>
                    <td colspan="3">
                        <strong style="text-transform: uppercase"><img src="/Resources/admin/images/bullet-red.png" border="0" />Cấu hình SSL(HTTPS)</strong>
                    </td>
                </tr>
                  <tr>
                    <td colspan="3" height="30"></td>
                </tr>
                 <tr>
                    <td></td>
                    <td style="padding-left: 15px">Cấu hình SSL(HTTPS)
                    </td>
                    <td>
                        <asp:RadioButton ID="Radio_Batssl" runat="server" Checked="true" GroupName="pagessl" Text="Bật" />
                        <asp:RadioButton ID="Radio_Tatssl" runat="server" GroupName="pagessl" Text="Tắt" /><br />
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Mục đích chuyển các link hiện đang chứa trong website từ dạng <b>http</b> thường thành <b>https</b> trong website)</em></span><br />
                        <span style="font-size: 8pt; color: #ed1c24"><em>(Mục này chỉ có tác dụng khi web đã được câu hình giao thức <b>SSL</b> trên server)</em></span>
                    </td>
                </tr>
                  <tr>
                    <td colspan="3" height="30"></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:LinkButton ID="btnsetup" runat="server" OnClick="btnsetup_Click"  CssClass="toolbar btn btn-info"  style="background:#ed1c24" > <i class="icon-save"></i>  Cập nhật</asp:LinkButton>
                        <asp:LinkButton ID="btsitemap"  runat="server" OnClick="btsitemap_Click"  CssClass="toolbar btn btn-info"  style="background:#ed1c24" > <i class="icon-save"></i>  Cập nhật Sitemap</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <asp:HiddenField ID="hdimage" runat="server" />
            <asp:HiddenField ID="hdbgimg" runat="server" />
            <asp:HiddenField ID="hdicon" runat="server" />

        </div>
    </div>
</div>
