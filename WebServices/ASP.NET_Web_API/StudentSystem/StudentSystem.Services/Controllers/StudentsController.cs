namespace StudentSystem.Services.Controllers
{
    using System.Web.Http;
    using System.Linq;
    using System.Web.Http.Description;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity;
    using System.Net;

    using StudentSystem.Models;
    using StudentSystem.Services.Models;
    using StudentSystem.Data.Repositories;

    public class StudentsController : ApiController
    {
        private readonly IGenericRepository<Student> students;

        public StudentsController()
            : this(new GenericRepository<Student>())
        {
        }

        public StudentsController(IGenericRepository<Student> students)
        {
            this.students = students;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.students.All().Select(StudentModel.FromStudent));
        }

        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = this.students.SearchFor(
                s => s.Id == id).Select(StudentModel.FromStudent).FirstOrDefault();

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent =
                this.students.SearchFor(s => s.Id == id).FirstOrDefault();

            if (existingStudent == null)
            {
                return this.BadRequest("That student does not exists!");
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;

            if (student.Level != null)
            {
                existingStudent.Level = student.Level;
            }

            if (student.AdditionalInformation != null)
            {
                existingStudent.AdditionalInformation = student.AdditionalInformation;
            }

            students.SaveChanges();

            return this.Ok(student);

        }

        //// POST: api/Students
        //[ResponseType(typeof(Student))]
        //public IHttpActionResult PostStudent(Student student)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Students.Add(student);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        //}

        //// DELETE: api/Students/5
        //[ResponseType(typeof(Student))]
        //public IHttpActionResult DeleteStudent(int id)
        //{
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Students.Remove(student);
        //    db.SaveChanges();

        //    return Ok(student);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool StudentExists(int id)
        //{
        //    return db.Students.Count(e => e.Id == id) > 0;
        //}
    }
}