function setFirstShowroomCity(){

	var firstChild = $('.content .showroom-item:first-child');
	$(firstChild).addClass('active');
	var lat = $(firstChild).attr('lat');
	var lon = $(firstChild).attr('lon');

	$('.gllpLatitude').val(lat);
	$('.gllpLongitude').val(lon);
}

function setShowroomCity(){
	var city_id = $('.city-selector select option:selected').val();
	$('.city-wrapper').css('display', 'none');
	$('.city_'+city_id).css('display', 'block');
	$('.city_'+city_id+":first-child").addClass('active');
	var lat = $('.city_'+city_id).find('.showroom-item:first-child').attr('lat');
	var lon = $('.city_'+city_id).find('.showroom-item:first-child').attr('lon');	
	$('.gllpLatitude').val(lat);
	$('.gllpLongitude').val(lon);
	$('.gllpUpdateButton').click();
}



$(document).ready(function (){
	setFirstShowroomCity();
	$('.showroom-item').click(function (){
		$('.showroom-item').removeClass('active');
		$(this).addClass('active');
		var lat = $(this).attr('lat');
		var lon = $(this).attr('lon');

		$('.gllpLatitude').val(lat);
		$('.gllpLongitude').val(lon);
		$('.gllpUpdateButton').click();
	});
	$('.showroom-item').hover(
		function (){$(this).addClass('hover');},
		function (){$(this).removeClass('hover');}
	);
setShowroomCity();
	$('.city-selector select').change(setShowroomCity);



})