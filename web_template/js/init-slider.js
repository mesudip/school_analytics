jQuery(document).ready(function($) { 

	jQuery("#academia-slideshow").flexslider({
        selector: ".academia-slides > .academia-slide",
		animationLoop: true,
        initDelay: 1000,
		smoothHeight: true,
		slideshow: true,
		slideshowSpeed: 5000,
		pauseOnAction: true,
        controlNav: true,
        directionNav: false,
		useCSS: true,
		touch: false,
        animationSpeed: 500
    });	 

});