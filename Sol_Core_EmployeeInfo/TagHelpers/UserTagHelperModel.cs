using Sol_Core_EmployeeInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Core_EmployeeInfo.TagHelpers
{
    public class UserTagHelperModel
    {
        public List<UserModel> UserList { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }
    }
}
