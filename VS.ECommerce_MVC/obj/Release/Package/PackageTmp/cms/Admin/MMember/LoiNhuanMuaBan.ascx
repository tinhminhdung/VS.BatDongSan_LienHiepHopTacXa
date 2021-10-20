<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoiNhuanMuaBan.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.MMember.LoiNhuanMuaBan" %>
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
                        <li class="Last"><span>Danh sách lợi nhuận Mua Bán</span></li>
                    </ul>
                </div>
                <div style="clear: both;"></div>
                <div class="widget">
                    <asp:Panel ID="pn_list" runat="server" Width="100%">
                        <div class="widget-title">
                            <h4><i class="icon-list-alt"></i>&nbsp;Danh sách lợi nhuận Mua Bán</h4>

                        </div>
                        <div class="widget-body">
                            <div class="row-fluid">
                                <div class="span9">
                                    <div>
                                        <asp:TextBox ID="txtkeyword" placeholder="Tìm kiếm theo tên User thành viên" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
                                        <asp:DropDownList CssClass="txt" runat="server" ID="ddlkieuthanhvien">
                                            <asp:ListItem Value="1">Người Mua Hàng</asp:ListItem>
                                            <asp:ListItem Value="2">Người Bán Hàng</asp:ListItem>
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
                                    </div>
                                </div>
                            </div>

                            <div class="list_item">
                                <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                    <tbody>

                                        <tr style="background: #ed1c24; color: #fff;">
                                            <td style="text-align: right; color: #fff; font-weight: bold" colspan="3">Tổng điểm gốc / Tổng:
                        <asp:Literal ID="lttongtien1" runat="server"></asp:Literal>
                                            </td>
                                            <td style="text-align: right; color: #fff; font-weight: bold" colspan="3">Tổng điểm đã chia / Tổng :
                        <asp:Literal ID="ltdachia1" runat="server"></asp:Literal>
                                            </td>
                                            <td style="text-align: center; color: #fff; font-weight: bold" colspan="4">Tổng điểm còn lại / Tổng : 
                        <asp:Literal ID="ltconlai1" runat="server"></asp:Literal>
                                            </td>
                                        </tr>

                                        <tr style="background: #ffa903; color: #fff;">
                                            <td style="text-align: right; color: #fff; font-weight: bold" colspan="3">Tổng điểm gốc / Trang :
                        <asp:Literal ID="lttongtien" runat="server"></asp:Literal>
                                            </td>
                                            <td style="text-align: right; color: #fff; font-weight: bold" colspan="3">Tổng điểm đã chia / Trang :
                        <asp:Literal ID="ltdachia" runat="server"></asp:Literal>
                                            </td>
                                            <td style="text-align: center; color: #fff; font-weight: bold" colspan="4">Tổng điểm còn lại / Trang : 
                        <asp:Literal ID="ltconlai" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr class="trHeader" style="height: 25px">
                                            <th style="width: 4%; font-weight: bold;" align="center" class="contentadmin" rowspan="">
                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" />
                                            </th>
                                            <th style="width: 4%; font-weight: bold; display: none;" class="contentadmin">No</th>
                                            <th style="font-weight: bold">Nội dung</th>
                                            <th style="font-weight: bold; width: 200px">Người Mua Hàng </th>
                                            <th style="font-weight: bold">Tổng tiền</th>
                                            <th style="font-weight: bold">Tồng tiền đã chia</th>
                                            <th style="font-weight: bold">Tồng tiền còn lại</th>
                                            <th style="font-weight: bold">Ngày tạo</th>

                                            <th style="font-weight: bold">Người duyệt</th>
                                            <th style="font-weight: bold">[Chi tiết]</th>
                                        </tr>

                                        <asp:Repeater ID="rp_pagelist" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <div>Mã đơn hàng: <%#Eval("IDDonHang").ToString() %></div>
                                                    </td>
                                                    <td>
                                                        <%#Commond.ShowThanhVien(DataBinder.Eval(Container.DataItem,"IDThanhVienMua").ToString())%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#AllQuery.MorePro.Detail_Price(Eval("TongTien").ToString())%> 
                                                    </td>

                                                    <td style="text-align: center;">
                                                        <%#AllQuery.MorePro.Detail_Price(Eval("TongTienDaChia").ToString())%> 
                                                    </td>

                                                    <td style="text-align: center;">
                                                        <%#AllQuery.MorePro.Detail_Price(Eval("TongTienCon").ToString())%> 
                                                    </td>
                                                    <td>
                                                        <%#MoreAll.FormatDateTime.FormatDates(DataBinder.Eval(Container.DataItem,"NgayTao"))%> 
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#Eval("NguoiDuyet").ToString()%> 
                                                    </td>
                                                    <td>
                                                        <a target="_blank" href="/admin.aspx?u=Danhsachhoahong&IDDonHang=<%#Eval("IDDonHang").ToString() %>">[Chi tiết]</a>
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
