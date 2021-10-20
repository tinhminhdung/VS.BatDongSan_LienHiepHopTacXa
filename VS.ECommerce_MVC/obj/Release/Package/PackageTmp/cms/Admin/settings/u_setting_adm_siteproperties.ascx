<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_setting_adm_siteproperties.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.settings.u_setting_adm_siteproperties" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<div id="cph_Main_ContentPane">
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Cấu hình hệ thống</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">
        <div class="widget-title">
            <h4><i class="icon-list-alt"></i>&nbsp;Cấu hình hệ thống</h4>
        </div>
        <div class="widget-body">
            <div class='frm-add'>
                <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td></td>
                        <td style="width: 143px"></td>
                        <td style="height: 16px">
                            <strong><font color="#ed1f27">
                    <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td></td>
                        <td style="padding-left: 15px">Seo , h1,h2,h3,h4
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtseo" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="padding-left: 15px">Lỗi 404
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtloi404" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                        </td>
                        </td>
                    </tr>
                       <tr style="height: 20px;">
                            <td colspan="3"></td>
                        </tr>
                     <tr>
                        <td></td>
                        <td style="padding-left: 15px">Bật tắt lỗi 404
                        </td>
                        <td>
                            <asp:RadioButton ID="Radio_loiCo" runat="server" Checked="true"  ForeColor="red"   GroupName="page" Text="Bật chuyển trang page 404 và Áp dụng chuyển trang 301" />
                            <asp:RadioButton ID="Radio_loiKhong" runat="server" GroupName="page" ForeColor="Blue"  Text="Tắt kiểm soát lỗi" />
                        </td>
                        </td>
                    </tr>
                       <tr style="height: 20px;">
                            <td colspan="3"></td>
                        </tr>
                    <tr>
                        <td></td>
                        <td style="padding-left: 15px">Bản đồ - liên hệ
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtbando" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                        </td>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="width: 143px">Thông tin trong giỏ hàng
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtgiohang" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="width: 143px">Nội dung dưới Foooter
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtfootercontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="width: 143px">Nội dung phần liên hệ
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtcontactcontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="width: 143px"></td>
                        <td>
                            <br />
                          <asp:LinkButton ID="btnsetup" runat="server" OnClick="btnsetup_Click"  CssClass="toolbar btn btn-info"  style="background:#ed1c24" > <i class="icon-save"></i>  Cập nhật</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdimage" runat="server" />
                <asp:HiddenField ID="hdbgimg" runat="server" />
                <asp:HiddenField ID="hdicon" runat="server" />
            </div>
        </div>
    </div>
</div>
