namespace Methods
{
    using System;
    using System.Globalization;

    public class Student
    {
        private DateTime dateOfBirth;

        public Student(string firstName, string lastName, string dateOfBirth, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;

            try
            {
                this.dateOfBirth = DateTime.Parse(dateOfBirth, new CultureInfo("de-DE"));
            }
            catch (Exception)
            {
                throw new ArgumentException("dateOfBirth must be in format \"30.12.1990\"");
            }
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth.Date;
            }
        }

        public string OtherInfo { get; private set; }

        public bool IsOlderThan(Student other)
        {
            DateTime thisDateOfBirth = this.DateOfBirth;
            DateTime otherDateOfBirth = other.DateOfBirth;

            return thisDateOfBirth < otherDateOfBirth;
        }
    }
}
