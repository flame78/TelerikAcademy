define(function () {
    'use strict';
    var Item;
    Item = (function () {

        function Item(content) {
            if (typeof(content) == "string") {
                this._itemContent = content;
            }
            else {
                throw new TypeError('The content of the item should be String')
            }
        }

        return Item;
    })();

    Item.prototype.getData = function () {
       
        return {
            content: this._itemContent
        };
            
    };

    return Item;
});