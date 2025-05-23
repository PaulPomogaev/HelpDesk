using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class TroubleTicketForm : Form
    {
        int ticketId;
        TroubleTicket troubleTicket;
        User userCreate;
        bool isEmployee;
        int resolveUserId;
        TicketStatus lastStatus;
        private readonly ITicketService ticketService;
        private readonly IUserService userService;

        public TroubleTicketForm(int ticketId, bool isEmployee, int resolveUserId, ITicketService ticketService, IUserService userService)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            this.isEmployee = isEmployee;
            this.resolveUserId = resolveUserId;
            this.ticketService = ticketService;
            this.userService = userService;
        }

        private void TrubleTicketForm_Shown(object sender, System.EventArgs e)
        {
            troubleTicket = ticketService.GetTicketById(ticketId);
            userCreate = userService.GetUserById(troubleTicket.CreateUser);
            lastStatus = troubleTicket.Status;
            statusTrubleTicketComboBox.DataSource = Enum.GetValues<TicketStatus>().Select(s => s.GetDescription()).ToList();
            statusTrubleTicketComboBox.SelectedItem = troubleTicket.Status;

            Text = $"HelpDesk. Заявка №{troubleTicket.Id}";  // исправил опечатку в слове Заявка
            userCreateTextBox.Text = $"{userCreate.Name} \\ {userCreate.Email}";
            trubleTicketRichTextBox.Text = troubleTicket.Text;

            if (troubleTicket.Resolve != null)
            {
                resolveRichTextBox.Text = $"Заявка решена {troubleTicket.ResolveTime}\n\r";
                resolveRichTextBox.Text += troubleTicket.Resolve;
                resolveRichTextBox.ReadOnly = true;
                statusTrubleTicketComboBox.Enabled = false;
                saveButton.Enabled = false;
            }

            if (!isEmployee)
            {
                saveButton.Visible = false;
                resolveRichTextBox.Enabled = false;
                statusTrubleTicketComboBox.Enabled = false;
            }
        }

        private void TroubleTicketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {

                var selectedItem = statusTrubleTicketComboBox.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedItem))
                {
                    e.Cancel = true;
                    MessageBox.Show("Выберите статус заявки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedStatus = StatusHelper.FromDescription(selectedItem);

                if (!selectedStatus.HasValue)
                {
                    e.Cancel = true;
                    MessageBox.Show("Некорректный статус заявки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((selectedStatus == TicketStatus.Выполнена || selectedStatus == TicketStatus.Отклонена) &&
                    resolveRichTextBox.Text == string.Empty)
                {
                    e.Cancel = true;
                    MessageBox.Show("Пожалуйста заполните решение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (selectedStatus == TicketStatus.Зарегистрирована && lastStatus != TicketStatus.Зарегистрирована)
                {
                    e.Cancel = true;
                    MessageBox.Show("Возврат в статус \"Зарегистрирована\" запрещён.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (selectedStatus == TicketStatus.Выполнена || selectedStatus == TicketStatus.Отклонена)
                {
                    troubleTicket.ResolveTime = DateTime.Now;
                }

                if (selectedStatus == TicketStatus.Выполнена || selectedStatus == TicketStatus.Отклонена)
                {
                    ticketService.ResolveTicket(troubleTicket.Id, selectedStatus.Value, resolveRichTextBox.Text, resolveUserId);
                }
                else if (selectedStatus != lastStatus)
                {
                    ticketService.UpdateTicketStatus(troubleTicket.Id, selectedStatus.Value, resolveUserId);
                }
            }
        }
    }
}
