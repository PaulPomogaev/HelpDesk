namespace HelpDeskWinFormsApp
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new System.Windows.Forms.Label();
            nameTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            loginTextBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            passwordTextBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            emailTextBox = new System.Windows.Forms.TextBox();
            registrationButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            exitButton = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            replyPasswordTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(12, 5);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(279, 30);
            label4.TabIndex = 0;
            label4.Text = "&Имя";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new System.Drawing.Point(12, 38);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new System.Drawing.Size(279, 23);
            nameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 64);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(279, 30);
            label1.TabIndex = 2;
            label1.Text = "&Логин";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new System.Drawing.Point(12, 97);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new System.Drawing.Size(279, 23);
            loginTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(12, 123);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(279, 30);
            label2.TabIndex = 4;
            label2.Text = "&Пароль";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new System.Drawing.Point(12, 156);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new System.Drawing.Size(279, 23);
            passwordTextBox.TabIndex = 5;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(12, 241);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(279, 30);
            label3.TabIndex = 8;
            label3.Text = "&E-Mail";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new System.Drawing.Point(12, 274);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(279, 23);
            emailTextBox.TabIndex = 9;
            // 
            // registrationButton
            // 
            registrationButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            registrationButton.Location = new System.Drawing.Point(12, 316);
            registrationButton.Name = "registrationButton";
            registrationButton.Size = new System.Drawing.Size(279, 33);
            registrationButton.TabIndex = 10;
            registrationButton.Text = "&Регистрация";
            registrationButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(12, 355);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(279, 33);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "&Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            exitButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            exitButton.Location = new System.Drawing.Point(12, 394);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(279, 33);
            exitButton.TabIndex = 12;
            exitButton.Text = "Выход";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(12, 182);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(279, 30);
            label5.TabIndex = 6;
            label5.Text = "Повторите пароль";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // replyPasswordTextBox
            // 
            replyPasswordTextBox.Location = new System.Drawing.Point(12, 215);
            replyPasswordTextBox.Name = "replyPasswordTextBox";
            replyPasswordTextBox.Size = new System.Drawing.Size(279, 23);
            replyPasswordTextBox.TabIndex = 7;
            replyPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // RegistrationForm
            // 
            AcceptButton = registrationButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(303, 437);
            ControlBox = false;
            Controls.Add(replyPasswordTextBox);
            Controls.Add(label5);
            Controls.Add(exitButton);
            Controls.Add(cancelButton);
            Controls.Add(registrationButton);
            Controls.Add(nameTextBox);
            Controls.Add(label4);
            Controls.Add(loginTextBox);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(label2);
            Controls.Add(emailTextBox);
            Controls.Add(label3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrationForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "HelpDesk Регистрация";
            FormClosing += RegistrationForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button exitButton;
        public System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox replyPasswordTextBox;
    }
}