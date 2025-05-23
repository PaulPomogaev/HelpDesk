using HelpDesk.Common.Models;
using System.Collections.Generic;

namespace HelpDesk.Common
{
    public interface IHelpDeskService
    {
        bool ValidateCredentials(string login, string password);
        User GetUserByLogin(string login);
        User GetUserById(int id);
        void AddUser(User user);
        List<User> GetAllUsers();
        void AddTicket(TroubleTicket trubleTicket);
        List<TroubleTicket> GetAllTickets();
        TroubleTicket GetTicketById(int id);
        void ResolveTicket(int id, TicketStatus status, string resolve, int resolveUserId);
        void UpdateTicketStatus(int id, TicketStatus status, int resolveUserId);  // переназвал string status, был staatus
        void ChangeUserToEmployee(User user, string function, string department);
        void ChangeEmployeeToUser(User user);
        void UpdateUser(User user);
    }
}