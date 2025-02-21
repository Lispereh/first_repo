document.addEventListener("DOMContentLoaded", function() {
    var form = document.getElementById("new-message-form");

    form.addEventListener("submit", (event) => {
        event.preventDefault();

        var data = document.getElementById("name").value;
        var text = document.getElementById("comment").value;

        createComment(data, text);
    });

    var messageList = document.getElementById("message-list");

    function createComment(data, text) {
        let npt1 = document.getElementById("name");
        let npt2 = document.getElementById("comment");

        if(data === "" && text === "") {
            npt1.classList.add("red-input");
            npt2.classList.add("red-input");
            return;
        }
        if(data === "") {
            npt1.classList.add("red-input");
            return;
        }
        if(text === "") {
            npt2.classList.add("red-input");
            return;
        }

        let message = document.createElement("div");
        message.classList.add("message");

        let messageInfo = document.createElement("div");
        messageInfo.classList.add("message-info");

        let messageComment = document.createElement("div");
        messageComment.classList.add("message-comment");

        messageInfo.textContent = data;
        messageComment.textContent = text;

        message.appendChild(messageInfo);
        message.appendChild(messageComment);

        messageList.appendChild(message);
    }
});