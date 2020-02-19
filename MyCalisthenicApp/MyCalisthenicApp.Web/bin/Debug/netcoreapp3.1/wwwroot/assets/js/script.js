;
(function($) {
    "use strict";

    $(document).ready(function() {

        /**-----------------------------
         *  Popup
         * ---------------------------*/
        $(".floating-icon-info").on("click", function() {
            $(".info-popup").toggleClass("active");
            $(".location-popup").removeClass("active");
            $(".message-popup").removeClass("active");
        });
        $(".info-popup-content_close").on("click", function() {
            $(this)
                .parent()
                .parent()
                .removeClass("active");
        });

        $(".floating-icon-location").on("click", function() {
            $(".location-popup").toggleClass("active");
            $(".message-popup").removeClass("active");
            $(".info-popup").removeClass("active");
        });
        $(".location-popup-content_close").on("click", function() {
            $(this)
                .parent()
                .parent()
                .removeClass("active");
        });

        $(".floating-icon-message").on("click", function() {
            $(".message-popup").toggleClass("active");
            $(".info-popup").removeClass("active");
            $(".location-popup").removeClass("active");
        });
        $(".message-popup-content_close").on("click", function() {
            $(this)
                .parent()
                .parent()
                .removeClass("active");
        });

        /*--------------------
           Nice select
        ---------------------*/
        if ($('.country_select').length != 0) {
            $('.country_select').niceSelect();
        }


        if ($(window).width() > 767) {
            if ($('.footer-parallax')) {
                var height = $('.footer-parallax').height();
                $(".wrapper").css("margin-bottom", height + 30 + 'px');
            }
        }

        /*-----------------------------
                    twentytwenty 
        ------------------------------*/


        var twentytwentyContainer = $('#twentytwenty-container');
        if (twentytwentyContainer.length) {
            twentytwentyContainer.imagesLoaded(function() {
                twentytwentyContainer.twentytwenty({
                    before_label: '',
                    after_label: ''
                });
            });
        }

        // form validation
        var contactform = $("form[name='registration']");
        if (contactform.length) {
            $(function() {
                $("form[name='registration']").validate({
                    rules: {
                        firstname: "required",
                        message: "required",
                        number: "required",
                        email: {
                            required: true,
                            email: true
                        },
                        password: {
                            required: true,
                            minlength: 5
                        }
                    },
                    messages: {
                        firstname: "Please enter your firstname",
                        message: "Please enter your message",
                        number: "Please enter your number",
                        password: {
                            required: "Please provide a password",
                            minlength: "Your password must be at least 5 characters long"
                        },
                        email: "Please enter a valid email address"
                    }
                });
            });
        }

        // Forms Validation
        var filterEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,6})+$/;
        $('.contact-form').submit(function() {
            var errors = 0;
            $(this).find('[data-required="text"]').each(function() {
                if ($(this).attr('data-required-email') === 'email') {
                    if (!filterEmail.test($(this).val())) {
                        $(this).addClass("redborder");
                        errors++;
                    } else {
                        $(this).removeClass("redborder");
                    }
                    return;
                }
                if ($(this).val() === '') {
                    $(this).addClass('redborder');
                    errors++;
                } else {
                    $(this).removeClass('redborder');
                }
            });
            if (errors === 0) {
                var form1 = $(this);
                $.ajax({
                    type: "POST",
                    url: 'contact-form.php',
                    data: $(this).serialize(),
                    success: function(data) {
                        form1.append('<p class="form-result">message has been sent successfully!</p>');
                        $("form").trigger('reset');
                    }
                });
            }
            return false;
        });
        $('.contact-form').find('[data-required="text"]').blur(function() {
            if ($(this).attr('data-required-email') === 'email' && ($(this).hasClass("redborder"))) {
                if (filterEmail.test($(this).val()))
                    $(this).removeClass("redborder");
                return;
            }
            if ($(this).val() != "" && ($(this).hasClass("redborder")))
                $(this).removeClass("redborder");
        });


        /*-------------------------------------
            magnific popup video activation
        -------------------------------------*/
        $('.video-play-btn,.video-popup,.small-vide-play-btn').magnificPopup({
            type: 'video'
        });

        $(".video-btn").magnificPopup({
            items: {
                src: "https://www.youtube.com/watch?v=8XRNwAXKb3s"
            },
            type: "iframe",
            iframe: {
                markup: '<div class="mfp-iframe-scaler">' +
                    '<div class="mfp-close"></div>' +
                    '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>' +
                    "</div>",
                patterns: {
                    youtube: {
                        index: "youtube.com/",
                        id: "v=",
                        src: "//www.youtube.com/embed/8XRNwAXKb3s"
                    }
                },
                srcAction: "iframe_src"
            }
        });

        $(".video-btn-style-2").magnificPopup({
            items: {
                src: "https://www.youtube.com/watch?v=8XRNwAXKb3s"
            },
            type: "iframe",
            iframe: {
                markup: '<div class="mfp-iframe-scaler">' +
                    '<div class="mfp-close"></div>' +
                    '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>' +
                    "</div>",
                patterns: {
                    youtube: {
                        index: "youtube.com/",
                        id: "v=",
                        src: "//www.youtube.com/embed/8XRNwAXKb3s"
                    }
                },
                srcAction: "iframe_src"
            }
        });

        $(".video-play3").magnificPopup({
            items: {
                src: "https://www.youtube.com/watch?v=8XRNwAXKb3s"
            },
            type: "iframe",
            iframe: {
                markup: '<div class="mfp-iframe-scaler">' +
                    '<div class="mfp-close"></div>' +
                    '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>' +
                    "</div>",
                patterns: {
                    youtube: {
                        index: "youtube.com/",
                        id: "v=",
                        src: "//www.youtube.com/embed/8XRNwAXKb3s"
                    }
                },
                srcAction: "iframe_src"
            }
        });

        /*-------------------------------------
            slick sliders
        -------------------------------------*/

        var bannerslider1 = $('.banner-slide1');
        // banner slider one
        bannerslider1.slick({
            dots: false,
            arrows: false,
            asNavFor: '.small-slider',
            fade: true,
            // autoplay: true
        });

        bannerslider1.slickAnimation();


        function ProgressbarStart(bannerprogress) {
            $('.progressbar .home-slider-progress-active').css({ 'width': bannerprogress + 'px' });
        }

        var smallslider = $('.small-slider');

        smallslider.slick({
            slidesToShow: 3,
            slidesToScroll: 1,
            asNavFor: '.banner-slide1',
            dots: false,
            arrows: true,
            focusOnSelect: true,
            centerPadding: 0,
            // autoplay: true
        });

        smallslider.on('beforeChange', function(event, slick, currentSlide, nextSlide) {
            var totalSlide = slick.slideCount;
            var currentSlideindex = ++slick.currentSlide;
            var progress = 100 / totalSlide;
            var progressWidth = progress * currentSlideindex;
            ProgressbarStart(progressWidth)
            $('.controler-wrapper .total-controler').text(check_number(totalSlide));
            $('.controler-wrapper .active-controler').text(check_number(currentSlideindex));

        });

        // banner slider two
        var bannerslider2 = $('.banner-slider2');
        bannerslider2.slick({
            dots: true,
            arrows: true,
            fade: true,
            // autoplay: true
        });
        bannerslider2.slickAnimation();

        // banner slider three
        var bannerslider3 = $('.banner-slider3');
        bannerslider3.slick({
            dots: true,
            arrows: true,
            fade: true,
            centerMode: true,
            // autoplay: true
        });
        bannerslider3.slickAnimation();

        // banner slider four
        var bannerslider4 = $('.banner-slider4');
        bannerslider4.slick({
            dots: true,
            arrows: true,
            fade: true,
            // autoplay: true
        });
        bannerslider4.slickAnimation();


        // popular slider
        $('.popular-slider').slick({
            dots: false,
            infinite: true,
            speed: 300,
            slidesToShow: 4,
            slidesToScroll: 4,
            arrows: true,
            responsive: [{
                    breakpoint: 1200,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 992,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2,
                        arrows: false,
                        autoplay: true
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                        autoplay: true
                    }
                }
            ]
        });

        // class slider
        $('.class-slider').slick({
            dots: true,
            infinite: true,
            speed: 300,
            slidesToShow: 2,
            slidesToScroll: 1,
            arrows: false,
            responsive: [{
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 850,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                        autoplay: true
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
            ]
        });

        // signin slider
        $('.sign-slider').slick({
            dots: true,
            infinite: true,
            speed: 300,
            slidesToShow: 1,
            slidesToScroll: 1,
            arrows: false,
            responsive: [{
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 850,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                        autoplay: true
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
            ]
        });

        // shopping slider
        $('.shopping-slider').slick({
            dots: false,
            infinite: true,
            speed: 300,
            slidesToShow: 4,
            slidesToScroll: 1,
            arrows: false,
            autoplay: true,
            responsive: [{
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 850,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                        autoplay: true
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
            ]
        });

        // shopping slider 3
        $('.shopping-slider3').slick({
            dots: false,
            infinite: true,
            speed: 300,
            slidesToShow: 4,
            slidesToScroll: 4,
            arrows: false,
            responsive: [{
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 850,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                        autoplay: true
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
            ]
        });

        // news slider
        $('.news-slider').slick({
            dots: true,
            infinite: true,
            speed: 300,
            slidesToShow: 4,
            slidesToScroll: 2,
            arrows: true,
            responsive: [{
                    breakpoint: 1200,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        infinite: true,
                        dots: true,
                        arrows: false,
                    }
                },
                {
                    breakpoint: 992,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2,
                        arrows: false,
                        autoplay: true
                    }
                },
                {
                    breakpoint: 575,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                    }
                }
            ]
        });

        // news slider
        $('.client-slider2').slick({
            dots: false,
            infinite: true,
            speed: 300,
            slidesToShow: 3,
            slidesToScroll: 3,
            arrows: false,
            responsive: [{
                    breakpoint: 1400,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 1199,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                        autoplay: true
                    }
                },
                {
                    breakpoint: 575,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                    }
                }
            ]
        });

        // counter up
        $(".project-counter__is").counterUp({
            delay: 10,
            time: 1000
        });



        // brand slider
        $('.brand-slider').slick({
            dots: false,
            arrows: false,
            infinite: true,
            speed: 300,
            slidesToShow: 5,
            slidesToScroll: 4,
            responsive: [{
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        infinite: true,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3
                    }
                }
            ]
        });


        /*-------------------------------------
            owl-carousel
        -------------------------------------*/

        $('.owl-carousel').owlCarousel({
            loop: true,
            margin: 20,
            nav: false,
            center: true,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 2
                },

                1300: {
                    items: 2
                },
                1600: {
                    items: 3,
                    stagePadding: 250
                }
            }
        })

        // blog right slider
        $('.blog-right-slider').slick({
            dots: true,
            infinite: true,
            speed: 300,
            slidesToShow: 1,
            slidesToScroll: 1,
            responsive: [{
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
            ]
        });



        if ($('.timepicker').length != 0) {
            $('.timepicker').wickedpicker();
        }

        //Scroll Down
        $('.scroll a').on('click', function(e) {
            e.preventDefault();
            $('html, body').animate({ scrollTop: $($(this).attr('href')).offset().top }, 500, 'linear');
        });

        // Modal close
        $(".alert-area .close-one").click(function() {
            $(".close-one-content").hide();
        });

        $(".alert-area .close-two").click(function() {
            $(".close-two-content").hide();
        });

        $(".alert-area .close-three").click(function() {
            $(".close-three-content").hide();
        });

        $(".alert-area .close-four").click(function() {
            $(".close-four-content").hide();
        });

        $(".alert-area .close-five").click(function() {
            $(".close-five-content").hide();
        });

        $(".info-popup2-content_close").click(function() {
            $(".info-popup2").hide();
        });

        $(".location-popup2-content_close").click(function() {
            $(".location-popup2").hide();
        });

        $(".message-popup2-content_close").click(function() {
            $(".message-popup2").hide();
        });

        /*-------------------------------------
           Massonry isotop
       -------------------------------------*/
        $(document).ready(function() {

            $('.grid').isotope({
                itemSelector: '.grid-item',
            });

            // filter items on button click
            $('.portfolio-menu').on('click', 'li', function() {
                var filterValue = $(this).attr('data-filter');
                $('.grid').isotope({ filter: filterValue });
                $('.portfolio-menu li').removeClass('active');
                $(this).addClass('active');
            });
        })

        /*-------------------------------
            Portfolio filter 
        ---------------------------------*/
        var $Container = $('.portfolio-masonry');
        if ($Container.length > 0) {
            $('.portfolio-masonry').imagesLoaded(function() {
                var festivarMasonry = $Container.isotope({
                    itemSelector: '.masonry-item', // use a separate class for itemSelector, other than .col-
                    masonry: {
                        gutter: 0
                    }
                });
                $(document).on('click', '.portfolio-menu li', function() {
                    var filterValue = $(this).attr('data-filter');
                    festivarMasonry.isotope({
                        filter: filterValue
                    });
                });
            });
            $(document).on('click', '.portfolio-menu li', function() {
                $(this).siblings().removeClass('active');
                $(this).addClass('active');
            });
        }

        // check_number function
        function check_number(num) {
            var IsInteger = /^[0-9]+$/.test(num);
            return IsInteger ? "0" + num : null;
        }

        /*------------------------------
              counter section activation
          -------------------------------*/
        var counternumber = $('.count-num');
        counternumber.counterUp({
            delay: 20,
            time: 3000
        });

        /*------------------------------
          Tab code
      -------------------------------*/

        // event tab
        $(".tab-accordion ul li").on('click', function() {
            var tabClass = $(this).attr("class");
            $(this).addClass("active").siblings().removeClass("active");
            $("." + tabClass + "-content").addClass("active").siblings().removeClass("active");
        });

        $('.slider-tabfor').slick({
            slidesToShow: 1,
            slidesToScroll: 1,
            arrows: false,
            fade: true,
            asNavFor: '.slider-tabnav'
        });
        $('.slider-tabnav').slick({
            slidesToShow: 4,
            slidesToScroll: 4,
            asNavFor: '.slider-tabfor',
            dots: false,
            arrows: true,
            focusOnSelect: true,
            centerMode: true,
            centerPadding: 0
        });

        /* pricing Active */
        var singlepricing = $('.pricing-area .single-pricing-style-01')

        singlepricing.mouseover(function() {
            singlepricing.removeClass('active');
            $(this).addClass('active');
        });

        // progress bar

        $('.html').rProgressbar({
            percentage: 80,
            height: 10,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: true,
            borderRadius: '20px',
            AbsolutePercentCount: true
        });

        $('.css').rProgressbar({
            percentage: 90,
            height: 10,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: true,
            borderRadius: '20px',
            AbsolutePercentCount: true
        });

        $('.php').rProgressbar({
            percentage: 75,
            height: 10,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: true,
            borderRadius: '20px',
            AbsolutePercentCount: true
        });

        $('.javascript').rProgressbar({
            percentage: 65,
            height: 10,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: true,
            borderRadius: '20px',
            AbsolutePercentCount: true
        });

        // progress bar

        $('.html1').rProgressbar({
            percentage: 80,
            height: 3,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: false,
        });
        $('.css1').rProgressbar({
            percentage: 90,
            height: 3,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: false
        });



        $('.php1').rProgressbar({
            percentage: 75,
            height: 3,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: false
        });



        $('.javascript1').rProgressbar({
            percentage: 65,
            height: 3,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: false
        });



        $('.jquery1').rProgressbar({
            percentage: 95,
            height: 3,
            fillBackgroundColor: '#88C13E',
            ShowProgressCount: false
        });

        $('.html3').rProgressbar({
            percentage: 80,
            height: 20,
            fillBackgroundColor: '#818181',
            ShowProgressCount: false,
        });
        $('.css3').rProgressbar({
            percentage: 90,
            height: 20,
            fillBackgroundColor: '#818181',
            ShowProgressCount: false
        });



        $('.php3').rProgressbar({
            percentage: 75,
            height: 20,
            fillBackgroundColor: '#818181',
            ShowProgressCount: false
        });



        $('.javascript3').rProgressbar({
            percentage: 10,
            height: 20,
            fillBackgroundColor: '#818181',
            ShowProgressCount: false
        });



        $('.jquery3').rProgressbar({
            percentage: 0,
            height: 20,
            fillBackgroundColor: '#818181',
            ShowProgressCount: false
        });


        $(document).ready(function() {
            $('#qty_input').prop('disabled', true);
            $('#plus-btn').click(function() {
                $('#qty_input').val(parseInt($('#qty_input').val()) + 1);
            });
            $('#minus-btn').click(function() {
                $('#qty_input').val(parseInt($('#qty_input').val()) - 1);
                if ($('#qty_input').val() == 0) {
                    $('#qty_input').val(1);
                }
            });

            $('#qty_input2').prop('disabled', true);
            $('#plus-btn2').click(function() {
                $('#qty_input2').val(parseInt($('#qty_input2').val()) + 1);
            });
            $('#minus-btn2').click(function() {
                $('#qty_input2').val(parseInt($('#qty_input2').val()) - 1);
                if ($('#qty_input2').val() == 0) {
                    $('#qty_input2').val(1);
                }
            });


            $('#qty_input3').prop('disabled', true);
            $('#plus-btn3').click(function() {
                $('#qty_input3').val(parseInt($('#qty_input3').val()) + 1);
            });
            $('#minus-btn3').click(function() {
                $('#qty_input3').val(parseInt($('#qty_input3').val()) - 1);
                if ($('#qty_input3').val() == 0) {
                    $('#qty_input3').val(1);
                }
            });


            $('#qty_input4').prop('disabled', true);
            $('#plus-btn4').click(function() {
                $('#qty_input4').val(parseInt($('#qty_input4').val()) + 1);
            });
            $('#minus-btn4').click(function() {
                $('#qty_input4').val(parseInt($('#qty_input4').val()) - 1);
                if ($('#qty_input4').val() == 0) {
                    $('#qty_input4').val(1);
                }
            });


            $('#qty_input5').prop('disabled', true);
            $('#plus-btn5').click(function() {
                $('#qty_input5').val(parseInt($('#qty_input5').val()) + 1);
            });
            $('#minus-btn5').click(function() {
                $('#qty_input5').val(parseInt($('#qty_input5').val()) - 1);
                if ($('#qty_input5').val() == 0) {
                    $('#qty_input5').val(1);
                }
            });
        });

        $(window).on("resize", function(e) {
            e.preventDefault();
            //floatingIcon
            if ($(window).width() < 768) {
                hideFloatingIcon();
            } else {
                showFloatingIcon();
            }
        });

        var lastScrollTop = "";
        var floatingIcon = $("#service_info_item");
        $(window).on("scroll", function() {

            var st = $(this).scrollTop();

            if ($(window).width() < 992) {
                if (st > lastScrollTop) {
                    // hide sticky menu on scrolldown
                    showFloatingIcon();
                } else {
                    // active sticky menu on scrollup
                    hideFloatingIcon();
                }
            }
            lastScrollTop = st;

        });



        function hideFloatingIcon() {
            //floatingIcon
            floatingIcon.hide();
        }

        function showFloatingIcon() {
            //floatingIcon
            floatingIcon.show();
        }



    })
})(jQuery);