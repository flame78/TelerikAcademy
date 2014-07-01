define(function () {
    'use strict';
    var Section;
    Section = (function () {

        function Section(title) {
            this.title = title;
            this.items = [];
        }

        Section.prototype = {

            add: function (item) {
                this.items.push(item);
            },

            getData: function () {
                return this.title;
            }
        }
        return Section;
    }());
    return Section;
});

