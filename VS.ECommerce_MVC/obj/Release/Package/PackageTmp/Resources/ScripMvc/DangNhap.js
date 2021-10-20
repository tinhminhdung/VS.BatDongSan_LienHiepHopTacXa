
function DangNhapThanhVien() {
  //  var regex_pass = /^((?=.*?[A-Z])|(?=.*?[a-z]))(?=.*?[0-9]).{6,}$/;
    var Matkhau = document.getElementById('txtmatkhau').value;
    //Global
    debugger;
    var loi = 0;
    if ($("#txttendangnhap").val() == "") {
        $("#TB_TenKH").text("Tên đăng nhập không được bỏ trống");
        loi++;
    }
    else {
        $("#TB_TenKH").text("");
    }
    if ($("#txtmatkhau").val() == "") {
        $("#TB_MatKhau").text("Mật khẩu không được bỏ trống");
        loi++;
    }
    else if (Matkhau.length < 6) {
        $("#TB_MatKhau")[0].innerHTML = 'Mật khẩu có ít nhất 6 kí tự';
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
            url: "/Members/Dang_Nhap",
            data: "{txttendangnhap:'" + txttendangnhap.toString() + "',txtmatkhau:'" + txtmatkhau.toString() + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: "true",
            success: function (response) {
                window.parent.location.href = '/';
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
      //  
    }
}