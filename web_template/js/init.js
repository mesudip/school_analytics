jQuery(document).ready(function($) { 
	
	$('#menu-main-menu').superfish({ 
		delay:       1000, // 0.1 second delay on mouseout 
		animation:   {opacity:'show',height:'show'},	// fade-in and slide-down animation
		animationOut: {opacity:'hide'},
		speed: 'fast',
		speedOut: 'fast',
		disableHI: true,
		useClick: false
	});

    $('#toggle-main').click(function() {
        $('#menu-main-menu').slideToggle(400);
        $(this).toggleClass("active");
 
        return false;
 
    });
  
    function mobileadjust() {
        
        var windowWidth = $(window).width();

        if( typeof window.orientation === 'undefined' ) {
            $('#menu-main-menu').removeAttr('style');
         }

        if( windowWidth < 769 ) {
            $('#menu-main-menu').addClass('mobile-menu');
         }
 
    }
    
    mobileadjust();

    $(window).resize(function() {
        mobileadjust();
    });

});