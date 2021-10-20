<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="main.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.main" %>

<div id="container" class="row-fluid">
    <div class="boder_menu">
        <div id="menu">
            <ul>
                <li class="content1"  id="Quantri" runat="server" style=" display:none">
                    <a class="TopMenuItem" href="javascript:;">
                        <span class="MenuText"><i class="icon-cogs"></i>Quản trị</span>
                    </a>
                    <ul>
                        <li id="set" runat="server">
                            <a class="LinkButton" href="/admin.aspx?u=set"><span class="SubMenuText">Cấu hình</span></a>
                        </li>
                    </ul>
                </li>
               <%-- <li class="content2"  id="User" runat="server">
                    <a class="TopMenuItem" href="javascript:;">
                        <span class="MenuText"><i class="icon-user"></i>Thành viên</span>
                    </a>
                    <ul>
                       
                    </ul>
                </li>--%>
             <%--   <li id="AdminUser" runat="server">
                            <a class="LinkButton" href="/admin.aspx?u=AdminUser"><span class="SubMenuText">Thành viên quản trị</span></a>
                        </li>--%>
                        <li id="Thanhvien" runat="server">
                            <a class="LinkButton" href="/admin.aspx?u=Thanhvien"><span class="SubMenuText">Thành viên đăng ký</span></a>
                        </li>
                        <li id="CauHinh" runat="server">
                            <a class="LinkButton" href="/admin.aspx?u=CauHinh"><span class="SubMenuText">Cấu hình hoa hồng</span></a>
                        </li>
                          <li id="ChiHoaHong" runat="server">
                            <a class="LinkButton" href="/admin.aspx?u=ChiHoaHong"><span class="SubMenuText">Chia hoa hồng</span></a>
                        </li>
                            <li id="Danhsachloinhuan" runat="server">
                            <a class="LinkButton" href="/admin.aspx?u=Danhsachloinhuan"><span class="SubMenuText">Danh sách lợi nhuận</span></a>
                        </li>
                            <li id="Danhsachhoahong" runat="server">
                            <a class="LinkButton" href="/admin.aspx?u=Danhsachhoahong"><span class="SubMenuText">Danh sách hoa hồng</span></a>
                        </li>
                         <li id="LichSuThanhToan" runat="server">
                            <a class="LinkButton" href="/admin.aspx?u=LichSuThanhToan"><span class="SubMenuText">Danh sách thanh toán</span></a>
                        </li>
            </ul>
        </div>
    </div>
</div>
<div id="main">
    <div id="main-content">
        <div class="container-fluid">
            <div style="width: 100%; margin: 0 auto;">
                <asp:PlaceHolder ID="phcontrol" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
</div>

