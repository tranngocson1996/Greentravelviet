(function ($) {
    "use strict";

    function ServiceHome() {
        if ($('.new-event-content .n-item').length > 1) {
            $('.new-event-content.owl-carousel').owlCarousel({
                loop: true,
                autoplay: true,
                margin: 30,
                slideSpeed: 3000,
                nav: false,
                dots: false,
                autoWidth: false,
                items: 3,
                navText: ['', ''],
                responsive: {
                    0: {
                        items: 1,
                        nav: false
                    },
                    320: {
                        items: 1,
                        nav: false
                    },
                    480: {
                        items: 2,
                        nav: false
                    },
                    768: {
                        items: 2,
                        nav: false
                    },
                    1200: {
                        items: 3,
                        nav: true
                    }
                }
            });
        }
    }
    function HotTourOwl() {
        if ($('.list .item').length > 1) {
            $('.list.owl-carousel').owlCarousel({
                loop: true,
                autoplay: true,
                margin: 0,
                slideSpeed: 3000,
                nav: true,
                dots: false,
                autoWidth: false,
                items: 4,
                navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
                responsive: {
                    0: {
                        items: 1,
                        nav: false
                    },
                    320: {
                        items: 1,
                        nav: false
                    },
                    480: {
                        items: 2,
                        nav: false
                    },
                    768: {
                        items: 3,
                        nav: false
                    },
                    1200: {
                        items: 4,
                        nav: true
                    }
                }
            });
        }
    }
    function TestimonialOwl() {
        if ($('.testimonial  .item').length > 1) {
            $('.testimonial.owl-carousel').owlCarousel({
                loop: true,
                autoplay: true,
                margin: 50,
                slideSpeed: 3000,
                nav: false,
                dots: false,
                autoWidth: false,
                items: 2,
                navText: ["", ""],
                responsive: {
                    0: {
                        items: 1,

                    },
                    320: {
                        items: 1,

                    },
                    480: {
                        items: 1,
                    },
                    767: {
                        items: 2,

                    },
                    1200: {
                        items: 2,

                    }
                }
            });
        }
    }
    function BannerHomeOwl() {
        if ($('.banner-home .bn-item').length > 1) {
            $('.banner-home .bn-items').owlCarousel({
                loop: true,
                autoplay: true,
                margin: 0,
                slideSpeed: 3000,
                nav: true,
                dots: true,
                autoWidth: false,
                items: 1,
                navText: ["", ""],
            });
        }
    }
    function NewsHightLightHome() {
        if ($('.new-hightlight .n-item').length > 1) {
            $('.new-hightlight.owl-carousel').owlCarousel({
                loop: true,
                autoplay: true,
                margin: 5,
                slideSpeed: 3000,
                nav: true,
                dots: false,
                autoWidth: false,
                items: 3,
                navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
                responsive: {
                    0: {
                        items: 1,
                        nav: false
                    },
                    320: {
                        items: 1,
                        nav: false
                    },
                    480: {
                        items: 2,
                        nav: false
                    },
                    768: {
                        items: 2,
                        nav: false
                    },
                    1200: {
                        items: 3,
                        nav: true
                    }
                }
            });
        }
    }
    function ArticleHomeOwl() {
        if ($('.module-article-home .article-item').length > 1) {
            $('.module-article-home .owl-carousel').owlCarousel({
                loop: true,
                autoplay: true,
                margin: 15,
                slideSpeed: 2000,
                smartSpeed: 1500,
                nav: false,
                autoWidth: false,
                items: 4,
                navText: ['', ''],
                responsive: {
                    0: {
                        items: 1,
                        nav: false
                    },
                    380: {
                        items: 2,
                        nav: false,
                        autoplay: true
                    },
                    640: {
                        items: 3,
                        nav: true
                    },
                    1200: {
                        items: 4,
                        nav: true
                    }
                }
            });
        }
    }
    function ProductThumbOwl() {
        if ($('.p-thumb li').length > 0) {
            $('.p-thumb ul').owlCarousel({
                loop: true,
                autoplay: false,
                margin: 10,
                slideSpeed: 2000,
                nav: true,
                dots: false,
                autoWidth: false,
                items: 4,
                navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
                responsive: {
                    0: {
                        items: 2,
                        nav: false
                    },
                    320: {
                        items: 3,
                        nav: false,
                        autoplay: true
                    },
                    1200: {
                        items: 4,
                        nav: true
                    }
                }
            });
        }
    }

    function moveScroller() {
        if ($(".product-info").length && $('.tab-link').length) {
            var $anchor = $(".product-info");
            var $scroller = $('.tab-link');

            var move = function () {
                var st = $(window).scrollTop();
                var ot = $anchor.offset().top;
                var wt = $scroller.width();
                if (st > ot) {
                    $scroller.css({
                        position: "fixed",
                        top: "0px"
                    });
                    $scroller.addClass("fixed");
                } else {
                    $scroller.css({
                        position: "relative",
                        top: ""
                    });
                    $scroller.removeClass("fixed");
                }
            };
            $(window).scroll(move);
            move();
        }
    }

    $(document).ready(function () {
        TestimonialOwl();
        BannerHomeOwl();
        ServiceHome();
        HotTourOwl();
        NewsHightLightHome();
        ProductThumbOwl();
        ArticleHomeOwl();
        moveScroller();
        $('.search-icon').on('click', function (e) {
            $('.search-form').toggleClass('active');
            e.preventDefault();
        });

        //Scrip language
        $('#languages-block').on('click', function () {
            $(this).children('.top-sub').slideToggle(200);
        });

        $('#back-to-top').on('click', function (e) {
            e.preventDefault();
            $("html, body").animate({
                scrollTop: $('html, body').offset().top
            }, 500);
        });

        if ($('.menu-primary .RadMenu_Top').length) {
            $('.menu-primary .RadMenu_Top').meanmenu({
                meanScreenWidth: "992",
                meanMenuContainer: ".mobile-menu",
                meanRevealPosition: "right"
            });
        }
        if ($('.images-gallery .swipebox').length) {
            $('.swipebox').venobox({
                border: '6px'
            });
        }
        if ($('.venoboxframe').length) {
            $('.venoboxframe').venobox({
                border: '6px'
            });
        }
    });

    $(window).on('scroll', function () {
        if ($(window).scrollTop() > 50) {
            $("#back-to-top").fadeIn(300);
            $('.header').addClass('stick');
        } else {
            $("#back-to-top").fadeOut(300);
            $('.header').removeClass('stick');
        }
    });

    $(window).on('load', function () {
        if ($('.preloader').length) {
            $('.preloader').delay(500).fadeOut(500);
        }

        //Slider product detail gallery images
        var slider = $('#slider');
        var thumbnailSlider = $('#thumbnailSlider');
        var duration = 500;
        if ($('#slider .item').length) {
            slider.owlCarousel({
                loop: false,
                nav: false,
                items: 1,
                navText: ['', '']
            }).on('changed.owl.carousel', function (e) {
                thumbnailSlider.trigger('to.owl.carousel', [e.item.index, duration, true]);
                $('.thumbnail-slider .owl-item').removeClass("center");
                $('.thumbnail-slider .owl-item:eq(' + e.item.index + ')').addClass("center");
            });
        }
        if ($('#thumbnailSlider .item').length) {
            thumbnailSlider.owlCarousel({
                loop: false,
                center: false,
                nav: false,
                margin: 15,
                navText: ['', ''],
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 2
                    },
                    1000: {
                        items: 4
                    }
                }
            }).on('click', '.owl-item', function () {
                slider.trigger('to.owl.carousel', [$(this).index(), duration, true]);
                $('.thumbnail-slider .owl-item').removeClass("center");
                $(this).addClass("center");
            }).on('changed.owl.carousel', function (e) {
                slider.trigger('to.owl.carousel', [e.item.index, duration, true]);
            });
            $('.thumbnail-slider .owl-item:eq(0)').addClass("center");
        }
        $('.slider-right').click(function () {
            slider.trigger('next.owl.carousel');
        });
        $('.slider-left').click(function () {
            slider.trigger('prev.owl.carousel');
        });
    });
})(jQuery);