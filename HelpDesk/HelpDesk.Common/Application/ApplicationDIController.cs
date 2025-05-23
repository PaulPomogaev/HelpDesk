using HelpDesk.Common.System;

namespace HelpDesk.Common.Application
{
    public class ApplicationDIController
    {
        public void Start()
        {            
            RegisterSystems();                       
        }

        private void RegisterSystems()
        {
            var storage = new JsonStorage();
            SystemManager.Register<ITicketService>(() => new JsonStorage());
            SystemManager.Register<IUserService>(() => new JsonStorage());
        }
    }
}
