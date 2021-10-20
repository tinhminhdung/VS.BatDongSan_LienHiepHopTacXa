<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DMAdvertising.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Advertisings.DMAdvertising" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Danh sách quảng cáo theo nhóm</span></li>
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
                                    <h4><i class="icon-reorder"></i>Danh sách quảng cáo theo nhóm</h4>
                                </div>
                                <div class="widget-body">
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <div id="sample_1_length" class="dataTables_length">
                                                <asp:DropDownList ID="ddlvalue" runat="server" AutoPostBack="true" Style="width: auto" OnSelectedIndexChanged="ddlvalue_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="span6">
                                            <div class="dataTables_filter" id="sample_1_filter">
                                                <asp:Label ID="ltthongbao" runat="server"></asp:Label>
                                                <asp:Button ID="bthienthi" runat="server" Text="Hiển thị" OnClick="bthienthi_Click" CssClass="btn btn-primary" />
                                                <asp:Button ID="btinsert" runat="server" Text="Thêm mới" OnClick="btinsert_Click" CssClass="btn btn-primary" />
                                                <asp:Button ID="btdelete" runat="server" ToolTip="Xóa những lựa chọn !" CssClass="btn btn-primary" OnClientClick=" return confirmDelete(this);" Text="Xóa" OnClick="btdelete_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="list_item">
                                        <asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td style="text-align: center;">
                                                        <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("images") %>' runat="server" />
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <a href="<%#Eval("Path")%>" target="_blank"><%#Image(Eval("vimg").ToString(), Eval("Type").ToString())%></a>
                                                    </td>
                                                    <td>
                                                        <b><%#Eval("Name")%></b>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#Vitri(Eval("Text").ToString())%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:TextBox ID="TextBox1" Text='<%#DataBinder.Eval(Container.DataItem, "Width")%>' onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')" CssClass="txt_cssb" Width="30px" runat="server" OnTextChanged="txtxWidth_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:TextBox ID="TextBox2" Text='<%#DataBinder.Eval(Container.DataItem, "Height")%>' onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')" CssClass="txt_cssb" Width="30px" runat="server" OnTextChanged="txtxHeight_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <a href="<%#Eval("Path")%>" target="_blank"><%#Eval("Path")%></a>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"Create_Date"))%>
                                                        <div><%#MoreAll.MoreAll.Enable_Date(DataBinder.Eval(Container.DataItem, "Chekdata").ToString())%></div>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#DataBinder.Eval(Container.DataItem,"Views")%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:LinkButton CssClass="active action-link-button" CommandName="ChangeStatus" CommandArgument='<%#Eval("images")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton3"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                                        <asp:LinkButton CssClass="active action-link-button" ID="LinkButton1" runat="server" CommandArgument='<%#Eval("images")%>' CommandName="update"><i class="icon-edit"></i></asp:LinkButton>
                                                        <asp:LinkButton CssClass="active action-link-button" ID="LinkButton2" runat="server" CommandArgument='<%#Eval("images")%>' CommandName="delete" OnLoad="Delete_Load"><i class="icon-trash"></i></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <table class="table table-striped table-bordered" id="sample_1">
                                                    <tr>
                                                        <th class="hidden-phone"><input id="Checkbox1" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" /></th>
                                                        <th class="hidden-phone">Hình ảnh</th>
                                                        <th class="hidden-phone">Tiêu đề</th>
                                                        <th class="hidden-phone">Vị trí</th>
                                                        <th class="hidden-phone">Độ Rộng</th>
                                                        <th class="hidden-phone">Độ cao</th>
                                                        <th class="hidden-phone">Liên kết</th>
                                                        <th class="hidden-phone">Ngày tạo</th>
                                                        <th class="hidden-phone">Xem</th>
                                                        <th class="hidden-phone">Thứ tự</th>
                                                        <th class="hidden-phone" colspan="3">Chức năng</th>
                                                    </tr>
                                            </HeaderTemplate>
                                            <FooterTemplate>
                                                </table>				
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                                        <tr align="center">
                                            <td>
                                                <div class="phantrang">
                                                    <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                                                        BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
                                                        ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                                                    </cc1:CollectionPager>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr bgcolor="whitesmoke" height="25">
                                            <td>
                                                <b>
                                                    <asp:LinkButton ID="linkcreatenew" runat="server" CssClass="underline" Font-Bold="True" OnClick="linkcreatenew_Click">[Thêm mới]</asp:LinkButton>
                                                </b>
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
                                        <div class='frm-add'>
                                            <table id="tblinput" border="0" cellpadding="1" cellspacing="0" class="all" width="100%">
                                                <tr>
                                                    <td></td>
                                                    <td width="97"></td>
                                                    <td width="5"></td>
                                                    <td>
                                                        <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td align="left"></td>
                                                    <td align="left">Loại quảng cáo 
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddltype" AutoPostBack="true" runat="server" CssClass="txt_adn" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                                            <asp:ListItem Value="1" Selected="True">Image</asp:ListItem>
                                                            <asp:ListItem Value="0">Text</asp:ListItem>
                                                            <asp:ListItem Value="2">Video Youtube</asp:ListItem>
                                                            <asp:ListItem Value="3">Flash</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"></td>
                                                    <td align="left">
                                                        Tiêu đề
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="txtname" runat="server" Width="420px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 100px"></td>
                                                    <td align="left">
                                                        Liên kết
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="txtSupport" runat="server" Width="420px">http://</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="PanelLink03" runat="server"></asp:Panel>
                                                <tr>
                                                    <td align="left" height="3" style="width: 100px"></td>
                                                    <td align="left" height="3">Mô tả
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="txtmota" runat="server" Width="446px" Height="101px" TextMode="MultiLine"></asp:TextBox><span style="font-size: 8pt; color: #ed1c24"><em></em></span></td>
                                                </tr>
                                                <asp:Panel ID="PanelLink01" runat="server">
                                                </asp:Panel>
                                                <tr>
                                                    <td align="left" style="width: 100px; height: 43px"></td>
                                                    <td align="left" style="height: 43px">
                                                       Hình ảnh
                                                    </td>
                                                    <td style="height: 43px"></td>
                                                    <td style="height: 43px">
                                                        <asp:RadioButton ID="rdFromComputer" runat="server" AutoPostBack="True" Checked="true" GroupName="FromType" OnCheckedChanged="rdFromComputer_CheckedChanged" Text="Từ máy tính của bạn" ValidationGroup="downloadtype" />
                                                        <asp:RadioButton ID="rdFromLinks" runat="server" AutoPostBack="True" GroupName="FromType" OnCheckedChanged="rdFromLinks_CheckedChanged" Text="Từ 1 liên kết trên Internet" />
                                                        &nbsp; &nbsp;&nbsp;<asp:LinkButton ID="lnkxoa" runat="server" OnClick="lnkxoa_Click" ForeColor="#FF0000">Xóa ảnh</asp:LinkButton><br />
                                                        <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                                                            <asp:View ID="vwFromComputer" runat="server">
                                                                <asp:FileUpload ID="flimage" runat="server" Width="323px" />
                                                                <br />
                                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Chỉ hỗ trợ định dạng *.jpg,*.gif,*.bmp,*.png,*.swf)</em></span><br />
                                                                <asp:Literal ID="ltimg" runat="server"></asp:Literal>
                                                            </asp:View>
                                                            <asp:View ID="vwFromLinks" runat="server">
                                                                <asp:TextBox ID="txtvimg" runat="server" Width="99%"></asp:TextBox><br />
                                                            </asp:View>
                                                        </asp:MultiView>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="PanelYoutube" Visible="false" runat="server">
                                                    <tr>
                                                        <td align="left" height="3" style="width: 100px"></td>
                                                        <td align="left" height="3">Link Youtube
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:TextBox ID="txtYoutube" runat="server" Width="446px" Height="101px" TextMode="MultiLine"></asp:TextBox><span style="font-size: 8pt; color: #ed1c24"><em></em></span></td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td align="left" style="width: 100px"></td>
                                                    <td align="left">Theo danh mục
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddllocal" runat="server" Style="width: auto">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 100px"></td>
                                                    <td align="left">Vị trí hiển thị
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlvitri" runat="server" Style="width: auto">
                                                            <asp:ListItem Value="1">Hiển thị theo danh sách</asp:ListItem>
                                                            <asp:ListItem Value="2">Hiển thị theo trang nhóm</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="PanelLink04" runat="server"></asp:Panel>
                                                <tr>
                                                    <td align="left" style="width: 100px"></td>
                                                    <td align="left">
                                                        Rộng
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="txtwidth" runat="server" Width="45px">1</asp:TextBox>pxCao<asp:TextBox ID="txtheight" runat="server" Width="45px">1</asp:TextBox>px (Default 0px) <span style="font-size: 8pt; color: #ed1c24"><em>((Để 0 px sẽ hiển thị kích thước thật của ảnh) - Sau khi chọn vị trí quảng cáo, Chép lại chiều cao và rộng vào ô)</em></span>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="PanelLink02" runat="server">
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td align="left">
                                                            Cách mở trang
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlopentype" runat="server">
                                                                <asp:ListItem Value="0">Mở trong trang hiện tại</asp:ListItem>
                                                                <asp:ListItem Value="1">Mở trang mới</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td align="left" height="3" style="width: 100px"></td>
                                                    <td align="left" height="3">
                                                        Thứ tự
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:TextBox ID="txtoder" runat="server" Width="60px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td align="left" style="width: 100px">&nbsp;
                                                    </td>
                                                    <td align="left">Thời gian&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:CheckBox ID="chkdaytype" runat="server" AutoPostBack="True" OnCheckedChanged="chkdaytype_CheckedChanged" Text="Hiển thị trong thời gian" />
                                                                &nbsp;
                                        <asp:Panel ID="pnadddate" runat="server" Visible="false">
                                            &nbsp;Ngày đăng tin
                                            <br />
                                            &nbsp;<asp:TextBox ID="txtfromday" runat="server" CssClass="txt" Height="22px"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtfromday_CalendarExtender0" runat="server" TargetControlID="txtfromday">
                                            </cc1:CalendarExtender>
                                            &nbsp;tồn tại trong
                                            <asp:TextBox ID="txtindays" runat="server" CssClass="txt" Width="48px">365</asp:TextBox>
                                            &nbsp;ngày
                                                                </asp:Panel>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 100px"></td>
                                                    <td align="left">
                                                       Trạng thái
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:CheckBox ID="chkstatus" runat="server" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px"></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" CssClass="btn btn-primary" Text="Lưu thông tin" />
                                                        <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" CssClass="btn btn-primary" Text="Hủy bỏ" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px"></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:HiddenField ID="hdinsertupdate" runat="server" Value="insert" />
                                                        <asp:HiddenField ID="hdid" runat="server" Value="-1" />
                                                        <asp:HiddenField ID="hdimages" runat="server" />
                                                        <asp:HiddenField ID="hhdimages" runat="server" />
                                                        <asp:HiddenField ID="hdFileName" runat="server" />
                                                        <asp:HiddenField ID="hdimg" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                </asp:View>
            </asp:MultiView>

        </div>
