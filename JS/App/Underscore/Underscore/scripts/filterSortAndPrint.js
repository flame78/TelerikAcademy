/// <reference path="../libs/underscore.js" />
/// <reference path="../app/student.js" />

/* Write a method that from a given array of students 
finds all students whose first name is before its last 
name alphabetically. Print the students in 
descending order by full name. Use Underscore.js */define(['underscore'], function () {
    function filterCriteria(student) {
        return (student.firstName.toLowerCase() < student.lastName.toLowerCase()) ? 1 : 0;
    }    function filterSortAndPrint(students) {

        _.chain(students)         .filter(filterCriteria)         .sortBy(function (student) {
             return student.fullName();
         })         .reverse()         .each(function (student) {
             console.log(student.fullName());
         });

    }    
    return filterSortAndPrint;
});