<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Advertisings.Category" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pn_list" runat="server" Width="100%">
            <div style="margin-top: 10px;" class="frm_search">
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lbl_curpage" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
                            <asp:Literal ID="ltmsg" runat="server"></asp:Literal>&nbsp;
                        </td>
                        <td class="topcontent" style="width: 50%">
                            &nbsp;<asp:Button ID="btthemmoi" runat="server" ForeColor="Green" OnClick="btthemmoi_Click"
                                Text="Thêm mới" Width="87px" />
                            <asp:Button ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);"
                                Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="35px" ForeColor="Green" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="list_item">
                <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                    <ItemTemplate>
                        <tr style="background-color: #f1f1f1" height="40">
                            <td align="center">
                                <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                    ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                            </td>
                            <td>
                                <asp:LinkButton CommandName="ListChildren" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server" ID="Linkbutton2" NAME="Linkbutton2"><%#DataBinder.Eval(Container.DataItem,"Name")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton7" CommandName="Tang" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server">[Tăng]</asp:LinkButton>
                                <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                <asp:LinkButton ID="LinkButton8" CommandName="Giam" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server">[Giảm]</asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                    runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server">[Hiệu chỉnh]</asp:LinkButton>
                            </td>
                            <td align="center">
                                <div class="del">
                                    <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                        runat="server" ID="Linkbutton3" OnLoad="Delete_Load">[Xóa]</asp:LinkButton></div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr height="40">
                            <td align="center">
                                <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField
                                    ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                            </td>
                            <td>
                                <asp:LinkButton CommandName="ListChildren" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server" ID="Linkbutton2" NAME="Linkbutton2"><%#DataBinder.Eval(Container.DataItem,"Name")%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton7" CommandName="Tang" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server">[Tăng]</asp:LinkButton>
                                <%#DataBinder.Eval(Container.DataItem,"Orders")%>
                                <asp:LinkButton ID="LinkButton8" CommandName="Giam" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server">[Giảm]</asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton CommandName="ChangeStatus" CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>'
                                    runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" CommandName="EditDetail" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server">[Hiệu chỉnh]</asp:LinkButton>
                            </td>
                            <td align="center">
                                <div class="del">
                                    <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                        runat="server" ID="Linkbutton3" OnLoad="Delete_Load">[Xóa]</asp:LinkButton></div>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <HeaderTemplate>
                        <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                            <tr bgcolor="#C4C4C4" height="22">
                                <td class="header">
                                    <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" />
                                </td>
                                <td class="header">
                                    Tiêu đề
                                </td>
                              
                                <td class="header">
                                    Thứ tự
                                </td>
                                <td class="header">
                                   Trạng thái
                                </td>
                                <td class="header">
                                    Hiệu chỉnh
                                </td>
                                <td class="header">
                                    Xóa
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                <tr height="20">
                    <td>
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
            <div class='frm-add'>
                <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="right" width="175">
                        </td>
                        <td width="10">
                        </td>
                        <td>
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Tiêu đề
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_title" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right">
                           ID cần lấy
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtid" CssClass="txt_css" runat="server" Width="120px"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
<td align="right">
    Hình ảnh
</td>
<td></td>
<td>

<div>
    <div align=left style=" float:left; width:700px">--%>
                    <asp:RadioButton ID="rdFromComputer" Visible="false" runat="server" CssClass="txt_css2"
                        AutoPostBack="True" Checked="true" GroupName="FromType" OnCheckedChanged="rdFromComputer_CheckedChanged"
                        Text="Từ máy tính của bạn" ValidationGroup="downloadtype" />
                    <asp:RadioButton ID="rdFromLinks" Visible="false" runat="server" CssClass="txt_css2"
                        AutoPostBack="True" GroupName="FromType" OnCheckedChanged="rdFromLinks_CheckedChanged"
                        Text="Từ 1 liên kết" />&nbsp;&nbsp;
                    <asp:Button ID="btDeleteimages" Visible="false" CssClass="txt_css" runat="server"
                        Text="Delete" OnClick="btDeleteimages_Click" Width="75px" /><br />
                    <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                        <asp:View ID="vwFromComputer" runat="server">
                            <asp:FileUpload CssClass="txt_css" Visible="false" ID="flimage" runat="server" Width="323px" />
                        </asp:View>
                        <asp:View ID="vwFromLinks" runat="server">
                            <asp:TextBox CssClass="txt_css" Visible="false" ID="txtvimg" runat="server" Width="99%"></asp:TextBox><br />
                        </asp:View>
                    </asp:MultiView>
            </div>
            <%--   <div  style=" padding:0px 0px 0px 0px">--%>
            <asp:Literal ID="ltimg" Visible="false" runat="server"></asp:Literal>
            <%--    </div>
   </div>
</td>
</tr>
<tr>
    <td align="right">
        Nội dung</td>
    <td>
    </td>
    <td>--%>
            <asp:TextBox ID="txtNoiDung" Visible="false" CssClass="txt_css" runat="server" Width="50%"
                Height="100px" TextMode="MultiLine"></asp:TextBox>
            <%--       <span style="font-size: 8pt; color: #ed1c24"><em>(Nội dung miêu tả qua về nhóm sản phẩm.)</em></span>
    </td>
</tr>--%>
            <%--<tr>
    <td align="right">
        Tùy chọn</td>
    <td>
    </td>
    <td>
            --%>
            <asp:CheckBox ID="chknews" Visible="false" CssClass="txt_css2" runat="server" Text="Mới" />
            <asp:CheckBox ID="chkTrangChu" Visible="false" CssClass="txt_css2" runat="server"
                Text="Trang chủ" />
            <%--       <span style="font-size: 8pt; color: #ed1c24"><em>(Sẽ được hiển thị vào trong các mục định sẵn.)</em></span>
    </td>
</tr>--%>
            <tr>
                <td align="right">
                    Thứ tự
                </td>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txt_order" runat="server" CssClass="txt_css" Width="32px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Hiển thị
                </td>
                <td>
                </td>
                <td>
                    <asp:CheckBox ID="chck_Enable" CssClass="txt_css2" runat="server" Visible="True" />
            </tr>
            </table> </div>
            <div style="padding-left: 150px; padding-top: 10px;">
                <asp:Button ID="btn_InsertUpdate" runat="server" OnClick="btn_InsertUpdate_Click"
                    Text="Insert/Update" Width="120px" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                    Width="56px" />
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
    </ContentTemplate>
</asp:UpdatePanel>
