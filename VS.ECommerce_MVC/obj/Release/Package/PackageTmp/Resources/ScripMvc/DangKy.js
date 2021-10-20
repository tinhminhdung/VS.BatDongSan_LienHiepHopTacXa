function DangKyThanhVien(language) {
    var regex_email = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var regex_phone = /^(0|84|\+84)+(\d{9}|\d{10})$/;
    //  var regex_pass = /^((?=.*?[A-Z])|(?=.*?[a-z]))(?=.*?[0-9]).{6,}$/;

    var txtHoTen = document.getElementById('txtHoTen').value;
    var txtaddress = document.getElementById('txtaddress').value;

    var Phone = document.getElementById('txtphone').value;
    var Emails = document.getElementById('txtemail').value;
    var Matkhau = document.getElementById('txtmatkhau').value;
    var hdlanguage = document.getElementById('hdlanguage').value;
    //Global
    debugger;
    var loi = 0;
    if ($("#txtHoTen").val() == "") {
        if (hdlanguage == "VIE") {
            $("#TB_TenKH").text("Tên khách hàng không được bỏ trống");
        }
        else {
            $("#TB_TenKH").text("Customer name must not be blank");
        }
        loi++;
    }
    else {
        $("#TB_TenKH").text("");
    }
    if ($("#txtphone").val() == "") {
        if (hdlanguage == "VIE") {
            $("#TB_SoDienThoai").text("Điện thoại không được bỏ trống");
        }
        else {
            $("#TB_SoDienThoai").text("Phone must not be blank");
        }
        loi++;
    }
    else if (!Phone.match(regex_phone)) {
        if (hdlanguage == "VIE") {
            $("#TB_SoDienThoai").text("Điện thoại không đúng định dạng");
        }
        else {
            $("#TB_SoDienThoai").text("The phone is not in the correct format");
        }
        loi++;
    } else {
        $("#TB_SoDienThoai").text("");
    }
    if ($("#txtaddress").val() == "") {
        if (hdlanguage == "VIE") {
            $("#TB_DiaChi").text("Địa chỉ không được bỏ trống");
        }
        else {
            $("#TB_DiaChi").text("Address must not be blank");
        }
        loi++;
    }
    else {
        $("#TB_DiaChi").text("");
    }
    if ($("#txtemail").val() == "") {
        if (hdlanguage == "VIE") {
            $("#TB_Email").text("Email không được bỏ trống");
        }
        else {
            $("#TB_Email").text("Email must not be blank");
        }
        loi++;
    }
    else if (!Emails.match(regex_email)) {
      
        if (hdlanguage == "VIE") {
            $("#TB_Email").text("Email không đúng định dạng");
        }
        else {
            $("#TB_Email").text("Email invalidate");
        }
        loi++;
    } else {
        $("#TB_Email").text("");
    }
    if ($("#txtmatkhau").val() == "") {
        if (hdlanguage == "VIE") {
            $("#TB_MatKhau").text("Mật khẩu không được bỏ trống");
        }
        else {
            $("#TB_MatKhau").text("password must not be blank");
        }
        loi++;
    }
    else if (Matkhau.length < 6) {

        if (hdlanguage == "VIE") {
            $("#TB_MatKhau")[0].innerHTML = 'Mật khẩu có ít nhất 6 kí tự';
        }
        else {
            $("#TB_MatKhau")[0].innerHTML = 'Password has at least 6 characters';
        }
        // document.getElementById('PassWord').focus();
        return false;
    }
    //else if (!Matkhau.match(regex_pass)) {
    //    $("#TB_MatKhau").text("Mật khẩu có ít nhất 6 kí tự, phải có cả chữ và số");
    //    loi++;
    //} else {
    //    $("#TB_MatKhau").text("");
    //}
    if (loi != 0) {
        return false;

        ///ajax
        $.ajax({
            type: "POST",
            url: "/Members/Dang_Ky",
            data: "{txtHoTen:'" + txtHoTen.toString() + "',txtemail:'" + Emails.toString() + "',txtphone:'" + Phone.toString() + "',txtaddress:'" + txtaddress.toString() + "',txtmatkhau:'" + Matkhau.toString() + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: "true",
            success: function (response) {
                debugger;
                // $("#Thongbao").html(response);
            },
            error: function (response) {
                // alert(response.responseText);
            },
            beforeSend: function () {
                //  $body.addClass('loading');
            },
            complete: function () {
                // $body.removeClass("loading");
            }
        });

        //Ngăn sự kiện submit đến server
        //  
    }
}