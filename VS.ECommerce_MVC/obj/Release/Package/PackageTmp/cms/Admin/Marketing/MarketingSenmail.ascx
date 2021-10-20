<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MarketingSenmail.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Marketing.MarketingSenmail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<style type="text/css">
    .dialogContacts
    {
        height: 100%;
        left: 0;
        position: fixed;
        text-align: center;
        top: 0;
        width: 100%;
        z-index: 1000;
    }
    .dialogContacts .dlConent
    {
        position: relative;
        text-align: left;
        top: 50px;
        width: 550px;
        left: 0px;
    }
    .dialogContacts .dlConent .dlTitle
    {
        float: left;
        font-size: 13px;
        font-weight: bold;
        height: 16px;
        padding-left: 30px;
        position: relative;
        right: 10px;
        top: 25px;
    }
    .dialogContacts .dlConent .dlTitle .csstxtsearch
    {
    	background: #FFFFFF url('pic/web/icon/searchbg.gif' ) no-repeat scroll 0 0 ;
    	width:20px; 
    	height:20px;
    }
    .dialogContacts .dlConent .dltl, .dialogContacts .dlConent .dltr, .dialogContacts .dlConent .dltc, .dialogContacts .dlConent .dlcl, .dialogContacts .dlConent .dlcr, .dialogContacts .dlConent .dlbl, .dialogContacts .dlConent .dlbr, .dialogContacts .dlConent .dlbc
    {
        background: #FFFFFF url('../Resources/admin/images/rounded-white.png' ) no-repeat scroll 0 0;
        text-align: left;
    }
    .dialogContacts .dlConent .dltl
    {
        background-position: left top;
    }
    .dialogContacts .dlConent .dltr
    {
        background-position: right top;
    }
    .dialogContacts .dlConent .dltc
    {
        background-position: left -40px;
        background-repeat: repeat-x;
    }
    .dialogContacts .dlConent .dlcl
    {
        background-position: left -80px;
        background-repeat: repeat-y;
    }
    .dialogContacts .dlConent .dlcr
    {
        background-position: right -80px;
        background-repeat: repeat-y;
    }
    .dialogContacts .dlConent .dlcc
    {
        background-color: #FFFFFF;
        padding-top: 10px;
    }
    .dialogContacts .dlConent .dlcl .dlcr .dlcc .Content
    {
        height: 400px;
        padding-top:15px;
    }
    .dialogContacts .dlConent .dlcl .dlcr .dlcc .Content .ContactsList
    {
        background: silver;
        overflow: scroll;
        margin: 3px 0px 8px 0px;
        padding: 2px;
    }
    .dialogContacts .dlConent .dlbl
    {
        background-position: left -20px;
    }
    .dialogContacts .dlConent .dlbr
    {
        background-position: right -20px;
    }
    .dialogContacts .dlConent .dlbc
    {
        background-position: 0 -60px;
        background-repeat: repeat-x;
    }
    .dialogContacts .dlConent .dltl, .dialogContacts .dlConent .dlcl, .dialogContacts .dlConent .dlbl
    {
        padding-left: 20px;
    }
    .dialogContacts .dlConent .dltl, .dialogContacts .dlConent .dltr, .dialogContacts .dlConent .dltc, .dialogContacts .dlConent .dlbl, .dialogContacts .dlConent .dlbr, .dialogContacts .dlConent .dlbc
    {
        clear: both;
        height: 20px;
    }
    .dialogContacts .dlConent .dltr, .dialogContacts .dlConent .dlcr, .dialogContacts .dlConent .dlbr
    {
        padding-right: 20px;
    }
    .dialogContacts .dlConent .dialogClose
    {
        float: right;
        height: 8px;
        position: relative;
        right: 10px;
        top: 25px;
        width: 8px;
    }
    .dialogContacts .dlConent .dlcl .dlcr .dlcc .Content .ContactsList
    {
        margin: 3px 0px 8px 0px;
        overflow: scroll;
        padding: 2px;
        height: 370px;
    }
    .txt
    {
        overflow: auto;
        width: 99%;
    }
    .sendto a{color:Black;text-decoration:underline}
</style>


<div class="container-fluid">
            <div class="row-fluid">
               <div class="span12">
                   <ul class="breadcrumb">
                       <li><a href="admin.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span></li>
                       <li><a href="admin.aspx">Trang chủ</a> <span class="divider">&nbsp;</span></li>
                       <li><a href="#">Soạn thư điện tử </a><span class="divider-last">&nbsp;</span></li>
                   </ul>
               </div>
            </div>

    <div class="row-fluid">
    <div class="span12 sortable">
        <div class="widget">
            <div class="widget-title">
                <h4><i class="icon-reorder"></i>Soạn thư</h4>
                <span class="tools">
                    <a href="javascript:;" class="icon-chevron-down"></a>
                    <a href="javascript:;" class="icon-remove"></a>
                </span>
            </div>
            <div class="widget-body">
