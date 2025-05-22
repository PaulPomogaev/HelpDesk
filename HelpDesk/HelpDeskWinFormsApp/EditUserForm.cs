using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class EditUserForm : Form
    {
        int userId;
        User user;
        private readonly IProvider provider;

        public EditUserForm(int userId, IProvider provider)
        {
            InitializeComponent();
            this.userId = userId;
            this.provider = provider;
        }

        private void EditUserForm_Shown(object sender, EventArgs e)
        {
            user = provider.GetUser(userId);

            if (user.IsEmployee)
            {
                deparmentComboBox.Enabled = true;
                functionComboBox.Enabled = true;

                userTypeComboBox.Text = "Сотрудник";
                deparmentComboBox.Text = user.Department;
                functionComboBox.Text = user.Function;
            }
            else
            {
                deparmentComboBox.Enabled = false;
                functionComboBox.Enabled = false;

                userTypeComboBox.Text = "Клиент";
            }

            nameTextBox.Text = user.Name;
            loginTextBox.Text = user.Login;
            emailTextBox.Text = user.Email;
        }

        private void UserTypeComboBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (userTypeComboBox.Text == "Сотрудник")
            {
                deparmentComboBox.Enabled = true;
                functionComboBox.Enabled = true;
            }
            else if (userTypeComboBox.Text == "Клиент")
            {
                deparmentComboBox.Enabled = false;
                functionComboBox.Enabled = false;
            }
        }

        private void EditUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                return;
            }

            string name = nameTextBox.Text.Trim();
            string login = loginTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string newPassword = changePasswordTextBox.Text.Trim();

            if (!Validator.AreAllFieldsFilled(name, login, email))
            {
                e.Cancel = true;
                MessageBox.Show("Имя, логин и email должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.IsEmailValid(email))
            {
                e.Cancel = true;
                MessageBox.Show("Некорректный email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(newPassword) && !Validator.IsPasswordValid(newPassword))
            {
                e.Cancel = true;
                MessageBox.Show("Пароль должен содержать минимум 6 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userTypeComboBox.Text == "Сотрудник")
            {
                string department = deparmentComboBox.Text?.Trim();
                string function = functionComboBox.Text?.Trim();

                if (!Validator.AreAllFieldsFilled(department, function))
                {
                    e.Cancel = true;
                    MessageBox.Show("Должность и отдел обязательны для сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            user.Name = name;
            user.Login = login;
            user.Email = email;

            if (!string.IsNullOrEmpty(newPassword))
            {
                user.Password = Methods.GetHashMD5(newPassword);
            }

            if (user.IsEmployee)
            {
                user.Function = functionComboBox.Text;
                user.Department = deparmentComboBox.Text;
            }

            if (userTypeComboBox.Text == "Сотрудник" && !user.IsEmployee)
            {
                provider.ChangeUserToEmployee(user, functionComboBox.Text, deparmentComboBox.Text);
            }
            else if (userTypeComboBox.Text == "Клиент" && user.IsEmployee)
            {
                provider.ChangeEmployeeToUser(user);
            }
            else
            {
                provider.UpdateUser(user);
            }
        }

        private void DeparmentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (deparmentComboBox.Text == "Техническая поддержка")
            {
                functionComboBox.Items.Clear();
                functionComboBox.Items.Add("Оператор");
                functionComboBox.Items.Add("Технический специалист");
                functionComboBox.Text = "Оператор";
            }
            else if (deparmentComboBox.Text == "Разработка")
            {
                functionComboBox.Items.Clear();
                functionComboBox.Items.Add("Тестировщик");
                functionComboBox.Items.Add("Разработчик");
                functionComboBox.Text = "Тестировщик";
            }
        }
    }
}
