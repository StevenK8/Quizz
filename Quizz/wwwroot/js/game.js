"use strict";

var urlParams = new URLSearchParams(window.location.search);
var gameId = urlParams.get('gameId');
var userId = parseInt(urlParams.get('userId'), 10);

var connection = new signalR.HubConnectionBuilder().withUrl("/GameHub").build();

connection.start().then(function () {
    console.log("Connexion établie");
    connection.invoke("UserConnectedToGame", userId, gameId).catch(function (err) {
        return console.error(err.toString());
    });

}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("AskQuestion", function (question, choices) {
    var questions = document.getElementById("questions");
    var answers = document.getElementById("answers");

    questions.innerHTML = '';
    answers.innerHTML = '';

    var tag = document.createElement("p");
    var text = document.createTextNode(question);
    tag.appendChild(text);
    questions.appendChild(tag);

    var i = 1;
    var divanswers = document.createElement("div");
    var divbtn = document.createElement("div");

    choices.forEach(choice => {
        tag = document.createElement("p");
        text = document.createTextNode(choice);
        tag.appendChild(text);
        divanswers.appendChild(tag);

        let btn = document.createElement("button");
        btn.innerHTML = i;
        btn.onclick = function () {
            GiveAnswer(choice);
        };
        i = i + 1;
        divbtn.appendChild(btn);
    })

    answers.appendChild(divanswers);
    answers.appendChild(divbtn);
});

function GiveAnswer(choice) {
    connection.invoke("AnswerQuestion", userId, gameId, choice).catch(function (err) {
        return console.error(err.toString());
    });
}

connection.on("ReceiveAnswer", function (answer) {
    
});


connection.on("EndGame", function (scores) {
   
});

