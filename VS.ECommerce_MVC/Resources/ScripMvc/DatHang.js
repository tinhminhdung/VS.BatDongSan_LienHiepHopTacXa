
function DatHang() {
    var regex_email = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var regex_phone = /^(0|84|\+84)+(\d{9}|\d{10})$/;
    var regex_pass = /^((?=.*?[A-Z])|(?=.*?[a-z]))(?=.*?[0-9]).{6,}$/;
    var Phone = document.getElementById('SoDienThoai').value;
    var Emails = document.getElementById('Email').value;
    //Global

    var loi = 0;
    if ($("#TenKH").val() == "") {
        //$("#TB_TenKH").text("Tên khách hàng không được bỏ trống");
        $("#TB_TenKH").text("(*)");
        $("#TenKH").css('border', '1px solid red');
        loi++;
    }
    else {
        $("#TB_TenKH").text("");
    }
    if ($("#SoDienThoai").val() == "") {
        // $("#TB_SoDienThoai").text("Điện thoại không được bỏ trống");
        $("#TB_SoDienThoai").text("(*)");
        $("#SoDienThoai").css('border', '1px solid red');
        loi++;
    }
    else if (!Phone.match(regex_phone)) {
       // $("#TB_SoDienThoai").text("Điện thoại không đúng định dạng");
        $("#TB_SoDienThoai").text("(*)");
        $("#SoDienThoai").css('border', '1px solid #ffa903');
        loi++;
    } else {
        $("#TB_SoDienThoai").text("");
    }

    if ($("#DiaChi").val() == "") {
        //$("#TB_DiaChi").text("Địa chỉ không được bỏ trống");
        $("#TB_DiaChi").text("(*)");
        $("#DiaChi").css('border', '1px solid red');
        loi++;
    }
    else {
        $("#TB_DiaChi").text("");
    }
    if ($("#Email").val() == "") {
       // $("#TB_Email").text("Email không được bỏ trống");
        $("#TB_Email").text("(*)");
        $("#Email").css('border', '1px solid red');
        loi++;
    }
    else if (!Emails.match(regex_email)) {
        //$("#TB_Email").text("Email không đúng định dạng");
        $("#TB_Email").text("(*)");
        $("#Email").css('border', '1px solid #ffa903');
        loi++;
    } else {
        $("#TB_Email").text("");
    }
    if (loi != 0) {
      
        //Ngăn sự kiện submit đến server
        return false;
       
    }
}