import { ParkingMesto } from "./ParkingMesto.js";
import { Vozilo } from "./Vozilo.js";

export class Garaza{
    constructor(naziv, ulica, broj, brojNivoa, brojMesta){
        this.naziv = naziv;
        this.ulica = ulica;
        this.broj = broj; 
        this.brojMesta = brojMesta;
        this.brojNivoa = brojNivoa;
        this.kontejner = null;
        this.parkingMesta = [];
        this.maxParkingMesta = this.brojMesta * this.brojNivoa;
        this.trenutno = 0;
    }

    crtajGarazu(host){
        if(!host)
            throw new Error("Roditeljski element ne postoji.");
        this.kontejner = document.createElement("div");
        this.kontejner.className = "kontejner";
        host.appendChild(this.kontejner);

        this.crtajPodatke(this.kontejner);
        this.crtajFormu(this.kontejner);
    }

    crtajPodatke(host){
        const nas = document.createElement("h1");
        nas.innerHTML = "-Dobrodošli!-";
        host.appendChild(nas);
        
        const kontFormaPodaci = document.createElement("div");
        kontFormaPodaci.className = "kontFormaPodaci";
        host.appendChild(kontFormaPodaci);

        let divP = document.createElement("div");
        divP.className = "divPodaci";

        //labela "naziv"
        let labela = document.createElement("labela");
        labela.className = "lab";
        labela.innerHTML = "Naziv garaze: ";
        divP.appendChild(labela);

        //labela za ime garaze
        labela = document.createElement("labela");
        labela.className = "podaci";
        labela.innerHTML = this.naziv;
        divP.appendChild(labela);

        kontFormaPodaci.appendChild(divP);

        divP = document.createElement("div");
        divP.className = "divPodaci";


        //labela "ulica"
        labela = document.createElement("labela");
        labela.className = "lab";
        labela.innerHTML = "Ulica: ";
        divP.appendChild(labela);

        //labela za ime ulice 
        labela = document.createElement("labela");
        labela.className = "podaci";
        labela.innerHTML = this.ulica;
        divP.appendChild(labela);

        kontFormaPodaci.appendChild(divP);

        divP = document.createElement("div");
        divP.className = "divPodaci";
        
        //labela "broj"
        labela = document.createElement("labela");
        labela.className = "lab";
        labela.innerHTML = "Broj: ";
        divP.appendChild(labela);

        labela = document.createElement("labela");
        labela.className = "podaci";
        labela.innerHTML = this.broj;
        divP.appendChild(labela);

        kontFormaPodaci.appendChild(divP);
    }


