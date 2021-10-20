<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Control" %>
<%@ Register Src="~/cms/Admin/u_admin_hr.ascx" TagPrefix="uc1" TagName="u_admin_hr" %>
<%@ Register Src="~/cms/Admin/u_admin_ftr.ascx" TagPrefix="uc1" TagName="u_admin_ftr" %>
<%if (MoreAll.MoreAll.GetCookie("UName") != "" ){ %>
<uc1:u_admin_hr runat="server" ID="u_admin_hr" />
<%} %>
<asp:PlaceHolder ID="phcontrol" runat="server"></asp:PlaceHolder>
<%if (MoreAll.MoreAll.GetCookie("UName") != "" ){ %>
<uc1:u_admin_ftr runat="server" ID="u_admin_ftr" />
<%} %>