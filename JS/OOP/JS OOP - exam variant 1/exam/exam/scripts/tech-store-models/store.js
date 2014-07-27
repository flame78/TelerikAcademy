/// <reference path="../libs/require.js" />
define(['tech-store-models/item'], function (Item) {
    'use strict';

    var Store;

    Store = (function () {


        var MIN_NAME_LENGTH,
            MAX_NAME_LENGTH,
            TYPES;

        TYPES = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'];

        MIN_NAME_LENGTH = 6;
        MAX_NAME_LENGTH = 30;

        function validateName(name) {
            var nameLength;

            if (typeof (name) != 'string') {
                throw new Error('The store name must be a string');
            }

            nameLength = name.trim().length;

            if (nameLength < MIN_NAME_LENGTH || nameLength > MAX_NAME_LENGTH) {
                throw new Error(
                    'The store name length must be between ' +
                   MIN_NAME_LENGTH +
                    ' and ' +
                    MAX_NAME_LENGTH +
                    ' characters');
            }
        }

        function sortItemsAlphabeticallyByName() {

            if (this._isSortedAlphabeticallyByName) {
                return;
            }

            this._items.sort(function (a, b) {
                return (a.name < b.name ? -1 : (a.name > b.name ? 1 : 0));
            });

            this._isSortedAlphabeticallyByName = true;
            this._isSortedAscendingByPrice = false;
        }

        function sortItemsAscendingByPrice() {

            if (this._isSortedAscendingByPrice) {
                return;
            }

            this._items.sort(function (a, b) {
                return a.price - b.price;
            });

            this._isSortedAlphabeticallyByName = false;
            this._isSortedAscendingByPrice = true;
        }



        function filterByType(type, type2) {
            var i, len, result = [];
            sortItemsAlphabeticallyByName.call(this);

            for (i = 0, len = this._items.length; i < len; i += 1) {

                if (this._items[i].type == type) {
                    result.push(this._items[i]);
                }

                if (type2 && this._items[i].type == type2) {
                    result.push(this._items[i]);
                }
            }

            return result;
        }

        function Store(name) {
            validateName(name);
            this.name = name;
            this._items = [];
            this._isSortedAlphabeticallyByName = false;
            this._isSortedAscendingByPrice = false;
        }

        Store.prototype = {

            //addItem(item) – adds an item to the stock of the store. A store can keep in stock only items of type Item
            addItem: function (item) {

                if (!(item instanceof Item)) {
                    throw new Error('A store can keep in stock only items of type Item')
                }

                this._items.push(item);
                this._isSortedAlphabeticallyByName = false;
                this._isSortedAscendingByPrice = false;

                return this;
            },
            //getAll() – returns a collection of all items, sorted alphabetically
            getAll: function () {

                sortItemsAlphabeticallyByName.call(this);

                return this._items.slice(0);
            },
            //getSmartPhones() – returns a collection of only the items in stock that have type 'smart-phone', sorted alphabetically by the name of the items
            getSmartPhones: function () {
                return filterByType.call(this, 'smart-phone');
            },
            //getMobiles() – returns a collection of only the items in stock that have type either 'smart-phone' or 'tablet', sorted alphabetically by the name of the items
            getMobiles: function () {
                return filterByType.call(this, 'smart-phone', 'tablet');
            },
            //getComputers() – returns a collection of only the items in stock that have type either 'pc' or 'notebook', sorted alphabetically by the name of the items
            getComputers: function () {
                return filterByType.call(this, 'pc', 'notebook');
            },
            //filterItemsByType(filterType) – returns a collection of only the items in stock that have type equal to the given filterType (item.type === filterType), sorted alphabetically by the name of the items
            filterItemsByType: function (filterType) {
                return filterByType.call(this, filterType);
            },
            //filterItemsByPrice (options) – returns a collection of only the items that have a price from the price range in the options parameter, sorted ascending by the price of the items. The options object is optional and have optional properties min and max. 
            filterItemsByPrice: function (options) {
                var len, i, min, max, result = [];

                sortItemsAscendingByPrice.call(this);

                //o	If min is missing, it should be considered as 0
                //        o	If max is missing, it should be considered + 
                if (!options) {
                    min = 0;
                    max = +Infinity;
                }
                else if (options.min) {
                    min = options.min;
                    if (options.max) {
                        max = options.max;
                    }
                    else {
                        max = +Infinity;
                    }
                }
                else {
                    min = 0;
                    if (options.max) {
                        max = options.max;
                    }
                    else {
                        max = +Infinity;
                    }
                }

                for (i = 0, len = this._items.length; i < len; i += 1) {
                    if (min <= this._items[i].price && this._items[i].price <= max) {
                        result.push(this._items[i]);
                    }
                }


                return result;
            },
            //•	storeInstance.filterItemsByName(partOfName) – returns a collection of only the items in stock that have a name containing partOfName, sorted alphabetically by the name of the items. The search should be performed case insensitive
            filterItemsByName: function (filter) {
                var len, i, result = [];

                filter = filter.toLowerCase();

                sortItemsAlphabeticallyByName.call(this);

                for (i = 0, len = this._items.length; i < len; i += 1) {
                    if (this._items[i].name.toLowerCase().indexOf(filter) >= 0) {
                        result.push(this._items[i]);
                    }
                }

                return result;
            },
            //        •	storeInstance.countItemsByType() – returns an associative array that have as keys the types, that are of items in stock in the store, and values that are equal to the number of items with this type
            countItemsByType: function () {
                var result = {};
                var self = this;

                TYPES.forEach(function (filterType) {
                    result[filterType] = filterByType.call(self, filterType).length;
                })

                return result;
                
            }
            //        Your task is to implement both the Item and Store modules, using RequireJS and classical JavaScript OOP. Use the best practices for Classical OOP in JavaScript. After your implementation, the code in the app.js file should work.

        };

        return Store;
    }());


    return Store;
});
