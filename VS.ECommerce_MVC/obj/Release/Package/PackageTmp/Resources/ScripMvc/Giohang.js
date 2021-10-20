$('body').on('keyup', '.txtQuantity', function (e) {
    debugger;
    e.preventDefault();
    var id = $(this).data('id');
    var q = $(this).val();
    if (q > 0) {
        // code ajax kiểu cũ
        //$.ajax({
        //    type: "POST",
        //    url: "/Ajax/ThemSoLuong",
        //    data: "{id: '" + id + "',SoLuong: '" + q + "'}",
        //    success: function (response) {
        //        alert(id + '---' + q);
        //    }
        //});
        // Bài video 52 dotnetcore
        $.ajax({
            url: '/Ajax/CapNhatSoLuong',
            type: 'post',
            data: {
                productId: id,
                quantity: q
            },
            success: function () {
               // alert(id + '- success--' + q);
                window.location.href = "/gio-hang.html";
            }
        });
    }
});
