/// <reference path="../libs/requirejs/require.js" />
define(['courses/student'], function (Student) {

    var Course;

    Course = (function () {

        function Course(title, totalScoreFormula) {
            this._title = title;
            this._totalScoreFormula = totalScoreFormula;
            this._students = []
        }

        function sortBy(property) {
            var sortedStudents = this._students.slice(0);

            sortedStudents.sort(function (a, b) {
                return b[property] - a[property]
            });

            return sortedStudents;

        }

        Course.prototype = {

            addStudent: function (student) {

                if (!(student instanceof Student)) {
                    throw new TypeError('Course.addStudent can only work with instance of Student');
                }

                this._students.push(student);

                return this;
            },

            calculateResults: function () {
                var self = this;
                this._students.forEach(function (student) {
                    student.totalScore = self._totalScoreFormula(student);
                });
            },

            getTopStudentsByExam: function (count) {
                return sortBy.call(this, 'exam').slice(0, count);
            },

            getTopStudentsByTotalScore: function (count) {
                return sortBy.call(this, 'totalScore').slice(0, count);
            }
        }

        return Course;
    }());

    return Course;
});

// first time writen

///// <reference path="../libs/requirejs/require.js" />
//define(['courses/student'], function (Student) {

//    function Course(title, totalScoreFunction) {
//        validateTitle(title);
//        this._title = title;
//        validateScoreFunction(totalScoreFunction);
//        this._totalScoreFunction = totalScoreFunction;
//        this._students = [];
//    }

//    Course.prototype = {
//        addStudent: addStudent,
//        calculateResults: calculateResults,
//        getTopStudentsByExam: getTopStudentsByExam,
//        getTopStudentsByTotalScore: getTopStudentsByTotalScore

//    }

//    function addStudent(student) {
//        if (!(student instanceof Student)) {
//            throw new TypeError('student must be instanceof Student');
//        }
//        this._students.push(student);
//    }

//    function calculateResults() {
//        for (var i = 0; i < this._students.length; i++) {
//            this._students[i].courseResult = this._totalScoreFunction(this._students[i]);
//        }
//    }

//    function getTopStudentsByExam(number) {

//        this._students.sort(function (a, b) {
//            return b.exam - a.exam;
//        });

//        return getCopyOfFirst(this, number);
//    }

//    function getTopStudentsByTotalScore(number) {

//        this._students.sort(function (a, b) {
//            return b.courseResult - a.courseResult;
//        })

//        return getCopyOfFirst(this, number);
//    }

//    return Course;

//    function validateTitle(title) {

//        if (typeof (title) != 'string') {
//            throw new TypeError('The title must be a string');
//        }

//        if (!title.trim()) {
//            throw new Error('Title cant be empty or whitespace')
//        }
//    }

//    function validateScoreFunction(totalScoreFunction) {

//        if (typeof (totalScoreFunction) != 'function') {
//            throw new TypeError('totalScoreFunction must be a function');
//        }
//    }

//    function getCopyOfFirst(course, number) {

//        if (number > course._students.length) {
//            number = course._students.length
//        }

//        var result = [];
//        for (var i = 0; i < number; i++) {
//            result.push(JSON.parse(JSON.stringify(course._students[i])));
//        }

//        return result;
//    }
//});
