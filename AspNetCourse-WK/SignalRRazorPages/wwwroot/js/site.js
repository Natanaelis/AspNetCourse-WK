const { signalR } = require("../lib/aspnet-signalr/signalr");

let userName;
let apiBaseUrl;
let connection;

function getUserName() {
    userName = prompt("Podaj imie");
    if (!userName) {
        alert("Nie podano nazwy uzytkownika, odswiez strone!")
        throw "No user name"
    }
}

function buildConnection(url) {
    apiBasUrl = url;
    connection = new signalR.HubConnectionBuilder()
        .withUrl(`${apiBaseUrl}/api`)
        .configureLogging(signalR.Information)
        .build();
    connection.on("newMessage", newMessage);
    connection.onClose(() => console.log("disconnected"));
    connection.start()
        .then(() => {
            console.log("Connection starts");
            getUserName();
        })
        .catch(console.error)
}
function sendNewMessage() {
    if (e.keyCode == 13) {
        let input = document.getElementById('messageInput').value;
        document.getElementById('messageInput').value = '';
        return sendMessage(input);
    }
}

function sendMessage(message) {
    return axios.post(`${apiBaseUrl}/api/messages`, {
        sender: userName,
        text: message
    }).then(resp => resp.data);
}

function newMessage(message) {
    let messages = document.getElementById('messages');
    let templateChildren = document.getElementById('messageTemplate').content.children[0];
    templateChildren.children[0].firstChild.innerHTML = userName;
    templateChildren.children[0].lastChild.innerHTML = new Date().toISOString();
    templateChildren.children[1].innerHTML = message.text;
    let template = document.getElementById('messageTemplate').content.cloneNode(true);
    messages.insertBefore(template, messages.firstChild);
}