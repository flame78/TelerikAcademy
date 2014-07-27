/// <reference path="jquery-2.1.1.js" />
/// <reference path="handlebars-v1.3.0.js" />

(function ($) {
    $.fn.templateListView = function (items) {
        var $this = $(this);

        var templateId = $this.data('template');
        var templateFunction;

        if (!templateId) {
            templateFunction = Handlebars.compile($this.html());
            $this.html('');
        }
        else {
            templateFunction = Handlebars.compile($('#' + templateId).html());
        }

        for (i = 0; i < items.length; i++){
            $this.append(templateFunction(items[i]));
        }
        return $this;
    }
}(jQuery));

var books = [
        { id: 1, title: 'JavaScript: The good parts' },
        { id: 2, title: 'Secrets of the JavaScript Ninja' },
        { id: 3, title: 'Core HTML5 Canvas: Graphics, Animation, and Game Development' },
        { id: 4, title: 'JavaScript Patterns' }
    ];

var students = [
        { number: 1, name: 'Petar Petrov', mark: 5.5 },
        { number: 2, name: 'Stamat Georgiev', mark: 4.7 },
        { number: 3, name: 'Maria Todorova', mark: 6 },
        { number: 4, name: 'Georgi Geshov', mark: 3.7 },
        { number: 5, name: 'Anna Hristova', mark: 4 }
    ];

$('#books-list').templateListView(books);
$('#students-table').templateListView(students);
$('#students-table-inside-template').templateListView(students);



