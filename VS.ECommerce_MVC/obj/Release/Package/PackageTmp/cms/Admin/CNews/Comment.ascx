<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comment.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.CNews.Comment" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>      
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="vwlist" runat="server">
<div style="margin-top:10px;"  class="frm_search">
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
    <tr>
        <td>
    <asp:DropDownList ID="ddlstatus"  CssClass="txt"  AutoPostBack=true runat="server" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
    <asp:ListItem Value="-1">Tất cả</asp:ListItem>
    <asp:ListItem Value="0">Chưa duyệt</asp:ListItem>
    <asp:ListItem Value="1">Đ&#227; duyệt</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlorder"  AutoPostBack=true CssClass="txt" runat="server" OnSelectedIndexChanged="ddlorder_SelectedIndexChanged">
    <asp:ListItem Value="0">Mới &gt; Cũ</asp:ListItem>
    <asp:ListItem Value="1">Cũ &gt; Mới</asp:ListItem>
    </asp:DropDownList>&nbsp;
    <asp:TextBox ID="txtkey" runat="server" Width="151px"></asp:TextBox><asp:Button ID="btndisplay" runat="server" Text="Hiển thị" OnClick="btndisplay_Click" Width="61px" /><asp:Button ID="btncreatecomment" runat="server" Text="Tạo Comment" OnClick="btncreatecomment_Click" Width="144px" />
    <asp:Button ID="btxoa"   runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);"  Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="35px" />
        </td>
       <td class="topcontent" style="width:20%; ">
                <asp:Literal ID="ltpage1" runat="server"></asp:Literal>&nbsp;
        </td>
    </tr>
</table>
</div>
<div  class="list_item">
 <asp:Repeater ID="rpitems" runat="server" OnItemCommand="rpitems_ItemCommand">
	<ItemTemplate>
	<tr style="background-color:#f1f1f1"  height="40">
         <td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
           <td>
              <b><%#Eval("Title") %></b>
           </td>
           <td align="center">
              <%#Eval("Name") %> - <%#Eval("Email")%>   
           </td>
          <td align="center">
           <%#Eval("Create_Date")%> 
           </td>
           <td align="center">
           <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton5"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
           </td>
          <td align="center">
             <asp:LinkButton ID="LinkButton1" CommandName="view" CommandArgument='<%#Eval("ID")%>' runat=server>[Hiệu chỉnh]</asp:LinkButton>
            </td>
           <td align="center">
                <div class="del"><asp:LinkButton ID="LinkButton2" CommandName="delete" OnLoad="Delete_Load" CommandArgument='<%#Eval("ID")%>' runat=server>[Xóa]</asp:LinkButton></div>
           </td>
     </tr>
	</ItemTemplate>
	<AlternatingItemTemplate>
	<tr height="40">
		<td align="center"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
           <td>
              <b><%#Eval("Title")%></b>
           </td>
           <td align="center">
              <%#Eval("Name") %> - <%#Eval("Email")%>   
           </td>
            <td align="center">
           <%#Eval("Create_Date")%> 
           </td>
           <td align="center">
           <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("ID")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton5"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
           </td>
          <td align="center">
             <asp:LinkButton ID="LinkButton1" CommandName="view" CommandArgument='<%#Eval("ID")%>' runat=server>[Hiệu chỉnh]</asp:LinkButton>
            </td>
           <td align="center">
          <div class="del"> <asp:LinkButton ID="LinkButton2" CommandName="delete" OnLoad="Delete_Load" CommandArgument='<%#Eval("ID")%>' runat=server>[Xóa]</asp:LinkButton></div>
           </td>
     </tr>
	</AlternatingItemTemplate>
	<HeaderTemplate>
		<table  border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
			 <tr bgcolor="#C4C4C4" height="22">
			    <td class="header"><input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);" type="checkbox" /></td>
				<td class="header">Phản hồi - bình luận</td>
				<td class="header">Thông tin</td>
				<td class="header">Ngày gởi</td>
				<td class="header">Trạng thái</td>
				<td class="header">Hiệu chỉnh</td>
				<td class="header">Xóa</td>
			</tr>
	</HeaderTemplate>
<FooterTemplate>
</table>				
</FooterTemplate>
</asp:Repeater>
</div>
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
<tr height="20">
    <td align=right>
        <div class="phantrang" style=" ">
        <cc1:CollectionPager id="CollectionPager1" runat="server"  BackNextDisplay="HyperLinks" BackNextLocation="Split"
            BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"  IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers" 
            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
        </cc1:CollectionPager>
        </div>
    </td>
    </tr>
</table>
               </asp:View>
            <asp:View ID="vwdetail" runat="server">
                <div class='frm-add'>
                <table border="0" cellpadding="0" class="all" style="border-collapse: collapse"
                    width="100%">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                           <font color=red> <asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></td>
                    </tr>
                    <tr>
                        <td width="125">
                            &nbsp;Tên người viết</td>
                        <td width="15">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtname" runat="server" Width="398px"></asp:TextBox></td>
                    </tr>
                   <%-- <tr>
                        <td>
                            &nbsp;Địa chỉ</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtaddress" runat="server" Width="398px"></asp:TextBox></td>
                    </tr>--%>
                    <tr>
                        <td>
                            &nbsp;Email</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" Width="398px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;Tiêu đề</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txttitle" runat="server" Width="398px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;Nội dung phản hồi</td>
                        <td>
                            &nbsp;</td>
                        <td>
                        <CKEditor:CKEditorControl ID="txtcontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                    </tr>
                    <tr>
                        <td>
                            Trạng thái</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:CheckBox ID="chkstatus" runat="server" Checked="True" /></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnsend" runat="server" OnClick="btnsend_Click" Text="Lưu " />
                            <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" Text="Hủy bỏ" /></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HiddenField ID="hdid" runat="server" /><asp:HiddenField ID="hdinsertupdate" runat="server" />
                        </td>
                    </tr>
                </table>
                </div>
            </asp:View>
        </asp:MultiView>
      </ContentTemplate>
        </asp:UpdatePanel>