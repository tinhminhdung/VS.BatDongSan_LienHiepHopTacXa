<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="VS.ECommerce_MVC.admin1" ValidateRequest="false" EnableEventValidation="false" ViewStateEncryptionMode="Never" EnableViewStateMac="false" %>
<%@ Register Src="Cms/Admin/Control.ascx" TagName="Control" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>::. HỆ THỐNG QUẢN TRỊ WEBSITE Vision 4.0 .::</title>
    <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="vi" lang="vi-VN">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link type="text/css" rel="stylesheet" href="/Resources/admins/css/bootstrap.css" />
    <link type="text/css" rel="stylesheet" href="/Resources/admins/css/font-awesome.css" />
    <link type="text/css" rel="stylesheet" href="/Resources/admins/css/style.css" />
    <script src="/Resources/admins/js/bootstrap.min.js"></script>
    <script src="/Resources/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Resources/admin/js/jquery-ui.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
            <uc1:Control ID="Control1" runat="server" />
        </div>
          <div class="scroll-top-inner" id="toTop"><img src="Resources/images/top.png" /></div>
            <script type="text/javascript">      
            $(window).scroll(function () {
                if ($(this).scrollTop() != 0) {
                    $('#toTop').fadeIn();
                } else {
                    $('#toTop').fadeOut();
                }
            });
            $('#toTop').click(function () {
                $('body,html').animate(
                    {
                        scrollTop: 0
                    }, 500
                );
            });
            </script>
            <script src="/Resources/admin/js/ChangeStatus.js"></script>
    </form>
</body>
</html>
