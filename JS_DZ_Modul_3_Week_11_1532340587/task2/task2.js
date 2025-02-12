document.addEventListener("DOMContentLoaded", function() {
    var btnOpen = document.querySelector("#btnOpen");
    btnOpen.addEventListener("click", () => document.querySelector('.modal').style.display = 'block');

    var btnClose = document.querySelector("#btnClose");
    btnClose.addEventListener("click", () => document.querySelector('.modal').style.display = 'none');
});