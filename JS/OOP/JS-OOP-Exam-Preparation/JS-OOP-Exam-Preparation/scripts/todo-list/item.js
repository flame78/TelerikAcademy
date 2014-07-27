define(function () {
    'use strict';
    var Item

    Item = (function () {

        function validateName(content) {
            if (typeof (name) != 'string') {
                throw new TypeError('Name must be a string');
            }
            if (!content.trim()) {
                throw new Error('Name cant be empty or white space')
            }
        }

        function Item(content, type) {
            validateName(content);
            this._content = content;

            if (type) {
                this.type = type;
            }
        }

        Item.prototype.getData = function () {
            return {
                content: this._content
            };
        }

        return Item;
    }());

    return Item;
});