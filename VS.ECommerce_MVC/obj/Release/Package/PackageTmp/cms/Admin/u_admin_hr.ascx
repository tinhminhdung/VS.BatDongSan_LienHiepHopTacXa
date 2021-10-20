<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="u_admin_hr.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.u_admin_hr" %>
<div id="wrapper">
    <div class="PageHeader">
        <div class="LogoHeader">
            <div class="linkroot">
                <a href="/admin.aspx" class="SiteName">ADMIN PAGE MANAGER</a>
            </div>
        </div>
        <div class="SystemMenu">
            <div>
                <ul class="sysMenu">
                    <li class="first"><a class="link-topmenu" href="/admin.aspx"><span class="SubMenuText"><i class="icon-home"></i>Trang chủ</span></a></li>
                    <li><a target="_blank" href="/" class="link-topmenu"><i class="icon-list-alt"></i>Xem website</a></li>
                    <asp:Repeater ID="rplangs" runat="server" OnItemCommand="rplangs_ItemCommand">
                        <ItemTemplate>
                            <li class="ngonngu" style=" display:none"><asp:LinkButton ID="LinkButton1" CssClass='<%#langcss(Eval("VLAN_ID").ToString()) %>' CommandName="change" CommandArgument='<%#Eval("VLAN_ID")%>' runat="server"> <img src="/Resources/languages/<%#Eval("VLAN_ID")%>.gif" /></asp:LinkButton></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li>Xin chào:<asp:Literal ID="ltadmin" runat="server"></asp:Literal></li>
                    <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkdangxuat_Click">[Thoát]</asp:LinkButton></li>
                </ul>
            </div>
        </div>
        <div class="langUse">
           
            <div class="lst">
            </div>
        </div>
    </div>
</div>





