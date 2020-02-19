/**
 * Plugin Name: rVideoPlayer
 *  Author : Sharifur Rahman
 *  A lightwet jquery image and video popup plugin
 *  */

(function($) {
    "use strict";

    $.fn.rVideoPlayer = function(options) {
        options = $.extend({
            autoplay: false,
        }, options);

        return this.each(function(index, value) {
            var $this = $(this);
            var intervalFunc;
            var imgsrc = $this.attr('data-videoSource');
            var embedUrl = 'https://www.youtube.com/embed/';
            var autoplay = options.autoplay ? 1 : 0;
            if (/(?:.mp4|.MOV|.avi|.AVI|.FLV|.MKV )/g.test(imgsrc)) {
                var markup = `<div id="rVideo__player" class="rVideo__player"><video class="rVideo__Player"><source src="${imgsrc}"></video>
                        <div class="rVideo__player__thumb" style="background-image:url(assets/img/blog/blog-lg-item.png)"><span class="rplayer__thumb__btn"></span></div>
                        <div class="rvideo_player__extra_wrap">
                            <div class="rvideo_player__progress_wrap">
                                    <span class="rvideo_player__progress_active"></span>
                                </div>
                                <div class="rvideo_player__controls_wrap">
                                    <div class="rvideo_player__buttons">
                                        <span class="rvideo_player_btn rvideo_play"></span>
                                        <div class="rvideo_player_time_wrap">
                                            <span class="rvideo_player_start_time">0:00</span>/
                                            <span class="rvideo_player_duration">2:00</span>
                                        </div>
                                    </div>
                                    <div class="rvideo_player_volume_wrap">
                                        <span class="rvideo_player_volume_icon"></span>
                                        <div class="rvideo_player_volume_progress_wrap">
                                            <input type="range" class="rvideo_player_volume_range" min="0" max="100" step="10" value="10">
                                        </div>
                                        <div class="rvideo_player_fullscreen">
                                            <span></span>
                                            <span></span>
                                            <span></span>
                                            <span></span>
                                        </div>
                                    </div>
                                </div> 
                            </div>
                    </div>`;
            }

            if (/v=([^\s]+)/g.test(imgsrc)) {
                var findId = /v=([^\s]+)/g.exec(imgsrc);
                imgsrc = embedUrl + findId[1];
                var markup = `<iframe id="rpopupIframe" src="${imgsrc}?autoplay=${autoplay}" frameborder="0" allowfullscreen=""></iframe>`;
            }
            $this.append(markup);
            $this.find('.rVideo__player__thumb').addClass('active');

            $('#rVideo__player').bind('contextmenu', function() {
                return false;
            });
            var video = document.querySelector('.rVideo__Player');
            if (video != null) {
                var currentTime = video.currentTime;
                var duration = video.duration;
                if (options.autoplay) {
                    video.play();
                    playHostedVideo($('.rvideo_player_btn, .rVideo__Player'));
                }
                video.onloadedmetadata = function() {
                    var minutes = parseInt(video.duration / 60, 10);
                    var seconds = video.duration % 60;
                    var videoDuration = minutes + ':' + Math.floor(seconds);
                    $('.rVideo__player .rvideo_player_duration').text(videoDuration);
                }

                $('.rVideo__player .rvideo_player_btn, .rVideo__Player,.rVideo__player .rVideo__player__thumb').click(function(e) {
                    e.preventDefault();
                    var el = $(this);
                    playHostedVideo(el);
                    $this.find('.rVideo__player__thumb').removeClass('active');
                });

                function rplayerTime() {
                    var minutes = parseInt(video.currentTime / 60, 10);
                    var seconds = video.currentTime % 60;
                    seconds = Math.floor(seconds);
                    var videoDuration = minutes + ':' + ('0' + seconds).slice(-2);
                    $('.rVideo__player .rvideo_player_start_time').text(videoDuration);
                }

                $('.rVideo__player .rvideo_player__progress_wrap').on('click', function(e) {
                    var el = $(this);
                    var currentPlayerTime = (e.offsetX / el.width()) * video.duration;
                    video.currentTime = currentPlayerTime;
                    var percent = video.currentTime / video.duration * 100;
                    rplayerTime();
                    rplayerProgress(percent);
                });

                $('.rVideo__player .rvideo_player_volume_range').on('change', function() {
                    var el = $(this);
                    video.volume = el.val() / 100;
                });

                $('.rVideo__player .rvideo_player_fullscreen ').on('click', function(e) {
                    makeFullScreenVideo($('#rVideo__player'));


                });

                function makeFullScreenVideo(selector) {
                    if (document.fullscreenElement || document.webkitFullscreenElement || document.mozFullScreenElement || document.msFullscreenElement) {
                        //if already full screen then exit
                        if (document.exitFullscreen) {
                            document.exitFullscreen();
                        } else if (document.mozCancelFullScreen) {
                            document.mozCancelFullScreen();
                        } else if (document.webkitExitFullscreen) {
                            document.webkitExitFullscreen();
                        } else if (document.msExitFullscreen) {
                            document.msExitFullscreen();
                        }
                        selector.removeClass('full-screen');
                    } else {
                        //request for full screen;
                        var element = selector.get(0);
                        if (element.requestFullscreen) {
                            element.requestFullscreen();
                        } else if (element.mozRequestFullScreen) {
                            element.mozRequestFullScreen();
                        } else if (element.webkitRequestFullscreen) {
                            element.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
                        } else if (element.msRequestFullscreen) {
                            element.msRequestFullscreen();
                        }
                        selector.addClass('full-screen');
                    }
                }

                function playHostedVideo(el) {
                    if (intervalFunc) {
                        clearInterval(intervalFunc);
                    }
                    intervalFunc = setInterval(function() {
                        var percent = video.currentTime / video.duration * 100;
                        rplayerTime();
                        rplayerProgress(percent);
                    }, 1000);

                    var el = $('.rVideo__player .rvideo_player_btn');
                    if (el.hasClass('rvideo_play')) {
                        video.play();
                        el.addClass('rvideo_pause').removeClass('rvideo_play');

                    } else if (el.hasClass('rvideo_pause')) {
                        clearInterval(intervalFunc);
                        video.pause();
                        el.addClass('rvideo_play').removeClass('rvideo_pause');
                    }
                }
            }

            function rplayerProgress(percent) {
                $('.rVideo__player .rvideo_player__progress_active').css({ width: percent + '%' })
            }



        });

    }


})(jQuery);

/*-------------------------
    Video player activation
-------------------------*/
$('.video-play-yoga').rVideoPlayer({
    autoplay: false
    });
/*--------------------*/