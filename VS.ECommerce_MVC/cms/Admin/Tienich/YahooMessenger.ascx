<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YahooMessenger.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Tienich.YahooMessenger" %>
<div id="cph_Main_ContentPane">
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Hỗ trợ chát Online</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pn_list" runat="server">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">
                                <div class="widget-title">
                                    <h4><i class="icon-reorder"></i>Hỗ trợ trực tuyến</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <div id="sample_1_length" class="dataTables_length">
                                                <asp:Label ID="lbl_curpage" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
                                                <asp:Literal ID="ltmsg" runat="server"></asp:Literal>&nbsp;
                                            </div>
                                        </div>
                                        <div class="span6">
                                            <div class="dataTables_filter" id="sample_1_filter">
                                                <asp:LinkButton ID="btthemmoi" CssClass="vadd toolbar btn btn-info" OnClick="btthemmoi_Click" runat="server"><i class="icon-plus"></i>&nbsp; Thêm mới</asp:LinkButton>
                                                <asp:LinkButton ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="list_item">
                                        <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("inick") %>' runat="server" />
                                                    </td>
                                                    <td>
                                                        <%#DataBinder.Eval(Container.DataItem,"Title")%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#DataBinder.Eval(Container.DataItem,"Nick")%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#DataBinder.Eval(Container.DataItem,"Phone")%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#Enable(DataBinder.Eval(Container.DataItem, "Type").ToString())%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#DataBinder.Eval(Container.DataItem, "Orders")%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:LinkButton CssClass="active action-link-button" CommandName="ChangeStatus" CommandArgument='<%#Eval("inick")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                                        <asp:LinkButton CssClass="active action-link-button" ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"inick")%>' runat="server"><i class="icon-edit"></i></asp:LinkButton>
                                                        <asp:LinkButton CssClass="active action-link-button" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"inick")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load"><i class="icon-trash"></i></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                                    <tr>
                                                        <th class="hidden-phone">
                                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" /></th>
                                                        <th class="hidden-phone">Tiêu đề</th>
                                                        <th class="hidden-phone">Nick</th>
                                                        <th class="hidden-phone">Phone</th>
                                                        <th class="hidden-phone">Kiểu</th>
                                                        <th class="hidden-phone">Thứ tự</th>
                                                        <th class="hidden-phone" colspan="3">Chức năng</th>
                                                    </tr>
                                            </HeaderTemplate>
                                            <FooterTemplate>
                                                </table>				
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                        <tr height="20">
                                            <td></td>
                                        </tr>
                                        <tr height="25" bgcolor="whitesmoke">
                                            <td>
                                                <asp:LinkButton ID="LinkButton5" OnClick="LinkButton4_Click" runat="server">[Thêm mới]</asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pn_insert" runat="server" Visible="False">
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
                                        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td width="200"></td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td>Loại nick chat</td>
                                                <td></td>
                                                <td>
                                                    <asp:DropDownList ID="ddltype" runat="server">
                                                        <asp:ListItem Value="1">Zalo</asp:ListItem>
                                                        <asp:ListItem Value="2">Skype</asp:ListItem>
                                                        <asp:ListItem Value="3">Facebook</asp:ListItem>
                                                        <asp:ListItem Value="4">Viber</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Tiêu đề
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txttitle" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Tên Nick</td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtname" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></td>
                                            </tr>
                                                    <asp:TextBox ID="txtSkype" Visible="false" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></td>
                                            <tr style="display:none">
                                                <td>Email</td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtEmail" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Điện thoại </td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtphone" CssClass="txt_css" runat="server" Width="250px"></asp:TextBox></td>
                                            </tr>
                                            <asp:DropDownList ID="ddlsize" Visible="false" runat="server" Width="41px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<tr>
            <td>
                
                    <%=label("lt_size")%>
                    </td>
            <td>
            </td>
            <td>
               
                <br /><br /><div  class="adaidien"><asp:Literal ID="ltimg" runat="server"></asp:Literal></div></td>
        </tr>--%>
                                            <tr>
                                                <td>Thứ tự</td>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txt_order" CssClass="txt_css" runat="server" Width="40px">1</asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Hiển thị</td>
                                                <td></td>
                                                <td>
                                                    <asp:CheckBox ID="chck_Enable" runat="server" Visible="True"></asp:CheckBox></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td>
                                                    <asp:LinkButton ID="btn_InsertUpdate" runat="server" OnClick="btn_InsertUpdate_Click"  CssClass="btn btn-primary"  style="background:#ed1c24"> <i class="icon-save"></i> Cập nhật </asp:LinkButton>
                                                    <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-info"> <i class="icon-ban-circle icon-white"></i> Hủy</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </asp:Panel>

                <input id="hd_insertupdate" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden1" runat="server">
                <input id="hd_id" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden2" runat="server">
                <input id="hd_par_id" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden2" runat="server">
                <input id="hd_page_edit_id" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden2" runat="server">
                <input id="hd_imgpath" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden2" runat="server">
                <input id="hd_rootpic" style="width: 24px; height: 22px" type="hidden" size="1" runat="server">
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
