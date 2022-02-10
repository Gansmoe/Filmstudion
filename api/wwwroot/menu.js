
export const printMenu = () => {
    const allFilmsButton = document.createElement("button");
    allFilmsButton.id = "allFilms";
    allFilmsButton.innerText = "Visa alla filmer";
    menuBar.appendChild(allFilmsButton);

    /* const logInButton = document.createElement("button");
    logInButton.id = "logInBtn";
    logInButton.innerText = "Logga in";
    menuBar.appendChild(logInButton) */
}

