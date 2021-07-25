// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*function Participate() {
    var x = document.getElementById();
    
    
    if (x.style.display === "none") {
        x.style.display = "block";
    }
    else {
        x.style.display = "none";
    }
}*/


var current = 0;

function next() {

    var boxes = document.getElementsByClassName("tweetbox");
    current += 1;
    if (current >= boxes.length) current = 0;

    for (var i = 0; i < boxes.length; i++) {
        boxes[i].style.display = "none";
    }

    boxes[current].style.display = "block";
    boxes[current + 1].style.display = "block";
    if (boxes[current] > boxes.length) {
        current = 0;
    }
}

function prev() {

    var boxes = document.getElementsByClassName("tweetbox");
    current -= 1;
    if (current < 0) current = boxes.length - 1;

    for (var i = 0; i < boxes.length; i++) {
        boxes[i].style.display = "none";
    }

    boxes[current].style.display = "block";
    boxes[current + 1].style.display = "block";
    if (boxes[current] > boxes.length) {
        current = 0;
    }
}
    //TO DO
function stringToHtml(tweet) {
    var parser = new DOMParser();
    var htmlDoc = parser.parseFromString(tweet, 'text/html');
    return document.write(htmlDoc);
}


    //NEWS SECTION SLIDER

var scrollDuration = 300;

var leftPaddle = document.getElementsByClassName('left-paddle');
var rightPaddle = document.getElementsByClassName('right-paddle');

var boxLength = $('.news-box').length;
var boxSize = $('.news-box').outerWidth(true);

var paddleMargin = 100;

var getNewsWrapperSize = function () {
    return $('.news-wrapper').outerWidth();
}

var newsWrapperSize = getNewsWrapperSize();

$(window).on('resize', function () {
    newsWrapperSize = getNewsWrapperSize();
});


var newsVisibleSize = newsWrapperSize;

var getNewsSize = function () {
    return boxLength * boxSize;
};

var newsSize = getNewsSize();

var newsInvisibleSize = newsSize - newsWrapperSize;

var getNewsPosition = function () {
    return $('.news').scrollLeft();
};


$('.news').on('scroll', function () {

    newsInvisibleSize = newsSize - newsWrapperSize;

    var newsPosition = getNewsPosition();

    var newsEndOffset = newsInvisibleSize - paddleMargin;

    if (newsPosition <= paddleMargin) {
        $(leftPaddle).addClass('hidden');
        $(rightPaddle).removeClass('hidden');
    }
    else if (newsPosition < newsEndOffset) {
        $(leftPaddle).removeClass('hidden');
        $(rightPaddle).removeClass('hidden');
    }
    else if (newsPosition >= newsEndOffset) {
        $(leftPaddle).removeClass('hidden');
        $(rightPaddle).addClass('hidden');
    }

    $('#print-wrapper-size span').text(newsWrapperSize);
    $('#print-menu-size span').text(newsSize);
    $('#print-menu-invisible-size span').text(newsInvisibleSize);
    $('#print-menu-position span').text(newsPosition);

});

$(rightPaddle).on('click', function () {
    $('.news').animate({ scrollLeft: 400 }, scrollDuration);
    
});

$(leftPaddle).on('click', function () {
    $('.news').animate({ scrollLeft: '0' }, scrollDuration);
});





//SCROLLING CARDS


$('.carousel.carousel-multi-item.v-2 .carousel-item').each(function () {
    var next = $(this).next();
    if (!next.length) {
        next = $(this).siblings(':first');
    }
    next.children(':first-child').clone().appendTo($(this));

    for (var i = 0; i < 5; i++) {
        next = next.next();
        if (!next.length) {
            next = $(this).siblings(':first');
        }
        next.children(':first-child').clone().appendTo($(this));
    }
});