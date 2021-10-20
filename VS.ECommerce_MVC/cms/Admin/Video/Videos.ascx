<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Videos.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Video.Videos" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="cph_Main_ContentPane">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Danh sách video</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="widget">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Danh sách thư viện</h4>
                                <div class="ui-widget-content ui-corner-top ui-corner-bottom">
                                        <div id="toolbox">
                                        <div class="toolbox-content" style="float: right;margin-top: 9px;">
                                        <asp:Label ID="ltmsg" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
                                        </div>
                                        </div>
                                        </div>
                        </div>
                        <div class="widget-body">
                            <div class="row-fluid">
                                <div class="span9">
                                    <div id="sample_1_length" class="dataTables_length">
                                        <div class="frm_search">
                                            <div>
                                                <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
                                                <asp:LinkButton ID="lnksearch" runat="server" OnClick="lnksearch_Click" CssClass="vadd toolbar btn btn-info" Style="margin-top: -9px;"> <i class="icon-search"></i>&nbsp;Tìm kiếm</asp:LinkButton>
                                            </div>
                                            <div style="margin-top: 10px;">
                                                <asp:DropDownList ID="ddlcategories" CssClass="txt" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlcategories_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" CssClass="txt" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                                                    <asp:ListItem Value="-1" Selected="True">Tất cả các mục</asp:ListItem>
                                                    <asp:ListItem Value="1">Hiển thị</asp:ListItem>
                                                    <asp:ListItem Value="0">Ẩn</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlorderby" runat="server" AutoPostBack="true" CssClass="txt" OnSelectedIndexChanged="ddlorderby_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="Create_Date">S.xếp:Ngày cập nhật</asp:ListItem>
                                                    <asp:ListItem Value="Modified_Date">S.xếp:Ngày hết hạn</asp:ListItem>
                                                    <asp:ListItem Value="Views">S.xếp:Lần xem</asp:ListItem>
                                                    <asp:ListItem Value="Title">S.xếp:Tiêu đề (ABC)</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlordertype" runat="server" AutoPostBack="True" CssClass="txt" OnSelectedIndexChanged="ddlordertype_SelectedIndexChanged">
                                                    <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                                                    <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div class="dataTables_filter" id="sample_1_filter">
                                        <asp:LinkButton ID="bthienthi" runat="server" OnClick="bthienthi_Click" CssClass="vadd toolbar btn btn-info"> <i class=" icon-folder-close"></i>&nbsp;Hiện thị</asp:LinkButton>
                                        <asp:LinkButton ID="btthemmoi" runat="server" Text="Thêm mới" OnClick="btthemmoi_Click" CssClass="vadd toolbar btn btn-info"><i class="icon-plus"></i>&nbsp;Thêm mới</asp:LinkButton>
                                        <asp:LinkButton ID="btDeleteall" ToolTip="Xóa những lựa chọn !" OnClientClick=" return confirmDelete(this);" runat="server" OnClick="btDeleteall_Click" CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                            <div class="list_item">
                                <asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-striped table-bordered" id="sample_1">
                                            <tr>
                                                <th class="hidden-phone">
                                                    <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" />
                                                </th>
                                                <th class="hidden-phone">Hình ảnh
                                                </th>
                                                <th class="hidden-phone">Tên sản phẩm
                                                </th>
                                                <th class="hidden-phone">
                                                    Ngày tạo
                                                </th>
                                                <th class="hidden-phone">
                                                    Xem
                                                </th>
                                                <th class="hidden-phone">Làm mới
                                                </th>
                                                <th class="hidden-phone">Trang chủ
                                                </th>
                                                <th class="hidden-phone" colspan="3">
                                                   Chức năng
                                                </th>
                                              
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td style="text-align: center;">
                                                <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("id") %>' runat="server" />
                                            </td>
                                            <td style="text-align: center;" class="Imgsmall">
                                                 <a title="<%#Eval("Title")%>" target="_blank" href="/video/<%#Eval("TangName")%>.html">  <img src="https://i.ytimg.com/vi/<%#Eval("Youtube")%>/maxresdefault.jpg" style="border:1px solid #9EC3CB;" width="100px" height="65px"></a>
                                               <%-- <a title="<%#Eval("Title")%>" target="_blank" href="/video/<%#Eval("TangName")%>.html"><%#MoreAll.MoreImage.Image(Eval("ImagesSmall").ToString())%></a>--%>
                                            </td>
                                             <td>
                                                <asp:TextBox ID="txtTieude" Style="border: 1px solid #d7d7d7; border-radius: 3px; text-align: left; width: 90%; height: 40px" TextMode="MultiLine" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>' CssClass="txt_css" runat="server" OnTextChanged="txtTieude_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                            <td style="text-align: center;">
                                                <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Create_Date"))%>
                                                <div>
                                                    <asp:LinkButton ID="LinkButton5" CssClass="active action-link-button" CommandName="Chekdata" CommandArgument='<%#Eval("ID") %>' runat="server"> <%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></asp:LinkButton></div>
                                            </td>
                                            <td style="text-align: center;">
                                                <%#DataBinder.Eval(Container.DataItem,"Views")%>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton ID="LinkButton1" CssClass="active action-link-button" CommandName="updat_date" CommandArgument='<%#Eval("id") %>' runat="server"><i class=" icon-refresh"></i></asp:LinkButton>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton CommandName="ChangeNews" CssClass="active action-link-button" CommandArgument='<%#Eval("id")+"|"+Eval("News")%>' runat="server" ID="Linkbutton6"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "News").ToString())%></asp:LinkButton>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton CommandName="ChangeStatus" CssClass="active action-link-button" CommandArgument='<%#Eval("id")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" CssClass="active action-link-button" CommandName="EditDetail" CommandArgument='<%#Eval("id") %>' runat="server"><i class="icon-edit"></i></asp:LinkButton>
                                                 <asp:LinkButton CssClass="active action-link-button" ID="LinkButton3" OnLoad="Delete_Load" CommandName="Delete" CommandArgument='<%#Eval("id") %>' runat="server"><i class="icon-trash"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                       <asp:Literal ID="lterr" runat="server"></asp:Literal>
                            </div>
                            <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                                <tr height="20">
                                    <td align="left">
                                        <asp:Literal ID="ltpage" runat="server"></asp:Literal>
                                        <div class="phantrang">
                                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks"
                                                BackNextLocation="Split" BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom"
                                                PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"
                                                IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText=""
                                                LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers" ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})"
                                                ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False"
                                                ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass=""
                                                ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                                            </cc1:CollectionPager>
                                        </div>
                                    </td>
                                </tr>
                                <tr bgcolor="whitesmoke" height="25">
                                    <td style="height: 25px">
                                        <b>
                                            <asp:LinkButton ID="lnkcreatenew" runat="server" Font-Bold="True" OnClick="lnkcreatenew_Click"
                                                CssClass="active action-link-button">[Thêm mới]</asp:LinkButton></b>
                                    </td>
                                </tr>
                            </table>
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
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td></td>
                                        <td width="140px"></td>
                                        <td></td>
                                        <td>
                                            <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            Phân mục
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:DropDownList ID="ddlcategoriesdetail" runat="server" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            Tiêu đề
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtname" runat="server" CssClass="txt_css" Width="70%"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td></td>
                                        <td>
                                           Rewrite Url
                                        </td>
                                        <td></td>
                                        <td>
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                          <asp:TextBox ID="txtRewriteUrl" runat="server" CssClass="txt_css" Width="700px"></asp:TextBox>
                                                            <asp:Button ID="btkiemtra" style="margin-top: -11px;"  runat="server" Text="Kiểm tra" CssClass="btn btn-primary" OnClick="btkiemtra_Click" />
                                                         <br />
                                                        <asp:Label ID="ltshowurl" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                     <tr style=" display:none">
                                        <td></td>
                                        <td>
                                            Tiêu đề Alt ảnh
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtAlt" runat="server" CssClass="txt_css" Width="70%"></asp:TextBox>
                                        </td>
                                    </tr>
                                  <tr style=" display:none">
                                        <td></td>
                                        <td>Hình ảnh
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>
                                            <input id="btnImage" type="button" onclick="BrowseServer('<%=txtImage.ClientID %>','News');" value="Chọn ảnh" class="toolbar btns btn-info" />
                                            <asp:Literal ID="ltimgs" runat="server"></asp:Literal>
                                            <asp:HiddenField ID="hdimgnews" runat="server" />
                                            <div style="font-size: 8pt; color: #ed1c24"><em>(Kích thước ảnh: Rộng: 500px X Cao: (Tùy ý) Hoặc 500px)</em></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top"></td>
                                        <td valign="top">Mã Youtobe
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtYoutube" runat="server" CssClass="txt_css" Width="30%" Height="20px"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td valign="top"></td>
                                        <td valign="top">Mô tả
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtdesc" runat="server" CssClass="txt_css" Width="99%" Height="70px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                           Mô tả
                                        </td>
                                        <td></td>
                                        <td>
                                            <CKEditor:CKEditorControl ID="txtcontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top"></td>
                                        <td valign="top">Tiêu đề từ khóa (Title)
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txttitleseo" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td valign="top"></td>
                                        <td valign="top">Từ khóa mô tả(Meta description) 
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtmeta" CssClass="txt_css" runat="server" Width="392px" Height="35px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top"></td>
                                        <td valign="top">Từ khóa trang web (Meta keyword)
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtKeywordS" CssClass="txt_css" runat="server" Width="459px" Height="43px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td style="height: 20px">&nbsp;
                                        </td>
                                        <td style="height: 20px">
                                            <strong>Thời gian</strong>
                                        </td>
                                        <td style="height: 20px">&nbsp;
                                        </td>
                                        <td style="height: 20px">
                                            <asp:CheckBox ID="chkdaytype" runat="server" Text="Hiển thị trong thời gian" AutoPostBack="True" OnCheckedChanged="chkdaytype_CheckedChanged" />
                                            <asp:Panel ID="pnadddate" Visible="false" runat="server">
                                                &nbsp;Ngày đăng tin
                            <br />
                                                &nbsp;<asp:TextBox ID="txtfromday" runat="server" CssClass="txt" Height="22px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtfromday_CalendarExtender0" runat="server" TargetControlID="txtfromday"></cc1:CalendarExtender>
                                                &nbsp;tồn tại trong
                            <asp:TextBox ID="txtindays" runat="server" CssClass="txt" Width="48px">365</asp:TextBox>&nbsp;ngày
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                           Tùy chọn
                                        </td>
                                        <td></td>
                                        <td>
                                            <div>
                                                <asp:CheckBox ID="chkstatus" runat="server" Visible="True" CssClass="CsCheckBox" Text="Chọn: kích hoạt" /></div>
                                            <div>
                                                <asp:CheckBox ID="chknews" runat="server" CssClass="CsCheckBox" Text=" Trang chủ" /></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="btnsave" runat="server" OnClick="btnsave_Click"  CssClass="btn btn-primary"  style="background:#ed1c24"> <i class="icon-save"></i> Cập nhật </asp:LinkButton>
                                            <asp:LinkButton ID="btncancel" runat="server" OnClick="btncancel_Click" CssClass="btn btn-info"> <i class="icon-ban-circle icon-white"></i> Hủy</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:TextBox ID="txtauthor" CssClass="txt_css" runat="server" Width="16%" Visible="False"></asp:TextBox>
                            <asp:HiddenField ID="hdinsertupdate" runat="server" Value="insert" />
                            <asp:HiddenField ID="hdid" runat="server" />
                            <asp:HiddenField ID="hdivd" runat="server" />
                            <asp:HiddenField ID="hdiclip" runat="server" />
                            <asp:HiddenField ID="hd_id" runat="server" />
                            <asp:HiddenField ID="hdFileName" runat="server" />
                            <asp:HiddenField ID="hdimgsmall" runat="server" />
                            <asp:HiddenField ID="hdimg" runat="server" />
                            <asp:HiddenField ID="hdimgMax" runat="server" />
                            <asp:HiddenField ID="hdimgMaxEdit" runat="server" />
                            <asp:HiddenField ID="hdimgsmallEdit" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</div>
</div>
