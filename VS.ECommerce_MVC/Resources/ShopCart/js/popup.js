$(document).ready(function () {
    $(".closes").click(function () {
        return $("#popuprel3").fadeOut(), $("#fade").css("display", "none"), !1
    }), $("#fade").click(function () {
        return
        $(this).css("display", "none"), !1
    }),
    $("a.popup").click(function () {
        ShowCart(); // Gọi lại hàm load giỏ hàng trong popup ra
        var e = $(this).attr("rel");
        $("#" + e).fadeIn(),
     $("body").append('<div id="fade"></div>'),
     $("#fade").css({ filter: "alpha(opacity=80)" }).fadeIn();
        var a = ($("#" + e).height() + 10) / 2, n = ($("#" + e).width() + 10) / 2;
        $("#" + e).css({ "margin-top": -a, "margin-left": -n })
    }), $("#fade").click(function () { return $("#popuprel3").fadeOut(), !1 })
});

$(document).ready(function () {
    $('a.popup').click(function () {
        var popupid = $(this).attr('rel');
        $('#' + popupid).fadeIn();
        $('body').append('<div id="fade"></div>');
        $('#fade').css({ 'filter': 'alpha(opacity=80)' }).fadeIn();
        var popuptopmargin = ($('#' + popupid).height() + 10) / 2;
        var popupleftmargin = ($('#' + popupid).width() + 10) / 2;
        $('#' + popupid).css({
            'margin-top': -popuptopmargin,
            'margin-left': -popupleftmargin
        });
    });
    $('#fade').click(function () {
        $('#fade , #popuprel , #popuprel2 , #popuprel3').fadeOut()
        return false;
    });
});

//function LoadCart() {
//    // make a server call here
//    $.ajax({
//        url: '/Ajax/LoadCart',
//        success: function (data) {
//            //alert(data.d);
//            $("#cart-total")[0].innerHTML = data;
//        },
//        error: function (response) {
//            // alert(response.responseText);
//        },
//        failure: function (response) {
//            // alert(response.responseText);
//        }
//    });
//}



function iframe() {
  $(document).ready(function () {
    $('#iframe').html('iframe login');
   });
}


function ShowCart() {
    $.ajax({
        url: '/Ajax/ShowCart',
        success: function (data) {
            $("#cartContent")[0].innerHTML = data;
           // $("#cartContent").append(data);
        },
        error: function (response) {
            // alert(response.responseText);
        },
        failure: function (response) {
            // alert(response.responseText);
        }
    });
}

function closeelement() {
    div = document.getElementById("jName"); div.style.display = "none";
}

// Demo
//<div onmouseover="doSomething('12334')">
//<a href="http://www.dantri.com/" >link</a>
//</div>
//<%--hoặc--%>
//<a href="http://www.dantri.com/" onmouseover="doSomething(this)">test</a>
//<script type="text/javascript">
//    function doSomething(elem) {
//        alert(elem);
//    }
//</script>


//onmouseover="UpdateOrder(<%#Eval("ipid")%>,'<%#Eval("Name")%>')"
//onclick="UpdateOrder(<%#Eval("ipid")%>,'<%#Eval("Name")%>')"
// Thêm số lương và sp vào giỏ hàng

function UpdateOrder(id, name) {
    var numPro = "#" + id;
    //bắt đầu
    $body = $("#Ajaxloading");
    $body = $("#Loadingshop");
    $.ajax({
        type: "POST",
        url: "/Ajax/Up_Order",
        data: "{id:'" + id.toString() + "',quantity:'1'}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: "true",
        success: function (response) {
            ShowCart();
            // Có thể gọi bằng cách này
            // $("#cartContent").load("/My_Partialview/AutoRefreshCart");
            loadHeaderCart();
            AutoRefreshHeaderCart();

        },
        error: function (response) {
            //  alert(response.status + ' ' + response.statusText);
        },
        beforeSend: function () {
            $body.addClass('loading');
        },
        complete: function () {
            $body.removeClass("loading");
        }
    });
    //    var soluong = 1;
    //    var total = parseInt(soluong) + parseInt($("#Cart")[0].innerHTML);
    //    $("#Cart")[0].innerHTML = total.toString();
    // kết thúc
   // $("#jName").show();
   // $("#jName")[0].innerHTML = '<a href="/gio-hang.html" style="color:#000; font-size:12px;"><b style="color:#ff3a00; font-size:12px;">Bạn đã thêm <b style="color:#ff3a00; font-size:13px;">' + $(numPro).val().toString() + '</b> Sản phẩm vào giỏ hàng</b><br />' + name + '</a>';
    setTimeout(closeelement, 3000);
}
function AutoRefreshHeaderCart() {
    $("#AutoRefreshHeaderCart").load("/My_Partialview/AutoRefreshHeaderCart");
}
function loadHeaderCart() {
    $("#AutoRefreshCart").load("/Home/AutoRefreshCart");
}
////<script type="text/javascript">
// Cách gọi load  Auto Refresh 
////function AutoRefreshHeaderCart() {
////$("#AutoRefreshHeaderCart").load("/My_Partialview/AutoRefreshHeaderCart");
////}
//////$(function () {
//////    setInterval(function () { loadHeaderCart() },1000);
//////});
////</script>
                                       
