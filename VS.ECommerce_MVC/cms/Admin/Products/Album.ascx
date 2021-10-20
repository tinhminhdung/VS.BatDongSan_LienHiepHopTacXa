<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Album.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Products.Album" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
<link href="Resources/admin/css/Css/Manager.css" rel="stylesheet" type="text/css" />

<div  class="list_item">
<asp:Repeater ID="rpitems" runat="server">
    <ITEMTEMPLATE>
 	<tr style="background-color:#f1f1f1"  height="40">
           <td>
              <%#MoreAll.MoreImage.Image(Eval("ImagesSmall").ToString())%>
           </td>
           <td>
               <b><%#Eval("Name")%></b>
           </td>
            <td>
                <%#AllQuery.MorePro.FormatMoney(Eval("Price").ToString())%>
           </td>
           <td align="center">
               <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date"))%>
           </td>
           <td align="center">
               <%#DataBinder.Eval(Container.DataItem,"Views")%>
           </td>
           <td align="center">
             <%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
           </td>
     </tr>
    </ITEMTEMPLATE>
    <HeaderTemplate>
     <table width="100%" cellpadding="10" cellspacing="0">
    <tr style="background-color:#d5d1d1"  height="40">
           <td class="header"  align=left>Hình ảnh</td>
           <td class="header">Tên sản phẩm</td>
            <td class="header">Giá</td>
           <td class="header">Ngày tạo</td>
           <td class="header">Xem</td>
           <td class="header">Hiển thị</td>
     </tr>
     </HeaderTemplate>
    <FooterTemplate>
    </TABLE>
    </FooterTemplate> 
    </asp:Repeater>
</div>
<asp:panel id="pn_list" runat="server" Width="100%">
<div style="margin-top:10px;"  class="frm_search">
<span CssClass="txt_css" >Chọn xóa tất cả  <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this,1);"  type="checkbox" style="width: 23px" /></span>  
 <asp:Button ID="btxoa"  runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);"  Text="Xóa" ToolTip="Xóa những lựa chọn !" Width="40px" />
<input id="cmd_New" type="button" value="Thêm"  class="Button" style="height:20px; width:65px;" onclick="javascript:$find('<%= mdpePopup.ClientID %>').show();" />
</div>
<div class="list-pic" align=center>
    <asp:Repeater ID="rp_pagelist" OnItemCommand="rp_pagelist_ItemCommand" runat="server">
	<ItemTemplate>
          <div class="item-pic" align=center>
                      <div class="imgadmin"> <a href=#><%#MoreAll.MoreImage.Image(Eval("ImagesSmall").ToString())%></a></div>
                       <div class="title"><%#DataBinder.Eval(Container.DataItem,"Title")%></div>
                       <div style="border-top:solid 1px #d7d7d7">
                           <table  width=100%>
                               <tr>
                                <td style="width:10%;border:none;">
                                       <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("id") %>' runat="server" />
                                   </td>
                                   <td style="width:10%;border:none;">
                                        <asp:LinkButton CommandName="Delete"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>' Runat="server" ID="Linkbutton3" OnLoad="Delete_Load"><IMG SRC="Resources/admin/images/del.png" border=0 /></asp:LinkButton>
                                   </td>
                                   <td style="width:10%;border:none;">
                                        <asp:LinkButton ID="LinkButton1" CommandName="EditDetail"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>' Runat="server"><IMG SRC="Resources/admin/images/edit.png" border=0 /></asp:LinkButton>
                                   </td>
                                   <td style="width:10%;border:none;" >
                                        <asp:LinkButton CommandName="ChangeStatus"  CommandArgument='<%#Eval("id")+"|"+Eval("Status")%>' Runat="server" ID="Linkbutton4"><%#MoreAll.MoreAll.Enable(DataBinder.Eval(Container.DataItem, "Status").ToString())%></asp:LinkButton>
                                   </td>
                               </tr>
                           </table>
                       </div>
                  </div>
    </ItemTemplate>
</asp:Repeater>
     </div>
<table  style="BORDER-COLLAPSE: collapse" cellPadding="0" width="100%"	border="0">
    <tr height="20"><td></td></tr>
	<tr height="25" bgcolor="whitesmoke">
		<td>
       <%-- <asp:LinkButton ID="LinkButton5" Font-Bold=true  OnClick="LinkButton4_Click" Runat="server">[Thêm mới]</asp:LinkButton>--%>
          <a href="#" style=" color:#004400; font-weight:bold" onclick="javascript:$find('<%= mdpePopup.ClientID %>').show();">[Thêm mới]</a>
        </td>
	</tr>
</TABLE>
</asp:panel>
<asp:panel id="pn_insert" runat="server" Visible="False" Width="100%">
<div class='frm-add'>
<table  style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
<tr>
    <td align="right" width="175"></td>
    <td width="10"></td>
    <td>
        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    </td>
</tr>
<tr>
    <td align="right">Tiêu đề</td>
    <td></td>
    <td>
        <asp:TextBox ID="txt_title" CssClass="txt_css" runat="server" Width="320px"></asp:TextBox>
    </td>
</tr>
<tr>
<td align="right">
    Hình ảnh
</td>
<td></td>
<td>

