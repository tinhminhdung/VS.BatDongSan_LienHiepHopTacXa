<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cartdetail.aspx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Products.Cartdetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>CHI TIẾT ĐƠN HÀNG</title>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<link rel="stylesheet" type="text/css" href="../../../cs/common.css">
	   <link href="Resources/admin/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:569pt" width="758">
    <colgroup>
        <col style="mso-width-source:userset;mso-width-alt:1280;width:26pt" 
            width="35" />
        <col style="mso-width-source:userset;mso-width-alt:2304;width:47pt" 
            width="63" />
        <col style="mso-width-source:userset;mso-width-alt:10240;width:210pt" 
            width="280" />
        <col style="mso-width-source:userset;mso-width-alt:1938;width:40pt" 
            width="53" />
        <col style="mso-width-source:userset;mso-width-alt:1828;width:38pt" 
            width="50" />
        <col style="mso-width-source:userset;mso-width-alt:2377;width:49pt" 
            width="65" />
        <col style="mso-width-source:userset;mso-width-alt:2779;" />
        <col style="mso-width-source:userset;mso-width-alt:2633;width:54pt" 
            width="72" />
        <col style="width:48pt" width="64" />
    </colgroup>
    <tr height="23" style="mso-height-source:userset;height:17.25pt">
        <td align="left" height="23" style="height:17.25pt;width:26pt" valign="top" 
            width="35">
            <span style="mso-ignore:vglayout;
  position:absolute;z-index:1;margin-left:4px;margin-top:3px;width:255px;
  height:73px">
          <%=AllQuery.Banner.Banners() %>
                </span><![endif]><span 
                style="mso-ignore:vglayout2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="style1" height="23" width="35">
                    </td>
                </tr>
            </table>
            </span>
        </td>
        <td class="style2" width="63">
        </td>
        <td class="style3" width="280">
        </td>
        <td class="style4" colspan="5" rowspan="3">
           <%=Commond.Setting("FooTer")%></td>
        <td class="style5" width="64">
        </td>
    </tr>
    <tr height="23" style="mso-height-source:userset;height:17.25pt">
        <td class="style6" height="23">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="23" style="mso-height-source:userset;height:17.25pt">
        <td class="style6" height="23">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="18" style="mso-height-source:userset;height:13.5pt">
        <td class="style10" height="18">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style11" colspan="5">
        </td>
        <td class="style11">
        </td>
    </tr>
    <tr height="32" style="mso-height-source:userset;height:24.0pt">
        <td class="style12" colspan="8" height="32">
            BẢNG CHI TIẾT ĐƠN HÀNG</td>
        <td class="style11">
        </td>
    </tr>
    <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="3" height="26" style="mso-ignore: colspan">
            Khách hàng: <asp:Literal ID="ltname" runat="server"></asp:Literal></td>
        <td class="style8" colspan="6">
            Mã số: <asp:Literal ID="ltmaso" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="3" height="26" style="mso-ignore: colspan">
            Điện thoại liên hệ: <asp:Literal ID="ltsodienthoai" runat="server"></asp:Literal></td>
        <td class="style14" colspan="6">
            Email:  <asp:Literal ID="ltemail" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="9" height="26" style="mso-ignore: colspan">
            Địa chỉ: <asp:Literal ID="ltdiachi" runat="server"></asp:Literal></td>
    </tr>
    <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="3" height="26" style="mso-ignore: colspan">
            Hình thức thanh toán: <asp:Literal ID="ltthanhtoan" runat="server"></asp:Literal></td>
        <td class="style14" colspan="6">
            Phương thức giao hàng: 	<asp:Literal ID="lthinhthucgiaohang" runat="server"></asp:Literal>	
        </td>
    </tr>
     <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="3" height="26" style="mso-ignore: colspan">
           Ghi chú:  <asp:Literal ID="ltghichu" runat="server"></asp:Literal>  </td>
        <td class="style14">
        </td>
        <td class="style7">
            &nbsp;</td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style46">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="9" style="mso-height-source:userset;height:6.75pt">
        <td class="style15" height="9">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style46">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="45" style="mso-height-source:userset;height:33.75pt">
        <td class="style16" height="45">
            STT</td>
        <td class="style17">
            Mã sp</td>
        <td class="style18" width="280">
            Tên</td>
        <td class="style19" width="53">
            Số lượng</td>
        <td class="style20" width="50">
            Đ.V<br />
            tính</td>
        <td class="style21" width="65">
            Đơn<br />
            <span style="mso-spacerun:yes">&nbsp;</span>giá</td>
        <td class="style23">
            Thành tiền</td>
        <td class="style8">
        </td>
    </tr>
    <asp:Repeater ID="rpcartdetail" runat="server">
	<ItemTemplate>
      <tr height="28" style="mso-height-source:userset;height:21.0pt">
        <td class="style24" height="28"  style='border:1px solid #000'> <%=i++ %></td>
        <td class="style7"  style='border:1px solid #000'><%#Code(Eval("ipid").ToString())%></td>
        <td class="style25"  style='border:1px solid #000'><%#DataBinder.Eval(Container.DataItem,"Name")%></td>
        <td class="style26"  style='border:1px solid #000'><%#DataBinder.Eval(Container.DataItem,"Quantity")%></td>
        <td class="style26"  style='border:1px solid #000'><%=Commond.Setting("Dongiapro") %></td>
        <td class="style27" width="65"  style='border:1px solid #000'><%#AllQuery.MorePro.Detail_Price(Eval("Price").ToString())%> <%=Commond.Setting("Dongiapro") %></td>
        <td class="style28" width="76"  style='border:1px solid #000'><%#AllQuery.MorePro.Detail_Price(Eval("Money").ToString())%> <%=Commond.Setting("Dongiapro") %></td>
     
         <td class="style8"  style='border:none'> </td>
    </tr>
	</ItemTemplate>