// Xóa sp trong giỏ hàng
function AJdeleteShoppingCartItem(id, name) {
    $body = $("#Loadingshop");
    var a = confirm("Bạn có muốn xóa sản phẩm này trong giỏ hàng ? ");
    if (a == true) {
        $.ajax({
            type: "POST",
            url: "/Ajax/DeleteShopCart",
            data: "{id:'" + id.toString() + "',quantity:'1'}",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            async: "true",
            success: function (response) {
                ShowCart();
            },
            error: function (response) {
                // alert(response.status + ' ' + response.statusText);
            },
            beforeSend: function () {
                $body.addClass('loading'); // Gọi lại hàm loading ảnh loading.png // Mỗi khi kích vào sự kiện Ajax là nó sẽ loading ra cái hàm này
            },
            complete: function () {
                $body.removeClass("loading");
            }
        });
    }
}
// Tăng giảm số lượng trong giỏ hàng
function AddShoppingCartItem(id, name, number) {
    //        var a = number.attr('data-abc');
    $body = $("#Loadingshop");
    $.ajax({
        type: "POST",
        url: "/Ajax/Updatequantity",
        data: "{id:'" + id.toString() + "',quantity:'" + number.val() + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: "true",
        success: function (response) {
            ShowCart();
            
        },
        error: function (response) {
        },
        beforeSend: function () {
            $body.addClass('loading');
        },
        complete: function () {
            $body.removeClass("loading");
        }
    });
}
function CartItem() {
    ShowCart();
}

// Chi tiet san pham phần kích cỡ và size
$(".size").on("click", function () {
    var count = $(this).parent().find("a").length;
    for (i = 0; i < count; i++) {
        $(this).parent().find("a")[i].className = "size";
    }
    this.className = "size active";
})
$(".Color").on("click", function () {
    var count = $(this).parent().find("a").length;
    for (i = 0; i < count; i++) {
        $(this).parent().find("a")[i].className = "Color";
    }
    this.className = "Color active";
})

function KichCo(id, name) {
    //bắt đầu
    $.ajax({
        type: "POST",
        url: "/Ajax/Up_KichCo",
        data: "{id:'" + id.toString() + "',quantity:'1'}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: "true",
        success: function (response) {
        },
        error: function (response) {
        }
    });
}

function MauSac(id, name) {
    //bắt đầu
    $.ajax({
        type: "POST",
        url: "/Ajax/Up_MauSac",
        data: "{id:'" + id.toString() + "',quantity:'1'}",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: "true",
        success: function (response) {
        },
        error: function (response) {
        }
    });
}



///Bộ lọc tìm kiếm 
//active
jQuery(document).ready(function () {
    // active color
    var color1 = getParameterByName("color");
    if (location.href.lastIndexOf("color") > 0) {
        var idcolor = color1.split(',');
        for (var i = 0; i < idcolor.length; i++) {
            var a = jQuery('div.color a[id=' + idcolor[i] + ']');
            //var a = jQuery('ul.color a[id=' + idcolor[i] + ']').parent();
            a.attr('class', 'sort_list active');
        }
    }
    //active produce
    var size1 = getParameterByName("produce");
    if (location.href.lastIndexOf("produce") > 0) {
        var idsize = size1.split(',');
        for (var i = 0; i < idsize.length; i++) {
            var a = jQuery('div.produce a[id=' + idsize[i] + ']');
            //var a = jQuery('ul.produce a[id=' + idsize[i] + ']').parent();
            a.attr('class', 'sort_list active');
        }
    }
    //active price
    var price1 = getParameterByName("price");
    if (location.href.lastIndexOf("price") > 0) {
        var idprice = price1.split(',');
        for (var i = 0; i < idprice.length; i++) {
            var a = jQuery('div.price a[name=' + idprice[i] + ']');
            //var a = jQuery('ul.price li  a[name=' + idprice[i] + ']').parent();
            a.attr('class', 'sort_list active');
        }
    }
});


