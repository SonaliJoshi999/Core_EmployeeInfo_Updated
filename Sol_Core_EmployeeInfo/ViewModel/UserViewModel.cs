using Sol_Core_EmployeeInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Core_EmployeeInfo.ViewModel
{
    public class UserViewModel
    {
        public List<UserModel> UsersList { get; set; }

        public UserModel User { get; set; }

        public string SearchQuery { get; set; }
    }
}
