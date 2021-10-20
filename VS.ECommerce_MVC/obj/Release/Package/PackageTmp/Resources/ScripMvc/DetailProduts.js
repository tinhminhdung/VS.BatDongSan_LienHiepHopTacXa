var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnUpdate').off('click').on('click', function () {
            debugger;
            //var Quantity = $(".txtQuantity").val();
            //var ID = $("#Hidden_ipid").val();
            $.ajax({
                type: "POST",
                url: "/Ajax/MuaHangTheoSoLuong",
                data: "{ID:'" + $("#Hidden_ipid").val() + "',Quantity:'" + $(".txtQuantity").val() + "'}",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: "true",
                success: function (response) {
                    window.location.href = "/gio-hang.html";
                },
                error: function (response) {
                    alert(response.status + ' ' + response.statusText);
                },
                beforeSend: function () {
                },
                complete: function () {
                }
            });
        });
    }
}
cart.init();