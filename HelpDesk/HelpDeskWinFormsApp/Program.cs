using HelpDesk.Common.Application;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using Newtonsoft.Json.Converters;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new ApplicationDIController()));
        }
    }
}