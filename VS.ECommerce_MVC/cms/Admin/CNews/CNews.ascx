<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CNews.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.M_News.CNews" %>
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
                        <li class="Last"><span>Nhóm tin tức</span></li>
                    </ul>
                </div>
                <div style="clear: both;"></div>
                <div class="widget">
                    <asp:Panel ID="pn_list" runat="server" Width="100%">
                        <div class="widget-title">
                            <h4><i class="icon-list-alt"></i>&nbsp;Danh sách nhóm </h4>
                            <div class="ui-widget-content ui-corner-top ui-corner-bottom">
                                <div id="toolbox">
                                    <div class="toolbox-content" style="float: right;">
                                        <table class="toolbar">
                                            <tbody>
                                                <tr>

                                                    <td align="center">
                                                        <asp:LinkButton ID="btthemmoi" CssClass="vadd toolbar btn btn-info" OnClick="btthemmoi_Click" runat="server"><i class="icon-plus"></i>&nbsp; Thêm mới</asp:LinkButton></td>
                                                     <td align="center">
                                                        <asp:LinkButton ID="bntcapnhat" CssClass="vadd toolbar btn btn-info" style=" background:#ed1c24" OnClick="bntcapnhat_Click" runat="server"><i class="icon-save"></i> Cập nhật</asp:LinkButton>
                                                    </td>
                                                     <td align="center">
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
                                    <asp:DropDownList runat="server" ID="ddlPage" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                        <asp:ListItem Value="50" Selected="True">Chọn số Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="100">100 Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="200">200 Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="300">300 Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="400">400 Bản ghi / Trang</asp:ListItem>
                                        <asp:ListItem Value="1000">1000 Bản ghi / Trang</asp:ListItem>
                                    </asp:DropDownList>
                                          <div><asp:Label ID="ltmsg" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label></div>
                                      <div><asp:Label ID="lbl_curpage" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label></div>
                                    </div>
                                </div>
                            </div>

                            <div class="list_item">
                                <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand" OnItemDataBound="rp_pagelist_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                            </td>
                                           <%-- <td style="text-align: center;" class="Imgsmall">
                                               <%#MoreAll.MoreImage.Image_width_height(Eval("Images").ToString(),"40","40")%></a>
                                           </td>--%>
                                             <td>
                                                   <%#MoreAll.Other.Hienthihinhcay("", DataBinder.Eval(Container.DataItem, "Level").ToString())%>
                                                <asp:TextBox ID="txtTennhom" Style="border: 1px solid #d7d7d7; border-radius: 3px; text-align: left; width:60%; height:28px" TextMode="MultiLine" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>' CssClass="txt_css" Width="40px" runat="server"  AutoPostBack="true" OnTextChanged="txtTennhom_TextChanged"></asp:TextBox>
                                            </td>
                                            	 <td style="text-align: center;">
                                                <asp:DropDownList ID="ddlCap" Width="200" runat="server" OnSelectedIndexChanged="ddlCaps_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                <asp:HiddenField ID="hdStatus" Value='<%#Eval("Level") %>' runat="server" />
                                                <asp:Label ID="lblLevel" runat="server" Visible="false" Text='<%# Eval("Level").ToString() %>'></asp:Label>
                                                </td>
                                            <td style="text-align: center;">
                                                 <asp:TextBox ID="txtOrders" runat="server" Style="border: 1px solid #d7d7d7; border-radius: 3px; text-align: center" CssClass="txt_css" Width="40px" Text='<%#DataBinder.Eval(Container.DataItem, "Orders")%>' onkeyup="valid(this,'quotes')" onblur="valid(this,'quotes')"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                                            </td>
                                               <td style="text-align: center;">
                                                <a href="#" class="ChangeStatus active action-link-button" data-id="<%#(Eval("ID").ToString()) %>"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></a>
                                               <%-- <asp:LinkButton CssClass="active action-link-button" CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>' runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>--%>
                                            </td>
                                            <td style="text-align: center;">
                                                 <a href="#" class="ChangeHome active action-link-button" data-id="<%#(Eval("ID").ToString()) %>"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "page_Home").ToString())%></a>
                                               <%-- <asp:LinkButton CssClass="active action-link-button" CommandName="page_Home" CommandArgument='<%#Eval("ID")+"|"+Eval("page_Home")%>' runat="server" ID="Linkbutton6"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "page_Home").ToString())%></asp:LinkButton>--%>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton CssClass="active action-link-button" CommandName="ListChildren" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton2" NAME="Linkbutton2"><i class="icon-plus"></i></asp:LinkButton>
                                                <asp:LinkButton CssClass="active action-link-button" ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server"><i class="icon-edit"></i></asp:LinkButton>
                                                <asp:LinkButton CssClass="active action-link-button" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load"><i class="icon-trash"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                            <tbody>
                                                <tr class="trHeader" style="height: 25px">
                                                    <th style="width: 4%; font-weight: bold;" align="center" class="contentadmin" rowspan="">
                                                        <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" />
                                                    </th>
                                                    <th style="width: 4%; font-weight: bold; display: none;" class="contentadmin">No</th>
                                                   <%--  <th style="font-weight: bold">Ảnh</th>--%>
                                                     <th style="font-weight: bold; width:400px">Tên chuyên mục </th>
													<th style="font-weight: bold; width:100px">Cấp cha </th>
                                                    <th style="font-weight: bold">Thứ tự</th>
                                                    <th style="font-weight: bold">Trạng thái</th>
                                                    <th style="font-weight: bold">Trang chủ</th>
                                                    <th style="width: 140px; text-align: center; font-weight: bold;">Chức năng</th>
                                                </tr>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
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
                                        <asp:LinkButton ID="LinkButton5" Font-Bold="true" OnClick="LinkButton4_Click" runat="server">[Thêm mới]</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
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
                                <table class="Tables">
                                    <tr>
                                        <td align="left" width="200"></td>
                                        <td width="10"></td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Tên chuyên mục
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txt_title" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr> 
                                    <td align="left">Rewrite Url
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
                                          <td align="left"><span style=" color:#ff0000">Ảnh đại diện <br />khi chia sẻ nhóm lên facebook</span>
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
                                    <tr style=" display:none">
                                        <td align="left">Nội dung
                                        </td>
                                        <td></td>
                                        <td>
                                             <asp:TextBox ID="txtcontent" CssClass="txt_css" runat="server" Width="520px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Tiêu đề từ khóa (Title)
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txttitleseo" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Nội dung hiển thị trong (Description)
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtmeta" CssClass="txt_css" runat="server" Width="392px"
                                                Height="35px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Nội dung hiển thị trong (Keyword)
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtKeyword" CssClass="txt_css" runat="server" Width="459px"
                                                Height="43px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td align="left">Tùy chọn
                                        </td>
                                        <td></td>
                                        <td>

                                            <asp:CheckBox ID="chknews" Visible="false" CssClass="CsCheckBox" runat="server" Text="Mới" />
                                            <asp:CheckBox ID="chkTrangChu" CssClass="CsCheckBox" runat="server" Text="Trang chủ" />
                                            <span style="font-size: 8pt; color: #ed1c24"><em>(Sẽ được hiển thị vào trong các mục định sẵn.)</em></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            Thứ tự
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txt_order" runat="server" CssClass="txt_css" Width="32px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            Hiển thị
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:CheckBox ID="chck_Enable" CssClass="CsCheckBox" runat="server" Visible="True" />
                                    </tr>
                                    <tr>
                                        <td align="left"></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td align="left"></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td align="left"></td>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="btn_InsertUpdate" runat="server" OnClick="btn_InsertUpdate_Click" style="background:#ed1c24" CssClass="toolbar btn btn-info"> <i class="icon-save"></i> Cập nhật </asp:LinkButton>
                                            <asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="toolbar btn btn-info"> <i class="icon-chevron-left"></i>Hủy</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                            <asp:HiddenField ID="hdFileName" runat="server" />
                            <asp:HiddenField ID="hdid" runat="server" />
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
        <asp:PostBackTrigger ControlID="btn_InsertUpdate" />
    </Triggers>
</asp:UpdatePanel>
