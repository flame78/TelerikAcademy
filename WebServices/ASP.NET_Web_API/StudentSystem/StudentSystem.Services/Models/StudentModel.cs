namespace StudentSystem.Services.Models
{
    using System.Linq;

    using Microsoft.Ajax.Utilities;
    using Microsoft.OData.Core.UriParser.Semantic;

    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class StudentModel
    {
       

        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel()
                 {
                     FirstName =  s.FirstName,
                     LastName =  s.LastName,
                     AdditionalInformation = s.AdditionalInformation,
                     Level = s.Level
                 };
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }

       public StudentInfo AdditionalInformation { get; set; }
    }
}