var Status = {
    init: function () {
        Status.registerEvents();
    },
    // Lưu ý chỉ làm mỗi nhóm sản phẩm thôi, vì các phần khác mà dùng chung sẽ bị ảnh hưởng đến Cache, hoặc phải viết riêng ra ko được dùng chung thì mới xử lý dc Cache cho từng menu và Modul
    registerEvents: function () {

        $('.ChangeThuPhi').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeThuPhi",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                        // btn.text('<i class="icon-check"></i>');
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                        //btn.text('<i class="icon-check-empty"></i>');
                    }
                }
            });
        });

        
        // Change Status Menu
        $('.ChangeStatus').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                        // btn.text('<i class="icon-check"></i>');
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                        //btn.text('<i class="icon-check-empty"></i>');
                    }
                }
            });
        });
        $('.ChangeHome').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeHome",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                        // btn.text('<i class="icon-check"></i>');
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                        //btn.text('<i class="icon-check-empty"></i>');
                    }
                }
            });
        });

        // Change Status Products
        $('.ChangeProStatus').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeProStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                    }
                }
            });
        });
        $('.ChangeProHome').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeProHome",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                    }
                }
            });
        });
        $('.ChangeProNews').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeProNews",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                    }
                }
            });
        });
        $('.ChangeProCheck_01').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeProCheck_01",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                    }
                }
            });
        });
        $('.ChangeProCheck_02').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeProCheck_02",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                    }
                }
            });
        });
        $('.ChangeProCheck_03').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeProCheck_03",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                    }
                }
            });
        });
        $('.ChangeProCheck_04').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeProCheck_04",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                    }
                }
            });
        });
        $('.ChangeProCheck_05').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeProCheck_05",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                    }
                }
            });
        });

        // Change Status News

        $('.ChangeNewsCheckBox1').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeNewsCheckBox1",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                        // btn.text('<i class="icon-check"></i>');
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                        //btn.text('<i class="icon-check-empty"></i>');
                    }
                }
            });
        });


        $('.ChangeNewsCheckBox2').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeNewsCheckBox2",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                        // btn.text('<i class="icon-check"></i>');
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                        //btn.text('<i class="icon-check-empty"></i>');
                    }
                }
            });
        });


        $('.ChangeNewsStatus').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeNewsStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                        // btn.text('<i class="icon-check"></i>');
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                        //btn.text('<i class="icon-check-empty"></i>');
                    }
                }
            });
        });
        $('.ChangeNewsHome').off('click').on('click', function (e) {
            // debugger;
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            //alert(id);
            $.ajax({
                url: "/AjaxAdmin/ChangeNewsHome",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn[0].innerHTML = '<i class="icon-check"></i>';
                        // btn.text('<i class="icon-check"></i>');
                    }
                    else {
                        btn[0].innerHTML = '<i class="icon-check-empty"></i>';
                        //btn.text('<i class="icon-check-empty"></i>');
                    }
                }
            });
        });

    }
}
Status.init();