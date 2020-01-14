using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Core_EmployeeInfo.Repository;
using Sol_Core_EmployeeInfo.ViewModel;

namespace Sol_Core_EmployeeInfo.Controllers
{
    public class UsersController : Controller
    {
        #region Declaration
        private readonly IUserRepository UserRepository = null;
        #endregion 

        #region Constructor
        public UsersController(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
            this.UserVM = new UserViewModel();
        }
        #endregion

        #region Property
        [BindProperty]
        public UserViewModel UserVM { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        #endregion 

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserVM.UsersList = (await UserRepository.GetUsersDetailsAsync()).ToList();
            UserVM.SearchQuery = null;
            return View(UserVM);
        }

        [HttpGet]
        public async Task<IActionResult> OnView()
        {
            UserVM.User = await UserRepository?.GetSingleUserDetails(this.id);

            return View(UserVM);
        }

        [HttpGet]
        public async Task<IActionResult> OnSearch()
        {
            UserVM.UsersList = (await UserRepository.GetUsersDetailsAsync(this.SearchQuery)).ToList();
            UserVM.SearchQuery = this.SearchQuery;
            ViewBag.JavascriptFunction = string.Format("ShowSearchMessage('{0}');", UserVM.UsersList?.Count() == 0 ? 1 : 0);
            return View("Index", UserVM);
        }
    }
}