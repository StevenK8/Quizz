"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/GameHub").build();

connection.on("TestConnexion", function () {
    document.getElementById("LabelTest").innerHTML = "Connexion établie";
});

connection.start().then(function () {
    console.log("Connexion établie");
    connection.invoke("TestConnexion").catch(function (err) {
        return console.error(err.toString());
    });

}).catch(function (err) {
    return console.error(err.toString());
});

