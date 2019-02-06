
function UcitajJezik(){
  var lng = localStorage.getItem('lang');
  console.log(lng);

  // provjera koji jezik je spremljen u localstorage
  if(lng == "en"){
    document.getElementById("langselector").selectedIndex = 0;
  }
  else if(lng == "cro"){
    document.getElementById("langselector").selectedIndex = 1;
  }
  else if(lng == "slo"){
    document.getElementById("langselector").selectedIndex = 2;
  }
  else{
    document.getElementById("langselector").selectedIndex = 0;
  }

  // tu dolazi za svaki jezik drugaciji sadrzaj
  switch (lng)
    {
      // tu dolazi engleski tekst
    case "en":

      // ovo je za navigaciju
      document.getElementById("n1").innerHTML = "Home";
      document.getElementById("n2").innerHTML = "News";
      document.getElementById("n3").innerHTML = "Partners";
      document.getElementById("n4").innerHTML = "Interreg";
      document.getElementById("n5").innerHTML = "Contact";
      document.getElementById("n6").innerHTML = "Game";

    break;
    case "cro":

      // ovo je za navigaciju
      document.getElementById("n1").innerHTML = "Naslovna";
      document.getElementById("n2").innerHTML = "Novosti";
      document.getElementById("n3").innerHTML = "Partneri";
      document.getElementById("n4").innerHTML = "Interreg";
      document.getElementById("n5").innerHTML = "Kontakt";
      document.getElementById("n6").innerHTML = "Igra";


    break;
    case "slo":
      // ovo je za navigaciju
      document.getElementById("n1").innerHTML = "Domov";
      document.getElementById("n2").innerHTML = "Novice";
      document.getElementById("n3").innerHTML = "Partnerji";
      document.getElementById("n4").innerHTML = "Interreg";
      document.getElementById("n5").innerHTML = "Kontakt";
      document.getElementById("n6").innerHTML = "Igra";


    break;
    // tu dolazi engleski tekst po default-u ukoliko je stranica ucitana prvi put i nije se promjenio jezik
    default:

      document.getElementById("n1").innerHTML = "Home";


    }
  }

  // funkcija za provjeru selektiranog te zapis u localStorage
  // localstorage je smjesten na bowseru te se pod kljucem zapisuju podaci
  // kljuc je lang te parametri su en, hr i null
  function PostaviJezik(value){
    if(value == "en"){
        localStorage.setItem('lang','en');
    }
    else if(value == "cro"){
      localStorage.setItem('lang','cro');
    }
    else if(value == "slo"){
      localStorage.setItem('lang','slo');
    }
    // reload nakon selekta jezika da se sav sadrzaj postavi
    window.location.reload(false);


  }
