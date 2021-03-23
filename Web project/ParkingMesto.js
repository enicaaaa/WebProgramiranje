import {Garaza} from "./Garaza.js"
import {Vozilo} from "./Vozilo.js"


export class ParkingMesto {
    constructor(vozilo, vreme, tip){  //ime, prezime, brTablica, telefon, vreme, tip


        this.vozilo = vozilo;
        /*this.ime = ime;
        this.prezime = prezime;
        this.brTablica = brTablica;
        this.telefon = telefon;*/
        this.vreme = vreme;
        this.tip = tip; //slobodno/zauzeto
        this.miniKontejner = null;
    }

    vratiBoju(){
        if(this.tip !== true)
            return "white";
        else
            return "rgb(110, 18, 22)";
    }

    crtajJednuLokaciju(host){

        this.miniKontejner = document.createElement("div");
        this.miniKontejner.addEventListener("click", () => {
            confirm(` Ovde je parkirano vozilo sa registarskom oznakom ${this.vratiTablicu()}.\n Vlasnik ovog vozila je ${this.vratiImeVlasnika()} ${this.vratiPrezimeVlasnika()}.\n Njegov kontakt telefon je ${this.vratiTelefon()}`);
        });
        this.miniKontejner.className = "mesto";
        this.miniKontejner.innerHTML = "P";
        this.miniKontejner.style.backgroundColor = this.vratiBoju();
        host.appendChild(this.miniKontejner);
    }
    
    zauzmiParkingMesto(vozilo, vreme){ //ime, prezime,tablice, brojTel, vreme
        /*this.ime = ime;
        this.prezime = prezime;
        this.brTablica = tablice;
        this.telefon = brojTel;*/
        this.vozilo = vozilo;
        this.vreme = vreme;
        this.tip = true;
        this.miniKontejner.innerHTML = "X";
        this.miniKontejner.style.backgroundColor = this.vratiBoju();
        //console.log("pozvana zauzmi");
    }   

    oslobodiParkingMesto(){ 
        /*this.ime = undefined;
        this.prezime = undefined;
        this.brTablica = undefined;
        this.telefon = undefined;*/
        this.vozilo.ime = undefined;
        this.vozilo.prezime = undefined;
        this.vozilo.registarskaOznaka = undefined;
        this.vozilo.brojTelefona = undefined;
        this.vreme = "";
        this.tip = false;
        this.miniKontejner.innerHTML = "P";
        this.miniKontejner.style.backgroundColor = this.vratiBoju();
    }

    pronadjiMesto(){ //resiti ovu funkciju!!!!!!!!! opacity ostaje u nastavku koriscenja aplikacije
        //this.miniKontejner.style.opacity = 0.5;
        let div = this.miniKontejner;
        div.style.opacity = 0.5;
        if(div.style.opacity == 0.5){
            div.addEventListener("mousemove", function(){
                div.style.opacity = 1;
           });
        }
        confirm("Klikom na okej prikazace se mesto vaseg vozila u nasoj garazi.");
    }

    vratiTablicu(){
        //return this.brTablica;
        return this.vozilo.registarskaOznaka;
    }

    vratiImeVlasnika(){
        return this.vozilo.ime;
    }

    vratiPrezimeVlasnika(){
        return this.vozilo.prezime;
    }

    vratiTelefon(){
        return this.vozilo.brojTelefona;
    }

    vratiVreme(){
        return this.vreme;
    }
}