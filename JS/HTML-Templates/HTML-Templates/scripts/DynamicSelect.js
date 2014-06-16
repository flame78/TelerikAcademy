/// <reference path="handlebars-v1.3.0.js" />
/// <reference path="jquery-2.1.1.js" />

var items = [{
        value: 1,
        text: 'One'
    },
    {
        value: 2,
        text: 'Two'
    },
    {
        value: 1,
        text: 'One'
    },
    {
        value: 2,
        text: 'Two'
    },
    {
        value: 1,
        text: 'One'
    },
    {
        value: 2,
        text: 'Two'
    },
    {
        value: 3,
        text: 'Three'
    },
    {
        value: 4,
        text: 'Four'
    },
    {
        value: 5,
        text: 'Five'
    }];


console.log($('#select-template').text());
var selectTemplate = Handlebars.compile($('#select-template').text());
var selectHTML = selectTemplate({ items: items });
console.log(selectHTML);
$('#select-container').append(selectHTML);
