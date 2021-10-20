<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Marketing.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Marketing.Marketing" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Danh sách đăng ký email khuyến mãi</span></li>
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
                            <h4><i class="icon-reorder"></i>Danh sách đăng ký email khuyến mãi</h4>
                        </div>
               <div class="widget-body">
                <div class="row-fluid">
                    <div class="span6">
                        <div id="sample_1_length" class="dataTables_length">
                            <asp:DropDownList ID="ddlstatus" AutoPostBack=true runat="server" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                            <asp:ListItem  Selected="True" Value="-1">Tất cả</asp:ListItem>
                            <asp:ListItem Value="0">Chưa kiểm duyệt</asp:ListItem>
                            <asp:ListItem Value="1">Đã kiểm duyệt &amp; trả lời</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div><div class="span6">
                        <div class="dataTables_filter" id="sample_1_filter">
                         <asp:Button ID="btndisplay" runat="server" OnClick="btndisplay_Click" Text="Hiển thị" CssClass="btn btn-primary" />
                            <asp:Button ID="btdelete" CssClass="btn btn-primary"  runat="server"  OnClientClick=" return confirmDelete(this);"  Text="Xóa" ToolTip="Xóa những lựa chọn !"  OnClick="btdelete_Click" />
                             <asp:Button ID="lbtExport" runat="server" OnClick="Export_Click" CssClass="vadd toolbar btn btn-info" Text="Export dữ liệu" ToolTip="Export dữ liệu" />
                                </div>
                    </div>
                </div>

<div  class="list_item">
<asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
	<ItemTemplate>
	 <tr class="odd gradeX">
          <td style="text-align: center;"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("IDMarketing") %>' runat="server" /></td>
             <td align=left style=" padding-left:10px; line-height:22px; color:#646465">
                Họ và tên:<span style="color:#444444; padding-left:27px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "Name")%></span><br />
                Địa chỉ:<span style="color:#444444; padding-left:40px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "Address")%></span><br />
                Điện thoại:<span style="color:#444444; padding-left:22px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "Phone")%></span><br />
                Email:<span style="color:#444444; padding-left:15px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "Email")%></span><br />
           </td>
           <td style="text-align: center;">
               <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem,"dcreatedate"))%>
           </td>
           <td style="text-align: center;">
               <asp:LinkButton CssClass="active action-link-button" CommandName="ChangeStatus"  CommandArgument='<%#Eval("IDMarketing")+"|"+Eval("istatus")%>' Runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "istatus").ToString())%></asp:LinkButton>
           </td>
          <td style="text-align: center;">
             <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "IDMarketing")%>' CommandName="detail"><img src="/Resources/admin/images/chitiet.png" border=0 /></asp:LinkButton>
            </td>
            <td style="text-align: center;">
               <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "IDMarketing")%>' CommandName="Email"><img src="/Resources/admin/images/email.png" border=0 /></asp:LinkButton>
           </td>
           <td style="text-align: center;">
              <asp:LinkButton  CssClass="active action-link-button" ID="LinkButton1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "IDMarketing")%>' CommandName='delete' OnLoad="Delete_Load"><i class="icon-trash"></i></asp:LinkButton>
           </td>
     </tr>
	</ItemTemplate>
	
	<HeaderTemplate>
		<table class="table table-striped table-bordered" id="sample_1">
			 <tr>
			     <th class="hidden-phone"><input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></th>
				 <th class="hidden-phone">Thông tin khách hàng</th>
				 <th class="hidden-phone">Ngày tạo</th>
				 <th class="hidden-phone">Trạng thái</th>
				 <th class="hidden-phone">Xem chi tiết</th>
				 <th class="hidden-phone">Email</th>
				 <th class="hidden-phone">Xóa</th>
			</tr>
	</HeaderTemplate>
<FooterTemplate>
</table>				
</FooterTemplate>
</asp:Repeater>
</div>
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
    <tr height="20">
        <td align=center>
            <div class="phantrang" style=" ">
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
</table>
</div></div></div></div>
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
<div style=" height:10px"></div>
<asp:Button ID="btnback" runat="server"  OnClick="btnback_Click" Text="Trở lại" CssClass="btn btn-primary" />
<asp:Button ID="btncheck" runat="server"  Text="Xác nhận kiểm tra" CssClass="btn btn-primary" OnClick="btncheck_Click" />
<asp:Button ID="btphanhoi" runat="server" Text="Phản hồi Email" CssClass="btn btn-primary" OnClick="btphanhoi_Click" />
<asp:Button ID="btxoa"  OnLoad="Delete_Load_Button" runat="server" CssClass="btn btn-primary" Text="Xóa" OnClick="btxoa_Click" />
        <div style=" line-height:33px; padding-top:10px">
            <span class="caption3">Họ và tên:</span> <asp:Literal ID="ltsender" runat="server"></asp:Literal><br />
            <span class="caption3">Địa chỉ:</span> <asp:Literal ID="ltaddress" runat="server"></asp:Literal><br />
            <span class="caption3">Điện thoại:</span> <asp:Literal ID="ltphone" runat="server"></asp:Literal><br />
            <span class="caption3">Email:</span> <asp:Literal ID="ltemail" runat="server"></asp:Literal><br />
        </div>
        <asp:HiddenField ID="hdid" runat="server" />
                </div>
 </div>
 </div>
       </div>
</asp:View>
    <asp:View ID="View3" runat="server">
        <div class="row-fluid">
                <div class="span12">
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Phản hồi liên hệ</h4>
                        </div>
               <div class="widget-body">
    <div class='frm-add'>
        <table border="0" cellpadding="0" cellspacing="0" width="99.5%">
            <tr>
                <td colspan="3">
                    <b>PHẢN HỒI LIÊN HỆ</b>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblmsg" runat="server" Font-Bold=true ForeColor=red></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;Gửi đến&nbsp;
                </td>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txtTo" CssClass="txt_css" runat="server" Width="421px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;Tiêu đề&nbsp;
                </td>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txttitle" CssClass="txt_css" runat="server" Width="421px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;Nội dung&nbsp;
                </td>
                <td>
                </td>
                <td>
                <CKEditor:CKEditorControl ID="txtContent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                    </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnreplyemail" runat="server"  Text="Trả lời" CssClass="btn btn-primary" OnClick="btnreplyemail_Click" />
                    &nbsp;<asp:Button ID="btcancelemail" runat="server" Text="Hủy bỏ" CssClass="btn btn-primary" OnClick="btcancelemail_Click" />
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
        background: #FFFFFF url('templates/sysstyles/popups/white/rounded-white.png' ) no-repeat scroll 0 0;
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
    </div>
