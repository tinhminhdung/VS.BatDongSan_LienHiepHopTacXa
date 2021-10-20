<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GioiThieu.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.GioiThieu.GioiThieu" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>

<div id="cph_Main_ContentPane">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Danh sách giới thiệu</span></li>
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
                            <h4><i class="icon-reorder"></i>Danh sách thông tin</h4>
                        </div>
               <div class="widget-body">
                <div class="row-fluid">
                    <div class="span9">
                        <div id="sample_1_length" class="dataTables_length">
                         <div class="frm_search">
                    <div>
                        <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
                        <asp:LinkButton ID="lnksearch" runat="server" OnClick="lnksearch_Click" CssClass="vadd toolbar btn btn-info" style="margin-top: -9px;"> <i class="icon-search"></i>&nbsp;Tìm kiếm</asp:LinkButton>
                    </div>
                    <div style="margin-top: 10px;">
                        <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" CssClass="txt"  OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Selected="True">Tất cả các mục</asp:ListItem>
                            <asp:ListItem Value="1">Hiển thị</asp:ListItem>
                            <asp:ListItem Value="0">Ẩn</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlorderby" runat="server" AutoPostBack="true" CssClass="txt"  OnSelectedIndexChanged="ddlorderby_SelectedIndexChanged">
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
                    </div><div class="span3">
                        <div class="dataTables_filter" id="sample_1_filter">
                       <asp:LinkButton ID="bthienthi" runat="server"  OnClick="bthienthi_Click" CssClass="vadd toolbar btn btn-info"> <i class=" icon-folder-close"></i>&nbsp;Hiện thị</asp:LinkButton>
                        <asp:LinkButton ID="btthemmoi" runat="server" Text="Thêm mới" OnClick="btthemmoi_Click"  CssClass="vadd toolbar btn btn-info"><i class="icon-plus"></i>&nbsp;Thêm mới</asp:LinkButton>
                        <asp:LinkButton ID="btDeleteall" ToolTip="Xóa những lựa chọn !" OnClientClick=" return confirmDelete(this);" runat="server" OnClick="btDeleteall_Click"  CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton>

                        </div>
                    </div>
                </div>
                <asp:Label ID="lterr" ForeColor="red" Font-Bold="true" runat="server"></asp:Label>
                <div class="list_item">
                    <asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
                        <ItemTemplate>
                            <tr class="odd gradeX">
                                <td class="hidden-phone">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                        ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                </td>
                                  <td class="hidden-phone">
                                    <%#MoreAll.MoreImage.Image(Eval("Images").ToString())%>
                                </td>
                                <td>
                                    <b>
                                        <%#Eval("Title")%></b>
                                </td>
                                <td class="hidden-phone">
                                    <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date"))%>
                                    <div>
                                        <asp:LinkButton ID="LinkButton5" CssClass="lnk" CommandName="Chekdata" CommandArgument='<%#Eval("ID") %>'
                                            runat="server"> <%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></asp:LinkButton></div>
                                </td>
                                <td class="hidden-phone">
                                    <%#DataBinder.Eval(Container.DataItem,"Views")%>
                                </td>
                                <td class="hidden-phone">
                                    <asp:LinkButton ID="LinkButton1" CssClass="active action-link-button" CommandName="updat_date" CommandArgument='<%#Eval("ID") %>'
                                        runat="server"><i class=" icon-refresh"></i></asp:LinkButton>
                                </td>
                                <td class="hidden-phone">
                                    <asp:LinkButton CommandName="ChangeStatus" CssClass="active action-link-button" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                        runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                </td>
                                <td class="hidden-phone">
                                    <asp:LinkButton ID="LinkButton2" CssClass="active action-link-button" CommandName="EditDetail" CommandArgument='<%#Eval("ID") %>'
                                        runat="server"><i class="icon-edit"></i></asp:LinkButton>
                                </td>
                                <td class="hidden-phone">
                                    <div class="del">
                                        <asp:LinkButton  CssClass="active action-link-button" ID="LinkButton3" OnLoad="Delete_Load" CommandName="Delete"
                                            CommandArgument='<%#Eval("ID") %>' runat="server"><i class="icon-trash"></i></asp:LinkButton></div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <HeaderTemplate>
                           <table class="table table-striped table-bordered" id="sample_1">
                                <tr>
                                     <th class="hidden-phone">
                                        <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" />
                                    </th>
                                     <th class="hidden-phone">
                                        Hình ảnh
                                    </th>
                                     <th class="hidden-phone">
                                        Tiêu đề
                                    </th>
                                     <th class="hidden-phone">
                                        Ngày tạo
                                    </th>
                                     <th class="hidden-phone">
                                        Xem
                                    </th>
                                     <th class="hidden-phone">
                                        Làm mới
                                    </th>
                                     <th class="hidden-phone">
                                        Hiển thị
                                    </th>
                                     <th class="hidden-phone">
                                        Hiệu chỉnh
                                    </th>
                                     <th class="hidden-phone">
                                        Xóa
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <FooterTemplate>
                         </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <tr height="20">
                        <td class="hidden-phone">
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
                                <asp:LinkButton ID="lnkcreatenew" runat="server" CssClass="lnk" Font-Bold="True"
                                    OnClick="lnkcreatenew_Click">[Thêm mới]</asp:LinkButton></b>
                        </td>
                    </tr>
                </table>
                   </div></div></div>
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
                            <td>
                            </td>
                            <td style="width: 110px">
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                Tiêu đề
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txtname" runat="server" CssClass="txt_css" Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                                      
                        <tr>
                            <td valign="top">
                            </td>
                            <td valign="top">
                             Ảnh
                            </td>
                            <td>
                            </td>
                            <td>
                            <asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>
                                                <input id="btnImage" type="button" onclick="BrowseServer('<%=txtImage.ClientID %>','News');" value="Chọn ảnh" class="toolbar btns btn-info" />
                                                <asp:Literal ID="ltimg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                 
                   <tr>
                            <td valign="top">
                            </td>
                            <td valign="top">
                               Mô tả
                            </td>
                            <td>
                            </td>
                            <td>
                               <CKEditor:CKEditorControl ID="txtdesc" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                            </td>
                            <td valign="top">
                                Nội dung
                            </td>
                            <td>
                            </td>
                            <td>
                                <CKEditor:CKEditorControl ID="txtcontent" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <asp:TextBox Visible="false" ID="txttags" runat="server" CssClass="txt_css" Width="99%"></asp:TextBox>
                        <tr style=" display:none">
                            <td>
                            </td>
                            <td>
                                Thời gian
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkdaytype" runat="server" Text="Hiển thị trong thời gian" AutoPostBack="True"
                                            OnCheckedChanged="chkdaytype_CheckedChanged" />
                                        <asp:Panel ID="pnadddate" Visible="false" runat="server">
                                            Ngày đăng tin
                                            <br />
                                            <asp:TextBox ID="txtfromday" runat="server" CssClass="txt" Height="22px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtfromday_CalendarExtender0" runat="server" TargetControlID="txtfromday">
                                            </cc1:CalendarExtender>
                                            tồn tại trong
                                            <asp:TextBox ID="txtindays" runat="server" CssClass="txt" Width="48px">365</asp:TextBox>
                                            ngày</asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                          <tr>
                            <td valign="top">
                            </td>
                            <td valign="top">
                                Tính năng seo
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                            
                  

                             <tr>
                            <td valign="top">
                            </td>
                            <td valign="top">
                               Tiêu đề từ khóa (Title)
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txttitleseo" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td valign="top">
                            </td>
                            <td valign="top">
                              Từ khóa mô tả(Meta description) 
                            </td>
                            <td>
                            </td>
                            <td>
                               <asp:TextBox ID="txtmeta" CssClass="txt_css" runat="server" Width="392px"  Height="35px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td valign="top">
                            </td>
                            <td valign="top">
                                Từ khóa trang web (Meta keyword)
                            </td>
                            <td>
                            </td>
                            <td>
                             <asp:TextBox ID="txtKeywordS" CssClass="txt_css" runat="server" Width="459px"   Height="43px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                               Tùy chọn
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkstatus" runat="server" Visible="True" CssClass="CsCheckBox" Text="Chọn: kích hoạt">
                                </asp:CheckBox>
                                <asp:CheckBox ID="chknews" Visible=false runat="server" CssClass="CsCheckBox" Text="Trang chủ - giới thiệu" />
                            </td>
                        </tr>
                         <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
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
                <asp:HiddenField ID="hdimg" runat="server" />
                <asp:HiddenField ID="hdcid" runat="server" />
                <asp:HiddenField ID="hdino" runat="server" />
                <asp:HiddenField ID="hd_id" runat="server" />
                <asp:HiddenField ID="hdFileName" runat="server" />
                </div> </div> </div> </div>
            </asp:View>
        </asp:MultiView>
    </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnsave" />
    </Triggers>
</asp:UpdatePanel>
