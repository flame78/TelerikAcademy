define(['./section'], function (Section) {
    'use strict';
    var Container;

    Container = (function () {

        function Container() {
            this._sections = [];
        }

        return Container;
    }());

    Container.prototype.add = function (section) {

            if (section instanceof Section) {
                this._sections.push(section);
            }
            else {
                throw new TypeError('You must supply an object of the Section type.')
            }
        }

    Container.prototype.getData = function () {
        var result = [];

        for (var index in this._sections) {
            result.push(this._sections[index].getData());
        }
        return result;
        }

    return Container;
});