</asp:Repeater>
    <tr height="33" style="mso-height-source:userset;height:24.75pt">
        <td class="style30" height="33">
            &nbsp;</td>
        <td class="style31">
            Tổng cộng</td>
        <td class="style32">
            &nbsp;</td>
        <td class="style33">
            <%=Soluong() %></td>
        <td class="style33" colspan="2">
            &nbsp;</td>
        <td class="style34" colspan="1">
            <asp:Literal ID="lttong" runat="server"></asp:Literal> <%=Commond.Setting("Dongiapro") %></td>
        <td class="style8">
        </td>
    </tr>
<tr height="39" style="mso-height-source:userset;height:29.25pt">
        <td class="style35" height="39">
            &nbsp;</td>
        <td class="style36" colspan="4" style="mso-ignore: colspan">
            Tổng số tiền (viết bằng chữ): <asp:Literal ID="ltvietchu" runat="server"></asp:Literal></td>
        <td class="style37">
            &nbsp;</td>
        <td class="style38">
            &nbsp;</td>
        <td class="style8">
        </td>
    </tr>
    <tr height="17" style="mso-height-source:userset;height:12.75pt">
        <td class="style39" height="17">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="27" style="mso-height-source:userset;height:20.25pt">
        <td class="style41" height="27">
        </td>
        <td class="style7">
            Khách hàng</td>
             <td class="style8">
             <div style=" text-align:center; margin-left:200px">Kế toán</div>
        </td>
         <td class="style8">
            </td>
        <td class="style7">
            &nbsp;</td>
             <td class="style8">
        </td>
        <td class="style7">
            Người xuất</td>
        <td class="style46">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="27" style="mso-height-source:userset;height:20.25pt">
        <td class="style41" height="27">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style46">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="27" style="mso-height-source:userset;height:20.25pt">
        <td class="style41" height="27">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style46">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="30" style="mso-height-source:userset;height:22.5pt">
        <td class="style42" height="30">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
            Ngày:<span style="mso-spacerun:yes">&nbsp; </span><%=MoreAll.MoreAll.FormatDate(DateTime.Now)%></td>
        <td class="style46">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="17" style="height:12.75pt">
        <td class="style45" height="17">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style46">
        </td>
        <td class="style8">
        </td>
    </tr>
</table>
    
<div><a onClick="window.print();return false"><img src="/Resources/images/services5.png" style=" width:70px" /></a></div>
          
       <style type="text/css">

td
	{border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            color:black;
	        font-size:11.0pt;
	        font-weight:400;
	        font-style:normal;
	        text-decoration:none;
	        font-family:Calibri, sans-serif;
	        text-align:general;
	        vertical-align:bottom;
	        white-space:nowrap;
	        text-align:center;
	}
        .style1
        {
            height: 17.25pt;
            width: 26pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style2
        {
            width: 47pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style3
        {
            width: 210pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style4
        {
            width: 238pt;
            color: black;
            font-size: 12.0pt;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align:left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style5
        {
            width: 48pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style6
        {
            height: 17.25pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style7
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style8
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style10
        {
            height: 13.5pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style11
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style12
        {
            height: 24.0pt;
            color: black;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style13
        {
            height: 19.5pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style14
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style15
        {
            height: 6.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style16
        {
            height: 33.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style17
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style18
        {
            width: 210pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style19
        {
            width: 100px;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style20
        {
            width: 100px;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style21
        {
            width: 100px;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style23
        {
            width:150pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style24
        {
            height: 21.0pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style25
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style26
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style27
        {
            width: 49pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style29
        {
            width: 92pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style30
        {
            height: 24.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style31
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style32
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style33
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
       
.style34 {
    border-color: windowtext -moz-use-text-color windowtext windowtext;
    border: .5pt solid windowtext;
    border-width: 0.5pt 1px 0.5pt 0.5pt;
    color: black;
    font-family: "Times New Roman",serif;
    font-size: 10pt;
    font-style: normal;
    font-weight: 700;
    padding: 0;
    text-align: center;
    text-decoration: none;
    vertical-align: middle;
    white-space: nowrap;
}
        .style35
        {
            height: 29.25pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: italic;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style36
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: italic;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style37
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style38
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
               width: 92pt;
           }
        .style39
        {
            height: 12.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style40
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style41
        {
            height: 20.25pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style42
        {
            height: 22.5pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style45
        {
            height: 12.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
           .style46
           {
               color: black;
               font-size: 10.0pt;
               font-weight: 400;
               font-style: normal;
               text-decoration: none;
               font-family: "Times New Roman", serif;
               text-align: center;
               vertical-align: middle;
               white-space: nowrap;
               border-style: none;
               border-color: inherit;
               border-width: medium;
               padding: 0px;
               width: 92pt;
           }
           .style47
           {
               color: black;
               font-size: 10.0pt;
               font-weight: 700;
               font-style: normal;
               text-decoration: none;
               font-family: "Times New Roman", serif;
               text-align: left;
               vertical-align: middle;
               white-space: nowrap;
               border-style: none;
               border-color: inherit;
               border-width: medium;
               padding: 0px;
               width: 92pt;
           }
    </style>
    </form>
</body>
</html>


