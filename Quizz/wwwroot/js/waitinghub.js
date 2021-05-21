"use strict";

var urlParams = new URLSearchParams(window.location.search);
var gameId = urlParams.get('gameId');
var userId = parseInt(urlParams.get('userId'),10);

var connection = new signalR.HubConnectionBuilder().withUrl("/GameHub").build();

connection.start().then(function () {
    console.log("Connexion établie");
    connection.invoke("AskForConnection", userId, gameId).catch(function (err) {
        return console.error(err.toString());
    });

}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("UserConnected", function (players) {
    var element = document.getElementById("playerlist");
    element.innerHTML = '';
    players.forEach(name => {
        var tr = document.createElement("tr");
        var td = document.createElement("td");
        var text = document.createTextNode(name);
        tr.appendChild(td.appendChild(text));
        element.appendChild(tr);
    });
});

//connection.on("GameStarted", function () {
//    var search = window.location.search;
//    var location = window.location.origin + "/Home/GameView" + search;
//    window.location.replace = location;
//});