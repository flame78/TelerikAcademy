define(['todo-list/section'], function (Section) {
    'use strict';
    var Container

    Container = (function () {

        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function (section) {
            if (!(section instanceof Section)) {
                throw new TypeError('Can add only instance of Section');
            }

            this._sections.push(section);

            return this;
        }

        Container.prototype.getData = function () {
            var sections = this._sections.map(function (section) {
                return section.getData();
            });

            return sections;
        }

        return Container;
    }());

    return Container;
});