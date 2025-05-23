using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class AddTroubleTicketForm : Form
    {
        User user;
        private readonly IHelpDeskService provider;

        public AddTroubleTicketForm(User user, IHelpDeskService provider)
        {
            InitializeComponent();

            this.provider = provider;
            this.user = user;
        }

        private void AddTroubleTicketForm_Shown(object sender, EventArgs e)
        {
            userNameTextBox.Text = $"{user.Name} \\ {user.Login}";
        }

        private void AddTroubleTicketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                var trubelTicket = new TroubleTicket
                {
                    CreateUser = user.Id,
                    Text = troubleRichTextBox.Text,
                    Status = TicketStatus.Зарегистрирована,
                    Created = DateTime.Now,
                    Deadline = DateTime.Now.AddDays(4)
                };

                provider.AddTicket(trubelTicket);
            }
        }

        private void TroubleRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (troubleRichTextBox.Text.Length < 5)
            {
                createTroubleTicketButton.Enabled = false;
            }
            else
            {
                createTroubleTicketButton.Enabled = true;
            }
        }
    }
}
