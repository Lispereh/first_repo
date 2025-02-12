document.addEventListener("DOMContentLoaded", function() {
    var books = document.querySelectorAll(".info");
    var prevBook = -1;

    function changeColor(event) {
        if(prevBook > -1) removeColor(prevBook);
        event.target.style.backgroundColor = "orange";
        prevBook = Array.from(books).indexOf(event.target);
    }

    function removeColor(index) {
        books[index].style.backgroundColor = "white";
    }

    for (var i = 0; i < books.length; i++) {
        books[i].addEventListener("click", changeColor);
    }
});