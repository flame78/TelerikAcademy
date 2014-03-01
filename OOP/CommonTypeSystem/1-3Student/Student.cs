using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace _1_3Student
{
    class Student : ICloneable, IComparable<Student>
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

        public override int GetHashCode()
        {
            int result=0;

            var thisProperties = this.GetType().GetProperties();

            foreach (var property in thisProperties)
            {
                result ^= property.GetValue(this).GetHashCode();
            }

            return result;
        }

        public override string ToString()
        {
            var result=new StringBuilder(base.GetType().Name);

            result.Append(Environment.NewLine);

            var thisProperties = this.GetType().GetProperties();

            foreach (var property in thisProperties)
            {
                result.Append(property.Name);
                result.Append(" : ");
                result.Append(property.GetValue(this));
                result.Append(Environment.NewLine);
            }

            return result.ToString(); 
        }

        public static  bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static  bool operator !=(Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }
        public override bool Equals(object obj)
        {
           
            if (obj == null) return false;

            var thisProperties = this.GetType().GetProperties();
            var objProperties = obj.GetType().GetProperties();

            for (int i = 0; i < thisProperties.Length; i++)
            {

                if (!(thisProperties[i].GetValue(this).Equals(objProperties[i].GetValue(obj)))) return false;
              
                
            }

            return true;
        }

        public object Clone()
        {
            var result = new Student();

            var thisProperties = this.GetType().GetProperties();

            for (int i = 0; i < thisProperties.Length; i++)
            {

                thisProperties[i].SetValue(result, thisProperties[i].GetValue(this));
            }

            return result;
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) != 0) return this.FirstName.CompareTo(other.FirstName);
            if (this.MiddleName.CompareTo(other.MiddleName) != 0) return this.MiddleName.CompareTo(other.MiddleName);
            if (this.LastName.CompareTo(other.LastName) != 0) return this.LastName.CompareTo(other.LastName);
            if (this.SSN.CompareTo(other.SSN) != 0) return this.SSN.CompareTo(other.SSN);
            return 0;
        }
    }
}
