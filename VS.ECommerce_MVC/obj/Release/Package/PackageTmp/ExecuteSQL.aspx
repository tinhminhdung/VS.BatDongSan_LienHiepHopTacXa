<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExecuteSQL.aspx.cs" Inherits="VS.ECommerce_MVC.ExecuteSQL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resources/Admins/css/bootstrap.css" rel="stylesheet" />
    <link href="Resources/Admins/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="list_item" style="width: 900px; margin: auto">
            Tên db:
            <asp:TextBox ID="txttenbd" runat="server"></asp:TextBox><br />
            <asp:Button ID="backup" runat="server" Text="Backup database" OnClick="backup_Click" />
            <asp:Button ID="resto" runat="server" Text="Restore database" OnClick="resto_Click" />
            <div style="color: Red">
                <asp:Literal ID="lblAlert" runat="server"></asp:Literal>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Run SQl" OnLoad="Sql_Load" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Update TangName" OnLoad="TangName_Load" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <div>-------------------------------------------------------------</div>
            <br />
            <br />


            Tìm kiếm
        <asp:TextBox ID="txttimkiem" runat="server"></asp:TextBox><br />
            <asp:Button ID="bttimkiem" runat="server" Text="Tìm kiếm" OnClick="bttimkiem_Click" />
            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" />
            <asp:LinkButton ID="btDeleteall" ToolTip="Xóa những lựa chọn !" OnClientClick=" return confirmDelete(this);" runat="server" OnClick="btDeleteall_Click" CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton>

            <script type="text/javascript">
                function confirmDelete(spanChk)
                {
                    var oItem = spanChk.children;
                    var theBox= (spanChk.type=="checkbox")?spanChk : spanChk.children.item[0];
                    var elm=<%=checkboxs.ClientID %>.getElementsByTagName("input");
                var haveChoose = new Boolean();
                haveChoose = true;
                var ok = new Boolean();
                ok == false;
                for(i=0;i<elm.length;i++)                   
                    if(elm[i].type=="checkbox")                         
                        if(elm[i].checked == haveChoose) ok = true;
                if(ok == haveChoose)
                    return confirm('Bạn muốn xóa những thông tin này ?');
                else
                    return confirm('Bạn chưa chọn thông tin nào để xóa !');                       
            }     
            function changeColor(CheckBoxObj,color) 
            {         
                if (CheckBoxObj.checked == true) 
                {
                    CheckBoxObj.parentNode.parentNode.style.backgroundColor='#e6f5de'; 
                }else
                    if (CheckBoxObj.checked == false) 
                    {
                        CheckBoxObj.parentNode.parentNode.style.backgroundColor='#FAF9FA'; 
                    }
            }    
            function SelectAllCheckboxes(spanChk){
                // Added as ASPX uses SPAN for checkbox
                var oItem = spanChk.children;
                var theBox= (spanChk.type=="checkbox") ? 
                    spanChk : spanChk.children.item[0];
                xState=theBox.checked;
                elm=theBox.form.elements;

                for(i=0;i<elm.length;i++)
                    if(elm[i].type=="checkbox" && 
                             elm[i].id!=theBox.id)
                    {
                        //elm[i].click();
                        if(elm[i].checked!=xState)
                            elm[i].click();
                        //elm[i].checked=xState;
                    } 
            } 
            </script>
            <div id="checkboxs" runat="server">




                <div style="color: red; font-size: 16px; text-transform: uppercase; padding: 20px">Menu</div>
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <asp:Repeater ID="rp_pagelist" runat="server" OnItemCommand="rp_pagelist_ItemCommand">
                        <ItemTemplate>
                            <tr style="background-color: #fcf0e0" height="40">
                                <td style="text-align: center;">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                </td>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem,"Name")%>
                                </td>
                                <td align="center">
                                    <div class="del">
                                        <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">Xóa]</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>

                <div style="color: red; font-size: 16px; text-transform: uppercase; padding: 20px">Tin tức</div>
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <asp:Repeater ID="rpNews" runat="server" OnItemCommand="rpNews_ItemCommand">
                        <ItemTemplate>
                            <tr style="background-color: #fcf0e0" height="40">
                                <td style="text-align: center;">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("inid") %>' runat="server" />
                                </td>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem,"title")%>
                                </td>
                                <td align="center">
                                    <div class="del">
                                        <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"inid")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">Xóa]</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>

                <div style="color: red; font-size: 16px; text-transform: uppercase; padding: 20px">Sản phẩm</div>
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <asp:Repeater ID="rpPro" runat="server" OnItemCommand="rpPro_ItemCommand">
                        <ItemTemplate>
                            <tr style="background-color: #fcf0e0" height="40">
                                <td style="text-align: center;">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ipid") %>' runat="server" />
                                </td>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem,"name")%>
                                </td>
                                <td align="center">
                                    <div class="del">
                                        <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ipid")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">Xóa]</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>

                <div style="color: red; font-size: 16px; text-transform: uppercase; padding: 20px">Video</div>
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <asp:Repeater ID="rpvideo" runat="server" OnItemCommand="rpvideo_ItemCommand">
                        <ItemTemplate>
                            <tr style="background-color: #fcf0e0" height="40">
                                <td style="text-align: center;">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                </td>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem,"Title")%>
                                </td>
                                <td align="center">
                                    <div class="del">
                                        <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">Xóa]</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>

                <div style="color: red; font-size: 16px; text-transform: uppercase; padding: 20px">Album</div>
                <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                    <asp:Repeater ID="rpalbum" runat="server" OnItemCommand="rpalbum_ItemCommand">
                        <ItemTemplate>
                            <tr style="background-color: #fcf0e0" height="40">
                                <td style="text-align: center;">
                                    <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                </td>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem,"Title")%>
                                </td>
                                <td align="center">
                                    <div class="del">
                                        <asp:LinkButton CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server" ID="Linkbutton3" OnLoad="Delete_Load">Xóa]</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>


            </div>
        </div>


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

        <asp:Literal ID="ltketqua" runat="server"></asp:Literal>      
           
    </form>
</body>
</html>
