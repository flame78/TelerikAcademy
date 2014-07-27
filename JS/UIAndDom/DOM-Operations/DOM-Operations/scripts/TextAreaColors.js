window.onload = function () {
    var fontColorInput = document.getElementById('FontColor');
    var backgroundColorInput = document.getElementById('BackgroundColor');
    var textArea = document.getElementById('TextArea');

    fontColorInput.onchange = function () {
        textArea.style.color = fontColorInput.value;
    }

    backgroundColorInput.onchange = function () {
        textArea.style.backgroundColor = backgroundColorInput.value;
    }

}