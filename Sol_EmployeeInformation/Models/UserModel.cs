using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_EmployeeInformation.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string ImageURL { get; set; }
    }
}
