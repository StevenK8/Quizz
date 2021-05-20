﻿"use strict";

var element = document.getElementById("idgame");
var gameId = element.innerText;

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
    players.forEach(id => {
        var tag = document.createElement("p");
        var text = document.createTextNode("Joueur Id : " + id);
        tag.appendChild(text);
        element.appendChild(tag);
    })
});