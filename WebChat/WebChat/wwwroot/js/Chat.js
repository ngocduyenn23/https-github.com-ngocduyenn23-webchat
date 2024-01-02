
var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

connection.on("ReceiveMessage", function (sender, message) {
    var div = document.createElement("div");
    document.getElementById("#messagesList").appendChild(div);
    div.textContent = `${sender} says ${message}`;
});

function sendMessage() {
    let mesg = document.querySelector("#mesg").value;

    // gui du lieu
    connect.invoke("sendMassage", mesg);

    // xoa noi dung tin nhan khi gui
    document.querySelector("#mesg").value = "";
    document.querySelector("")
};



document.addEventListener('alpine:init', () => {
    Alpine.data('chatdata', () => ({
        _friends: [],

        init() {
            let url = "/Friend/GetAll";
            fetch(url)
                .then(res => res.json())
                .then(json => {
                    this._friends = json
                });
        }
    }))
});




