

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

