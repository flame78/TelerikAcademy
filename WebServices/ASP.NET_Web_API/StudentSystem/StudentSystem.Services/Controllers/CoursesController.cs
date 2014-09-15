namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class CoursesController : ApiController
    {
        private readonly IGenericRepository<Course> courses;

        public CoursesController()
            : this(new GenericRepository<Course>())
        {
        }

        public CoursesController(IGenericRepository<Course> courses)
        {
            this.courses = courses;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.courses.All().Select(CourseModel.FromCourse));
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

            this.courses.Add(newCourse);
            this.courses.SaveChanges();
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

            var existingCourse = courses.SearchFor(c => c.Id == id).FirstOrDefault();

            if (existingCourse == null)
            {
                return this.NotFound();
            }

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            courses.SaveChanges();
          
            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var existingCourse = courses.SearchFor(c => c.Id == id).FirstOrDefault();

            if (existingCourse == null)
            {
                return this.NotFound();
            }

            courses.Delete(existingCourse);
            courses.SaveChanges();

            return this.Ok();
        }

    }
}
