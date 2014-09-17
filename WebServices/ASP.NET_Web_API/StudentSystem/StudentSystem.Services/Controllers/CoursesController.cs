namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class CoursesController : ApiController
    {
        private readonly IStudentSystemData context;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData context)
        {
            this.context = context;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.context.Courses.All().Select(CourseModel.FromCourse));
        }

        [HttpGet]
        public IHttpActionResult ById(Guid id)
        {
            return this.Ok(context.Courses.Find(id));
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Course
            {
                Description = course.Description,
                Name = course.Name
            };

            this.context.Courses.Add(newCourse);
            this.context.SaveChanges();
            course.Id = newCourse.Id;
            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult Update(Guid id, CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var existingCourse = context.Courses.Find(id);

            if (existingCourse == null)
            {
                return this.NotFound();
            }

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            context.SaveChanges();
          
            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var existingCourse = context.Courses.Find(id);

            if (existingCourse == null)
            {
                return this.NotFound();
            }

            context.Courses.Delete(existingCourse);
            context.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult AddStudentToCourse(Guid id, int studentId)
        {
            var course = context.Courses.Find(id);
            var student = context.Students.Find(studentId);

            if (course == null || student == null)
            {
                return this.NotFound();
            }

            course.Students.Add(student);
            context.SaveChanges();

            return this.Ok();
        }
    }
}