    crtajFormu(host){
        const parentKontFormaDiv = document.createElement("div");
        parentKontFormaDiv.className = "parent";
        host.appendChild(parentKontFormaDiv);

        const kontForma = document.createElement("div");
        kontForma.className = "kontForma";
        parentKontFormaDiv.appendChild(kontForma);

        const razdeljak = document.createElement("div");
        razdeljak.className = "razdeljak";
        parentKontFormaDiv.appendChild(razdeljak);

        var labela1 = document.createElement("h3");
        labela1.className = "unosPodataka";
        labela1.innerHTML = "-Unesite podatke-";
        kontForma.appendChild(labela1);

        labela1 = document.createElement("labela");
        labela1.className = "labelaForma";
        labela1.innerHTML = "Ime: ";
        kontForma.appendChild(labela1);

        let inp = document.createElement("input");
        inp.className = "ime";
        kontForma.appendChild(inp);

        labela1 = document.createElement("labela");
        labela1.className = "labelaForma";
        labela1.innerHTML = "Prezime: ";
        kontForma.appendChild(labela1);

        inp = document.createElement("input");
        inp.className = "prezime";
        kontForma.appendChild(inp);

        labela1 = document.createElement("labela");
        labela1.className = " labelaForma";
        labela1.innerHTML = "Registarska tablica: ";
        kontForma.appendChild(labela1);

        inp = document.createElement("input");
        inp.className = "tablice";
        kontForma.appendChild(inp);

        labela1 = document.createElement("labela");
        labela1.className = "labelaForma";
        labela1.innerHTML = "Broj telefona: ";
        kontForma.appendChild(labela1);

        inp = document.createElement("input");
        inp.className = "brojTelefona";
        kontForma.appendChild(inp);

        labela1 = document.createElement("labela");
        labela1.className = "labelaForma";
        labela1.innerHTML = "Vreme: ";
        kontForma.appendChild(labela1);

        let divRb = document.createElement("div");
        divRb.className = "divZaRb";

        let radio = document.createElement("input");
        radio.className = "radio";
        radio.type = "radio";
        radio.name = this.naziv;
        radio.value = "1";
        divRb.appendChild(radio);

        labela1 = document.createElement("labela");
        labela1.className = "sat";
        labela1.innerHTML = "1h ";
        divRb.appendChild(labela1);

        radio = document.createElement("input");
        radio.className = "radio";
        radio.type = "radio";
        radio.name = this.naziv;
        radio.value = "24";
        divRb.appendChild(radio);

        labela1 = document.createElement("labela");
        labela1.className = "sat";
        labela1.innerHTML = "24h ";
        divRb.appendChild(labela1);

        kontForma.appendChild(divRb);

        const dugmeParkiraj = document.createElement("button");
        dugmeParkiraj.innerHTML = "Parkiraj";
        dugmeParkiraj.classList.add("labelaForma","dugmeParkiraj");
        kontForma.appendChild(dugmeParkiraj);

        dugmeParkiraj.onclick=(ev)=>{

            const ime = this.kontejner.querySelector(".ime").value;
            const prezime = this.kontejner.querySelector(".prezime").value;
            const tablice = this.kontejner.querySelector(".tablice").value;
            const brojTel = this.kontejner.querySelector(".brojTelefona").value;

            /*vozilo.ime = ime;
            vozilo.prezime = prezime;
            vozilo.registarskaOznaka = tablice;
            vozilo.brojTelefona = brojTel;*/

            const vozilo = new Vozilo(tablice, ime, prezime, brojTel);

            const vreme = this.kontejner.querySelector(`input[name='${this.naziv}']:checked`); 
            if(vreme === null){
                alert("Molim vas unesite zeljeno vreme.");
                return;
            }
            for(let i = 0; i < this.maxParkingMesta; i++){
                if(this.parkingMesta[i].vratiTablicu() === tablice){
                    alert("Vozilo sa ovom registarskom oznakom vec postoji. Molim vas proverite da li ste uneli ispravno vasu registarsku oznaku.")
                    return;
                }
            }
            if(tablice.length != 7){
                alert("Molim Vas unesite vazecu registarsku oznaku. Registarska oznaka mora imati 7 karaktera.");
                return;
            }
            for(let i = 0; i <= this.maxParkingMesta; i++){
                if(this.parkingMesta[i].vratiTablicu() == undefined){
                    //console.log(this.parkingMesta[i].vratiTablicu());  vraca undefined, tacno!
                    this.parkingMesta[i].zauzmiParkingMesto(vozilo, vreme);
                    this.trenutno++;
                    break;
                }
                else if(this.trenutno > this.maxParkingMesta){
                    alert(`U nasoj garazi nema vise slobodnih parking mesta. Njen kapacitet je ${this.maxParkingMesta}. Molim Vas pokusajte kasnije.`);
                    return;
                }
            }
            /*if(this.trenutno > (this.brojNivoa*this.brojMesta)){
                alert(`U nasoj garazi nema vise slobodnih parking mesta. Njen kapacitet je ${this.maxParkingMesta}. Molim Vas pokusajte kasnije.`);
                return;
            }*/
            console.log(this.parkingMesta);
            this.clearFieldsParkiraj();
            
        }

        const dugmeIsparkiraj = document.createElement("button");
        dugmeIsparkiraj.innerHTML = "Isparkiraj";
        dugmeIsparkiraj.classList.add("labelaForma","dugmeParkiraj");
        kontForma.appendChild(dugmeIsparkiraj);

        
        dugmeIsparkiraj.onclick=(ev)=>{
        
            const tablice = this.kontejner.querySelector(".tablice").value;

            if(tablice.length != 7){
                alert("Molim Vas unesite vazecu registarsku oznaku. Registarska oznaka mora imati 7 karaktera.");
                return;
            }
            for(let i = 0; i < this.maxParkingMesta; i++){ 
                if(this.parkingMesta[i].vratiTablicu() === tablice){
                    console.log(this.parkingMesta[i].vratiTablicu());
                    this.parkingMesta[i].oslobodiParkingMesto();
                    console.log(this.parkingMesta);
                    break;
                }  
                else
                    alert("Vozilo sa ovom regostarskom oznakom ne postoji u nasoj garazi.");
                    break;                              
            }
            this.clearFieldsIsparkiraj();
        }

        const dugmeNadji = document.createElement("button");
        dugmeNadji.innerHTML = "Pronadji vozilo";
        dugmeNadji.classList.add("labelaForma","dugmeParkiraj");
        kontForma.appendChild(dugmeNadji);

        dugmeNadji.onclick=(ev)=>{
            const tablice = this.kontejner.querySelector(".tablice").value;
            if(tablice.length != 7){
                alert("Molim Vas unesite vazecu registarsku oznaku. Registarska oznaka mora imati 7 karaktera.");
                return;
            }
            for(let i = 0; i < this.maxParkingMesta; i++){ 
                if(this.parkingMesta[i].vratiTablicu() === tablice){
                    this.parkingMesta[i].pronadjiMesto();
                    console.log(this.parkingMesta);
                    break;
                }  
                else
                    alert("Vozilo sa ovom regostarskom oznakom ne postoji u nasoj garazi.");
                    break;                              
            }
            this.clearFieldsIsparkiraj();
        }

        this.crtajParkingMesta(parentKontFormaDiv);
    }

