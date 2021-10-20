<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiHoaHong.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.MMember.ChiHoaHong" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang ch?</a></li>
                <li class="Last"><span>Chia hoa hồng</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="widget">
            <div class="widget-title">
                <h4><i class="icon-list-alt"></i>&nbsp;Chia hoa hồng</h4>
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
                                        Chia hoa hồng</strong>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                              <tr>
                                <td style="padding-left: 15px; width: 294px;">Người Mua
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="ThanhVienMua" AutoPostBack="true" OnTextChanged="ThanhVienMua_TextChanged" ValidationGroup="GInfo" placeholder="Tìm số điện thoại người Mua" runat="server" Width="233px" CssClass="txt">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="GInfo" ControlToValidate="ThanhVienMua" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="ltthongtin2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    <asp:HiddenField ID="hdThanhVienMua" runat="server" />

                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px; width: 294px;">Thành viên bán
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="ThanhVienBan" AutoPostBack="true" OnTextChanged="ThanhVienBan_TextChanged" ValidationGroup="GInfo" placeholder="Tìm số điện thoại người bán" runat="server" Width="233px" CssClass="txt">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="GInfo" ControlToValidate="ThanhVienBan" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="ltthongtin1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    <asp:HiddenField ID="hdThanhVienBan" runat="server" />
                                </td>
                            </tr>
                          
                            <tr>
                                <td style="padding-left: 15px; width: 294px;">Người khai thác nguồn hàng
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="NguoiKhaiThacNguonHang" AutoPostBack="true" OnTextChanged="NguoiKhaiThacNguonHang_TextChanged" ValidationGroup="GInfo" placeholder="Tìm số điện thoại người khai thác nguồn hàng" runat="server" Width="233px" CssClass="txt">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="GInfo" ControlToValidate="NguoiKhaiThacNguonHang" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="ltthongtin3" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    <asp:HiddenField ID="hdNguoiKhaiThacNguonHang" runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td style="padding-left: 15px; width: 294px;">Số tiền
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="SoTien" ValidationGroup="GInfo" runat="server" Width="233px" CssClass="txt">0</asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="SoTien"></cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="GInfo" ControlToValidate="SoTien" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 294px"></td>
                                <td></td>
                                <td>
                                    <br />
                                    <asp:LinkButton ID="btnsetup" ValidationGroup="GInfo" runat="server" OnClick="btnsetup_Click" CssClass="toolbar btn btn-info" Style="background: #ed1c24"> <i class="icon-save"></i>  Chia Hoa hồng</asp:LinkButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
