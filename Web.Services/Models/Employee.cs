using System;

namespace Web.Services.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public int empNumber { get; set; }
        public string empName { get; set; }
        public string empGender { get; set; }
        public string empAddress { get; set; }
        public string empDepartment { get; set; }
        public string empPosition { get; set; }
        public DateTime empDOJ { get; set; }
        public string empEmail { get; set; }

    }
}
