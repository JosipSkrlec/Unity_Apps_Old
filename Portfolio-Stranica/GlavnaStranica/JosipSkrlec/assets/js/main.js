/*
	Snapshot by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
*/

// Button za povratak na pocetak stranice
//Get the button:
mybutton = document.getElementById("myBtn");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
  document.body.scrollTop = 0; // For Safari
  document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
}

// Button za povratak na pocetak stranice DO TUDA


(function($) {

	skel.breakpoints({
		xlarge: '(max-width: 1680px)',
		large: '(max-width: 1280px)',
		medium: '(max-width: 980px)',
		small: '(max-width: 736px)',
		xsmall: '(max-width: 480px)'
	});


	
	$(function() {

		var	$window = $(window),
			$body = $('body');

		// Disable animations/transitions until the page has loaded.
			$body.addClass('is-loading');

			$window.on('load', function() {
				window.setTimeout(function() {
					$body.removeClass('is-loading');
				}, 100);
			});

		// Fix: Placeholder polyfill.
			$('form').placeholder();

		// Prioritize "important" elements on medium.
			skel.on('+medium -medium', function() {
				$.prioritize(
					'.important\\28 medium\\29',
					skel.breakpoint('medium').active
				);
			});

		// Scrolly.
			$('.scrolly').scrolly();

		// Gallery.
			$('.gallery').each(function() {

				var	$gallery = $(this),
					$content = $gallery.find('.content');

				// Poptrox.
					$content.poptrox({
						usePopupCaption: true
					});

				// Tabs.
					$gallery.each( function() {

						var $this = $(this),
							$tabs = $this.find('.tabs a'),
							$media = $this.find('.media');

						$tabs.on('click', function(e) {

							var $this = $(this),
								tag = $this.data('tag');

							// Prevent default.
							 	e.preventDefault();

							// Remove active class from all tabs.
								$tabs.removeClass('active');

							// Reapply active class to current tab.
								$this.addClass('active');

							// Hide media that do not have the same class as the clicked tab.
								$media
									.fadeOut('fast')
									.each(function() {

										var $this = $(this);

										if ($this.hasClass(tag))
											$this
												.fadeOut('fast')
												.delay(200)
												.queue(function(next) {
													$this.fadeIn();
													next();
												});

									});

						});

					});


			});

	});

})(jQuery);

// Custom JS

function animateHeadline($headlines) {
	var duration = animationDelay;
	$headlines.each(function(){
		var headline = $(this);

		if(headline.hasClass('loading-bar')) {
			duration = barAnimationDelay;
			setTimeout(function(){ headline.find('.cd-words-wrapper').addClass('is-loading') }, barWaiting);
		} else if (headline.hasClass('clip')){
			var spanWrapper = headline.find('.cd-words-wrapper'),
				newWidth = spanWrapper.width() + 10
			spanWrapper.css('width', newWidth);
		} else if (!headline.hasClass('type') ) {
			//assign to .cd-words-wrapper the width of its longest word
			var words = headline.find('.cd-words-wrapper b'),
				width = 0;
			words.each(function(){
				var wordWidth = $(this).width();
					if (wordWidth > width) width = wordWidth;
			});
			headline.find('.cd-words-wrapper').css('width', width);
		};

		//trigger animation
		setTimeout(function(){ hideWord( headline.find('.is-visible').eq(0) ) }, duration);
	});
}
