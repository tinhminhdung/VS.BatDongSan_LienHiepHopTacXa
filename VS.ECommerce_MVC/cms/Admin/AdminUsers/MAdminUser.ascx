<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MAdminUser.ascx.cs" Inherits="VS.Lieugiai.cms.Admin.AdminUsers.MAdminUser" %>
<asp:Literal ID="lt_info" Visible="false" runat="server"></asp:Literal>
<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Quản lý tài khoản</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="widget">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pn_list" runat="server" Width="100%">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4><i class="icon-reorder"></i>Quản lý tài khoản</h4>
                                    </div>
                                    <div class="widget-body">
                                        <div class="list_item">
                                            <asp:Repeater ID="rp_admins" runat="server" OnItemCommand="rp_admins_ItemCommand">
                                                <ItemTemplate>
                                                    <tr class="odd gradeX">
                                                        <td>
                                                            <%#DataBinder.Eval(Container.DataItem,"VUSER_NAME")%>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <%#DataBinder.Eval(Container.DataItem,"DASSIGN_DATE")%>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <%#Lock(Eval("ilocked").ToString())%>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:LinkButton CommandName="update" Visible="true" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                                                runat="server" ID="Linkbutton5" NAME="Linkbutton1">[Update]</asp:LinkButton>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:LinkButton ID="LinkButton2" runat="server" Visible="true" CommandName='updatepassword'
                                                                CommandArgument='<%#Eval("ID")%>'>Cập nhật</asp:LinkButton>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:LinkButton CssClass="active action-link-button" CommandName="ChangeStatus" Visible="true" CommandArgument='<%#Eval("ID")+"|"+Eval("ILOCKED")%>'
                                                                runat="server" ID="Linkbutton1"> <%#lockunlock(Eval("ILOCKED").ToString())%></asp:LinkButton>
                                                            <span style='enable: <%#EnableUpdatePassword(Eval("ID").ToString())%>'></span>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:LinkButton OnLoad="Delete_Load" CssClass="active action-link-button" Visible="true" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton4"><i class="icon-trash"></i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                                        <tr>
                                                            <th class="hidden-phone">
                                                                Tên đăng nhập
                                                            </th>
                                                            <th class="hidden-phone">
                                                               Ngày tạo Account
                                                            </th>
                                                            <th class="hidden-phone">
                                                               Trạng thái
                                                            </th>
                                                            <th class="hidden-phone">
                                                               Trạng thái
                                                            </th>
                                                            <th class="hidden-phone">
                                                               Cập nhật Mật khẩu
                                                            </th>
                                                            <th class="hidden-phone">Lock
                                                            </th>
                                                            <th class="hidden-phone">
                                                                Xóa
                                                            </th>
                                                        </tr>
                                                </HeaderTemplate>
                                                <FooterTemplate>
                                                    </TABLE>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                            <tr height="20">
                                                <td></td>
                                            </tr>
                                            <tr height="25" bgcolor="WhiteSmoke">
                                                <td>
                                                    <asp:LinkButton ID="lnk_insertnewadmin" runat="server" Font-Bold="True" OnClick="lnk_insertnewadmin_Click">[Thêm mới]</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pn_detail" runat="server" Visible="False" Width="100%">
                        <div class="row-fluid">
                            <div class="span12 sortable">
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4><i class="icon-reorder"></i>Form Thêm mới - Cập nhật</h4>
                                        <span class="tools">
                                            <a href="javascript:;" class="icon-chevron-down"></a>
                                            <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                                    </div>
                                    <div class="widget-body">
                                        <div class='frm-add'>
                                            <input id="id" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden1"
                                                runat="server">
                                            <input id="hd_insertnew" style="width: 24px; height: 22px" type="hidden" size="1"
                                                name="Hidden1" runat="server">
                                            <table style="border-collapse: collapse" cellpadding="3" width="100%" border="0">
                                                <tr>
                                                    <td style="width: 132px"></td>
                                                    <td style="width: 183px">
                                                        <strong>
                                                           Tên đăng nhập</strong>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_username" CssClass="txt_css" runat="server" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 132px"></td>
                                                    <td style="width: 183px">
                                                        <strong>
                                                           Password</strong>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_password" CssClass="txt_css" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 14px; width: 132px;"></td>
                                                    <td style="width: 183px; height: 14px">
                                                        <strong>Quyền hạn</strong>
                                                    </td>
                                                    <td style="height: 14px">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr style="vertical-align: top">
                                                                <td style="width: 50%">
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Cài đặt chung" /><br />
                                                                    <asp:CheckBox ID="CheckBox16" runat="server" Text="Quản lý menu chính" /><br />
                                                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Quản trị tin tức" /><br />
                                                                    <asp:CheckBox ID="CheckBox3" runat="server" Text="Quản trị bật động sản" /><br />
                                                                    <asp:CheckBox ID="CheckBox17" runat="server" Text="Giỏ hàng" /><br />
                                                                    <asp:CheckBox ID="CheckBox4" runat="server" Text="Tài khoản hệ thống" /><br />
                                                                    <asp:CheckBox ID="CheckBox5" runat="server" Text="Thông tin Liên hệ" /><br />
                                                                    <asp:CheckBox ID="CheckBox6" runat="server" Text="Hình ảnh Quảng cáo" /><br />
                                                                    <asp:CheckBox ID="CheckBox11" runat="server" Text="Thành viên đăng ký - đăng nhập" /><br />
                                                                </td>
                                                                <td style=" display:none">
                                                                    <asp:CheckBox ID="CheckBox7" Visible="false" runat="server" Text="Thư viện Download File" /><br />
                                                                    <asp:CheckBox ID="CheckBox8" runat="server" Text="Thư viện video" /><br />
                                                                    <asp:CheckBox ID="CheckBox9" runat="server" Text="Hỗ trợ chát trực tuyến" /><br />
                                                                    <asp:CheckBox ID="CheckBox10" runat="server" Text="Thông tin Hỏi đáp" /><br />
                                                                    <asp:CheckBox ID="CheckBox12" runat="server" Text="Nhận email đăng ký" /><br />
                                                                    <asp:CheckBox ID="CheckBox13" runat="server" Text="Thư viện ảnh" /><br />
                                                                    <asp:CheckBox ID="CheckBox21" Visible="false" runat="server" Text="Biểu đồ thống kê" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:CheckBox ID="CheckBox19" Visible="false" runat="server" Text="File thư viện" />
                                                        <asp:CheckBox ID="CheckBox20" Visible="false" runat="server" Text="Hệ thống xuất bản" />
                                                        <asp:CheckBox ID="CheckBox14" Visible="false" runat="server" Text="Bình chọn" />
                                                        <asp:CheckBox ID="CheckBox18" Visible="false" runat="server" Text="Quản lý liên hệ" />
                                                        <asp:CheckBox ID="CheckBox15" Visible="false" runat="server" Text=" " />
                                                    </td>
                                                    <td style="height: 14px"></td>
                                                    <td style="height: 14px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 1px; width: 132px;"></td>
                                                    <td style="width: 183px; height: 1px">
                                                        <strong>
                                                            Chọn hiển thị</strong>
                                                    </td>
                                                    <td style="height: 1px">
                                                        <asp:CheckBox ID="chk_enable" runat="server"></asp:CheckBox>
                                                    </td>
                                                    <td style="height: 1px"></td>
                                                    <td style="height: 1px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 4px; width: 132px;"></td>
                                                    <td style="width: 183px; height: 4px"></td>
                                                    <td style="height: 4px">
                                                        <asp:Button ID="btn_update" runat="server" CssClass="btn btn-primary" Text="Cập nhật" OnClick="btn_update_Click"></asp:Button>
                                                        <asp:Button ID="btn_cancel" runat="server" CssClass="btn btn-primary" Text="Hủy" OnClick="btn_cancel_Click"></asp:Button>
                                                    </td>
                                                    <td style="height: 4px"></td>
                                                    <td style="height: 4px"></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnupdatepassword" runat="server" Visible="False">
                        <div class="row-fluid">
                            <div class="span12 sortable">
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4><i class="icon-reorder"></i>Form Thêm mới - Cập nhật</h4>
                                        <span class="tools">
                                            <a href="javascript:;" class="icon-chevron-down"></a>
                                            <a href="javascript:;" class="icon-remove"></a>
                                        </span>
                                    </div>
                                    <div class="widget-body">
                                        <div class='frm-add'>
                                            <table class="all" border="0" width="100%" cellpadding="0" cellspacing="0">
                                                <tr align="center">
                                                    <td style="width: 200px">
                                                        Mật khẩu mới
                                                    </td>
                                                    <td></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtnewpassword" runat="server" CssClass="txt_css" Width="279px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 200px; height: 40px;"></td>
                                                    <td style="height: 40px"></td>
                                                    <td align="left" style="height: 40px">
                                                        <asp:Button ID="btnupdatenewpassword" CssClass="btn btn-primary" runat="server" Text="Cập nhật" OnClick="btnupdatenewpassword_Click" />
                                                        <asp:Button ID="btnCancelUpdatePass" CssClass="btn btn-primary" runat="server" Text="Hủy" OnClick="btn_cancel_Click" />
                                                    </td>
                                                </tr>
                                                <input id="hdid" runat="server" style="width: 36px" type="hidden" />
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
