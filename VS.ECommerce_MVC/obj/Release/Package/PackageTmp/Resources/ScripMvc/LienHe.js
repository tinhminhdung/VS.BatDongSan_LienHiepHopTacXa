
function LienHe() {
    var regex_email = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var regex_phone = /^(0|84|\+84)+(\d{9}|\d{10})$/;
    var regex_pass = /^((?=.*?[A-Z])|(?=.*?[a-z]))(?=.*?[0-9]).{6,}$/;
    var Phone = document.getElementById('txtphone').value;
    var Emails = document.getElementById('txtemail').value;
    //Global
    $('html, body').animate({ scrollTop: 850 }, 'slow');
    debugger;
    var loi = 0;
    if ($("#txtHoTen").val() == "") {
        $("#TB_TenKH").text("(*)");
        $("#txtHoTen").css('border', '1px solid red');
        loi++;
    }
    else {
        $("#TB_TenKH").text("");
    }
    if ($("#txtphone").val() == "") {
        $("#TB_SoDienThoai").text("(*)");
        $("#txtphone").css('border', '1px solid red');
        loi++;
    }
    else if (!Phone.match(regex_phone)) {
        $("#TB_SoDienThoai").text("(*)");
        $("#txtphone").css('border', '1px solid #ffa903');
        loi++;
    } else {
        $("#TB_SoDienThoai").text("");
    }

    if ($("#txtaddress").val() == "") {
        $("#TB_DiaChi").text("(*)");
        $("#txtaddress").css('border', '1px solid red');
        loi++;
    }
    else {
        $("#TB_DiaChi").text("");
    }
    if ($("#txtemail").val() == "") {
        $("#TB_Email").text("(*)");
        $("#txtemail").css('border', '1px solid red');
        loi++;
    }
    else if (!Emails.match(regex_email)) {
        $("#TB_Email").text("(*)");
        $("#txtemail").css('border', '1px solid #ffa903');
        loi++;
    } else {
        $("#TB_Email").text("");
    }
   
    if (loi != 0) {


        //Ngăn sự kiện submit đến server
        return false;
    }
}