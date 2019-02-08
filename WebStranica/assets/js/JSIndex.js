function UcitajJezik(){
  var lng = localStorage.getItem('lang');
  // console log zapisuje u console koji jezik je odabran za lakšu kontrolu nad kodom
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

      document.getElementById("zastava").src = "Slike/Zastave/UKflag.png";
      // ovo je za tekst dobrodoslice
      document.getElementById("DobrodosliTekst").innerHTML = "Welcome to our page";
      // ovo je za navigaciju
      document.getElementById("n1").innerHTML = "Home";
      document.getElementById("n2").innerHTML = "About Project";
      document.getElementById("n3").innerHTML = "Partners";
      document.getElementById("n4").innerHTML = "Interreg";
      document.getElementById("n5").innerHTML = "Contact";
      document.getElementById("n6").innerHTML = "Game";
      // ovo je za dropdown jezike
      document.getElementById("jezikdropdown1").innerHTML = "🇬🇧 English";
      document.getElementById("jezikdropdown2").innerHTML = "🇭🇷 Croatian";
      document.getElementById("jezikdropdown3").innerHTML = "🇸🇮 Slovenian";
      // ovo je za visit us on (social media)
      document.getElementById("PosjetiteNas").innerHTML = "Visit us";
      // ovo je za footer
      document.getElementById("FooterPartneri").innerHTML = "Project partners";


    break;
    case "cro":

    document.getElementById("zastava").src = "Slike/Zastave/CROflag.png";
    // ovo je za tekst dobrodoslice
    document.getElementById("DobrodosliTekst").innerHTML = "Dobrodošli na našu stranicu";
    // ovo je za navigaciju
    document.getElementById("n1").innerHTML = "Naslovna";
    document.getElementById("n2").innerHTML = "O projektu";
    document.getElementById("n3").innerHTML = "Partneri";
    document.getElementById("n4").innerHTML = "Interreg";
    document.getElementById("n5").innerHTML = "Kontakt";
    document.getElementById("n6").innerHTML = "Igra";
    // ovo je za dropdown jezike
    document.getElementById("jezikdropdown1").innerHTML = "🇬🇧 Engleski";
    document.getElementById("jezikdropdown2").innerHTML = "🇭🇷 Hrvatski";
    document.getElementById("jezikdropdown3").innerHTML = "🇸🇮 Slovenski";
    // ovo je za visit us on (social media)
    document.getElementById("PosjetiteNas").innerHTML = "Posjetite nas na";
    // ovo je za footer
    document.getElementById("FooterPartneri").innerHTML = "Partneri Projekta";

    break;
    case "slo":

    document.getElementById("zastava").src = "Slike/Zastave/SLOflag.png";
    // ovo je za tekst dobrodoslice
    document.getElementById("DobrodosliTekst").innerHTML = "Dobrodošli na naši spletni strani";
    // ovo je za navigaciju
    document.getElementById("n1").innerHTML = "Domov";
    document.getElementById("n2").innerHTML = "O projektu";
    document.getElementById("n3").innerHTML = "Partnerji";
    document.getElementById("n4").innerHTML = "Interreg";
    document.getElementById("n5").innerHTML = "Kontakt";
    document.getElementById("n6").innerHTML = "Igra";
    // ovo je za dropdown jezike
    document.getElementById("jezikdropdown1").innerHTML = "🇬🇧 Angleščina";
    document.getElementById("jezikdropdown2").innerHTML = "🇭🇷 Hrvaški";
    document.getElementById("jezikdropdown3").innerHTML = "🇸🇮 Slovenščina";
    // ovo je za visit us on (social media)
    document.getElementById("PosjetiteNas").innerHTML = "Obiščite nas";
    // ovo je za footer
    document.getElementById("FooterPartneri").innerHTML = "Projektni partnerji";

    break;
    // tu dolazi engleski tekst po default-u ukoliko je stranica ucitana prvi put i nije se promjenio jezik
    default:

    document.getElementById("zastava").src = "Slike/Zastave/UKflag.png";
    // ovo je za tekst dobrodoslice
    document.getElementById("DobrodosliTekst").innerHTML = "Welcome to our page";
    // ovo je za navigaciju
    document.getElementById("n1").innerHTML = "Home";
    document.getElementById("n2").innerHTML = "About Project";
    document.getElementById("n3").innerHTML = "Partners";
    document.getElementById("n4").innerHTML = "Interreg";
    document.getElementById("n5").innerHTML = "Contact";
    document.getElementById("n6").innerHTML = "Game";
    // ovo je za dropdown jezike
    document.getElementById("jezikdropdown1").innerHTML = "🇬🇧 English";
    document.getElementById("jezikdropdown2").innerHTML = "🇭🇷 Croatian";
    document.getElementById("jezikdropdown3").innerHTML = "🇸🇮 Slovenian";
    // ovo je za visit us on (social media)
    document.getElementById("PosjetiteNas").innerHTML = "Visit us";
    // ovo je za footer
    document.getElementById("FooterPartneri").innerHTML = "Project partners";


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
