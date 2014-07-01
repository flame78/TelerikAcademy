define(function () {
    'use strict';
    var Container;
    Container = (function () {

        function Container() {
            this.sections = [];
        }

        Container.prototype = {

            add: function (section) {
                this.sections.push(section);
            },

            getData: function () {
                return this.sections;
            }
        }
        return Container;
    }());
    return Container;
});