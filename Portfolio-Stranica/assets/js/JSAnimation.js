// provjera da li je element u viewportu
// ako je tada se aktivira funkcija isinview koja vraca true i pokazu se skillovi
function isInView(elem){
   return $(elem).offset().top - $(window).scrollTop() < $(elem).height() ;
}

$(window).scroll(function(){
   if (isInView($('#skills')))
   jQuery(document).ready(function(){
     jQuery('.skillbar').each(function(){
       jQuery(this).find('.skillbar-bar').animate({
         width:jQuery(this).attr('data-percent')
       },6000);
     });
   });

})


// goto top button
var btn = $('#button');

$(window).scroll(function() {
  if ($(window).scrollTop() > 300) {
    btn.addClass('show');
  } else {
    btn.removeClass('show');
  }
});

btn.on('click', function(e) {
  e.preventDefault();
  $('html, body').animate({scrollTop:0}, '300');
});

// vrijeme servera
function startTime() {
  var today = new Date();
  var h = today.getHours();
  var m = today.getMinutes();
  var s = today.getSeconds();
  m = checkTime(m);
  s = checkTime(s);
  document.getElementById('vrijeme').innerHTML = " ST = " + h + ":" + m + ":" + s;
  var t = setTimeout(startTime, 500);
}
function checkTime(i) {
  if (i < 10) {i = "0" + i};  // add zero in front of numbers < 10
  return i;
}


// SLJDECA FUNKCIJA PRIKAZUJE SLOVA PO REDU
function typeEffect(element, speed) {
	var text = element.innerHTML;
	element.innerHTML = "";
	console.log("Počinjem pisati slova");

	var i = 0;
	var timer = setInterval(function() { // provjera da li je *, ako je onda se stavlja novi red
		if(text.charAt(i) == "*"){
			var br = document.createElement("br");
			element.appendChild(br);

			i++;
		}
    else if (i < text.length) {
      element.append(text.charAt(i));
      i++;
    } else {
      clearInterval(timer);
			console.log("gotov sam sa pisanjem slova");
    }
  }, speed);
}


// application
var speed = 100;
var h1 = document.querySelector('h4');
// var p = document.querySelector('p');
var delay = h1.innerHTML.length * speed + speed;

// type affect to header
typeEffect(h1, speed);


// type affect to body
// setTimeout(function(){
//   p.style.display = "inline-block";
//   typeEffect(p, speed);
// }, delay);
