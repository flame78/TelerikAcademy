
function selectDivDirectInDiv() {

    console.dir(divsInDivWithQuerySelectorAll());
    console.dir(divsInDivWithGetElementsByTagName());



}

function divsInDivWithQuerySelectorAll() {

    var divsInDiv = document.querySelectorAll('div>div');

    return divsInDiv;
}

function divsInDivWithGetElementsByTagName() {

    var div, children;
    var divsInDiv = []
    var divs = document.getElementsByTagName('div');

    for (var i = 0, length = divs.length; i < length; i += 1) {

        div = divs[i];

        for (var j = 0, len = div.children.length ; j < len; j++) {

            children = div.children[j];

            if (children.tagName == 'DIV') {
                divsInDiv.push(children);
            }
        }
    }

    return divsInDiv;
}

function printValueOfInput() {

    var inp = document.querySelector('input[type=text]');

    console.log(inp.value);
}

function changeColor() {

    var color = document.querySelector('input[type=color]');

    document.body.bgColor = color.value;
}

function shimQuerySelector() {

    if (typeof document.querySelector === 'undefined') {
        document.querySelector = function (selector) {
            var result = this.querySelectorAll(selector);
            if (result.length > 0) {
                return result[0];
            }
            else {
                return null;
            }
        };
    }

    if (typeof document.querySelectorAll === 'undefined') {
        (function (aDocument, styleSheet) {
            aDocument = document,
            styleSheet = aDocument.createStyleSheet();

            aDocument.querySelectorAll = function (selector) {
                var allElements = aDocument.all;
                var array = [];
                selector = selector.replace(/\[for\b/gi, '[htmlFor').split(',');
                for (var i = selector.length; i--;) {
                    styleSheet.addRule(selector[i], 'k:v');

                    for (var j = allElements.length; j--;) {
                        allElements[j].currentStyle.k && array.push(allElements[j]);
                    }
                    styleSheet.removeRule(0);
                }
                return array;
            };
        })();
    }

    if (typeof document.createStyleSheet === 'undefined') {
        document.createStyleSheet = (function () {
            function createStyleSheet(href) {
                var element;
                if (typeof href !== 'undefined') {
                    element = document.createElement('link');
                    element.type = 'text/css';
                    element.rel = 'stylesheet';
                    element.href = href;
                }
                else {
                    element = document.createElement('style');
                    element.type = 'text/css';
                }

                document.getElementsByTagName('head')[0].appendChild(element);
                var sheet = document.styleSheets[document.styleSheets.length - 1];

                if (typeof sheet.addRule === 'undefined')
                    sheet.addRule = addRule;

                if (typeof sheet.removeRule === 'undefined')
                    sheet.removeRule = sheet.deleteRule;

                return sheet;
            }

            function addRule(selectorText, cssText, index) {
                if (typeof index === 'undefined')
                    index = this.cssRules.length;

                this.insertRule(selectorText + ' {' + cssText + '}', index);
            }

            return createStyleSheet;
        })();
    }

    console.dir(divsInDivWithQuerySelectorAll());
    console.dir(divsInDivWithGetElementsByTagName());
}