//end active
// color
function choose_color(tag) {
    jQuery.noConflict();
    var id = jQuery(tag).attr('id');
    var url = location.href.toString();
    if (url.lastIndexOf("?") > 0) {
        if (url.lastIndexOf("color") > 0) {
            var idcolor = getParameterByName("color");
            var arridcolor = idcolor.split(',');
            var strcolor = "";
            var bool = 0;
            for (var i = 0; i < arridcolor.length; i++) {
                if (id == arridcolor[i]) {
                    arridcolor[i] = "";
                    bool = 1;
                }
                if (arridcolor[i] != "")
                    strcolor += arridcolor[i] + ',';
            }
            if (bool == 1) {
                strcolor = strcolor.substring(0, strcolor.length - 1);
            }
            else {
                strcolor += id;
            }
            strcolor = "color=" + strcolor;
            if (bool == 1 && arridcolor.length == 1) {
                var index = location.href.lastIndexOf("color");
                var a = location.href.substring(index - 1, index);
                if (a == "?") {
                    if (location.href.indexOf("&") > 0)
                        location.href = location.href.replace("color=" + idcolor + "&", "");
                    else location.href = location.href.replace("?color=" + idcolor, "");
                }
                else if (a == "&") {
                    location.href = location.href.replace("&color=" + idcolor, "");
                }
                return;
            }
            else {
                url = url.replace("color=" + idcolor, strcolor);
            }
        }
        else url = url + "&color=" + id;
    }
    else
        url = url + "?color=" + id;
    location.href = url;
};

//produce
function choose_produce(tag) {
    jQuery.noConflict();
    var id = jQuery(tag).attr('id');
    var url = location.href.toString();
    if (url.lastIndexOf("?") > 0) {
        if (url.lastIndexOf("produce") > 0) {
            var idproduce = getParameterByName("produce");
            var arridproduce = idproduce.split(',');
            var strproduce = "";
            var bool = 0;
            for (var i = 0; i < arridproduce.length; i++) {
                if (id == arridproduce[i]) {
                    arridproduce[i] = "";
                    bool = 1;
                }
                if (arridproduce[i] != "")
                    strproduce += arridproduce[i] + ',';
            }
            if (bool == 1) {
                strproduce = strproduce.substring(0, strproduce.length - 1);
            }
            else {
                strproduce += id;
            }
            strproduce = "produce=" + strproduce;
            if (bool == 1 && arridproduce.length == 1) {
                var index = location.href.lastIndexOf("produce");
                var a = location.href.substring(index - 1, index);
                if (a == "?") {
                    if (location.href.indexOf("&") > 0)
                        location.href = location.href.replace("produce=" + idproduce + "&", "");
                    else location.href = location.href.replace("?produce=" + idproduce, "");
                }
                else if (a == "&") {
                    location.href = location.href.replace("&produce=" + idproduce, "");
                }
                return;
            }
            else {
                url = url.replace("produce=" + idproduce, strproduce);
            }
        }
        else url = url + "&produce=" + id;
    }
    else
        url = url + "?produce=" + id;
    location.href = url;
};


//price
 function choose_price(tag) {
        jQuery.noConflict();
        var id = jQuery(tag).attr('name');
        var url = location.href.toString();
        if (url.lastIndexOf("?") > 0) {
            if (url.lastIndexOf("price") > 0) {
                var idprice = getParameterByName("price");
                var arridprice = idprice.split(',');
                var strprice = "";
                var bool = 0;
                for (var i = 0; i < arridprice.length; i++) {
                    if (id == arridprice[i]) {
                        arridprice[i] = "";
                        bool = 1;
                    }
                    if (arridprice[i] != "")
                        strprice += arridprice[i] + ',';
                }
                if (bool == 1) {
                    strprice = strprice.substring(0, strprice.length - 1);
                }
                else {
                    strprice += id;
                }
                strprice = "price=" + strprice;
                if (bool == 1 && arridprice.length == 1) {
                    var index = location.href.lastIndexOf("price");
                    var a = location.href.substring(index - 1, index);
                    if (a == "?") {
                        if (location.href.indexOf("&") > 0)
                            location.href = location.href.replace("price=" + idprice + "&", "");
                        else location.href = location.href.replace("?price=" + idprice, "");
                    }
                    else if (a == "&") {
                        location.href = location.href.replace("&price=" + idprice, "");
                    }
                    return;
                }
                else {
                    url = url.replace("price=" + idprice, strprice);
                }
            }
            else url = url + "&price=" + id;
        }
        else
            url = url + "?price=" + id;
        location.href = url;
    };


function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"), results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
};
