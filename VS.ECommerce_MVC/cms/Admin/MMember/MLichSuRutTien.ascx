<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MLichSuRutTien.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.MMember.MLichSuRutTien" %>
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
        <div id="cph_Main_ContentPane">
            <div id="">
                <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
                    <ul>
                        <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                        <li class="Last"><span>Danh sách rút tiền</span></li>
                    </ul>
                </div>
                <div style="clear: both;"></div>
                <div class="widget">
                    <asp:Panel ID="pn_list" runat="server" Width="100%">
                        <div class="widget-title">
                            <h4><i class="icon-list-alt"></i>&nbsp;Danh sách rút tiền</h4>
                        </div>
                        <div class="widget-body">
                            <div class="row-fluid">
                                <div class="span10">
                                     <div>
                                    <asp:TextBox ID="txtkeyword" placeholder="Tìm kiếm theo tên User thành viên" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
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
                                         <asp:DropDownList ID="ddltrangthai" CssClass="txt" AutoPostBack="true" Width="210px"
                                            runat="server" OnSelectedIndexChanged="ddltrangthai_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">- Tất cả trạng thái - </asp:ListItem>
                                            <asp:ListItem Value="1"> Đã duyệt</asp:ListItem>
                                            <asp:ListItem Value="0">Chưa duyệt</asp:ListItem>
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
                                <div class="span2">
                                    <div class="dataTables_filter" id="sample_1_filter">
                                           <asp:LinkButton ID="lnkxuatExel" runat="server" OnClick="lnkxuatExel_Click" CssClass="vadd toolbar btn btn-info"> Xuất Exel</asp:LinkButton>
                                        <asp:LinkButton ID="bthienthi" runat="server" OnClick="bthienthi_Click" CssClass="vadd toolbar btn btn-info"> <i class=" icon-folder-close"></i>&nbsp;Hiện thị</asp:LinkButton>
                                        <asp:LinkButton ID="btxoa" Visible="false" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div style="color:red">Lưu ý: hiện tại xuất Exel sắp xếp theo ngày duyệt mới nhất</div>
                            <div class="list_item">
                                <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                          <%--  <td style="text-align: center;">
                                                <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                            </td>--%>
                                            <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465" width="350px">
                                                Họ và tên:<span style="color: #444444; padding-left: 27px; font-weight: bold"> <%#Commond.ShowThanhVien(DataBinder.Eval(Container.DataItem,"IDThanhVien").ToString())%></span><br />
                                                Tên ngân hàng:<span style="color: #444444; padding-left: 40px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "TenNganHang")%></span><br />
                                                Số tài khoản:<span style="color: #444444; padding-left: 40px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "SoTaiKHoan")%></span><br />
                                                Chi nhánh:<span style="color: #444444; padding-left: 22px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "ChiNhanh")%></span><br />
                                                Nội dung chuyển tiền:<span style="color: #444444; padding-left: 15px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "NoiDungChuyenTien")%></span><br />
                                                Ghi chú:<span style="color: #444444; padding-left: 15px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "GhiChu")%></span><br />
                                            </td>
                                         <%--   <td style="text-align: center;">
                                                <%#MoreAll.MorePro.FormatMoney_NO(DataBinder.Eval(Container.DataItem,"TongTienTrongVi").ToString())%> VNĐ
                                            </td>--%>

                                            <td style="text-align: center;">
                                                <%#DataBinder.Eval(Container.DataItem,"SoTienCanRut")%> 
                                            </td>
                                              <td style="text-align: center;">
                                               <%#DataBinder.Eval(Container.DataItem,"SoCoin").ToString()%> 
                                                    </td>
                                            <td style="text-align: center;">
                                                <%#MoreAll.FormatDateTime.FormatDate_Brithday(DataBinder.Eval(Container.DataItem,"NgayTao"))%> 
                                            </td>
                                              <td style="text-align: center;">
                                                <%#DataBinder.Eval(Container.DataItem,"NgayDuyet").ToString()%> 
                                            </td>
                                             <td>
                                                <%#MoreAll.MoreAll.TrangThaiEnableRut(DataBinder.Eval(Container.DataItem,"TrangThai").ToString())%> 
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton CssClass="active action-link-button" ID="LinkButton2" runat="server" CommandName="Huy" CommandArgument='<%#Eval("ID")%>' OnLoad="Lock_Load" Visible='<%#EnableLock(Eval("TrangThai").ToString())%>'><span style=" font-size:12px; background:red;padding: 4px;margin-right:3px;margin-left:5px;color:#fff;border-radius: 3px;font-weight: 600;">[Hủy]</span></asp:LinkButton>
                                              <asp:LinkButton CssClass="active action-link-button" ID="LinkButton5" runat="server" CommandName="ThanhToan" OnLoad="Duyet_Load" CommandArgument='<%#Eval("ID")%>' Visible='<%#EnableUnLock(Eval("TrangThai").ToString())%>'><span style=" font-size:12px; background:#00a9d2;padding: 4px;margin-right:3px;margin-left:5px;color:#fff;border-radius: 3px;font-weight: 600;">[Duyệt]</span></asp:LinkButton>
                                            </td>
                                           <%-- <td style="text-align: center;">
                                                <asp:LinkButton CssClass="active action-link-button" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load"><i class="icon-trash"></i></asp:LinkButton>
                                            </td>--%>
                                        </tr>
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                            <tbody>
                                                <tr class="trHeader" style="height: 25px">
                                                 <%--   <th style="width: 4%; font-weight: bold;" align="center" class="contentadmin" rowspan="">
                                                        <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" />
                                                    </th>--%>
                                                    <th style="width: 4%; font-weight: bold; display: none;" class="contentadmin">No</th>
                                                    <th style="font-weight: bold">Thông tin thành viên</th>
                                               <%--     <th style="font-weight: bold">Số tiền còn lại</th>--%>
                                                    <th style="font-weight: bold">Số điểm cần rút</th>
                                                     <th style="font-weight: bold">Số điểm còn lại</th>
                                                    <th style="font-weight: bold">Ngày tạo</th>
                                                       <th style="font-weight: bold">Ngày duyệt</th>
                                                    <th style="font-weight: bold">Trạng thái</th>
                                                    <th style="font-weight: bold">Trạng thái</th>
                                                  <%--  <th style="width: 140px; text-align: center; font-weight: bold;">Chức năng</th>--%>
                                                </tr>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <div style="color: red; text-align: right; padding-top: 7px; font-weight: 600">
                                <asp:Literal ID="lttongtien" runat="server"></asp:Literal>
                            </div>
                            <div style="color: red; text-align: right; padding-top: 7px; font-weight: 600">
                                <asp:Literal ID="lttongtienbangchu" runat="server"></asp:Literal>
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


<style>
    i {
        font-size: 20px;
    }
</style>
