<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleAnalytics.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.settings.GoogleAnalytics.GoogleAnalytics" %>


<div id="cph_Main_ContentPane">
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Nhúng mã</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">
        <div class="widget-title">
            <h4><i class="icon-list-alt"></i>&nbsp; Nhúng mã</h4>
        </div>
        <div class="widget-body">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class='frm-add'>
                        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td></td>
                                <td></td>
                                <td style="height: 16px">
                                    <strong><font color="#ed1f27"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td style="padding-left: 15px">Nhúng mã trong thẻ head
                                </td>
                                <td>
                                    <asp:TextBox CssClass="txt_css" ID="txthead" placeholder="Mã sẽ hiển thị trong thẻ (HEAD) cửa website" runat="server" TextMode="MultiLine" Width="700px" Height="200px"></asp:TextBox>
                                    <br />
                                    <span style="font-size: 8pt; color: #ed1c24"><em>(Mã sẽ được hiển thị trong code trong thẻ (HEAD))</em></span>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td style="padding-left: 15px">Nhúng mã trong thẻ body
                                </td>
                                <td>
                                    <asp:TextBox CssClass="txt_css" ID="txtbody" runat="server" placeholder="Mã sẽ hiển thị trong thẻ (BODY) cửa website" TextMode="MultiLine" Width="700px" Height="200px"></asp:TextBox>
                                    <br />
                                    <span style="font-size: 8pt; color: #ed1c24"><em>(Mã sẽ được hiển thị trong code trong thẻ (BODY))</em></span>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnsetup" runat="server" Text="Cập nhật" OnClick="btnsetup_Click" CssClass="toolbar btn btn-info" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
