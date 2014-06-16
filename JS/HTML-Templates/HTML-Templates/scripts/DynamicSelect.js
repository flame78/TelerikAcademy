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

$('#select-container').append(Handlebars.compile($('#select-template').text())({ items: items }));
