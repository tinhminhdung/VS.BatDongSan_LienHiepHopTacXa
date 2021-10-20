<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_nws_setting.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Download.u_nws_setting" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
<div id="cph_Main_ContentPane">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Cấu hình</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="widget">
		
                  <div class="row-fluid">
    <div class="span12 sortable">
        <div class="widget">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Cấu hình</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
        <div class='frm-add'>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="400px">
                    </td>
                    <td>
                    </td>
                    <td>
                        <strong><font color="#ed1f27">
                            <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                           Hiển thị trên trang Index
                        </strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Số mục trên trang
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpagenews" runat="server" CssClass="txt" Width="50px">1</asp:TextBox>
                        <span style="font-size: 8pt; color: #ed1c24"><em>(là chỉ số để phân trang cho danh sách
                            tin - Ex:Trang: 1 2 3 4 5 tiếp theo)</em></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            Cấu hình kích thước của ảnh </strong>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Rộng
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtwidth" runat="server" CssClass="txt" Width="50px">130</asp:TextBox>
                        px <span style="font-size: 8pt; color: #ed1c24"><em>(Chiều rộng của hình ảnh trong danh
                            sách tin)</em></span>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td style="padding-left: 15px">
                        Cao
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtheight" runat="server" CssClass="txt" Width="50px">100</asp:TextBox>
                        px <span style="font-size: 8pt; color: #ed1c24"><em>(Chiều cao của hình ảnh trong danh
                            sách tin)</em></span>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
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
             </div>
    </ContentTemplate>
</asp:UpdatePanel>
