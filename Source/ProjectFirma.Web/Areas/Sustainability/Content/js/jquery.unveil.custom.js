/**
 * jQuery Unveil
 * A very lightweight jQuery plugin to lazy load images
 * http://luis-almeida.github.com/unveil
 *
 * Licensed under the MIT license.
 * Copyright 2013 Luís Almeida
 * https://github.com/luis-almeida
 */

;(function($) {

	$.fn.unveil = function(threshold, callback) {

		var $w = $(window),
				th = threshold || 0,
				retina = window.devicePixelRatio > 1,
				attrib = retina? "data-src-retina" : "data-src",
				images = this,
				loaded;

		/** Modified */
		this.one("unveil", function() {
			var source = this.getAttribute(attrib);
			source = source || this.getAttribute("data-src");
			if (source) {
				this.setAttribute("src", source);
			}

			if (typeof callback === "function") callback.call(this);
		});

		/** Added */
		function throttle (func, delay) {
			var timer = null;

			return function () {
				var context = this, args = arguments;

				if (timer === null) {
					timer = setTimeout(function () {
						func.apply(context, args);
						timer = null;
					}, delay);
				}
			};
		}

		function unveil() {
			var inview = images.filter(function() {
				var $e = $(this);
				if ($e.is(":hidden")) return;

				var wt = $w.scrollTop(),
						wb = wt + $w.height(),
						et = $e.offset().top,
						eb = et + $e.height();

				return eb >= wt - th && et <= wb + th;
			});

			loaded = inview.trigger("unveil");
			images = images.not(loaded);
		}

		/** Modified */
		$w.scroll(throttle(unveil, 75));
		$w.resize(unveil);

		unveil();

		return this;

	};

})(window.jQuery || window.Zepto);
