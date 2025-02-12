document.addEventListener("DOMContentLoaded", function() {
    var counter = 1;

    var lights = document.querySelectorAll(".traffic-lights div");

    function changeColor() {
        lights.forEach(element => {
            element.style.backgroundColor = "gray";
        });

        switch(counter) {
            case 1:
                lights[0].style.backgroundColor = "red";
                counter++;
                break;
            case 2:
                lights[1].style.backgroundColor = "yellow";
                counter++;
                break;
            case 3:
                lights[2].style.backgroundColor = "green";
                counter = 1;
                break;
        }
    }

    var btn = document.querySelector("#next");
    btn.addEventListener("click", changeColor);
});