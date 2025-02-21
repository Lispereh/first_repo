document.addEventListener("DOMContentLoaded", function() {
    const container = document.querySelector(".container");
        const button = document.querySelector("#addButton")

        function addBlock() {

            let block = document.createElement("div");
            block.style.backgroundColor = `rgb(${color()},${color()},${color()})`;
            block.classList.add("myBlock");

            block.addEventListener("click", () =>{
                block.remove();
            })

            container.appendChild(block);
        }

        function color() {
            return Math.floor(Math.random() * (256 - 0 + 1)) + 0;
        }

        button.addEventListener("click", addBlock);
});