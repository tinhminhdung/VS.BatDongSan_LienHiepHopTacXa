<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="languages.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.languages.languages" %>
<asp:Literal ID="lt_info" Visible="false" runat="server"></asp:Literal>
<asp:HiddenField ID="hdlangid" runat="server" />
<asp:HiddenField ID="hdvalue" runat="server" />
<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Quản lý ngôn ngữ</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="">
            <asp:Panel ID="pn_list" runat="server">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-title">
                                <h4><i class="icon-reorder"></i>Quản lý ngôn ngữ</h4>
                            </div>
                            <div class="widget-body">
                                <div class="list_item">
                                    <asp:Repeater ID="rp_lans" runat="server" OnItemCommand="rp_lans_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-bordered" id="sample_1">
                                                <tr>
                                                    <th class="hidden-phone">Tên</th>
                                                    <th class="hidden-phone">Ngôn ngữ mặc định</th>
                                                    <th class="hidden-phone">Danh sách</th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                               
                                                <td style="text-align: center;">
                                                    <%#DataBinder.Eval(Container.DataItem,"VLAN_NAME")%>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton CssClass="active action-link-button" CommandName="MacDinh" CommandArgument='<%#Eval("ilanid")+"|"+Eval("Macdinh")%>' runat="server" ID="Linkbutton5" NAME="Linkbutton1"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "MacDinh").ToString())%></asp:LinkButton>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton CssClass="active action-link-button"  CommandName="ValuesList" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VLAN_ID")%>' runat="server" ID="Linkbutton6" NAME="Linkbutton1" ToolTip="Danh sách giá trị"><span style=" font-size:14px">[Danh sách giá trị cần sửa]</span></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                               <div style="color:red; font-size:14px; padding-top:20px"> Lưu ý : Ngôn ngữ mặc định bắt buộc phải có 1 ô được chọn</div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <div style="clear: both"></div>
            <asp:Panel ID="pn_detail" runat="server" Visible="False">
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
                                    <input id="id" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden1" runat="server">
                                    <input id="hd_insertnew" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden1" runat="server">
                                    <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td></td>
                                            <td>
                                                <strong>
                                                    Từ khóa</strong>
                                            </td>
                                            <td>

                                                <asp:DropDownList ID="txt_shortname" runat="server">
                                                    <asp:ListItem Value="VIE">VIE</asp:ListItem>
                                                    <asp:ListItem Value="ENG">ENG</asp:ListItem>
                                                    <asp:ListItem Value="FRA">FRA</asp:ListItem>
                                                    <asp:ListItem Value="GER">GER</asp:ListItem>
                                                    <asp:ListItem Value="JAN">JAN</asp:ListItem>
                                                    <asp:ListItem Value="CHI">CHI</asp:ListItem>
                                                    <asp:ListItem Value="KOR">KOR</asp:ListItem>
                                                    <asp:ListItem Value="ESP">ESP</asp:ListItem>
                                                    <asp:ListItem Value="NED">NED</asp:ListItem>
                                                    <asp:ListItem Value="ARA">ARA</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <strong>
                                                    Tên</strong>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txt_showinvie" runat="server" Width="249px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <strong>
                                                    Tiêu đề hiển thị</strong>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txt_name_inother" runat="server" Width="248px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <strong>
                                                    Thứ tự</strong>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txt_order" runat="server" Width="48px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <strong>
                                                    Chọn hiển thị</strong>
                                            </td>
                                            <td>

                                                <asp:CheckBox ID="chk_show" runat="server" Text="Trạng thái"></asp:CheckBox>
                                                <asp:CheckBox ID="chk_MacDinh" Text="Mặc định chạy đầu tiên" runat="server"></asp:CheckBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td>

                                                <asp:Button ID="btn_update" runat="server" Font-Bold="True" Text="Insert/Update"
                                                    BackColor="#E0E0E0" OnClick="btn_update_Click"></asp:Button>
                                                <asp:Button ID="btn_cancel" runat="server" Font-Bold="True" Text="Cancel" BackColor="#E0E0E0"
                                                    OnClick="btn_cancel_Click"></asp:Button>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div style="clear: both"></div>
            <asp:Panel ID="pnvalue" runat="server" Width="100%">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
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
                                        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                            <tr height="20">
                                                <td></td>
                                            </tr>
                                            <tr height="25" bgcolor="WhiteSmoke">
                                                <td>
                                                    <asp:LinkButton ID="lnk_back" runat="server" OnClick="lnk_back_Click">Trở lại</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class='frm-add'>
                                            <asp:Repeater ID="rpvalues" runat="server" OnItemCommand="rpvalues_ItemCommand">
                                                <HeaderTemplate>
                                                    <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td width="100" align="center">
                                                            <asp:LinkButton ID="Linkbutton4" CommandName="ValuesList" CommandArgument='<%#Eval("ID")%>' runat="server">Hiệu chỉnh</asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <%#Eval("VALUE") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
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
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td width="200px"></td>
                                                    <td width="5px"></td>
                                                    <td>
                                                        <asp:Label ID="ltmsg" runat="server" Font-Bold="true" ForeColor="red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="200px">&nbsp;Nội dung</td>
                                                    <td width="5px"></td>
                                                    <td>
                                                        <asp:TextBox ID="txtvalues" runat="server" Height="150px" TextMode="MultiLine" Width="500px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td width="200"></td>
                                                    <td width="5"></td>
                                                    <td>
                                                        <asp:Button ID="btnupdatevalue" CssClass="btn btn-primary" runat="server" OnClick="btnupdatevalue_Click" Text="Cập nhật" />
                                                        <asp:Button ID="btncancelvalue" CssClass="btn btn-primary" runat="server" OnClick="btncancelvalue_Click" Text="Hủy bỏ" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </asp:Panel>
        </div>
    </div>
</div>
