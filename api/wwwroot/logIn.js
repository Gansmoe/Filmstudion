import { printMenu } from "./menu.js";
import { printFilmData } from "./films.js";

const url = "http://localhost:5000"

export let token = "";

export function loginPage() {
    const body = document.getElementById("body");
    const menuBar = document.getElementById("menuBar");
    body.innerHTML="";
    menuBar.innerHTML="";
    createDiv();
    const div = document.getElementById("div");
    const form = document.createElement("form");

    const user = document.createElement("input");
    user.type = "text";
    user.id = "user";
    form.appendChild(user);
    div.appendChild(form);

    const psw = document.createElement("input");
    psw.type = "password";
    psw.id = "psw";
    form.appendChild(psw);
    div.appendChild(form);

    const btn = document.createElement("button");
    btn.id = "inBtn";
    const text = document.createTextNode("Logga in");
    btn.appendChild(text);
    div.appendChild(btn);

    const inBtn = document.getElementById("inBtn");

    inBtn.addEventListener("click", function () {
        const user = document.getElementById("user").value;
        const psw = document.getElementById("psw").value;

        deleteDiv();
        logIn(user, psw);


    })
}

function logIn(user, psw) {

    let userData = {
        UserName: user,
        Password: psw
    }
    const getData = async () => {
        const response = await fetch(url + "/api/users/authenticate", {
            method: 'POST',
            headers: {'Content-type': 'application/json; charset=UTF-8'},
            body: JSON.stringify(userData)
        });
        const data = await response.json();

        console.log(data);

        token = data.token;

        console.log(token);

        localStorage.setItem("token", token);

        showWelcomePage();
    }
    getData();
};

function showWelcomePage() {

    const getData = () => {

        const menuBar = document.getElementById("menuBar");
        /* createDiv();
        const div = document.getElementById("div"); */


        const logOut = document.createElement("button");
        logOut.id = "logOut";
        const btnText = document.createTextNode("Logga ut");
        logOut.appendChild(btnText);
        menuBar.appendChild(logOut);

        printMenu();

        const allFilmsBtn = document.getElementById("allFilms");
        const logOutBtn = document.getElementById("logOut");

        allFilmsBtn.addEventListener("click", function(){
            body.innerHTML = ""
            printFilmData();
        });

        logOutBtn.addEventListener("click", function () {
            logOutReset();
        }) // Genererar en sida vid lyckad inloggning
    }
    getData();

}

function createDiv() {
    let createDiv = document.createElement("div");
    createDiv.id = "div";
    body.appendChild(createDiv);
}

function deleteDiv() {
    const divDelete = document.getElementById("div");
    divDelete.remove();
}

function logOutReset() {
    localStorage.removeItem("token");
    loginPage();
}