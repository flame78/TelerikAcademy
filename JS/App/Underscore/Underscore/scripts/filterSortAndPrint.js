﻿/// <reference path="../libs/underscore.js" />
/// <reference path="../app/student.js" />

/* Write a method that from a given array of students 
finds all students whose first name is before its last 
name alphabetically. Print the students in 
descending order by full name. Use Underscore.js */

        return (student.firstName.toLowerCase() < student.lastName.toLowerCase()) ? 1 : 0;
    }

        _.chain(students)
             return student.fullName();
         })
             console.log(student.fullName());
         });

    }
    return filterSortAndPrint;
});