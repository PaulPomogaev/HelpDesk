using System;

namespace HelpDesk.Common
{
    public static class StatusHelper
    {
        public static TicketStatus? FromDescription(string description)
        {
            foreach (TicketStatus status in Enum.GetValues(typeof(TicketStatus)))
            {
                if (status.GetDescription() == description)
                    return status;
            }
            return null;
        }
    }
}  // для получения TicketStatus по описанию
