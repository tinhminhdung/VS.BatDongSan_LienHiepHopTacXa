<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.M_News.Setting" %>
<div id="cph_Main_ContentPane">
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Cấu hình</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-title">
                                <h4><i class="icon-reorder"></i>Cấu hình tin tức</h4>
                            </div>
                            <span class="capnhatphai">
                                <asp:LinkButton ID="btnupdate" runat="server" OnClick="btnupdate_Click"  CssClass="btn btn-primary"  style="background:#ed1c24"> <i class="icon-save"></i> Cập nhật </asp:LinkButton>
                            </span>
                            <div class="widget-body">
                                <div class='frm-add'>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="400px"></td>
                                            <td></td>
                                            <td>
                                                <strong><font color="#ed1f27"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong style="text-transform: uppercase">
                                                    <img src="/Resources/admin/images/bullet-red.png" border="0" />Hiển thị trên trang Index </strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Số mục trên trang</td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtpagenews" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(là chỉ số để phân trang cho danh sách tin - Ex:Trang: 1 2 3 4 5 tiếp theo)</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong style="text-transform: uppercase">
                                                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                                                    Cắt chuỗi </strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Cắt chuỗi tiêu đề
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtSubstring" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 là mặc định không cắt chuỗi)  - Cắt chuỗi trong tiêu đề tin tức)</em></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Cắt chuỗi mô tả
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtSubstring_Mota" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 là mặc định không cắt chuỗi) - Cắt chuỗi trong mô tả tin tức)</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong style="text-transform: uppercase">
                                                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                                                    Cấu hình kích thước của ảnh </strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Rộng
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtwidth" runat="server" CssClass="txt" Width="50px">130</asp:TextBox>
                                                px <span style="font-size: 8pt; color: #ed1c24"><em>(Chiều rộng của hình ảnh trong danh  sách tin)</em></span>
                                            </td>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Cao
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtheight" runat="server" CssClass="txt" Width="50px">100</asp:TextBox>
                                                px <span style="font-size: 8pt; color: #ed1c24"><em>(Chiều cao của hình ảnh trong danh
                            sách tin)</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong style="text-transform: uppercase">
                                                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                                                    Cấu hình trong phần chi tiết</strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Số tin hiển thị trong các tin khác
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtnewsother" runat="server" CssClass="txt" Width="50px">7</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(được hiển thị bao nhiêu tin khác trong phần chi tiết bài)</em></span>
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
                                        <tr valign="bottom" height="40">
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Cấu hình Like Button - Facebook
                                                </strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px; width: 294px;">Cấu hình Like Button - Facebook
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:RadioButton ID="Facebook1" runat="server" Text="Không kích hoạt" GroupName="Facebook" Checked="true"></asp:RadioButton>
                                                <asp:RadioButton ID="Facebook2" runat="server" Text="Hiển thị không có hình đại diện" GroupName="Facebook"></asp:RadioButton>
                                                <asp:RadioButton ID="Facebook3" runat="server" Text="Hiển thị kèm theo  hình đại diện" GroupName="Facebook"></asp:RadioButton>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Hiển thị hình ảnh - và mô tả)</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <asp:LinkButton ID="btnsetup" runat="server" OnClick="btnsetup_Click"  CssClass="btn btn-primary"  style="background:#ed1c24"> <i class="icon-save"></i> Cập nhật </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
