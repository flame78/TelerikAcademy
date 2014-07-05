/// <reference path="../libs/requirejs/require.js" />
define(function () {

    NegativeScoreError.prototype = new Error();
    
    function Student(object) {
        validateName(object.name);
        this.name = object.name;
        validateScore(object.exam);
        this.exam = object.exam;
        validateScore(object.homework);
        this.homework = object.homework;
        validateScore(object.attendance);
        this.attendance = object.attendance;
        validateScore(object.teamwork);
        this.teamwork = object.teamwork;
        validateScore(object.bonus);
        this.bonus = object.bonus;
    }

    function NegativeScoreError() {
        this.message = 'Score cant be negative'
    }
 
    return Student;

    function validateScore(score) {

        if (typeof (score) != 'number') {
            throw new Error('The score be a number');
        }
        if (score < 0) {
            throw new NegativeScoreError();
        }
    }

    function validateName(name) {
        if (typeof (name) != 'string') {
            throw new TypeError('The name must be a string');
        }
        if (!name.trim()) {
            throw new Error('Name cant be empty or whitespace')
        }
    }

});