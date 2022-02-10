const url = "http://localhost:5000"

const getFilmsData = async() => {
    const response = await fetch(url + "/api/films");
    const data = await response.json();
    console.log(data);
    return data;
}

export const printFilmData = async() => {
    const data = await getFilmsData();

    for(let i = 0; i<data.length; i++){
        const div = document.createElement("div");
        div.id = "film";
        const ul = document.createElement("ul");
        const liName = document.createElement("li");
        const liRelease = document.createElement("li");
        const liCountry = document.createElement("li");
        const liDirector = document.createElement("li");
        liName.innerText = "Filmtitel: " + data[i].name;
        liRelease.innerText = "Utgivningsår: " + data[i].releaseDate;
        liCountry.innerText = data[i].country;
        liDirector.innerText = data[i].director;
        ul.appendChild(liName);
        ul.appendChild(liRelease);
        ul.appendChild(liCountry);
        ul.appendChild(liDirector);
        div.appendChild(ul);
        body.appendChild(div);

    }
}