    clearFieldsParkiraj(){
        let ime = document.getElementsByClassName("ime");
        ime[0].value = "";
        let prezime = document.getElementsByClassName("prezime");
        prezime[0].value = "";
        let tablice = document.getElementsByClassName("tablice");
        tablice[0].value = "";
        let brojTel = document.getElementsByClassName("brojTelefona");
        brojTel[0].value = "";
        document.querySelector(`input[name='${this.naziv}']:checked`).checked = false;
    }

    clearFieldsIsparkiraj(){
        let tablice = document.getElementsByClassName("tablice");
        tablice[0].value = "";
        
    }

    dodajParkingMesto(P){
        this.parkingMesta.push(P);
    }

    crtajParkingMesta(host){
        const kontParkingMesta = document.createElement("div");
        kontParkingMesta.className = "kontParkingMesta";
        host.appendChild(kontParkingMesta);

        let labela2 = document.createElement("h2");
        labela2.className = "hedParkMesta";
        labela2.innerHTML = "-Parking mesta-";
        kontParkingMesta.appendChild(labela2);

        let red;
        let mesto;

        for(let i = 1; i <= this.brojNivoa; i++){

            labela2 = document.createElement("label");
            labela2.className = "nivo";
            labela2.innerHTML = i + "." + " nivo: ";
            kontParkingMesta.appendChild(labela2);

            red = document.createElement("div");
            red.className = "red";
            kontParkingMesta.appendChild(red);

            const v = new Vozilo();
            for(let j = 1; j <= this.brojMesta; j++){
                mesto = new ParkingMesto(v,"","");
                this.dodajParkingMesto(mesto);
                mesto.crtajJednuLokaciju(red);
            }
        }
    }

}
