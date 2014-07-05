/// <reference path="../libs/requirejs/require.js" />
define(['courses/student'], function (Student) {

    function Course(title, totalScoreFunction) {
        validateTitle(title);
        this._title = title;
        validateScoreFunction(totalScoreFunction);
        this._totalScoreFunction = totalScoreFunction;
        this._students = [];
        this._courseResults = [];
    }

    function validateTitle(title) {
        if (typeof (title) != 'string') {
            throw new TypeError('The title must be a string');
        }
        if (!title.trim()) {
            throw new Error('Title cant be empty or whitespace')
        }
    }

    function validateScoreFunction(totalScoreFunction) {
        if (typeof (totalScoreFunction) != 'function') {
            throw new TypeError('totalScoreFunction must be a function');
        }
    }

    function addStudent(student) {
        if (!(student instanceof Student)) {
            throw new TypeError('student must be instanceof Student');
        }
        this._students.push(student);
    }

    function calculateResults() {
        for (var i = 0; i < this._students.length; i++) {
            this._students[i].courseResult = this._totalScoreFunction(this._students[i]);
        }
    }

    function getTopStudentsByExam(number) {

        this._students.sort(function (a, b) {
            return b.exam - a.exam;
        })

        if (number > this._students.length) {
            number = this._students.length
        }

        var result = [];
        for (var i = 0; i < number; i++) {
            result.push(this._students[i]);
        }

        return result;
    }

    function getTopStudentsByTotalScore(number) {

        this._students.sort(function (a, b) {
            return b.courseResult - a.courseResult;
        })

        if (number > this._students.length) {
            number = this._students.length
        }

        var result = [];
        for (var i = 0; i < number; i++) {
            result.push(this._students[i]);
        }

        return result;
    }

    Course.prototype = {
        addStudent: addStudent,
        calculateResults: calculateResults,
        getTopStudentsByExam: getTopStudentsByExam,
        getTopStudentsByTotalScore: getTopStudentsByTotalScore

    }

    return Course;
});
