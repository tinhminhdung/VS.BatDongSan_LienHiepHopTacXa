<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu_Page.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Page.Menu_Page" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
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
<div id="cph_Main_ContentPane" >
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Quản trị menu chính</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnDanhsach" runat="server">
                    <div class="widget-title">
                        <h4><i class="icon-list-alt"></i>&nbsp;Danh sách menu </h4>
                        <div class="ui-widget-content ui-corner-top ui-corner-bottom">
                            <div id="toolbox">
                                <div class="toolbox-content" style="float: right;">
                                    <table class="toolbar">
                                        <tbody>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btthemmoi" CssClass="vadd toolbar btn btn-info" OnClick="AddButton_Click" runat="server"><i class="icon-plus"></i>&nbsp; Thêm mới</asp:LinkButton></td>
                                                <td align="center">
                                                        <asp:LinkButton ID="bntcapnhat" CssClass="vadd toolbar btn btn-info" style=" background:#ed1c24" OnClick="bntcapnhat_Click" runat="server"><i class="icon-save"></i> Cập nhật</asp:LinkButton>
                                                    </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" ToolTip="Xóa những lựa chọn!" CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="row-fluid">
                            <div class="span4">
                                <div id="sample_1_length" class="dataTables_length">
                                    <div class="frm_search">
                                        <div>
                                            <div>Tổng số menu:<asp:Literal runat="server" ID="ltrTotalProduct"></asp:Literal></div>
                                            <asp:Label ID="lblThongbao" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span8">
                                <div class="dataTables_filter" id="sample_1_filter">
                                    <asp:DropDownList runat="server" ID="ddlPage" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_OnSelectedIndexChanged">
                                        <asp:ListItem Value="50" Selected="True">Chọn số Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="100">100 Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="200">200 Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="300">300 Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="400">400 Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="1000">1000 Bản ghi / Trang</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drlFilterVitri" AutoPostBack="true"  OnSelectedIndexChanged="drlFilterVitri_SelectedIndexChanged" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#003366">
                                        <asp:ListItem Value="1">Menu trên</asp:ListItem>
                                        <asp:ListItem Value="2">Menu dưới</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" CssClass="txt" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                                        <asp:ListItem Value="-1" Selected="True">Tất cả các mục</asp:ListItem>
                                        <asp:ListItem Value="1">Hiển thị</asp:ListItem>
                                        <asp:ListItem Value="0">Ẩn</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="list_item">
                            <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                <tr height="22">
                                    <th style="width: 8px;">
                                        <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" />
                                    </th>
                                          <th style="font-weight: bold; width:400px">Tên Menu</th>
													<th style="font-weight: bold; width:100px">Cấp cha </th>
                                    <th class="header">Kiểu menu
                                    </th>
                                    <th class="header">Target</th>
                                    <th class="header">Thứ tự
                                    </th>
                                    <th class="header">Trạng thái
                                    </th>
                                    <th class="header">Chức năng
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptDanhsach" runat="server" OnItemCommand="rptDanhsach_ItemCommand" OnItemDataBound="rptDanhsach_ItemDataBound">
                                    <ItemTemplate>
                                        <tr height="40">
                                            <td style="text-align: center;">
                                                <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                                <input type="hidden" value="<%#DataBinder.Eval(Container.DataItem, "ID")%>" name="hd<%#DataBinder.Eval(Container.DataItem, "ID")%>" />
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ID")%>'></asp:Label></td>
                                            <td>
                                                <%#MoreAll.Other.Hienthihinhcay("", DataBinder.Eval(Container.DataItem, "Level").ToString())%>
                                                <asp:TextBox ID="txtTennhom"  OnTextChanged="Name_TextChanged" AutoPostBack="true" runat="server"  Style="border: 1px solid #d7d7d7; border-radius: 3px; text-align: left; width:60%;height:28px" TextMode="MultiLine" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:TextBox>
                                            </td>
                                            <td class="center">
                                                <asp:Label ID="lblLevel" runat="server" Visible="false" Text='<%# Eval("Level").ToString() %>'></asp:Label>
                                                <asp:DropDownList ID="ddlCap" CssClass="Nselect" Width="170" runat="server" OnSelectedIndexChanged="ddlCap_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </td>
                                            <td align="left" style="text-align: center; padding-left: 5px; width: 120px">
                                                <%#Vitri(DataBinder.Eval(Container.DataItem, "Views").ToString())%>
                                            </td>
                                            <td style="text-align: center;">
                                                <%#DataBinder.Eval(Container.DataItem, "Styleshow")%>
                                            </td>
                                             <td style="text-align: center;">
                                                 <asp:TextBox ID="txtOrders" runat="server" Style="border: 1px solid #d7d7d7; border-radius: 3px; text-align: center" CssClass="txt_css" Width="40px" Text='<%#DataBinder.Eval(Container.DataItem, "Orders")%>' onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton CssClass="active action-link-button" ID="LinkButton9" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' CommandName="ChangeStatus" ToolTip="Kích hoạt menu này"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton CssClass="active action-link-button" ID="LinkButton10" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' CommandName="Add" ToolTip="Thêm menu con"><i class="icon-plus"></i></asp:LinkButton>
                                                <asp:LinkButton CssClass="active action-link-button" ID="LinkButton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' CommandName="Edit" ToolTip="Hiệu chỉnh"><i class="icon-edit"></i></asp:LinkButton>
                                                <asp:LinkButton CssClass="active action-link-button" ID="lbt2" runat="server" OnLoad="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' CommandName="Delete" ToolTip="Xoá"><i class="icon-trash"></i></asp:LinkButton>
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
                            <tr height="25" bgcolor="whitesmoke">
                                <td>
                                    <asp:LinkButton ID="AddButton" Font-Bold="true" OnClick="AddButton_Click" runat="server">[Thêm mới]</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnUpdate" runat="server" Visible="false">
                    <div class="widget-title">
                        <h4><i class="icon-list-alt"></i>&nbsp;Thêm mới - cập nhật </h4>
                    </div>
                    <div class="widget-body">
                        <div class="row-fluid">
                            <div class="span12 sortable">
                                <div class="">
                                    <div class="widget-body">
                                        <div class="row-fluid">
                                            <div class="span6">
                                                <div id="sample_1_length" class="dataTables_length">
                                                    <asp:Label ID="ltcapcha" runat="server" ForeColor="#003366" Style="color: #FF0000; font-size: 15px;"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="span6">
                                                <div class="dataTables_filter" id="sample_1_filter">
                                                    <asp:Label ID="lblLoi" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#003366" Style="color: #FF0000; font-size: 8pt;"></asp:Label>
                                                    <asp:Button ID="lbtCapnhat1" runat="server" CssClass="toolbar btn btn-info" Text="Cập nhật" OnClick="lbtCapnhat_Click"></asp:Button>
                                                    <asp:Button ID="lbtTrolai1" runat="server" CssClass="toolbar btn btn-info" Text="Quay lại" OnClick="lbtTrolai_Click"></asp:Button>
                                                </div>
                                            </div>
                                        </div>

                                        <table class="Tables">
                                            <tr>
                                                <td class="leftadd"></td>
                                                <td class="lerightadd" style="padding-top: 5px">
                                                    <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label4" runat="server" CssClass="labadd" Text="Tên menu:"></asp:Label></td>
                                                <td class="lerightadd" style="padding-top: 5px">
                                                    <asp:TextBox ID="txtTenmenu" runat="server" CssClass="Addinput" Width="400px"></asp:TextBox>
                                                    <asp:HiddenField ID="HidId" runat="server" />
                                                    <asp:HiddenField ID="hidLevel" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label17" runat="server" CssClass="labadd" Text="Chọn cấp cha:"></asp:Label></td>
                                                <td class="lerightadd" style="padding-top: 5px">
                                                    <asp:DropDownList ID="ddlcha" runat="server" CssClass="Nselect">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label1" runat="server" CssClass="labadd" Text="Kiểu trang:"></asp:Label></td>
                                                <td class="lerightadd" style="padding-top: 5px">
                                                    <asp:DropDownList ID="drlKieutrang" runat="server" CssClass="Nselect"  AutoPostBack="True" OnSelectedIndexChanged="drlKieutrang_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">===Chọn kiểu trang===</asp:ListItem>
                                                        <asp:ListItem Value="1">Trang liên kết</asp:ListItem>
                                                        <asp:ListItem Value="2">Trang nội dung</asp:ListItem>
                                                        <asp:ListItem Value="3">Url</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <asp:Panel ID="pnKieulienket" runat="server" Visible="false">
                                                <tr>
                                                    <td class="leftadd">
                                                        <asp:Label ID="Label14" runat="server" CssClass="labadd" Text="Nhóm liên kết:"></asp:Label></td>
                                                    <td class="lerightadd" style="padding-top: 5px">
                                                        <asp:DropDownList ID="drlNhomlienket" runat="server" CssClass="Nselect" AutoPostBack="True" OnSelectedIndexChanged="drlNhomlienket_SelectedIndexChanged"></asp:DropDownList></td>
                                                </tr>
                                                <asp:Panel ID="pnNhom" runat="server" Visible="false">
                                                    <tr>
                                                        <td class="leftadd">
                                                            <asp:Label ID="Label15" runat="server" CssClass="labadd" Text="Chuyên mục liên kết:"></asp:Label>
                                                        </td>
                                                        <td class="lerightadd">
                                                            <asp:DropDownList ID="ddlNews" runat="server" CssClass="Nselect">
                                                            </asp:DropDownList>
                                                            <asp:Button ID="btcopyallcateNews" runat="server" CssClass="toolbar btn btn-info" Text="Coppy toàn bộ nhóm tin tức sang" OnClick="btcopyallcateNews_Click"></asp:Button>
                                                            <asp:Button ID="lbtCoppy1" runat="server" CssClass="toolbar btn btn-info" Text="Coppy tiêu đề" OnClick="lbtCoppy1_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="pnpro" runat="server" Visible="false">
                                                    <tr>
                                                        <td class="leftadd">
                                                            <asp:Label ID="Label10" runat="server" CssClass="labadd" Text="Chuyên mục liên kết:"></asp:Label></td>
                                                        <td class="lerightadd">
                                                            <asp:DropDownList ID="ddlProducts" runat="server" CssClass="Nselect">
                                                            </asp:DropDownList>
                                                            <asp:Button ID="btcopyallcatepro" runat="server" CssClass="toolbar btn btn-info" Text="Coppy toàn bộ nhóm sản phẩm sang" OnClick="btcopyallcatepro_Click"></asp:Button>
                                                            <asp:Button ID="lbtCoppy" runat="server" CssClass="toolbar btn btn-info" Text="Coppy tiêu đề" OnClick="lbtCoppy_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="pnLibrary" runat="server" Visible="false">
                                                    <tr>
                                                        <td class="leftadd">
                                                            <asp:Label ID="Label18" runat="server" CssClass="labadd" Text="Chuyên mục liên kết:"></asp:Label></td>
                                                        <td class="lerightadd">
                                                            <asp:DropDownList ID="ddlAmbum" runat="server" CssClass="Nselect">
                                                            </asp:DropDownList>
                                                            <asp:Button ID="btcopyallcateThuvien" runat="server" CssClass="toolbar btn btn-info" Text="Coppy toàn bộ nhóm thư viện sang" OnClick="btcopyallcateThuvien_Click"></asp:Button>
                                                            <asp:Button ID="lbtCoppy2" runat="server" CssClass="toolbar btn btn-info" Text="Coppy tiêu đề" OnClick="lbtCoppy2_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="pnVideo" runat="server" Visible="false">
                                                    <tr>
                                                        <td class="leftadd">
                                                            <asp:Label ID="Label16" runat="server" CssClass="labadd" Text="Chuyên mục liên kết:"></asp:Label></td>
                                                        <td class="lerightadd">
                                                            <asp:DropDownList ID="ddlVideo" runat="server" CssClass="Nselect">
                                                            </asp:DropDownList>
                                                            <asp:Button ID="btcopyallcateVideo" runat="server" CssClass="toolbar btn btn-info" Text="Coppy toàn bộ nhóm video sang" OnClick="btcopyallcateVideo_Click"></asp:Button>
                                                            <asp:Button ID="lbtCoppy3" runat="server" CssClass="toolbar btn btn-info" Text="Coppy tiêu đề" OnClick="lbtCoppy3_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                            </asp:Panel>
                                            <asp:Panel ID="pnNoidung" runat="server" Visible="false">
                                                <tr>
                                                    <td class="leftadd">Rewrite Url
                                                    </td>
                                                    <td class="lerightadd" style="padding-top: 5px">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="txtRewriteUrl" runat="server" CssClass="txt_css" Width="700px"></asp:TextBox>
                                                                <asp:Button ID="btkiemtra" Style="margin-top: -11px;" runat="server" Text="Kiểm tra" CssClass="btn btn-primary" OnClick="btkiemtra_Click" />
                                                                <br />
                                                                <asp:Label ID="ltshowurl" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left"><span style=" color:#ff0000">Ảnh đại diện <br />khi chia sẻ nhóm lên facebook</span>
                                        </td>
                                                    <td class="lerightadd">
                                                        <asp:TextBox ID="txtImg" runat="server"></asp:TextBox>
                                                        <input id="btnBrowse" type="button" value="Browse" onclick="BrowseServer('<%=txtImg.ClientID %>','news');" class="toolbar btns btn-info" />
                                                        <asp:Label ID="lblImg" runat="server"></asp:Label>&nbsp;
                                                     <div style="font-size: 8pt; color: #ed1c24"><em>(Kích thước ảnh: Rộng: 500px X Cao: (Tùy ý) Hoặc 500px)</em></div>
                                                    </td>


                                                </tr>
                                                <tr>
                                                    <td class="leftadd" style="height: 25px">
                                                        <asp:Label ID="Label8" runat="server" CssClass="labadd" Text="Nội dung trang:"></asp:Label></td>
                                                    <td class="lerightadd" style="padding-top: 5px; height: 25px">
                                                        <CKEditor:CKEditorControl ID="fckNoidung" runat="server"></CKEditor:CKEditorControl>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnUrl" runat="server" Visible="false">
                                                <tr>
                                                    <td class="leftadd">
                                                        <asp:Label ID="Label13" runat="server" CssClass="labadd" Text="Đường dẫn liên kết:"></asp:Label></td>
                                                    <td class="lerightadd">
                                                        <asp:TextBox ID="txtUrl" runat="server" CssClass="Addinput" Width="400px"></asp:TextBox></td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnimg" runat="server" Visible="false">
                                                
                                            </asp:Panel>
                                            <tr>
                                                <td class="leftadd"></td>
                                                <td class="lerightadd" style="display: none">
                                                    <asp:Literal ID="ltrImg" runat="server"></asp:Literal>
                                                    <asp:LinkButton ID="lbtDelimg" runat="server" CssClass="delete" OnClick="lbtDelimg_Click"
                                                        Visible="False">Xóa ảnh</asp:LinkButton></td>
                                            </tr>

                                            <asp:Panel ID="Pnseo" runat="server" Visible="false"></asp:Panel>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label2" runat="server" CssClass="labadd"
                                                        Text="Tiêu đề hiển thị trên title:"></asp:Label>
                                                </td>
                                                <td class="lerightadd">
                                                    <asp:TextBox ID="txtTieude" runat="server" CssClass="Addinput" Width="690px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label6" runat="server" CssClass="labadd" Text="Nội dung hiển thị trong Description:"></asp:Label>
                                                </td>
                                                <td class="lerightadd">
                                                    <asp:TextBox ID="txtDesscription" runat="server" CssClass="Addinput" Width="690px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label9" runat="server" CssClass="labadd" Text="Nội dung hiển thị trong Keyword:"></asp:Label></td>
                                                <td class="lerightadd">
                                                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="Addinput" Width="690px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                            </tr>

                                            
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label12" runat="server" CssClass="labadd" Text="Kiểu xuất hiện trang:"></asp:Label></td>
                                                <td class="lerightadd">
                                                    <asp:DropDownList ID="drlKieuxuathien" runat="server" CssClass="Nselect">
                                                        <asp:ListItem Value="_self">Cùng trang</asp:ListItem>
                                                        <asp:ListItem Value="_blank">Trang mới</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label11" runat="server" CssClass="labadd" Text="Vị trí trang:"></asp:Label></td>
                                                <td class="lerightadd">
                                                    <asp:DropDownList ID="drlVitri" runat="server" CssClass="Nselect">
                                                        <asp:ListItem Value="0">===Chọn vị tr&#237;===</asp:ListItem>
                                                        <asp:ListItem Value="1">Menu trên</asp:ListItem>
                                                        <asp:ListItem Value="2">Menu dưới</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label7" runat="server" CssClass="labadd"
                                                        Text="Thứ tự:"></asp:Label>
                                                </td>
                                                <td class="lerightadd">
                                                    <asp:TextBox ID="txtThuTu" CssClass="Addinput" runat="server" Width="30px" onblur="valid(this,'quotes')" onkeyup="valid(this,'quotes')">1</asp:TextBox>
                                                    <span style="color: #bcbcbc; font-style: italic; font-size: 11px;">(Nhập số tự nhiên : 1,2,3...)</span>
                                                    <asp:DropDownList ID="drlThutu" runat="server" CssClass="Nselect" Visible="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd">
                                                    <asp:Label ID="Label5" runat="server" CssClass="labadd" Text="Kích hoạt:"></asp:Label>
                                                </td>
                                                <td class="lerightadd">
                                                    <asp:CheckBox ID="chkKichhoat" runat="server" Checked="true" />

                                                    <asp:HiddenField ID="hd_id" Value="-1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="leftadd"></td>
                                                <td class="lerightadd">

                                                    <asp:Button ID="lbtCapnhat" runat="server" CssClass="toolbar btn btn-info" Text="Cập nhật" OnClick="lbtCapnhat_Click"></asp:Button>
                                                    <asp:Button ID="lbtTrolai" runat="server" CssClass="toolbar btn btn-info" Text="Quay lại" OnClick="lbtTrolai_Click"></asp:Button>

                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="idxoa1" runat="server" Value="1" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lbtCapnhat" />
                <asp:PostBackTrigger ControlID="lbtTrolai" />
                <asp:PostBackTrigger ControlID="lbtCapnhat1" />
                <asp:PostBackTrigger ControlID="lbtTrolai1" />
                <asp:PostBackTrigger ControlID="lbtCoppy" />
                <asp:PostBackTrigger ControlID="lbtCoppy1" />
                <asp:PostBackTrigger ControlID="lbtCoppy2" />
                <asp:PostBackTrigger ControlID="lbtCoppy3" />
                <asp:PostBackTrigger ControlID="AddButton" />
                <asp:PostBackTrigger ControlID="btthemmoi" />
                <asp:PostBackTrigger ControlID="btxoa" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
