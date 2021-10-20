<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagementPrice.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Products.ManagementPrice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="cph_Main_ContentPane">
            <div id="">
                <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
                    <ul>
                        <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                        <li class="Last"><span>Danh sách khoảng giá</span></li>
                    </ul>
                </div>
                <div style="clear: both;"></div>
                <div class="widget">

                    <asp:Panel ID="pn_list" runat="server" Width="100%">
                        <div class="widget-title">
                            <h4><i class="icon-list-alt"></i>&nbsp;Danh sách khoảng giá</h4>
                            <div class="ui-widget-content ui-corner-top ui-corner-bottom">
                                <div id="toolbox">
                                    <div class="toolbox-content" style="float: right;">
                                        <table class="toolbar">
                                            <tbody>
                                                <tr>

                                                    <td style="text-align: center;">
                                                        <asp:LinkButton ID="btthemmoi" CssClass="vadd toolbar btn btn-info" OnClick="btthemmoi_Click" runat="server"><i class="icon-plus"></i>&nbsp; Thêm mới</asp:LinkButton></td>
                                                    <td style="text-align: center;">
                                                        <asp:LinkButton ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="row-fluid">
                                <div class="span3">
                                    <div class="dataTables_length" id="sample_1_length">
                                        <div>
                                            <asp:Label ID="ltmsg" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label></div>
                                        <div>
                                            <asp:Label ID="lbl_curpage" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label></div>
                                    </div>
                                </div>
                            </div>
                            <div class="list_item">
                                <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                                    <ItemTemplate>
                                         <tr height="40">
                                            <td style="text-align: center;">
                                                <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                            </td>
                                            <td style="text-align: center;"> 
                                               <%#DataBinder.Eval(Container.DataItem,"Name")%>
                                            </td>
                                            <td style="text-align: center;">  <%#(Eval("Noidung1").ToString())%>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:TextBox ID="txtOrders" Style="border: 1px solid #d7d7d7; border-radius: 3px; text-align: center" Text='<%#DataBinder.Eval(Container.DataItem, "Orders")%>' CssClass="txt_css" Width="40px" runat="server" OnTextChanged="txtOrders_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton CssClass="active action-link-button" CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                                <asp:LinkButton CssClass="active action-link-button" ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server"><i class="icon-edit"></i></asp:LinkButton>
                                                <asp:LinkButton CssClass="active action-link-button" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load"><i class="icon-trash"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                 
                                    <HeaderTemplate>
                                          <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                                <tr class="trHeader" style="height: 25px">
                                                    <th style="width: 4%; font-weight: bold;" align="center" class="contentadmin" rowspan="">
                                                        <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" />
                                                    </th>
                                                    <th style="width: 4%; font-weight: bold; display: none;" class="contentadmin">No</th>
                                                    <th style="font-weight: bold">Tiêu đề</th>
                                                            <th style="font-weight: bold">Giá tiền </th>
                                                    <th style="font-weight: bold">Thứ tự</th>
                                                    <th style="width: 140px; text-align: center; font-weight: bold;">Chức năng</th>
                                                </tr>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        </table>				
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                <tr height="20">
                                    <td></td>
                                </tr>
                                <tr height="25" bgcolor="whitesmoke">
                                    <td>
                                        <asp:LinkButton ID="LinkButton5" Font-Bold="true" OnClick="LinkButton4_Click" runat="server">[Thêm mới]</asp:LinkButton></td>
                                </tr>
                            </table>
                        </div>

                    </asp:Panel>

                    <asp:Panel ID="pn_insert" runat="server" Visible="False" Width="100%">

                        <div class="widget-title">
                            <h4><i class="icon-list-alt"></i>&nbsp;Danh sách nhóm </h4>
                        </div>
                        <div class="widget-body">
                            <div class="row-fluid">
                                <div class="span3">
                                    <div class="dataTables_length" id="sample_1_length">
                                        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                            </div>

                        <div class='frm-add'>
                            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                <tr>
                                        <td align="left" width="200"></td>
                                        <td width="10"></td>
                                        <td>
                                        </td>
                                    </tr>
                                <tr>
                                    <td align="right">Tiêu đề</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txt_title" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Giá tiền</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txttu" runat="server" CssClass="txt_css" Width="320px"></asp:TextBox></td>
                                </tr>
                                <tr style=" display:none">
                                <td align="right">Đến khoảng giá</td>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtden" runat="server" CssClass="txt_css" Width="320px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <%--<tr>
    <td align="right">
        Tùy chọn</td>
    <td>
    </td>
    <td>
                                    --%>
                                    <asp:CheckBox ID="chknews" Visible="false" CssClass="txt_css2" runat="server" Text="Mới" />
                                    <asp:CheckBox ID="chkTrangChu" Visible="false" CssClass="txt_css2" runat="server" Text="Trang chủ" />
                                    <%--       <span style="font-size: 8pt; color: #ed1c24"><em>(Sẽ được hiển thị vào trong các mục định sẵn.)</em></span>
    </td>
</tr>--%>
                                <tr>
                                    <td align="right">
                                        Thứ tự
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txt_order" runat="server" CssClass="txt_css" Width="32px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Hiển thị
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:CheckBox ID="chck_Enable" CssClass="txt_css2" runat="server" Visible="True" />
                                </tr>
                                <tr>
                                    <td align="right"></td>
                                    <td></td>
                                    <td>
                                          <asp:LinkButton ID="btn_InsertUpdate" runat="server" OnClick="btn_InsertUpdate_Click" style="background:#ed1c24" CssClass="toolbar btn btn-info"> <i class="icon-save"></i> Cập nhật </asp:LinkButton>
                                            <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="toolbar btn btn-info"> <i class="icon-chevron-left"></i>Hủy</asp:LinkButton>
                                        </td>
                                </tr>
                            </table>
                        </div>
                            </div>
                        <asp:HiddenField ID="hdFileName" runat="server" />
                        <asp:HiddenField ID="hdid" runat="server" />
                    </asp:Panel>
                    <input id="hd_insertupdate" type="hidden" size="1" name="Hidden1" runat="server">
                    <input id="hd_id" type="hidden" size="1" name="Hidden2" runat="server">
                    <input id="hd_page_edit_id" type="hidden" size="1" name="Hidden2" runat="server">
                    <input id="hd_imgpath" type="hidden" size="1" name="Hidden2" runat="server">
                    <input id="hd_rootpic" type="hidden" size="1" runat="server">
                    <input id="hd_par_id" type="hidden" size="1" name="Hidden2" runat="server">
                </div>
            </div>
        </div>

    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_InsertUpdate" />
    </Triggers>
</asp:UpdatePanel>
