function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);

    var docFrag = document.createDocumentFragment();

    var contDiv = document.createElement('div');
    contDiv.className = 'ImagesPreviewer';
    contDiv.style.width = '850px';


    // preview
    var divLeft = document.createElement('div');
    divLeft.className = 'preview';
    divLeft.style.display = 'inline-block';
    divLeft.style.width = '640px';
    divLeft.style.cssFloat = 'left';

    var h1 = document.createElement('h1');
    h1.className='name';
    h1.style.textAlign = 'center';
    h1.style.display = 'block';
    h1.innerText = items[0].title;

    var img = document.createElement('img');
    img.style.display = 'block';
    img.style.width = '630px';
    img.style.verticalAlign = 'middle';
    img.style.borderRadius = '20px';
    img.src = './' + items[0].url;

    divLeft.appendChild(h1);
    divLeft.appendChild(img);
    contDiv.appendChild(divLeft);


    // selection 
    var divRight = document.createElement('div');
    divRight.className = 'selection';
    divRight.style.display = 'inline-block';
    divRight.style.height = '550px';
    divRight.style.width = '180px';
    divRight.style.overflowX = 'scroll';
    divRight.style.overflowY = 'hiden';


    var tmplSpan = document.createElement('span');
    tmplSpan.innerText = 'Filter';
    tmplSpan.style.textAlign = 'center';
    tmplSpan.style.display = 'block';

    var filterInput = document.createElement('input');
    filterInput.className = 'filterInput';
    filterInput.style.display = 'block';
    filterInput.addEventListener('keyup', onFilterChange);

    divRight.appendChild(tmplSpan);
    divRight.appendChild(filterInput);

    var tmplImg = document.createElement('img');
    var tmplH4 = document.createElement('h4');
    tmplH4.style.textAlign = 'center';
    tmplH4.style.display = 'block';
    tmplH4.style.margin = '0';
    tmplImg.style.display = 'block';
    tmplImg.style.width = '150px';
    tmplImg.style.borderRadius = '5px';

    var tmplDiv = document.createElement('div');
    tmplDiv.className = 'item';
    tmplDiv.style.padding = '5px';
    tmplDiv.style.display = 'block';
    tmplDiv.appendChild(tmplH4);
    tmplDiv.appendChild(tmplImg);

    for (var i = 0; i < items.length; i++) {
        tmplH4.innerText = items[i].title;
        tmplImg.src = './' + items[i].url;
        divRight.appendChild(tmplDiv.cloneNode(true));
    }

    contDiv.appendChild(divRight);
    docFrag.appendChild(contDiv);

    var boxes = docFrag.querySelectorAll('.item');

    for (var i = 0; i < boxes.length; i += 1) {
        boxes[i].addEventListener('click', onBoxClick);
        boxes[i].addEventListener('mouseover', onBoxMouseover);
        boxes[i].addEventListener('mouseout', onBoxMouseout);
    }

    container.appendChild(docFrag);

    function onBoxMouseout(ev) {
        this.style.background = '#FFF';
    }

    function onBoxMouseover(ev) {
            this.style.background = '#CCC';
    }

    function onBoxClick(ev) {
        h1.innerText = this.innerText;
        img.src = this.querySelector('img').src;;
        this.style.background = '#888';
    }

    function onFilterChange(ev) {

        console.log(filterInput.value.toUpperCase());
        

        var showedElemts = 0;
        for (var i = 0; i < boxes.length; i += 1) {
            boxes[i].style.display = 'block';
            showedElemts++;
            if (boxes[i].innerText.toUpperCase().indexOf(filterInput.value.toUpperCase()) < 0) {

                console.log(boxes[i].innerText.toUpperCase());

                boxes[i].style.display = 'none';
                showedElemts--;
            }
        }
        if (showedElemts == 0) {
            for (var i = 0; i < boxes.length; i += 1) {
                boxes[i].style.display = 'block';
            }
        }
    }
}