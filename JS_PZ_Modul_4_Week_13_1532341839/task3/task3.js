document.addEventListener("DOMContentLoaded", function() {
    const container = document.querySelector(".container");
        const button = document.querySelector("#addButton")
        var text = document.querySelector(".text");

        function addBlock() {

            let block = document.createElement("div");
            const colorValue = `rgb(${color()},${color()},${color()})`;
            block.style.backgroundColor = colorValue;
            block.classList.add("myBlock");
            block.dataset.color = colorValue;

            block.addEventListener("click", () => {
                text.style.color = block.dataset.color;
            });

            container.appendChild(block);
        }

        function color() {
            return Math.floor(Math.random() * (256 - 0 + 1)) + 0;
        }

        button.addEventListener("click", addBlock);
});