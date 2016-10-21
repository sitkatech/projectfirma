/* global jQuery */

(function ($, window) {
    'use strict';

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

    /**
     * Sustainability Dashboard Homepage functions
     */
    var sustainabilityDashboard = function () {
        var $w = jQuery(window),
            $scrollCover = jQuery(document.body).append('<div class="scroll-cover"></div>').find('.scroll-cover'),
            scrollTimer,
            scrolling,
            windowHeight = 0,
            homepageHeader = jQuery('.sustainability-home'),
            touchEnabled = jQuery('html').hasClass('touch'),
            homepageHeaderMinHeight = 830;

        // header full height
        function homepageHeaderHandler ()
        {
            homepageHeader.css("min-height", homepageHeaderMinHeight);
            windowHeight = window.innerHeight;
            homepageHeader.css("height", windowHeight);
            homepageHeader.css("max-height", windowHeight);
        }


        // scroll cover
        function scrollHandler () {
            scrolling = true;

            window.clearTimeout(scrollTimer);

            if (scrolling && !$scrollCover.hasClass('on')) {
                $scrollCover.addClass('on');
            }

            scrollTimer = window.setTimeout(function () {
                $scrollCover.removeClass('on');

                scrolling = false;
            }, 55);
        }
        var homepageScrollHandler = throttle(scrollHandler, 25);


        // block grid
        var $blockColumns = $('.block-col'),
            $blockItems = $blockColumns.find('.block-item'),
            hash;

        function activeColumnFromHash () {
            hash = window.location.hash;

            if (hash) {
                changeActiveColumn($(hash).index());
            }
        }
        activeColumnFromHash();

        function resetActiveColumn () {
            $blockColumns.removeClass('active');
        }

        function resetActiveItem () {
            $blockItems.removeClass('active');
        }

        function changeActiveItem (column, row) {
            resetActiveItem();

            var $item = $blockColumns.eq(column).find('.block-item').eq(row).addClass('active');

            $item.off('mouseenter.activeItem');

            $item.one('mouseenter.activeItem', function () {
                $item.removeClass('active');
            });

            return $item;
        }

        function changeActiveColumn (index) {
            resetActiveColumn();
            resetActiveItem();

            return $blockColumns.eq(index).addClass('active');
        }

        function mobileToggleBlock (e) {
            /*jshint validthis: true */
            e.preventDefault();

            var $el = $(this);

            $blockItems.not($el).removeClass('active');

            if (!$el.hasClass('active')) {
                $el.find('.btn').on('click', function (e) {
                    e.stopImmediatePropagation();

                    window.location = $(this).attr('href');
                });
            } else {
                $el.find('.btn').off('click');
            }

            $el.not('.no-hover').toggleClass('active');
        }


        function truncate (str, maxLength, useWordBoundary){
            var toLong = str.length > maxLength,
                s_ = toLong ? str.substr(0, maxLength - 1) : str;

            useWordBoundary = useWordBoundary || false;

            s_ = useWordBoundary && toLong ? s_.substr(0,s_.lastIndexOf(' ')) : s_;

            return  toLong ? s_ + '&hellip;' : s_;
        }

        function addTruncatedBlockSummary () {
            $blockItems.not('.no-hover').each(function () {
                var $el = $(this),
                    $summary = $el.find('.summary'),
                    $truncatedSummary = $('<span class="truncated"></span>'),
                    truncatedText;

                truncatedText = truncate($summary.html(), 110, true);

                $summary.wrapInner('<span class="original"></span>');

                $truncatedSummary.html(truncatedText);

                $summary.append($truncatedSummary);
            });
        }


        /**
         * Center element in viewport
         * @param  {Object} $el    jQuery selector
         * @param  {number} timing
         */
        function centerElement ($el, timing) {
            var offset = $el.offset().top,
                height = $el.height(),
                windowHeight = window.innerHeight,
                distance;

            if (height < windowHeight) {
                distance = offset - Math.round((windowHeight / 2) - (height / 2));
            } else {
                distance = offset;
            }

            $(document.body).scrollTo(distance + 'px', timing);
        }

        function parentLinkHandler (e) {
            /*jshint validthis: true */
            e.preventDefault();

            var $el = $(this),
                $bubble = $el.closest('.bubble'),
                index = $bubble.index();

            changeActiveColumn(index);
        }

        function subpageLinkHandler (e) {
            /*jshint validthis: true */
            e.preventDefault();

            var $el = $(this),
                $bubble = $el.closest('.bubble'),
                column = $bubble.index(),
                row = $el.parent().index();

            resetActiveColumn();
            var $activeItem = changeActiveItem(column, row);

            centerElement($activeItem, (400 + (row * 100)));
        }

        var $menu = $('.menu');

        // click handlers
        $menu.find('.parent').on('click', parentLinkHandler);
        $menu.find('.subpages').on('click', 'a', subpageLinkHandler);

        // other event handlers
        $w.on('hashchange', activeColumnFromHash);

        $(window).on('load', function () {
            $.localScroll({
                duration: 400,
                hash: true
            });
        });

        // Responsive handlers
        function largeDeviceHandler () {
            $w.on('resize.homepage', homepageHeaderHandler);
            $w.on('scroll.homepage', homepageScrollHandler);

            $blockItems.not('.no-hover').addClass('hover-enabled');
            $blockItems.off('click.blockGrid');

            homepageHeaderHandler();
            resetActiveItem();
            resetActiveColumn();
        }

        function smallDeviceHandler () {
            $w.off('resize.homepage');
            $w.off('scroll.homepage');

            if (touchEnabled) {
                $blockItems.removeClass('hover-enabled');
                $blockItems.on('click.blockGrid', mobileToggleBlock);
            }
            homepageHeader.css("min-height", "");
            resetActiveItem();
            resetActiveColumn();
        }


        var smallMediaQuery = 882;
        var width, currentScreenSize;

        function responsiveHandler () {
            width = $w.innerWidth();

            if (width < smallMediaQuery) {
                if (currentScreenSize !== 'small') {
                    currentScreenSize = 'small';
                    smallDeviceHandler();
                }
            } else {
                if (currentScreenSize !== 'large') {
                    currentScreenSize = 'large';
                    largeDeviceHandler();
                }
            }
        }

        responsiveHandler();
        $(window).on('resize', responsiveHandler);

        addTruncatedBlockSummary();
    };


    $(function () {
        // wrap all tables to make overflow scrollable
        var $tables = $('table');
        if ($tables.length > 0) {
            $tables.wrap('<div class="table-wrapper"></div>');
        }

        // add class to all linked images in body text
        var $textBody = $('.body');
        if ($textBody.length > 0) {
            $('img').parent('a').addClass('has-image');
        }
    });


    window.loadSustainabilityDashboard = sustainabilityDashboard;
})(jQuery, window);
