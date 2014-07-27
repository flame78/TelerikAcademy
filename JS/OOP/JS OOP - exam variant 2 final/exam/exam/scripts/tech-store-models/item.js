/// <reference path="../libs/require.js" />
define([''], function () {
    'use strict';

    var Item;

    Item = (function () {
        var TYPES,
            MIN_NAME_LENGTH,
            MAX_NAME_LENGTH;

        MIN_NAME_LENGTH = 6;
        MAX_NAME_LENGTH = 40;

        TYPES = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'];

        function validateName(name) {
            var nameLength;

            if (typeof (name) !== 'string') {
                throw new Error('The item name must be a string');
            }

            nameLength = name.trim().length;

            if (nameLength < MIN_NAME_LENGTH || nameLength > MAX_NAME_LENGTH) {
                throw new Error(
                    'The item name length must be between ' +
                   MIN_NAME_LENGTH +
                    ' and ' +
                    MAX_NAME_LENGTH +
                    ' characters');
            }
        }

        function validateType(type) {
            var i, len, correctType;

            if (typeof (type) !== 'string') {
                throw new Error('The type name must be a string');
            }

            correctType = false;

            for (i = 0, len = TYPES.length; i < len; i += 1) {

                if (TYPES[i] === type) {
                    correctType = true;
                    break;
                }
            }

            if (!correctType) {
                throw new Error('Type is incorrect');
            }

        }

        function validatePrice(price) {

            if (typeof (price) !== 'number') {
                throw new Error('The price of item must be a decimal floating-point number');
            }
        }

        function Item(type, name, price) {
            validateName(name);
            this.name = name;
            validateType(type);
            this.type = type;
            validatePrice(price);
            this.price = price;
        }

        Item.prototype = {
            getTypes: function () {
                return TYPES.slice(0)
            }

        };

        return Item;
    }());


    return Item;
});