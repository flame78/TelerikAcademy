namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class CoursesController : ApiController
    {
        private IGenericRepository<Course> courses;

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

    }
}
