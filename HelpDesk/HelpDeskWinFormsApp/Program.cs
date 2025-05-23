using HelpDesk.Common.Application;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using Newtonsoft.Json.Converters;
using HelpDesk.Common.System;
using HelpDesk.Common;
namespace HelpDeskWinFormsApp

{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = { new StringEnumConverter() }
            };

            var diController = new ApplicationDIController();
            diController.Start();

            SystemManager.Get(out ITicketService ticketService);
            SystemManager.Get(out IUserService userService);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(diController, ticketService, userService));
        }
    }
}