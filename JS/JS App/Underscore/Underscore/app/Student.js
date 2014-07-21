/// <reference path="..\libs/require.js" />

define(function () {

    var Student = (function(){
    
        function Student(firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        Student.prototype.toString = function(){
            return 'Student - first name: '+this.firstName+', last name: '+ this.lastName;
        }

        Student.prototype.fullName = function () {
            return this.firstName + ' ' + this.lastName;
        }

        return Student;
    }());

    return Student;
});
