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
    var divbtn = document.createElement("div");

    choices.forEach(choice => {
        tag = document.createElement("p");
        text = document.createTextNode(i +" : " + choice);
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
    if (isTimed) {
        SetTimer();
    }
});

function GiveAnswer(choice) {
    if (isTimed) {
        HideTimer();
    }
    connection.invoke("AnswerQuestion", userId, gameId, choice).catch(function (err) {
        return console.error(err.toString());
    });
}

connection.on("ReceiveAnswer", function (answer, score, isGoodAnswer) {
    var answers = document.getElementById("answers");
    answers.innerHTML = '';
    HideTimer();

    var tag = document.createElement("p");

    var text;
    if (isGoodAnswer)
    {
        text = document.createTextNode("Bonne réponse !");
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
    var elem = document.getElementById('timer');
    timerId = setInterval(countdown, 1000);

    function countdown() {
        if (timeLeft == 0) {
            elem.innerHTML = 'fin du temps';
        } else {
            elem.innerHTML = timeLeft + ' secondes...';
            timeLeft--;
        }
    }
}

function HideTimer() {
    clearInterval(timerId);
    var elem = document.getElementById('timer');
    elem.innerHTML = '';
}


connection.on("EndGame", function (scores, winner) {

    var questions = document.getElementById("questions");
    var answers = document.getElementById("answers");
    questions.innerHTML = '';
    answers.innerHTML = '';

    var tag = document.createElement("p");
    var text = document.createTextNode("Fin de la partie, le gagnant est : " + winner + ". Félicitation !");
    tag.appendChild(text);
    questions.appendChild(tag);
    computeScore(scores);
});

