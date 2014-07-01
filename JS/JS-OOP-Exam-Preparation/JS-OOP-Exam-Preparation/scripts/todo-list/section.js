define(['./item'], function (Item) {
    'use strict';
    var Section;

    Section = (function () {

        function Section(title) {
            if (typeof (title) == "string") {
                this._title = title;
                this._items = [];
            }
            else {
                throw new TypeError('The title of the section should be String');
            }
        }

        return Section;
    }());

    Section.prototype.add = function (item) {

        if (item instanceof Item) {
            this._items.push(item);
        }
        else {
            throw new TypeError('The item of the section should be Item type');
        }
    };

    Section.prototype.getData = function () {

        var resultItems = [];

        for (var index in this._items) {
            resultItems.push(this._items[index].getData());
        }

        return {
            title: this._title,
            items: resultItems
        }
    };

    return Section;
});

