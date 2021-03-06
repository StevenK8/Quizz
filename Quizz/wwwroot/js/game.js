"use strict";

var urlParams = new URLSearchParams(window.location.search);
var gameId = urlParams.get('gameId');
var userId = parseInt(urlParams.get('userId'), 10);
var isTimed = false;

var connection = new signalR.HubConnectionBuilder().withUrl("/GameHub").build();

connection.start().then(function () {
    console.log("Connexion établie");
    connection.invoke("UserConnectedToGame", userId, gameId).catch(function (err) {
        return console.error(err.toString());
    });

}).catch(function (err) {
    return console.error(err.toString());
});
var divbtn;
connection.on("AskQuestion", function (question, choices, timed) {
    var questions = document.getElementById("questions");
    var answers = document.getElementById("answers");
    isTimed = timed;
    questions.innerHTML = '';
    answers.innerHTML = '';

    var tag = document.createElement("p");
    var text = document.createTextNode(question);
    tag.appendChild(text);
    questions.appendChild(tag);

    var i = 1;
    var divanswers = document.createElement("div");
    divbtn = document.createElement("div");
    choices.forEach(choice => {
        if (choice !== "vide") {
            let btn = document.createElement("button");
            btn.setAttribute("class", "btn btn-primary d-grid gap-2 col-4 mx-auto");
            btn.innerHTML = choice;
            btn.onclick = function () {
                GiveAnswer(choice);
            };
            i = i + 1;

            var newLine = document.createElement("br");
            var newLine2 = document.createElement("br");

            divbtn.appendChild(btn);
            divbtn.appendChild(newLine);
            divbtn.appendChild(newLine2);
        }
    })

    answers.appendChild(divanswers);
    answers.appendChild(divbtn);
    if (isTimed) {
        SetTimer();
    }
});

function GiveAnswer(choice) {
    if (isTimed) {
        HideTimer();
    }
    var answers = document.getElementById("answers");
    answers.removeChild(divbtn);
    var tag = document.createElement("p");
    var text = document.createTextNode("En attente de la réponse de l'adversaire...");
    tag.appendChild(text);
    answers.appendChild(tag);

    connection.invoke("AnswerQuestion", userId, gameId, choice).catch(function (err) {
        return console.error(err.toString());
    });
}

connection.on("ReceiveAnswer", function (answer, score, isGoodAnswer, msg) {
    var answers = document.getElementById("answers");
    answers.innerHTML = '';
    HideTimer();

    var tag = document.createElement("p");

    var text;
    if (isGoodAnswer) {
        if (msg == null) {
            msg = "";
        }
        text = document.createTextNode("Bonne réponse ! " + msg);
        
    }
    else
    {
        text = document.createTextNode("Mauvaise réponse... La bonne réponse était : " + answer);
    }

    tag.appendChild(text);
    answers.appendChild(tag);

    computeScore(score);
});

function computeScore(score) {

    var scr = document.getElementById("scoring");
    scr.innerHTML = '';

    var tag = document.createElement("p");
    var tag2 = document.createElement("br");
    scr.appendChild(tag2);
    scr.appendChild(tag2);
    var text = document.createTextNode("Score des joueurs : ");
    tag.appendChild(text);
    scr.appendChild(tag);

    score.forEach(userAndScores => {
        tag = document.createElement("p");
        text = document.createTextNode(userAndScores);
        tag.appendChild(text);
        scr.appendChild(tag);
    });

    //var table = document.createElement("table");
    //var thead = document.createElement("thead");
    //var tr = document.createElement("tr");
    //var th = document.createElement("th");
    //var text = document.createTextNode("Score");

    //th.appendChild(text);
    //tr.appendChild(th);
    //thead.appendChild(tr);
    //table.appendChild(thead);

    //score.forEach(userAndScores => {
    //    var tbody = document.createElement("tbody");
    //    tr = document.createElement("tr");
    //    var td = document.createElement("td");
    //    text = document.createTextNode(userAndScores);

    //    td.appendChild(text);
    //    tr.appendChild(th);
    //    tbody.appendChild(tr);
    //});

    //table.appendChild(tbody);
}

var timerId;
function SetTimer() {
    var timeLeft = 29;
    var elem = document.getElementById("timer");
    timerId = setInterval(countdown, 1000);

    function countdown() {
        if (timeLeft == 0) {
            elem.innerHTML = "Fin du temps";
        } else {
            elem.innerHTML = timeLeft + " secondes...";
            timeLeft--;
        }
    }
}

function HideTimer() {
    clearInterval(timerId);
    var elem = document.getElementById('timer');
    elem.innerHTML = "";
}


connection.on("EndGame", function (scores, winner) {

    var questions = document.getElementById("questions");
    var answers = document.getElementById("answers");
    questions.innerHTML = "";
    answers.innerHTML = "";

    

    var tag = document.createElement("p");
    var text = document.createTextNode("Fin de la partie, le gagnant est : " + winner + ". Félicitations !");
    tag.appendChild(text);
    questions.appendChild(tag);
    computeScore(scores);

    let btn = document.createElement("button");
    btn.setAttribute("class", "btn btn-primary d-grid gap-2 col-4 mx-auto");
    btn.innerHTML = "Retour au menu";
    btn.onclick = function () {
        RedirectToIndex();
    };
    answers.appendChild(btn);
});

function RedirectToIndex() {
    var location = window.location.origin;
    window.location.href = location;
}

