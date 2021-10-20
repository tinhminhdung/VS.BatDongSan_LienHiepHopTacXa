jQuery(document).ready(function ($) {
    var loadimg = $('.loadings');
    // load ảnh loading.gif trước
    var images = loadimg.find('iframe').get();
    //console.log(images);
    if (images.length > 0) {
        images.forEach(function (item) {
            // console.log('item ', item);
            $(item).attr('load', $(item).attr('src'));
           // $(item).attr('src', 'data:image/gif;base64,R0lGODdhAQABAPAAAP///wAAACwAAAAAAQABAEACAkQBADs=');
		     $(item).attr('src', 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAANSURBVBhXYzh8+PB/AAffA0nNPuCLAAAAAElFTkSuQmCC');
        	$(item).addClass('Nenimgaes');
		});
    }
    // load xong moi load anh
    var swap = function () {
        //Chuyển load ở thẻ attr('load') thành src
        //  $(window).height() cộng thêm chiều cao của trang tính từ thẻ boby
        var top = $(window).scrollTop() + $(window).height();
        var images = $(loadimg).find('iframe').get();
        if (images.length > 0) {
            images.forEach(function (item) {
                //console.log($(item).offset(), top, top > $(item).offset().top);
                if ($(item).is(':visible') && $(item).attr('src') !== undefined && $(item).attr('src') !== '' && top > $(item).offset().top && $(item).offset().top > 0) {
                    $(item).attr('src', $(item).attr('load'));
						 $(item).removeClass('Nenimgaes');
                    //  console.log($(item).attr('src', $(item).attr('load')));
                }
            });
        }
    }
    // sét thời gian khi vào web 1 giây sau mới load trang
    setTimeout(function () {
        swap();
    }, 1000);

    $(window).scroll(function () {
        swap();
    });

});

jQuery(document).ready(function ($) {
  
    var loadimg = $('.loadings');
    // load ảnh loading.gif trước
    var images = loadimg.find('img').get();
    //console.log(images);
    if (images.length > 0) {
        images.forEach(function (item) {
           // console.log('item ', item);
            $(item).attr('load', $(item).attr('src'));
           // $(item).attr('src', 'data:image/gif;base64,R0lGODdhAQABAPAAAP///wAAACwAAAAAAQABAEACAkQBADs=');
		     $(item).attr('src', 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAANSURBVBhXYzh8+PB/AAffA0nNPuCLAAAAAElFTkSuQmCC');
				$(item).addClass('Nenimgaes');
		});
    }
    // load xong moi load anh
    var swap = function () {
        //Chuyển load ở thẻ attr('load') thành src
        //  $(window).height() cộng thêm chiều cao của trang tính từ thẻ boby
        var top = $(window).scrollTop() + $(window).height();
        var images = $(loadimg).find('img').get();
        if (images.length > 0) {
            images.forEach(function (item) {
                //console.log($(item).offset(), top, top > $(item).offset().top);
                if ($(item).is(':visible') && $(item).attr('src') !== undefined && $(item).attr('src') !== '' && top > $(item).offset().top && $(item).offset().top > 0) {
                    $(item).attr('src', $(item).attr('load'));
						 $(item).removeClass('Nenimgaes');
                    //console.log($(item).attr('src', $(item).attr('load')));
                }
            });
        }
    }
    // sét thời gian khi vào web 1 giây sau mới load trang
    setTimeout(function () {
        swap();
    }, 1000);

    $(window).scroll(function () {
        swap();
    });

});


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
        }, 800
    );
});