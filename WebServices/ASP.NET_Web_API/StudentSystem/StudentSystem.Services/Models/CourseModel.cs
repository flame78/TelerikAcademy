namespace StudentSystem.Services.Models
{
    using System.Collections.Generic;

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using StudentSystem.Models;


    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return c => new CourseModel
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Description = c.Description
                 };
            }
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}