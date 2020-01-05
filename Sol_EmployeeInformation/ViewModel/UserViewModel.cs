using Sol_EmployeeInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_EmployeeInformation.ViewModel
{
    public class UserViewModel
    {
        public List<UserModel> UsersList { get; set; }

        public UserModel User { get; set; }

        public string SearchQuery { get; set; }
    }
}
