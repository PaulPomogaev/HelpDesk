using HelpDesk.Common.Models;
using System.Collections.Generic;

namespace HelpDesk.Common
{
    public interface ITicketService
    {
        TroubleTicket GetTicketById(int id);
        List<TroubleTicket> GetAllTickets();
        void CreateTicket(TroubleTicket troubleTicket);
        void ResolveTicket(int id, TicketStatus status, string resolve, int resolverUserId);
        void UpdateTicketStatus(int id, TicketStatus status, int userId);
    }
}
