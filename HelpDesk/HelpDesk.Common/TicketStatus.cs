using System.ComponentModel;

public enum TicketStatus
{
    [Description("Зарегистрирована")]
    Зарегистрирована,

    [Description("В работе")]
    Выполняется,

    [Description("Выполнена")]
    Выполнена,

    [Description("Отклонена")]
    Отклонена
}  // добавил статусы в enum с описанием
