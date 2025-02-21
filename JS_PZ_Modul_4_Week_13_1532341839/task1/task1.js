document.addEventListener("DOMContentLoaded", function() {
    var number = document.querySelector(".left-field");

    var btnUp = document.querySelector("#up");
    btnUp.addEventListener("click", () => number.innerText = `${parseInt(number.innerText) + 1}`);

    var btnDown = document.querySelector("#down");
    btnDown.addEventListener("click", () => number.innerText = `${parseInt(number.innerText) - 1}`);
});