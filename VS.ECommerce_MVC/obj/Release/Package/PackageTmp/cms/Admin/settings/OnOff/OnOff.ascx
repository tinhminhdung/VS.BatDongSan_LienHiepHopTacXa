<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnOff.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.settings.OnOff.OnOff" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<div id="cph_Main_ContentPane">
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Tắt mở website</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">
        <div class="widget-title">
            <h4><i class="icon-list-alt"></i>&nbsp; Tắt / Mở website</h4>
        </div>
        <div class="widget-body">
            <div class='frm-add'>
                <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td style="width: 78px"></td>
                        <td></td>
                        <td style="height: 16px">
                            <strong><font color="#ed1f27">
                    <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-transform: uppercase">
                            <img src="/Resources/admin/images/bullet-red.png" border="0" />
                            <strong>Tắt / Mở trang web ở ngoài</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="30"></td>
                    </tr>
                    <tr>
                        <td style="width: 78px">Nội Dung
                        </td>
                        <td style="padding-left: 15px"></td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtOnOff" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                            <span style="font-size: 8pt; color: #ed1c24"><em>(Khi mở web ra sẽ xuất hiện dòng thông báo này ở ngoài trang web)</em></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="30"></td>
                    </tr>
                    <tr>
                        <td style="padding-left: 15px; width: 78px;">Trạng thái
                        </td>
                        <td></td>
                        <td>
                            <asp:RadioButton ID="rdcommentoptioncheckcomments" runat="server" Checked="true"
                                GroupName="co" Text="Trạng thái mở" />
                            <asp:RadioButton ID="rdcommentoptionnotcheckcomments" runat="server" GroupName="co"
                                Text="Trạng thái tắt" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="30"></td>
                    </tr>
                    <tr>
                        <td style="width: 78px"></td>
                        <td></td>
                        <td>
                            <asp:Button ID="btnsetup" runat="server" Text="Update" CssClass="toolbar btn btn-info" OnClick="btnsetup_Click" Width="123px"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </div>
</div>
