<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.login" %>
<style>
    body {
        background-color: #f1f1f1;
    }
</style>
<div id="g_subcontrols_ctl00_pnlogin">
    <div class="subdiv" id="subdivevent">
        <div style="height: 1px"></div>
        <div class="divcontrol">Control panel Login</div>
        <div class="div1">
            <p class="spancsu"></p>
            <p>
                 <asp:TextBox ID="txt_username" runat="server" class="inputcs" placeholder="Tên đăng nhập"></asp:TextBox>
            </p>
        </div>
        <div class="div1">
            <p class="spancsp"></p>
            <p>
                <asp:TextBox ID="txt_pwd" class="inputcs" placeholder="Mật khẩu" TextMode="Password" runat="server" ></asp:TextBox>
            </p>
        </div>
        <div class="div2">
            <p></p>
            <asp:Button ID="lnkdangnhap" runat="server" CssClass="buttoncs" OnClick="lnkdangnhap_Click" Text="ĐĂNG NHẬP" />
        </div>
        <div>
          <asp:Label ID="lt_msg" runat="server" ForeColor="red"></asp:Label>
        </div>
    </div>
</div>

               
           