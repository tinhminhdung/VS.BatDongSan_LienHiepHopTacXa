<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.MMember.Settings" %>
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
                                               Cấu hình hoa hồng </strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Người khái thác nguồn hàng
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="khaithacnguonhang" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Người bán hàng
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="NguoiBanHang" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 15px; width: 294px;">Người tuyển dụng
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="NguoiTuyenDung" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>
                                             <tr>
                                        <td style="padding-left: 15px; width: 294px;">Văn phòng chi nhánh
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="VanPhongChiNhanh" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>
                                           <tr>
                                        <td style="padding-left: 15px; width: 294px;">Ban Đào tạo
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="BanDaoTao" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>
                                              <tr>
                                        <td style="padding-left: 15px; width: 294px;">Ban Điều Hành
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="BanDieuHanh" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 294px">
                                            <strong style="text-transform: uppercase">
                                                <img src="Resources/admin/images/bullet-red.png" border="0" />
                                              Cấp quản lý</strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>

                                       <tr>
                                        <td style="padding-left: 15px; width: 294px;">Trưởng nhóm kinh doanh
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TruongNhomKinhDoanh" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>
                                             <tr>
                                        <td style="padding-left: 15px; width: 294px;">Trưởng phòng kinh doanh
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="TruongPhongKinhDoanh" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>
                                                <tr>
                                        <td style="padding-left: 15px; width: 294px;">Giám đốc kinh doanh
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="GiamDocKinhDoanh" runat="server" Width="133px" CssClass="txt">0</asp:TextBox>
                                        </td>
                                    </tr>
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
