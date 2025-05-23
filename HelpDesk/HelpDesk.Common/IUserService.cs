using HelpDesk.Common.Models;
using System.Collections.Generic;

namespace HelpDesk.Common
{
    public interface IUserService
    {
        bool ValidateCredentials(string login, string password);
        User GetUserByLogin(string login);
        User GetUserById(int id);
        void AddUser(User user);
        List<User> GetAllUsers();
        void ChangeUserToEmployee(User user, string function, string department);
        void ChangeEmployeeToUser(User user);
        void UpdateUser(User user);
    }
}
