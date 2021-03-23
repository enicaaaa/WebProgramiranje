import {Garaza} from "./Garaza.js"

//const Garaza1 = new Garaza("JP Nis","Bulevar Nemanjica", "68A",3,4);
//const Garaza2 = new Garaza("Enina garaza", "Obilicev venac","78",5,10);

//Garaza1.crtajGarazu(document.body);
//Garaza2.crtajGarazu(document.body);

fetch("https://localhost:5001/Garage/PreuzmiGaraze").then(p => {
    p.json().then(data => {
        data.forEach(garaza => {
            var Garaza1 = new Garaza(garaza.naziv, garaza.ulica ,garaza.broj ,garaza.broj_mesta ,garaza.broj_nivoa);
            Garaza1.crtajGarazu(document.body);
        });
    });
});