<div>
    <div align=left style=" float:left; width:700px">
    <asp:RadioButton ID="rdFromComputer" runat="server" CssClass="txt_css2" AutoPostBack="True" Checked="true" GroupName="FromType" OnCheckedChanged="rdFromComputer_CheckedChanged" Text="Từ máy tính của bạn"  ValidationGroup="downloadtype" />
    <asp:RadioButton ID="rdFromLinks" runat="server" CssClass="txt_css2" AutoPostBack="True" GroupName="FromType"  OnCheckedChanged="rdFromLinks_CheckedChanged" Text="Từ 1 liên kết" />&nbsp;&nbsp;
    <asp:Button ID="btDeleteimages"   runat="server" Text="Delete" OnClick="btDeleteimages_Click" Width="75px" /><br />
    <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwFromComputer" runat="server">
            <asp:FileUpload CssClass="txt_css" ID="flimage"  runat="server" Width="323px" />
          </asp:View>
        <asp:View ID="vwFromLinks" runat="server">
            <asp:TextBox CssClass="txt_css" ID="txtvimg"  runat="server" Width="99%"></asp:TextBox><br />
        </asp:View>
    </asp:MultiView>
</div>
    <div  style=" padding:0px 0px 0px 0px">
     <div  class="adaidien"><asp:Literal ID="ltimg" runat="server"></asp:Literal></div>
   </div>
   </div>
</td>
</tr>
<%-- <tr>
    <td align="right">
        Nội dung</td>
    <td>
    </td>
    <td>--%>
       <asp:TextBox ID="txtNoiDung"  Visible=false CssClass="txt_css" runat="server" Width="50%" Height="100px" TextMode="MultiLine"></asp:TextBox>
 <%--   </td>
</tr>--%>
<tr>
    <td align="right">
        Thứ tự
    </td>
    <td></td>
    <td>
        <asp:TextBox ID="txt_order" runat="server" CssClass="txt_css" Width="32px">1</asp:TextBox>
    </td>
</tr>
<tr>
    <td align="right">
        Hiển thị
    </td>
    <td></td>
    <td>
        <asp:CheckBox ID="chck_Enable" CssClass="txt_css2"  runat="server" Visible="True" />
</tr>
<tr>
    <td align="right"></td>
    <td></td>
    <td>
        <asp:Button ID="btn_InsertUpdate" runat="server" OnClick="btn_InsertUpdate_Click" Text="Insert/Update" Width="120px" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="56px" />
    </td>
</tr>
</table>
</div>
   <asp:Label ID="lbl_curpage" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
<asp:Literal ID="ltmsg" runat="server"></asp:Literal>
<asp:HiddenField ID="hdimgsmall" runat="server" />
<asp:HiddenField ID="hdimgMax" runat="server" />
<asp:HiddenField ID="hdimgMaxEdit" runat="server" />
<asp:HiddenField ID="hdimgsmallEdit" runat="server" />
<asp:HiddenField ID="hdFileName" runat="server" />
<asp:HiddenField ID="hdid" runat="server" />
</asp:panel>                                  
<INPUT id="hd_insertupdate" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1" runat="server">
<INPUT id="hd_id" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden2" runat="server">
<INPUT id="hd_page_edit_id" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden2"	runat="server">
<INPUT id="hd_imgpath" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden2" runat="server">
<INPUT id="hd_rootpic" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" runat="server">
<INPUT id="hd_par_id" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden2" runat="server">
<div id="VStootbalmain">
       <%-- <input id="cmd_New" type="button" value="Thêm"  class="Button" style="height:18px; width:65px;" onclick="javascript:$find('<%= mdpePopup.ClientID %>').show();" />--%>
        <asp:Button ID="btpu" runat="server"  Style="display: none" />   
        <asp:ModalPopupExtender ID="mdpePopup" BackgroundCssClass="hmweb_pu" runat="server" Enabled="True"   TargetControlID="btpu"   PopupDragHandleControlID="pnlPopup_Hand"  PopupControlID="pnlPopup"      Y="150"    CancelControlID="cmd_close" />
        <asp:Panel ID="pnlPopup" runat="server" CssClass="hmwebdiv" Width="532px"  Style="display: none" >
        <asp:Panel ID="pnlPopup_Hand"  runat="server" >           
        <div class="Pupup_Header"><div style="float:left;margin-top:4px; margin-left:5px;">Thêm mới ảnh</div>
        <div style="float:right; margin-top:6px; margin-right:10px; cursor:pointer;">
            <asp:Image ID="cmd_close" runat="server"  ImageUrl="/Resources/admin/images/Pupup_Button.png"/>
        </div></div>                          
           <div style="padding-top:25px; padding-left:25px;">             
       </div>   
            
      <div style="float:left; padding-left:25px;"><asp:Label ID="lb_Messages" runat="server" ForeColor="Red"></asp:Label></div>
     <div style="clear:left;padding-top:2px;">       
       <div style="float:left; padding-bottom:15px;margin-left: 8px;">           
       </div>
	  </div>   
      <div style="clear:left; margin-top:15px; width:532px; background-color:#f7f7f7; height:35px;border-top: 1px solid #dad7d7; padding-top:12px;">        
      <div style="padding-left:60px;float:left;  ">
    <div style="float:left;">
    <asp:CheckBox ID="ChAction" runat="server"  Font-Bold="True" ForeColor="DarkGreen"  TabIndex="20" Text="Kích hoạt "  TextAlign="Left" /></div>
    </div>
    <div style=" float:right; padding-right:21px; ">               
          <input id="cmd_cancel" type="button" value="Thoát" class="Button" style="height:24px; width:86px; color:Red;" onclick="javascript:$find('<%= mdpePopup.ClientID %>').hide();" />
      </div>
      </div>                                 
        </asp:Panel>
        
        </asp:Panel>
</div>

<asp:HiddenField ID="title_Desc" runat="server" />
<asp:HiddenField ID="hi_update" runat="server" />
<asp:HiddenField ID="hi_resources" runat="server" />   
<asp:HiddenField ID="hi_Original" runat="server" />
