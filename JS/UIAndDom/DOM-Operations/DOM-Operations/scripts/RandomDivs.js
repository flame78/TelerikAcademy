function randomDivs (numberOfDivs){
    var documentFragment = document.createDocumentFragment();
    var divTemplate = document.createElement('div');
    var strong = document.createElement('strong');

    divTemplate.style.position = 'absolute';
    divTemplate.style.zIndex = 2;
    strong.innerHTML = 'div'
    divTemplate.appendChild(strong);

    for (var i = 0; i < numberOfDivs; i++) {

        divTemplate.style.width = randomNumber(20, 100) + 'px';
        divTemplate.style.height = randomNumber(20, 100) + 'px';
        divTemplate.style.backgroundColor = randomColor();
        divTemplate.style.color = randomColor();
        divTemplate.style.top = randomNumber(0, window.innerHeight) + 'px';
        divTemplate.style.left = randomNumber(0, window.innerWidth) +'px';
        divTemplate.style.borderRadius = randomNumber() + 'px';
        divTemplate.style.borderColor = randomColor();
        divTemplate.style.borderWidth = randomNumber(1, 20) + 'px';

        documentFragment.appendChild(divTemplate.cloneNode(true));
    }

    document.body.appendChild(documentFragment);
}
