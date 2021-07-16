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
/*function participatebtn() {
    document.style.display = "none";
    
    var id = 0;
    id++;
    
    return id;
}*/

