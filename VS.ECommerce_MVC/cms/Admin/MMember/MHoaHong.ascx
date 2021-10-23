<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MHoaHong.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.MMember.MHoaHong" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<script language="javascript">
    var r = {
        'special': /[\W]/g,
        'quotes': /[^0-9^,]/g,
        'notnumbers': /[^a-zA]/g
    }
    function valid(o, w) {
        o.value = o.value.replace(r[w], '');
    }
</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="cph_Main_ContentPane">
            <div id="">
                <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
                    <ul>
                        <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                        <li class="Last"><span>Danh sách các hoa hồng</span></li>
                    </ul>
                </div>
                <div style="clear: both;"></div>
                <div class="widget">
                    <asp:Panel ID="pn_list" runat="server" Width="100%">
                        <div class="widget-title">
                            <h4><i class="icon-list-alt"></i>&nbsp;Danh sách các hoa hồng</h4>

                        </div>
                        <div class="widget-body">
                            <div class="row-fluid">
                                <div class="span9">
                                    <div>
                                        <asp:TextBox ID="txtkeyword" placeholder="Tìm kiếm theo tên User thành viên" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
                                        <asp:DropDownList CssClass="txt" runat="server" ID="ddlkieuthanhvien">
                                            <asp:ListItem Value="1">Người Tham Gia</asp:ListItem>
                                            <asp:ListItem Value="2">Người được hưởng</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:LinkButton ID="lnksearch" runat="server" OnClick="lnksearch_Click" CssClass="vadd toolbar btn btn-info" Style="margin-top: -9px;"> <i class="icon-search"></i>&nbsp;Tìm kiếm</asp:LinkButton>
                                        <asp:Label ID="ltthongbao" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="dataTables_length" id="sample_1_length">
                                        <asp:DropDownList CssClass="txt" runat="server" ID="ddlPage" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                            <asp:ListItem Value="50" Selected="True">Chọn số Bản ghi / Trang</asp:ListItem>
                                            <asp:ListItem Value="100">100 Bản ghi / Trang</asp:ListItem>
                                            <asp:ListItem Value="200">200 Bản ghi / Trang</asp:ListItem>
                                            <asp:ListItem Value="300">300 Bản ghi / Trang</asp:ListItem>
                                            <asp:ListItem Value="400">400 Bản ghi / Trang</asp:ListItem>
                                            <asp:ListItem Value="1000">1000 Bản ghi / Trang</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlkieu" CssClass="txt" AutoPostBack="true"
                                            runat="server" OnSelectedIndexChanged="ddlkieu_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Tất cả loại Hoa Hồng</asp:ListItem>
                                            <asp:ListItem Value="1">Hoa hồng Người Bán Hàng</asp:ListItem>
                                            <asp:ListItem Value="10">Hoa hồng cấp bậc</asp:ListItem>
                                            <asp:ListItem Value="3">Văn Phòng</asp:ListItem>
                                            <asp:ListItem Value="4">Đồng hưởng</asp:ListItem>
                                    <%--        <asp:ListItem Value="5">Hoa hồng Ban Điều hành</asp:ListItem>
                                            <asp:ListItem Value="6">Hoa hồng Người Khai Thác</asp:ListItem>
                                            <asp:ListItem Value="7">Hoa hồng Trưởng Nhóm Kinh Doanh</asp:ListItem>
                                            <asp:ListItem Value="8">Hoa hồng Trưởng Phòng Kinh Doanh</asp:ListItem>
                                            <asp:ListItem Value="9">Hoa hồng Giám Đốc Kinh Doanh</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        <asp:TextBox Style="width: 200px;" ID="txtNgayThangNam" placeholder="Tìm kiếm từ ngày/tháng/năm" AutoPostBack="true" OnTextChanged="txtNgayThangNam_TextChanged" runat="server" CssClass="txt_csssearch" Width="200px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtNgayThangNam"></cc1:CalendarExtender>
                                        <asp:TextBox Style="width: 200px;" ID="txtDenNgayThangNam" placeholder="Tìm kiếm đến ngày/tháng/năm" AutoPostBack="true" OnTextChanged="txtDenNgayThangNam_TextChanged" runat="server" CssClass="txt_csssearch" Width="200px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDenNgayThangNam"></cc1:CalendarExtender>

                                        <div>
                                            <asp:Label ID="ltmsg" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lbl_curpage" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div class="dataTables_filter" id="sample_1_filter">
                                        <asp:LinkButton ID="lnkxuatExel" runat="server" OnClick="lnkxuatExel_Click" CssClass="vadd toolbar btn btn-info"> Xuất Exel</asp:LinkButton>

                                        <asp:LinkButton ID="bthienthi" runat="server" OnClick="bthienthi_Click" CssClass="vadd toolbar btn btn-info"> <i class=" icon-folder-close"></i>&nbsp;Hiện thị</asp:LinkButton>
                                        <asp:LinkButton ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="list_item">
                                <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                    <tbody>
                                        <tr style="background: #ffa903; color: #fff;">
                                            <td style="text-align: right; color: #fff; font-weight: bold" colspan="4">Tổng cộng :
                        <asp:Literal ID="lttongtien" runat="server"></asp:Literal>
                                            </td>
                                            <td style="text-align: center; color: #fff; font-weight: bold" colspan="4">Tổng tiền / Trang : 
                        <asp:Literal ID="ltCoin" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr class="trHeader" style="height: 25px">
                                            <th style="width: 4%; font-weight: bold;" align="center" class="contentadmin" rowspan="">
                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" />
                                            </th>
                                            <th style="width: 4%; font-weight: bold; display: none;" class="contentadmin">No</th>
                                            <th style="font-weight: bold">Kiểu</th>
                                            <th style="font-weight: bold; width: 200px">Người mua 
                                            </th>
                                            <th style="font-weight: bold; width: 200px">Người hưởng</th>
                                            <th style="font-weight: bold">% Hoa Hồng</th>
                                            <th style="font-weight: bold">Số tiền</th>
                                            <th style="font-weight: bold">Ngày tạo</th>
                                        </tr>

                                        <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <%#DataBinder.Eval(Container.DataItem,"KieuHH")%> <%---  <%#DataBinder.Eval(Container.DataItem,"KieuHoaHong")%>--%>
                                                        <%--<div><%#ShowPro(Eval("IDProducts").ToString(),Eval("NoiDung").ToString())%></div>--%>
                                                        <div>Mã đơn hàng: <%#Eval("IDDonHang").ToString() %></div>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#Commond.ShowThanhVien(DataBinder.Eval(Container.DataItem,"IDThanhVienMua").ToString())%> <%----- ( <%#DataBinder.Eval(Container.DataItem,"IDThanhVienMua")%>)--%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#Commond.ShowThanhVien(DataBinder.Eval(Container.DataItem,"IDThanhVienHuong").ToString())%> <%-----( <%#DataBinder.Eval(Container.DataItem,"IDThanhVienHuong")%>)--%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#DataBinder.Eval(Container.DataItem,"PhanTram")%> %
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#AllQuery.MorePro.FormatMoney_Cart(Eval("SoTienDuocHuong").ToString())%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#MoreAll.FormatDateTime.FormatDate_Brithday(DataBinder.Eval(Container.DataItem,"NgayTao"))%> 
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                </table>
                            </div>

                            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                <tr height="20">
                                    <td align="right">
                                        <asp:Literal ID="ltpage" runat="server"></asp:Literal>
                                        <div class="phantrang" style="">
                                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                                                BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
                                                ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                                            </cc1:CollectionPager>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <input id="hd_insertupdate" type="hidden" size="1" name="Hidden1" runat="server">
        <input id="hd_id" type="hidden" size="1" name="Hidden2" runat="server">
        <input id="hd_page_edit_id" type="hidden" size="1" name="Hidden2" runat="server">
        <input id="hd_imgpath" type="hidden" size="1" name="Hidden2" runat="server">
        <input id="hd_rootpic" type="hidden" size="1" runat="server">
        <input id="hd_par_id" type="hidden" size="1" name="Hidden2" runat="server">
        <asp:HiddenField ID="hidLevel" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="lnkxuatExel" />
    </Triggers>
</asp:UpdatePanel>


<style>
    i {
        font-size: 20px;
    }
</style>
