/* global $, alert, console */

$(document).ready(function () {
	'use strict';

// Adjusting Preloader
	window.onload = setTimeout(function () {
		    document.body.style.overflow = "auto";
	        document.getElementById("preloader").style.display = "none";
	    },700
	);

// Adjust Agents owl-carousel
	$('.owl-carousel').owlCarousel({
	    rtl:true,
	    loop:true,
	    autoplay:true,
	    margin:10,
	    nav:true,
	    autoplayTimeout:1500,
	    autoplayHoverPause:true, 
	    responsive:{
	        0:{
	            items:1
	        },
	        500:{
	            items:2
	        },
	        768:{
	            items:3
	        },
	        992:{
		        items:4
	        },
	        1200:{
		        items:4
	       }   
	    }
	});
	
// Back Top Button
	var topButton = document.getElementById('backTop');
	
	window.onscroll = function (){
	    if(window.scrollY > 700) {
	        topButton.style.bottom = "10px";
	    } else {
	        topButton.style.bottom = "-300px";
	    }
	}
	
	topButton.addEventListener("click", function (){
	    window.scroll({
			behavior: 'smooth',
			top: 0, 
			left: 0
	    });
	});
	
});