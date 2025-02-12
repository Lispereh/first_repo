document.addEventListener("DOMContentLoaded", function() {
    var text = document.querySelector("#myInput");
    if(text) text.addEventListener("input", () => text.value = text.value.replace(/\d+/g, ""));
});