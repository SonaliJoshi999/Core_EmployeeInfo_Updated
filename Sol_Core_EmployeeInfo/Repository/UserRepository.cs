using Sol_Core_EmployeeInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Core_EmployeeInfo.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsersDetailsAsync();
        Task<IEnumerable<UserModel>> GetUsersDetailsAsync(string searchData);
        Task<UserModel> GetSingleUserDetails(int id);
    }
    public class UserRepository : IUserRepository
    {
        async Task<UserModel> IUserRepository.GetSingleUserDetails(int id)
        {
            try
            {
                var data = await ((IUserRepository)this).GetUsersDetailsAsync();

                return data
                    ?.AsEnumerable()
                    ?.FirstOrDefault((leUserModel) => leUserModel.Id == id);
            }
            catch
            {
                throw;
            }
        }

        async Task<IEnumerable<UserModel>> IUserRepository.GetUsersDetailsAsync()
        {
            try
            {
                return await Task.Run(() =>
                {
                    var ListOfUsers = new List<UserModel>()
                    {
                        new UserModel()
                        {
                            Id=1,
                            FirstName="Kishor",
                            LastName="Naik",
                            Designation="Solution Architect",
                            Department="IT",
                            DOB=new DateTime(1984,01,01),
                            Address="Mumbai",
                            ImageURL="~/Images/KishorImages.jpg"
                        },
                        new UserModel()
                        {
                            Id=2,
                            FirstName="Sonali",
                            LastName="Joshi",
                            Designation="Web Developer",
                            Department="IT",
                            DOB=new DateTime(1988,09,05),
                            Address="Mumbai",
                            ImageURL="~/Images/sonali.jpg"
                        },
                         new UserModel()
                        {
                            Id=3,
                            FirstName="Ashwini",
                            LastName="Bhangale",
                            Designation="Web Developer",
                            Department="IT",
                            DOB=new DateTime(1991,09,01),
                            Address="Mumbai",
                            ImageURL="~/Images/Ashwini.jpg"
                        },
                          new UserModel()
                        {
                            Id=4,
                            FirstName="Swati",
                            LastName="Mane",
                            Designation="Web Developer",
                            Department="IT",
                            DOB=new DateTime(1986,08,01),
                            Address="Mumbai",
                            ImageURL="~/Images/Swati.jpg"
                        },
                        new UserModel()
                        {
                            Id=4,
                            FirstName="Rajashree",
                            LastName="Mhatre",
                            Designation="Web Developer",
                            Department="IT",
                            DOB=new DateTime(1986,02,01),
                            Address="Mumbai",
                            ImageURL="~/Images/Rajashree.jpg"
                        },
                        new UserModel()
                        {
                            Id=5,
                            FirstName="Bhushan",
                            LastName="Pawar",
                            Designation="Senior Manager",
                            Department="Management",
                            DOB=new DateTime(1984,01,01),
                            Address="Thane",
                            ImageURL="http://cliparts101.com/files/367/63BA654AECB7FD26A32D08915C923030/avatar_nick.png"
                        },
                         new UserModel()
                        {
                            Id=6,
                            FirstName="Manisha",
                            LastName="Giri",
                            Designation="Senior Admin",
                            Department="Management",
                            DOB=new DateTime(1984,01,01),
                            Address="Dombivali",
                            ImageURL="~/Images/Image1.jpg"
                        },
                          new UserModel()
                        {
                            Id=7,
                            FirstName="Yogita",
                            LastName="Shinde",
                            Designation="Marketing Head",
                            Department="Marketing",
                            DOB=new DateTime(1991,01,01),
                            Address="Dombivali",
                            ImageURL="~/Images/sonali1.jpg"
                        }
                    };

                    return ListOfUsers;
                });
            }
            catch
            {
                throw;
            }
        }

        async Task<IEnumerable<UserModel>> IUserRepository.GetUsersDetailsAsync(string searchData)
        {
            try
            {
                var data = await ((IUserRepository)this).GetUsersDetailsAsync();

                return !string.IsNullOrEmpty(searchData) ? data
                    ?.AsEnumerable()
                    ?.Where((leUserModel) => leUserModel.FirstName.Equals(searchData, StringComparison.OrdinalIgnoreCase) ||
                    leUserModel.LastName.Equals(searchData, StringComparison.OrdinalIgnoreCase) || leUserModel.Department.Equals(searchData, StringComparison.OrdinalIgnoreCase)
                    || leUserModel.Designation.Equals(searchData, StringComparison.OrdinalIgnoreCase)) : data;
            }
            catch
            {
                throw;
            }
        }
    }
}
