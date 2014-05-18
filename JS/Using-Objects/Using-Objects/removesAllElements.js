Array.prototype.remove = function (elementToRemove) {

    result = [];

    for (var i = 0 ; i < this.length; i++) {
        if (this[i] !== elementToRemove) {
            result.push(this[i]);
        }
    }
    this[0] = result;
    this.length=1;
};

function removesAllElements() {

    var arr = document.getElementById('arr2').value.split(',');
    var element = document.getElementById('el2').value;

    debugger;

    arr.remove(element);

    console.log(arr);

    alert(arr.join(','));



}