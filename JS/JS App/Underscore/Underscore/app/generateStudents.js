/// <reference path="..\libs/require.js" />
/// <reference path="..\libs/underscore.js" />
/// <reference path="Student.js" />

define(['app/student', 'underscore'], function (Student,_) {

    var table = document.getElementById('table-data').innerHTML;
    var cells = table.split('\t');

    var students = _.chain(cells)
                  .rest(9)
                 .map(function (cell, index) {
                     if (index % 7 === 0) {
                         var names = cell.split(' ');
                         if (names[0].trim() === '') return;
                         return new Student(names[0], names[1], Math.random()*50+10|0);
                     }
                 })
                 .compact()
                 .value();

  
    return students;

});