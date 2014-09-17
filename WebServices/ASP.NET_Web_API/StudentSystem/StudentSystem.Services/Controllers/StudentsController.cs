namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Web.Http;
    using System.Linq;
    using System.Web.Http.Description;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity;
    using System.Net;

    using Microsoft.Ajax.Utilities;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;
    using StudentSystem.Data.Repositories;

    public class StudentsController : ApiController
    {
        private readonly IStudentSystemData context;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData context)
        {
            this.context = context;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.context.Students.All().Select(StudentModel.FromStudent));
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.context.Students.SearchFor(
                s => s.Id == id).Select(StudentModel.FromStudent).FirstOrDefault();

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet]
        public IHttpActionResult AllDataById(int id)
        {
            var student = this.context.Students.SearchFor(
                s => s.Id == id).FirstOrDefault();

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
                this.context.Students.SearchFor(s => s.Id == id).FirstOrDefault();

            if (existingStudent == null)
            {
                return this.BadRequest("That student does not exists!");
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;

            if (student.Level != null)
            {
                existingStudent.Level = (int)student.Level;
            }

            if (student.AdditionalInformation != null)
            {

                existingStudent.AdditionalInformation.Address =
                    student.AdditionalInformation.Address
                    ?? existingStudent.AdditionalInformation.Address;

                existingStudent.AdditionalInformation.Email =
                    student.AdditionalInformation.Email
                    ?? existingStudent.AdditionalInformation.Email;
            }

            context.SaveChanges();

            return this.Ok(student);

        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = new Student
                                 {
                                     FirstName = student.FirstName,
                                     LastName = student.LastName,
                                     Level = (int)student.Level,
                                     AdditionalInformation = student.AdditionalInformation

                                 };

            this.context.Students.Add(newStudent);
            this.context.SaveChanges();

            student.Id = newStudent.Id;

            return this.Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Student student = this.context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            this.context.Students.Delete(student);
            this.context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AddCourseToStudent(int id, Guid courseId)
        {
            var student = context.Students.Find(id);
            var course = context.Courses.Find(courseId);

            if (student == null || course == null)
            {
                return this.NotFound();
            }

            student.Courses.Add(course);
            context.SaveChanges();

            return this.Ok();
        }
    }
}