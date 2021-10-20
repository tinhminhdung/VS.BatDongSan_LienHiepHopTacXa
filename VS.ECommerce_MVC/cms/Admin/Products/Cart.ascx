<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cart.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Products.Cart" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Quản lý giỏ hàng</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="widget">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="widget-title">
                        <h4><i class="icon-list-alt"></i>&nbsp;Quản lý giỏ hàng     </h4>
                    </div>
                    <div class="widget-body">

                        <div class="row-fluid">
                            <div class="span6">
                                <div id="sample_1_length" class="dataTables_length">
                                    <div class="frm_search">
                                        <div>
                                            <asp:Literal ID="lttotal1" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="dataTables_filter" id="sample_1_filter">
                                    <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" Width="144px">
                                        <asp:ListItem Value="-1" Selected="True">Tất cả các mục</asp:ListItem>
                                        <asp:ListItem Value="1">Đơn hàng đã duyệt</asp:ListItem>
                                        <asp:ListItem Value="0">Đơn hàng chưa duyệt</asp:ListItem>
                                        <asp:ListItem Value="2">Đơn hàng đang chờ xử lý</asp:ListItem>
                                        <asp:ListItem Value="3">Đơn hàng đang vận chuyển</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch"></asp:TextBox>
                                    <asp:Button ID="btnshow" runat="server" Text="Hiển thị" OnClick="btnshow_Click" CssClass="vadd toolbar btn btn-info"></asp:Button>
                                    <asp:Button ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" CssClass="vadd toolbar btn btn-info" />
                                    <asp:Button ID="lbtExport" runat="server" OnClick="Export_Click" CssClass="vadd toolbar btn btn-info" Text="Export dữ liệu" ToolTip="Export dữ liệu" />
                                </div>
                            </div>
                        </div>
                        <div class="list_item">
                            <asp:Repeater ID="rp_items" runat="server" OnItemCommand="rp_items_ItemCommand" OnItemDataBound="rp_items_ItemDataBound">
                                <ItemTemplate>
                                    <tr height="40">
                                        <td style="text-align: center;">
                                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                        </td>
                                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465" width="500px">
                                           <span style="color: #444444; padding-left:0px; font-weight: bold; color:red">Mã đơn hàng: #<%#DataBinder.Eval(Container.DataItem, "ID")%></span><br />
                                             Họ và tên:<span style="color: #444444; padding-left: 27px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Name")%></span><br />
                                            Địa chỉ:<span style="color: #444444; padding-left: 40px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Address")%></span><br />
                                            Điện thoại:<span style="color: #444444; padding-left: 22px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Phone")%></span><br />
                                            Email:<span style="color: #444444; padding-left: 15px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Email")%></span><br />
                                          <%--  <div>Hình thức thanh toán: <span style="color: #fff; padding: 3px; font-weight: bold; background: #1a8506; border-radius: 5px; width: 250px"><%#DataBinder.Eval(Container.DataItem, "Phuongthucthanhtoan")%></span></div>
                                            <div>Phương thức vận chuyển: <span style="<%#Thanhtoan(Eval("ID").ToString())%>"><%#DataBinder.Eval(Container.DataItem, "Hinhthucvanchuyen")%></span></div>--%>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#AllQuery.MorePro.FormatMoney(Eval("Money").ToString())%>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date").ToString())%>
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:DropDownList ID="ddltrangthai" runat="server" OnSelectedIndexChanged="ddltrangthai_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="1">Đơn hàng đã duyệt</asp:ListItem>
                                                <asp:ListItem Value="0">Đơn hàng chưa duyệt</asp:ListItem>
                                                <asp:ListItem Value="2">Đơn hàng đang chờ xử lý</asp:ListItem>
                                                <asp:ListItem Value="3">Đơn hàng đang vận chuyển</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hdStatus" Value='<%#Eval("Status") %>' runat="server" />
                                        </td>
                                        
                                        <td style="text-align: center;">
                                            <asp:LinkButton ID="LinkButton5" CommandName="SendMail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server"><img src="Resources/admin/images/email.png" border=0 /></asp:LinkButton>
                                        </td>
                                        <td style="text-align: center;">
                                            <a target="_blank" class="active action-link-button"  href="/cms/admin/products/Cartdetail.aspx?ID_Cart=<%#DataBinder.Eval(Container.DataItem,"ID")%>"><img src="/Resources/Admins/images/print.png" /></a>
                                        </td>
                                        <td style="text-align: center;">
                                            <asp:LinkButton ID="LinkButton1" CommandName="Detail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server"><img src="/Resources/admin/images/chitiet.png" border=0 /></asp:LinkButton>
                                        </td>
                                        <td style="text-align: center;">
                                                <asp:LinkButton CssClass="active action-link-button" ID="LinkButton2" OnLoad="Delete_Load" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server"><i class="icon-trash"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                                <HeaderTemplate>
                                    <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                        <tr height="40">
                                            <td class="header">
                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" /></td>
                                            <td class="header">Thông tin khách hàng</td>
                                            <td class="header" style="text-align: center;">Tổng tiền</td>
                                            <td class="header" style="text-align: center;">Ngày gửi</td>
                                            <td class="header" style="text-align: center;">Tình trạng đơn hàng</td>
                                              <td class="header" style="text-align: center;">Gửi mail</td>
                                            <td class="header" style="text-align: center;">Print</td>
                                          <td class="header" style="text-align: center;">Xem chi tiết</td>
                                            <td class="header">Xóa</td>
                                        </tr>
                                </HeaderTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                            <tr height="20">
                                <td style="text-align: center;">
                                    <asp:Literal ID="ltpage" runat="server"></asp:Literal>
                                    <div class="phantrang" style="">
                                        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                                            BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
                                            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                                        </cc1:CollectionPager>
                                    </div>
                                </td>
                        </table>

                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="widget-title">
                        <h4><i class="icon-list-alt"></i>&nbsp;Gửi Email </h4>
                    </div>
                    <div class="widget-body">
                        <div class='frm-add'>
                            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Tiêu đề</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txttitle" runat="server" Width="350px" CssClass="txt_css"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Tên người nhận</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txttoname" runat="server" CssClass="txt_css" Width="350px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="height: 24px"></td>
                                    <td style="height: 24px">Email đến</td>
                                    <td style="height: 24px"></td>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtTo" runat="server" CssClass="txt_css" Width="350px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Nội dung<br />
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="3">
                                        <CKEditor:CKEditorControl ID="txtContent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="padding-left: 0px; height: 0px;">
                            <br />
                            <asp:LinkButton ID="btnSend" runat="server" OnClick="btnSend_Click" CssClass="toolbar btn btn-info"> <i class="icon-ok"></i>Gửi mail</asp:LinkButton>
                            <asp:LinkButton ID="btncancel" runat="server" OnClick="btncancel_Click" CssClass="toolbar btn btn-info"> <i class="icon-chevron-left"></i>Hủy</asp:LinkButton>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <div id="cph_Main_ContentPane">
                        <div class="widget">
                            <div class="widget-title">
                                <h4><i class="icon-reorder"></i>&nbsp;Thông tin giỏ hàng</h4>
                                <div class="ui-widget-content ui-corner-top ui-corner-bottom">
                                    <div id="toolbox">
                                        <div style="float: right;" class="toolbox-content">
                                            <table class="toolbar">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <a id="" class="toolbar btn btn-info" href="javascript:{}" onclick="window.print()"><i class="fa fa-print"></i>Print </a></td>
                                                        <td align="center">
                                                            <a id="" class="toolbar btn btn-info" href="/admin.aspx?u=pro&su=carts"><i class="icon-chevron-left"></i>Quay lại</a></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-body">
                                <table style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <td style="width: 14%; text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Tên khách hàng:</span>
                                            </td>
                                            <td style="font-weight: bold">
                                                <asp:Literal ID="ltname" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Địa chỉ:</span>
                                            </td>
                                            <td style="font-weight: bold">
                                                <asp:Literal ID="ltdiachi" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Điện thoại:</span>
                                            </td>
                                            <td style="font-weight: bold">
                                                <asp:Literal ID="ltdienthoai" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Email:</span>
                                            </td>
                                            <td style="font-weight: bold">
                                                <asp:Literal ID="ltemail" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr style=" display:none">
                                            <td style="text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Hình thức thanh toán:</span>
                                            </td>
                                            <td style="font-weight: bold">
                                                <asp:Literal ID="ltthanhtoan" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                          <tr style=" display:none">
                                            <td style="text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Phương thức giao hàng:</span>
                                            </td>
                                            <td style="font-weight: bold">
                                                <asp:Literal ID="lthinhthucgiaohang" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Nội dung yêu cầu:</span>
                                            </td>
                                            <td style="font-weight: bold">
                                                <asp:Literal ID="ltghichu" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Tổng số tiền:</span>
                                            </td>
                                            <td style="font-weight: bold; color: red">
                                                <asp:Literal ID="lttong" runat="server"></asp:Literal> <%=Commond.Setting("Dongiapro") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right; padding-right: 15px">
                                                <span id="" class="lbleft">Tổng số tiền bằng chữ:</span>
                                            </td>
                                            <td style="font-weight: bold; color: red">
                                                <asp:Literal ID="ltvietchu" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                    <tbody>
                                        <tr class="trHeader" style="height: 40px">
                                            <td style="width: 4%" class="contentadmin">STT</td>
                                            <td class="contentadmin">Ảnh</td>
                                            <td class="contentadmin">Mã sản phẩm</td>
                                            <td class="contentadmin">Tên sản phẩm</td>
                                            <td style="width: 10%; text-align: center !important" class="contentadmin">Giá</td>
                                            <td style="width: 7%; text-align: center !important" class="contentadmin">Số lượng</td>
                                            <td style="width: 15%; text-align: center !important" class="contentadmin">Số tiền</td>
                                        </tr>
                                        <asp:Repeater ID="rpcartdetail" runat="server">
                                            <ItemTemplate>
                                           <tr style="height: 20px" class="tr_while" onmouseover="this.className='tr_while_over'" onmouseout="this.className='tr_while'">
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%=i++ %></td>
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin">
                                                        <img src="<%#Anh(Eval("ipid").ToString())%>" style="width: 50px; height: 50px;" /></td>
                                                    <td style="padding-left: 5px; text-align: left !important" class="cartadmin"><%#Codes(Eval("ipid").ToString())%></td>
                                                    <td style="padding-left: 5px; text-align: left !important" class="cartadmin"><%#DataBinder.Eval(Container.DataItem,"Name")%></td>
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#AllQuery.MorePro.Detail_Price(Eval("Price").ToString())%> <%=Commond.Setting("Dongiapro") %></td>
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#DataBinder.Eval(Container.DataItem,"Quantity")%></td>
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#AllQuery.MorePro.Detail_Price(Eval("Money").ToString())%> <%=Commond.Setting("Dongiapro") %></td>
                                          </tr>
                                           </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                 <tr style="height: 20px; background:#fafafa" class="tr_while" onmouseover="this.className='tr_while_over'" onmouseout="this.className='tr_while'">
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%=i++ %></td>
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin">
                                                        <img src="<%#Anh(Eval("ipid").ToString())%>" style="width: 50px; height: 50px;" /></td>
                                                    <td style="padding-left: 5px; text-align: left !important" class="cartadmin"><%#Codes(Eval("ipid").ToString())%></td>
                                                    <td style="padding-left: 5px; text-align: left !important" class="cartadmin"><%#DataBinder.Eval(Container.DataItem,"Name")%></td>
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#AllQuery.MorePro.Detail_Price(Eval("Price").ToString())%> <%=Commond.Setting("Dongiapro") %> </td>
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#DataBinder.Eval(Container.DataItem,"Quantity")%></td>
                                                    <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#AllQuery.MorePro.Detail_Price(Eval("Money").ToString())%> <%=Commond.Setting("Dongiapro") %></td>
                                          </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                                <br />
                                <br />
                                <br />

                            </div>

                        </div>
                    </div>
                </asp:View>

            </asp:MultiView>
        </div>
    </div>
</div>

<div style="clear: both;"></div>
