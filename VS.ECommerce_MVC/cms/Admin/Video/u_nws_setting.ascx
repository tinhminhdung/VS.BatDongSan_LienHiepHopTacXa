<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_nws_setting.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Video.u_nws_setting" %>
<div id="cph_Main_ContentPane">

    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Cấu hình</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">
        <div class="widget-title">
            <h4><i class="icon-list-alt"></i>&nbsp;Cấu hình     </h4>
        </div>
        <div class="widget-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class='frm-add'>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="400px"></td>
                                <td></td>
                                <td>
                                    <strong><font color="#ed1f27">
                            <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong style="text-transform: uppercase">
                                        <img src="/Resources/admin/images/bullet-red.png" border="0" />
                                        Hiển thị số video ở trang chủ </strong>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px; width: 294px;">Số video trang chủ
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtHomePage" runat="server" Width="50px" CssClass="txt">1</asp:TextBox>
                                    &nbsp;&nbsp; <span style="font-size: 7pt; color: dimgray"><em>(Hiển thị bao nhiêu video trên trang chủ)</em></span>
                                </td>
                            </tr>



                            <tr style="display: none">
                                <td>
                                    <strong style="text-transform: uppercase">
                                        <img src="/Resources/admin/images/bullet-red.png" border="0" />
                                        kích thước hình ảnh Video </strong>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr style="display: none">
                                <td style="padding-left: 15px">Rộng
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtronghinhanh" runat="server" CssClass="txt" Width="50px">130</asp:TextBox>
                                   px <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh)
                            - chiều rộng của hình ảnh trong danh sách tin)</em></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td style="padding-left: 15px">Cao
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtcaohinhanh" runat="server" CssClass="txt" Width="50px">100</asp:TextBox>
                                   px <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh)
                            - chiều rộng của hình ảnh trong danh sách tin)</em></span>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <strong style="text-transform: uppercase">
                                        <img src="/Resources/admin/images/bullet-red.png" border="0" />
                                        Hiển thị trên trang Index
                                    </strong>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px">
                                    Số mục trên trang
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtpagevideo" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                                    <span style="font-size: 7pt; color: dimgray"><em>(là chỉ số để phân trang cho danh sách
                            Video Clip - Ex:Trang: 1 2 3 4 5 tiếp theo)</em></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <strong style="text-transform: uppercase">
                                        <img src="/Resources/admin/images/bullet-red.png" border="0" />
                                        kích thước Video </strong>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr style="display: none">
                                <td style="padding-left: 15px">Rộng
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtwidth" runat="server" CssClass="txt" Width="50px">130</asp:TextBox>
                                  px <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh)
                            - chiều rộng của hình ảnh trong danh sách tin)</em></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td style="padding-left: 15px">Cao
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtheight" runat="server" CssClass="txt" Width="50px">100</asp:TextBox>
                                    px <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh)
                            - chiều rộng của hình ảnh trong danh sách tin)</em></span>
                                </td>
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
                                <td style="padding-left: 15px">Số video Clip hiển thị trong các videp clip khác
                                </td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtvideoother" runat="server" CssClass="txt" Width="50px">7</asp:TextBox>
                                    <span style="font-size: 7pt; color: dimgray"><em>(được hiển thị bao nhiêu tin khác trong
                            phần chi tiết bài)</em></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <strong style="text-transform: uppercase">
                                        <img src="/Resources/admin/images/bullet-red.png" border="0" />Thông tin chia sẻ</strong>
                                </td>
                                <td></td>
                                <td></td>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</div>
<