<div class='frm-add'>
<div style="padding:5px">
<table width=100%>
    <div align=left style=" padding-left:70px; padding-bottom:10px"><asp:Label ID="lblmsg" runat="server" Font-Bold=true ForeColor=red></asp:Label></div>
    <tr>
        <td colspan="2"></td>
        <td style="text-align: left">
            <asp:RadioButton ID="rdball" runat="server" Text="Gửi toàn bộ" GroupName="typesend"
                OnCheckedChanged="rdball_CheckedChanged" Checked='true' AutoPostBack="true" />
                &nbsp;&nbsp;
            <asp:RadioButton ID="rdbselect" runat="server" Text="Gửi theo lựa chọn" GroupName="typesend"
                OnCheckedChanged="rdbselect_CheckedChanged" AutoPostBack="true" />
        </td>   
    </tr>
    <asp:Panel ID="pnto" runat="server" Visible="false">
        <tr>
            <td colspan="2"></td>
            <td>Nhập địa chỉ (cách nhau bằng dấu phẩy).</td>
        </tr>
        <tr>
            <td valign="top" style="width:65px" class="sendto">
              <asp:LinkButton  ID="lnksendto" runat="server" OnClick="lnksendto_Click" ToolTip="Nhấn: Chọn danh sách email gửi đến">   <strong style=" color:Red"> Gửi đến</strong></asp:LinkButton>
              <span style="font-size: 8pt; color: #ed1c24"><em>(Nhấn:"Gửi đến" Chọn danh sách email )</em></span>
            </td>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtto" CssClass="txt_css" TextMode="MultiLine" runat="server" Height="50px" Width="97%"></asp:TextBox>
            </td>
        </tr>
    </asp:Panel>
    <tr>
        <td valign="top" style="width:65px">
            <strong>Tiêu đề</strong>
        </td>
        <td>
        </td>
        <td>
            <asp:TextBox ID="txtsubject" CssClass="txt_css" runat="server" Width="99%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" style="width:65px">
            <strong>Nội dung</strong> 
        </td>
        <td>
        </td>
        <td>            
        <CKEditor:CKEditorControl ID="txtcontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            <asp:Button ID="btnsend" runat="server" Text="Gửi thư" CssClass="btn btn-primary" OnClick="btnsend_Click" />&nbsp;
            <asp:Button ID="btnhuy" runat="server" Text="Hủy bỏ"  CssClass="btn btn-primary"/>
        </td>
    </tr>
</table>

<asp:Panel ID="pndl" runat="server" Visible="false">
    <div class="dialogContacts">
        <center>
            <div class="dlConent">
                <asp:LinkButton ID="lnkclose"  CssClass="btn btn-primary" runat="server" OnClick="lnkclose_Click">x</asp:LinkButton>
                <div class="dlTitle">
                    Danh sách hòm thư khách hàng <br /><asp:TextBox ID="txtsearch" runat="server" Width="220px"></asp:TextBox>
                    <asp:Button ID="lkbsearch" runat="server" onclick="lkbsearch_Click" CssClass="btn" Text="Search" />
                    </div>
                    
                <div style="clear: both">
                </div>               
                <div class="dltl">
                    <div class="dltr">
                        <div class="dltc">
                        </div>
                    </div>
                </div>
                <div class="dlcl">
                    <div class="dlcr">
                        <div class="dlcc">
                            <div class="Content">
                                <div class="ContactsList">
                                    <asp:Literal ID="ltpage1" runat="server"></asp:Literal>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" class="all" width="100%">
                                                <tr bgcolor="#f1f1f1" height="22">
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <b>
                                                            Email</b>
                                                    </td>
                                                    <td>
                                                        <b>
                                                            Họ và tên</b>
                                                    </td>
                                                    <td>
                                                        <b>
                                                            Phone</b>
                                                    </td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr height="25">
                                                <td>
                                                    <input type="checkbox" name="chk" value="<%#Eval("Email") %>" />
                                                </td>
                                                <td>
                                                    <%#Eval("Email") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Name") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Phone") %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <br />
                                </div>
                                <asp:Button ID="btnadd"  runat="server" Text="Thêm vào danh sách" CssClass="btn btn-primary" OnClick="btnadd_Click"/>&nbsp;
                                <asp:Button ID="btnhuy2"  runat="server" Text="Hủy bỏ" OnClick="btnhuy2_Click" CssClass="btn btn-primary"/>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="dlbl">
                    <div class="dlbr">
                        <div class="dlbc">
                        </div>
                    </div>
                </div>
            </div>
        </center>
    </div>
</asp:Panel>
</div>
 </div>
                </div>
   </div>
         </div>
         </div>
     </div>