using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace _1_3Student
{
    class Student
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int SSN { get; set; }
        public string Address { get; private set; }
        public string MobilePhone { get; set; }
        public string EMail { get; set; }
        public byte Course { get; set; }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }

        public Student() { }
        public Student(string firstName, string middleName, string lastName, int ssn, string address, string mobilePhone, string eMail, byte course, Specialties specialty, Universities university, Faculties faculty)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            SSN = ssn;
            Address = address;
            MobilePhone = mobilePhone;
            EMail = eMail;
            Course = course;
            Specialty = specialty;
            University = university;
            Faculty = faculty;
        }
        public override bool Equals(object obj)
        {
            obj = obj as Student;

            if (obj == null) return false;

            var thisProperties = this.GetType().GetProperties();
            var objProperties = obj.GetType().GetProperties();

            for (int i = 0; i < thisProperties.Length; i++)
            {
                Console.WriteLine(thisProperties[i].GetValue(this) + "==" + objProperties[i].GetValue(obj));
                if (thisProperties[i].GetValue(this)!=objProperties[i].GetValue(obj))
                {
                    Console.WriteLine(thisProperties[i].GetValue(this) + "!=" + objProperties[i].GetValue(obj));

                    return false;
                }
                
            }

            return true;


        }
    }
}
