using HelpDesk.Common.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HelpDesk.Common
{
    public class JsonStorage : IProvider
    {
        private string usersFileName = "users.json";
        private string troubleTicketsFileName = "troubleTicket.json";

        public bool IsCorrectLoginPassword(string login, string password)
        {
            var users = JsonProvider.Deserialize<User>(usersFileName);
            User user = null;

            if (users == null || users.Count == 0)
            {
                return false;
            }
            else
            {
                user = users.FirstOrDefault(x => x.Login == login);
            }

            if (user == null)
            {
                return false;
            }

            return user?.Password == Methods.GetHashMD5(password); // заменил return user.Password != Methods.GetHashMD5(password), при !=  пароль никогда не будет хешу 
        }

        public User GetUser(string login)
        {
            var users = JsonProvider.Deserialize<User>(usersFileName);
            User user = null;

            if (users == null || users.Count == 0)
            {
                return new User();
            }
            else
            {
                user = users.FirstOrDefault(x => x.Login == login);
            }

            if (user == null)
            {
                return new User();
            }

            return user;
        }

        public User GetUser(int id)
        {
            var users = JsonProvider.Deserialize<User>(usersFileName);
            User user = null;

            if (users == null || users.Count == 0)
            {
                return new User();
            }
            else
            {
                user = users.FirstOrDefault(x => x.Id == id);
            }

            if (user == null)
            {
                return new User();
            }

            return user;
        }

        public void AddUser(User user)
        {
            var users = JsonProvider.Deserialize<User>(usersFileName);

            if (users != null)
            {
                user.Id = users.Max(x => x.Id) + 1;

                users.Add(user);
            }
            else
            {
                users = new List<User> { user };
            }


            JsonProvider.Serialize(users, usersFileName);
        }

        public List<User> GetAllUsers()
        {
            return JsonProvider.Deserialize<User>(usersFileName);
        }

        public void AddTrubleTicket(TroubleTicket troubleTicket)
        {
            var troubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName);

            if (troubleTickets == null)
            {
                troubleTickets = new List<TroubleTicket> { troubleTicket };
            }
            else
            {
                troubleTicket.Id = troubleTickets.Max(x => x.Id) + 1;

                troubleTickets.Add(troubleTicket);
            }

            JsonProvider.Serialize(troubleTickets, troubleTicketsFileName);
        }

        public List<TroubleTicket> GetAllTroubleTickets()
        {
            var trubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName);

            if (trubleTickets == null)
            {
                return new List<TroubleTicket>();
            }
            else
            {
                return trubleTickets;   // удалил дубль JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName);
            }
        }

        public TroubleTicket GetTroubleTicket(int id)
        {
            var trubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName);

            if (trubleTickets == null)
            {
                return new TroubleTicket();
            }
            else
            {
                var trubleTicket = trubleTickets.FirstOrDefault(t => t.Id == id);

                return trubleTicket;
            }
        }

        public void ResolveTroubleTicket(int id, TicketStatus status, string resolve, int resolveUserId)
        {
            var trubleTickets = GetAllTroubleTickets();
            var trubleTicket = GetTroubleTicket(id);

            trubleTickets.RemoveAll(x => x.Id == id);

            trubleTicket.IsSolved = true;
            trubleTicket.Status = status;
            trubleTicket.Resolve = resolve;
            trubleTicket.ResolveTime = DateTime.Now;
            trubleTicket.ResolveUser = resolveUserId;

            trubleTickets.Add(trubleTicket);

            var sortedTrubleTickets = trubleTickets.OrderBy(x => x.Id).ToList();

            JsonProvider.Serialize(sortedTrubleTickets, troubleTicketsFileName);
        }

        public void ChangeStatusTroubleTicket(int id, TicketStatus status, int resolveUserId)
        {
            var trubleTickets = GetAllTroubleTickets();
            var trubleTicket = GetTroubleTicket(id);

            trubleTickets.RemoveAll(x => x.Id == id);

            trubleTicket.Status = status;
            trubleTicket.ResolveUser = resolveUserId;

            trubleTickets.Add(trubleTicket);

            var sortedTroubleTickets = trubleTickets.OrderBy(x => x.Id).ToList();

            JsonProvider.Serialize(sortedTroubleTickets, troubleTicketsFileName);

        }

        public void ChangeUserToEmployee(User user, string function, string department)
        {
            var users = GetAllUsers();
            users.RemoveAll(x => x.Id == user.Id);

            var convertedUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                IsEmployee = true,
                Function = function,
                Department = department
            };

            users.Add(convertedUser);

            var sortedUsers = users.OrderBy(x => x.Id).ToList();

            JsonProvider.Serialize(sortedUsers, usersFileName);
        }

        public void ChangeEmployeeToUser(User user)
        {
            var users = GetAllUsers();
            users.RemoveAll(x => x.Id == user.Id);

            user.IsEmployee = false;
            user.Function = null;
            user.Department = null;

            users.Add(user);

            var sortedUsers = users.OrderBy(x => x.Id).ToList();

            JsonProvider.Serialize(sortedUsers, usersFileName);
        }

        public void UpdateUser(User user)
        {
            var users = GetAllUsers();
            users.RemoveAll(x => x.Id == user.Id);
            users.Add(user);

            var sortedUsers = users.OrderBy(x => x.Id).ToList();

            JsonProvider.Serialize(sortedUsers, usersFileName);
        }
    }
}

