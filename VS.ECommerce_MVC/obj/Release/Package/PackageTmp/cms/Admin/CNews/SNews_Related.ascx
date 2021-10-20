<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SNews_Related.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.M_News.News_Related" %>
<div style="padding: 3px 5px 3p 5px">
        <asp:HiddenField ID="hditemiid" Value="-1" runat="server" />
        <asp:HiddenField ID="hdinid" Value="-1" runat="server" />
        <asp:HiddenField ID="hdinsertupdate" Value="insert" runat="server" />
        <table style="border-collapse: collapse" cellpadding="0"  width="100%" border="0">
            <tr class="bgTitle" height="25">
                <td>
                    QUẢN LÝ MỤC LIÊN QUAN
                </td>
            </tr>
        </table>
        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
            <tr style="vertical-align:top">
                <td>
                    <asp:Repeater ID="rp_itemslist" runat="server" OnItemCommand="rp_itemslist_ItemCommand">
                        <ItemTemplate>
                            <tr height="35" bgcolor="GhostWhite">
                                <td><b><%#Eval("Title")%></b>
                                    <br>
                                </td>
                                <td></td>
                                <td align="center">
                                </td>
                                <td align="right">
                                    <asp:LinkButton CommandName="Delete" CommandArgument='<%#Eval("inid")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load"><img src='/Uploads/pic/web/icon/trash_can.png' border="0" alt="Delete this"></asp:LinkButton>
                                </td>
                                <td>
                                    
                                </td>
                            </tr>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <table class="all" border="0" width="100%" cellpadding="0" style="border-collapse: collapse"
                                id="table1">
                                <tr bgcolor="#C4C4C4" height="22">
                                    <td>
                                        <font color="black"><b>Tiêu đề</b></font>
                                    </td>
                                    <td width="5" align="center"></td>
                                    <td width="5" align="center">
                                    </td>
                                    <td width="45" align="right">
                                        <font color="black"><b></b></font>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td style="width:10px"></td>
                <td style="width:450px">THÊM MỤC LIÊN QUAN<br />
                    <asp:TextBox ID="txtkeyword" runat="server" ></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server"  Text="Tìm kiếm"  onclick="btnsearch_Click" />
                    <br />
                    <asp:Repeater ID="rp_searcheditems" runat="server" 
                        onitemcommand="rp_searcheditems_ItemCommand" >

                        <ItemTemplate>
                            <tr height="35" bgcolor="GhostWhite">
                                <td><b><%#Eval("Title")%></b>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="LinkButton6" CommandName="addtorelateditems" CommandArgument='<%#Eval("inid")%>' runat="server"><img src='/Uploads/pic/web/icon/add.png' border="0" alt="Add to Related Items"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <table class="all" border="0" width="100%" cellpadding="0" style="border-collapse: collapse"
                                id="table4">
                                <tr bgcolor="#C4C4C4" height="22">
                                    <td>
                                        <font color="black"><b>Tiêu đề</b></font>
                                    </td>
                                    <td style="width:45px">
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
