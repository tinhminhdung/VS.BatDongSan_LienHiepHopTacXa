jQuery(document).ready(function ($) {
  /* Main slider */
  $('.mh-main-slider').flickity({
    // options
    cellAlign: 'center',
    contain: true,
    wrapAround: true,
    pauseAutoPlayOnHover: true,
    prevNextButtons: false,
    pageDots: false,
    autoPlay: true,
    autoPlay: 5000
  });

  $('.mh-nav-slider').flickity({
    asNavFor: '.mh-main-slider',
    cellAlign: 'center',
    contain: true,
    pageDots: false,
    prevNextButtons: false
  });

  /* Carousel */
  $('.mh-carousel').flickity({
    // options
    cellAlign: 'left',
    contain: true,
    wrapAround: true,
    pauseAutoPlayOnHover: true,
    prevNextButtons: true,
    pageDots: false,
  });

  /* Get districts */
  $('[name="province"]').on('change', function(e) {
    e.preventDefault();
    var $this = $(this);
    $.ajax({
      type: 'GET',
      url: ajax.ajax_url,
      data: {
        'province' : $this.val(),
        'action'   : 'willgroup_get_districts'
      },
      success: function( data, textStatus, jqXHR ) {
        $('[name="district"]').html(data);
      },
      error: function( jqXHR, textStatus, errorThrown ) {
        alert( errorThrown );
      }
    });
  });

  /* Re embebd */
  if($('.nav-link-map').length) {
    $('.nav-link-map').click(function() {
      var lat_var = $(this).data('lat');
      var lng_var = $(this).data('lng');
      if($('.nav-link-map-content').html() =='' && lat_var!='' && lng_var !='') {
        $('.nav-link-map-content').html('<iframe src="https://maps.google.com/maps?q='+ lat_var +','+ lng_var +'&hl=es;z=15&amp;output=embed"></iframe>');
      }
    });
  }

  if($('.nav-link-video').length) {
    $('.nav-link-video').click(function() {
      var video_url = $(this).data('video');
      if($('.re_video_content').html() =='' && video_url!='') {
        $('.re_video_content').html('<iframe width="100%" height="360" src="https://www.youtube.com/embed/'+ video_url +'" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>');
      }
    });
  }

  /* Get wards */
  $('[name="district"]').on('change', function(e) {
    e.preventDefault();
    var $this = $(this);
    $.ajax({
      type: 'GET',
      url: ajax.ajax_url,
      data: {
        'district' : $this.val(),
        'action'   : 'willgroup_get_wards'
      },
      success: function( data, textStatus, jqXHR ) {
        $('[name="ward"]').html(data);
      },
      error: function( jqXHR, textStatus, errorThrown ) {
        alert( errorThrown );
      }
    });
  });

  /* Get recat */
  $('[name="demand"]').on('change', function(e) {
    e.preventDefault();
    var $this = $(this);
    $.ajax({
    type: 'GET',
    url: ajax.ajax_url,
      data: {
        'demand' : $this.val(),
        'action'   : 'willgroup_get_recat'
      },
      success: function( data, textStatus, jqXHR ) {
        $('[name="category"]').html(data);
      },
        error: function( jqXHR, textStatus, errorThrown ) {
        alert( errorThrown );
      }
    });
  });

  /* Show/hide forgot pass */
  $('.forgot-password button').click(function(){
    $('.forgot-password-form').toggleClass('show');
  });

  /* Login */
  $('.form-login, .form-register, .form-forgot-password').on('submit', function(e) {
    e.preventDefault();
    $form = $(this);
    $form.find('[type="submit"]').append('<i class="fas fa-circle-notch fa-spin ml-2 icon"></i>');
    $form.find('.alert').remove();
    $.ajax({
      type: 'POST',
      url: ajax.ajax_url,
      data: $form.serialize(),
      success: function( data, textStatus, jqXHR ) {
        $form.find('[type="submit"]').find('.icon').remove();
          if( data.status == true ) {
          $form.append('<div class="alert alert-success">' + data.message + '</div>');
          $form.find('.form-control').val('');
          if( $form.hasClass('form-login') ) {
            window.location.href = '/nguoi-dung/dang-tin';
          }
        } else {
          $form.append('<div class="alert alert-danger">' + data.message + '</div>');
        }
      },
      error: function( jqXHR, textStatus, errorThrown ) {
        alert( errorThrown );
      }
    });
  });

  /* Upload images */
	$('[name="images[]"]').on('change', function(e) {
		e.preventDefault();
		var $file = $(this);
		var $form = $file.parents('.form-upload');
		var formData = new FormData();
		formData.append('name', $file.attr('id'));
		formData.append('action', 'willgroup_upload_images');
		$.each($file[0].files, function(i, file) {
      formData.append('images[' + i + ']', file);
    });

		// $form.prepend('<p class="font-weight-bold text-primary text-center uploading">Đang upload...</p>');

    $('.spinner').addClass('before-ajax');

		$.ajax({
			type: 'POST',
			url: ajax.ajax_url,
			data: formData,
			contentType: false,
			processData: false,
			success: function(data) {
				$form.find('.images').prepend(data);
				// $form.find('.uploading').remove();
				$file.val('');
        $('.spinner').removeClass('before-ajax');
			}
		});
	});

	/* Remove image */
	$('body').on('click', '[data-toggle="remove-image"]', function(e) {
		e.preventDefault();
		var $this = $(this);
		$this.html('<i class="far fa-circle-notch"></i>');
    $(this).addClass('before');
		$.ajax({
			type: 'POST',
			url: ajax.ajax_url,
			data: {
				'action' : 'willgroup_remove_image',
				'attachment_id' : $this.data('attachment-id')
			},

			success: function(data) {
				$this.parents('.image').remove();
			}
		});
	});


  $('#result').on('change', function() {
    if ( $(this).val() === 'map_text' ) {
      $('#map_text').css('display', 'block');
      $('#map_location').css('display', 'none');
    }

    if ( $(this).val() === 'map_location' ) {
      $('#map_location').css('display', 'block');
      $('#map_text').css('display', 'none');
    }

  });


});
