using HelpDesk.Common;
using HelpDesk.Common.Models;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class RegistrationForm : Form
    {
        private readonly IUserService userService;

        public RegistrationForm(IUserService userService)
        {
            InitializeComponent();

            this.userService = userService;
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel || DialogResult == DialogResult.Abort)
            {
                return;
            }

            string name = nameTextBox.Text.Trim();
            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string confirmPassword = replyPasswordTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();

            if (!Validator.AreAllFieldsFilled(name, login, password, confirmPassword, email))
            {
                e.Cancel = true;
                MessageBox.Show("Все поля обязательны к заполнению.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.IsLoginValid(login))
            {
                e.Cancel = true;
                MessageBox.Show("Логин должен содержать минимум 3 символа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.IsPasswordValid(password))
            {
                e.Cancel = true;
                MessageBox.Show("Пароль должен содержать минимум 6 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.DoPasswordsMatch(password, confirmPassword))
            {
                e.Cancel = true;
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.IsEmailValid(email))
            {
                e.Cancel = true;
                MessageBox.Show("Введите корректный email.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validator.IsLoginUnique(userService, login))
            {
                e.Cancel = true;
                MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = new User
            {
                Name = name,
                Login = login,
                Password = Methods.GetHashMD5(password),
                Email = email
            };

            userService.AddUser(user);
        }
    }
}
