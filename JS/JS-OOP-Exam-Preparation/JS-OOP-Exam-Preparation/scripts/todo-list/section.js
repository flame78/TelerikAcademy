define(['todo-list/item'], function (Item) {
    'use strict';
    var Section

    Section = (function () {

        function validateTitle(title) {
            if (typeof (title) != 'string') {
                throw new TypeError('Title must be a string');
            }
            if (!title.trim()) {
                throw new Error('Title can not be empty or white space');
            }
        }

        function Section(title) {
            validateTitle(title);
            this._title = title;
            this._items = [];
        }

        Section.prototype.add = function (item) {
            if (!(item instanceof Item)) {
                throw new TypeError('Section can add only instance of Item');
            }
            this._items.push(item);
        }

        Section.prototype.getData = function () {
            var items = this._items.map(function (item) {
                return item.getData();
            });

            return {
                Title: this._title,
                Items: items
            }
        }

        return Section;
    }());

    return Section;
});