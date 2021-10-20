function ThanhToan(language) {
    var txthovaten = document.getElementById('txthovaten').value;
    var txtsotiencanrut = document.getElementById('txtsotiencanrut').value;
    var txttennganhang = document.getElementById('txttennganhang').value;
    var txtsotaikhoan = document.getElementById('txtsotaikhoan').value;
    var txtchinhanh = document.getElementById('txtchinhanh').value;
    var txtnoidungchuyentien = document.getElementById('txtnoidungchuyentien').value;
    //Global
    debugger;
    var loi = 0;
    if ($("#txthovaten").val() == "") {
            $("#TB_TenKH").text("Tên khách hàng không được bỏ trống");
        loi++;
    }
    else {
        $("#TB_TenKH").text("");
    }

    if ($("#txtsotiencanrut").val() == "") {
        $("#TBtsotiencanrut").text("Số tiền cần rút không được bỏ trống");
        loi++;
    }
    else {
        $("#TBtsotiencanrut").text("");
    }

    if ($("#txttennganhang").val() == "") {
        $("#TB_tennganhang").text("Tên ngân hàng không được bỏ trống");
        loi++;
    }
    else {
        $("#TB_tennganhang").text("");
    }

    if ($("#txtsotaikhoan").val() == "") {
        $("#TB_sotaikhoan").text("Số tài khoản không được bỏ trống");
        loi++;
    }
    else {
        $("#TB_sotaikhoan").text("");
    }

    if ($("#txtchinhanh").val() == "") {
        $("#TB_Chinhanh").text("Chi nhánh không được bỏ trống");
        loi++;
    }
    else {
        $("#TB_Chinhanh").text("");
    }

    if ($("#txtnoidungchuyentien").val() == "") {
        $("#TB_noidungchuyentien").text("Nội dung không được bỏ trống");
        loi++;
    }
    else {
        $("#TB_noidungchuyentien").text("");
    }
    
    if (loi != 0) {
        return false;
    }
}