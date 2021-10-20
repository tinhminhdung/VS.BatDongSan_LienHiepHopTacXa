$(function() {
  $.fn.scrollToTop = function(a) {
    var d = a.speed ? a.speed : "slow", e = a.ease ? a.ease : "jswing", b = a.start ? a.start : "0", c = $(this);
    $(this).hide().removeAttr("href");
    $(window).scrollTop() > b && $(this).fadeIn("slow");
    $(window).scroll(function() {
      $(window).scrollTop() > b ? $(c).fadeIn("slow") : $(c).fadeOut("slow")
    });
    $(this).click(function() {
      $("html, body").animate({scrollTop:"0px"}, d, e)
    })
  }
});

