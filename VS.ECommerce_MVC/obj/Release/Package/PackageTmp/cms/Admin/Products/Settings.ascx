<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Products.Settings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang ch?</a></li>
                <li class="Last"><span>Cấu hình sản phẩm</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="widget">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="widget-title">
                        <h4><i class="icon-list-alt"></i>&nbsp;Cấu hình sản phẩm</h4>
                    </div>
                    <div class="widget-body">
                        <div class="frm-add">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 294px"></td>
                                        <td></td>
                                        <td>
                                            <strong><font color="#ed1f27">
                                            <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 294px">
                                            <strong style="text-transform: uppercase">
                                                <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                Đơn vị tiền tệ </strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Tiêu đề tiền
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txttieudeGia" runat="server" Width="133px" CssClass="txt">Gi&#225; th&#224;nh</asp:TextBox>
                                            &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(Tiêu đề của tiền, ví
                                dụ:Giá thành, Giá, Đơn giá, vv...)</em></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Đơn vị tiền
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtdongia" runat="server" Width="50px" CssClass="txt">VND</asp:TextBox>
                                            &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(Đơn vị tiền của sản phẩm
                                - Ex:VND,USD)</em></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Liên hệ
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtlienhevnd" runat="server" Width="368px" CssClass="txt"></asp:TextBox>
                                            &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(Khi sản phẩm không có
                                giá tiền thì liên hệ theo link hay số nào.)</em></span>
                                        </td>
                                    </tr>
                                    <tr style=" display:none">
                                        <td style="padding-left: 15px; width: 294px;">Mầu sắc của giá
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtoptioncolor" runat="server" Width="88px" CssClass="txt"></asp:TextBox>
                                            <cc1:ColorPickerExtender ID="txtoptioncolor_ColorPickerExtender" runat="server" TargetControlID="txtoptioncolor"></cc1:ColorPickerExtender>
                                            &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(Mầu sắc của giá tiền)</em></span>
                                        </td>
                                    </tr>
                                    <tr style="height: 7px;">
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr valign="bottom" height="40" style="display: none">
                                        <td style="width: 294px">
                                            <strong style="text-transform: uppercase">
                                                <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                Cấu hình ToolTip
                                            </strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr style="display: none">
                                        <td style="padding-left: 15px; width: 294px;">Cấu hình ToolTip
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:RadioButton ID="ToolTip1" runat="server" Text="Không kích hoạt" GroupName="ToolTip" Checked="true"></asp:RadioButton>
                                            <asp:RadioButton ID="ToolTip2" runat="server" Text="Hiển thị Hình ảnh" GroupName="ToolTip"></asp:RadioButton>
                                            <asp:RadioButton ID="ToolTip3" runat="server" Text="Hiển thị mô tả" GroupName="ToolTip"></asp:RadioButton>
                                            <span style="font-size: 8pt; color: #ed1c24"><em>(Hiển thị hình ảnh - và mô tả)</em></span>
                                        </td>
                                    </tr>
                                    <tr style="height: 7px;">
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr valign="bottom" height="40">
                                        <td style="width: 294px">
                                            <strong style="text-transform: uppercase">
                                                <img src="Resources/admin/images/bullet-red.png" border="0" />
                                               Hiển thị trên trang Index
                                            </strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">
                                            Số mục trên trang
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtpagenews" runat="server" Width="50px" CssClass="txt">1</asp:TextBox>
                                            &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(là chỉ số để phân trang
                                cho danh sản phẩm - Ex:Trang: 1 2 3 4 5 tiếp theo)</em></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Số sản phẩm trang chủ
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtHomePage" runat="server" Width="50px" CssClass="txt">1</asp:TextBox>
                                            &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(Hiển thị bao nhiêu sản
                                phẩm trên trang chủ)</em></span>
                                        </td>
                                    </tr>
                                    <tr style="height: 7px;">
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 294px">
                                            <strong style="text-transform: uppercase">
                                                <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                Cắt chuỗi
                                            </strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Cắt chuỗi tiêu đề
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtSubstring" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                                            <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 là mặc định không cắt chuỗi) - Cắt chuỗi trong tên sản phẩm)</em></span>
                                        </td>
                                    </tr>
                                    <tr style="height: 7px;">
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr valign="bottom" height="40">
                                        <td style="width: 294px">
                                            <strong style="text-transform: uppercase">
                                                <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                Cấu hình kích thước hình ảnh </strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Rộng
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtwidth" runat="server" Width="50px" CssClass="txt">130</asp:TextBox>
                                            px &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(chiều rộng của hình
                                ảnh trong danh sản phẩm)</em></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Cao
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtheight" runat="server" Width="50px" CssClass="txt">100</asp:TextBox>
                                            px &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(chiều cao của hình
                                ảnh trong danh sách sản phẩm)</em></span>
                                        </td>
                                    </tr>
                                    <tr style="height: 7px;">
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr valign="bottom" height="40" style=" display:none">
                                        <td style="width: 294px">
                                            <strong style="text-transform: uppercase">
                                                <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                Cấu hình ảnh trong Chi tiết sản phẩm  </strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr style=" display:none">
                                        <td style="padding-left: 15px; width: 294px;">Rộng <span style="font-size: 8pt; color: #ed1c24"><em>(Chi tiết sản phẩm )</em></span>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtrongThumbnail" runat="server" Width="50px" CssClass="txt">130</asp:TextBox>
                                            px &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh) - chiều rộng của hình
                                ảnh trong Chi tiết sản phẩm )</em></span>
                                        </td>
                                    </tr>
                                    <tr style=" display:none">
                                        <td style="padding-left: 15px; width: 294px;">Cao <span style="font-size: 8pt; color: #ed1c24"><em>(Chi tiết sản phẩm )</em></span>
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtcaoThumbnail" runat="server" Width="50px" CssClass="txt">100</asp:TextBox>
                                            px &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh) - chiều cao của hình
                                ảnh trong Chi tiết sản phẩm )</em></span>
                                        </td>
                                    </tr>
                                    <tr style="height: 7px;">
                                        <td colspan="3"></td>
                                    </tr>
                                    <tr valign="bottom" height="40">
                                        <td style="width: 294px">
                                            <strong style="text-transform: uppercase">
                                                <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                Cấu hình trong phần chi tiết</strong></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Số tin hiển thị trong các tin khác
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtnewsother" runat="server" Width="50px" CssClass="txt">7</asp:TextBox>
                                            &nbsp;&nbsp; <span style="font-size: 8pt; color: #ed1c24"><em>(được hiển thị bao nhiêu
                                tin khác trong phần chi tiết bài)</em></span>
                                        </td>
                                    </tr>

                                    <tr style="height: 7px;">
                                        <td colspan="3"></td>
                                    </tr>


                                    <tr>
                                        <td>
                                            <strong style="text-transform: uppercase">
                                                <img src="/Resources/admin/images/bullet-red.png" border="0" />
                                                Cấu hình Comment Facebook</strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px">Comment Facebook
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:RadioButton ID="Radio_CommentCo" runat="server" Checked="true" GroupName="Comment" Text="Có hiển thị" />
                                            <asp:RadioButton ID="Radio_CommentKhong" runat="server" GroupName="Comment" Text="Không hiển thị" />
                                        </td>
                                    </tr>

                                    <tr style="height: 7px;">
                                        <td colspan="3"></td>
                                    </tr>
                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                        <tr valign="bottom" height="40">
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Thanh toán qua ngân lượng </strong></td>
                                            <td></td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td colspan="3">

                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">&nbsp;&nbsp;&nbsp;Kích hoạt thanh toán</td>
                                                        <td></td>
                                                        <td>
                                                            <asp:CheckBox ID="chknganluong" runat="server" />
                                                        </td>
                                                    </tr>

                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">&nbsp;&nbsp;&nbsp;Ngân Lượng URL</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtCheckOutUrl" runat="server" CssClass="txt" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">&nbsp;&nbsp;&nbsp;Merchant Site Code</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtMerchantSiteCodes" runat="server" CssClass="txt" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">&nbsp;&nbsp;&nbsp;Mật khẩu giao tiếp</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtPasss" TextMode="Password" runat="server" CssClass="txt" Width="350px"></asp:TextBox>&nbsp;&nbsp;<asp:CheckBox ID="chkChangePass" runat="server" Text="Cập nhật mật khẩu" />
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">&nbsp;&nbsp;&nbsp;Tài khoản nhận tiền</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtReceive" runat="server" CssClass="txt" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>

                                        <tr valign="bottom" height="40">
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Thanh toán qua Paypal </strong></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">&nbsp;&nbsp;&nbsp;Kích hoạt thanh toán</td>
                                                        <td></td>
                                                        <td>
                                                            <asp:CheckBox ID="CheckPaypal" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">Email thanh toán</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtpaypal" runat="server" CssClass="txt" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">USD</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtusd" runat="server" CssClass="txt" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>


                                        <tr valign="bottom" height="40">
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Thanh toán qua Onepay </strong></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">&nbsp;&nbsp;&nbsp;Kích hoạt thanh toán</td>
                                                        <td></td>
                                                        <td>
                                                            <asp:CheckBox ID="CheckOnepay" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">&nbsp;&nbsp;&nbsp;Chế độ Test</td>
                                                        <td></td>
                                                        <td>
                                                            <asp:CheckBox ID="CheckTest" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">Tên tài khoản Merchant ID</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtMerchant" runat="server" CssClass="txt" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">Mã Hashcode</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtHashcode" runat="server" CssClass="txt" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr style="vertical-align: top; height: 24px">
                                                        <td></td>
                                                        <td style="width: 200px">Mã Accesscode</td>
                                                        <td></td>
                                                        <td>&nbsp;<asp:TextBox ID="txtAccesscode" runat="server" CssClass="txt" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>

                                        <tr valign="bottom" height="40">
                                            <td style="width: 180px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Phươn thức thanh toán</strong></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 10px; width: 294px;">Thanh toán tại cửa hàng
                                            </td>
                                            <td></td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtttcuahang" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px; width: 294px;">Thanh toán chuyển khoản ATM
                                            </td>
                                            <td></td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtttnganhang" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding-left: 15px; width: 294px;">Thanh toán Online qua thẻ ATM nội địa
                                            </td>
                                            <td></td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtttatm" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px; width: 294px;">Thanh toán qua NgânLượng.vn
                                            </td>
                                            <td></td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtttnganluong" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px; width: 294px;">Thanh toán Visa - NgânLượng.vn
                                            </td>
                                            <td></td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtVisa" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px; width: 294px;">Thanh toán PayPal
                                            </td>
                                            <td></td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtttPayPal" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>

                                        <tr valign="bottom" height="40">
                                            <td style="width: 180px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Hình thức vận chuyển</strong></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px; width: 294px;">Giao hàng tại cửa hàng
                                            </td>
                                            <td></td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtttgiaodich" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding-left: 15px; width: 294px;">Chuyển phát nhanh
                                            </td>
                                            <td></td>
                                            <td>
                                                <CKEditor:CKEditorControl ID="txtttchuyenphatnhanh" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td style="width: 294px"></td>
                                        <td></td>
                                        <td>
                                            <br />
                                            <asp:LinkButton ID="btnsetup" runat="server" OnClick="btnsetup_Click"  CssClass="toolbar btn btn-info"  style="background:#ed1c24" > <i class="icon-save"></i>  Cập nhật</asp:LinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
