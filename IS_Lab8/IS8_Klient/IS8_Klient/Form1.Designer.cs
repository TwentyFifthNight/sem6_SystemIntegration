using System.Reflection;

namespace IS8_Klient
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.countButton = new System.Windows.Forms.Button();
            this.primeNumberButton = new System.Windows.Forms.Button();
            this.allUsersButton = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.primeLabel = new System.Windows.Forms.Label();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.usersBox = new System.Windows.Forms.TextBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(921, 10);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(70, 16);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(767, 10);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(73, 16);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(771, 30);
            this.username.Margin = new System.Windows.Forms.Padding(4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(132, 22);
            this.username.TabIndex = 2;
            this.username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(925, 30);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(132, 22);
            this.password.TabIndex = 3;
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(925, 60);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(133, 28);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Log in";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(822, 329);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "JWT Token:";
            // 
            // countButton
            // 
            this.countButton.Enabled = false;
            this.countButton.Location = new System.Drawing.Point(16, 156);
            this.countButton.Margin = new System.Windows.Forms.Padding(4);
            this.countButton.Name = "countButton";
            this.countButton.Size = new System.Drawing.Size(128, 25);
            this.countButton.TabIndex = 6;
            this.countButton.Text = "Users counter";
            this.countButton.UseVisualStyleBackColor = true;
            this.countButton.Click += new System.EventHandler(this.countButton_Click);
            // 
            // primeNumberButton
            // 
            this.primeNumberButton.Enabled = false;
            this.primeNumberButton.Location = new System.Drawing.Point(16, 198);
            this.primeNumberButton.Margin = new System.Windows.Forms.Padding(4);
            this.primeNumberButton.Name = "primeNumberButton";
            this.primeNumberButton.Size = new System.Drawing.Size(128, 28);
            this.primeNumberButton.TabIndex = 7;
            this.primeNumberButton.Text = "Magic number";
            this.primeNumberButton.UseVisualStyleBackColor = true;
            this.primeNumberButton.Click += new System.EventHandler(this.primeNumberButton_Click);
            // 
            // allUsersButton
            // 
            this.allUsersButton.Enabled = false;
            this.allUsersButton.Location = new System.Drawing.Point(16, 243);
            this.allUsersButton.Margin = new System.Windows.Forms.Padding(4);
            this.allUsersButton.Name = "allUsersButton";
            this.allUsersButton.Size = new System.Drawing.Size(128, 28);
            this.allUsersButton.TabIndex = 8;
            this.allUsersButton.Text = "Users";
            this.allUsersButton.UseVisualStyleBackColor = true;
            this.allUsersButton.Click += new System.EventHandler(this.allUsersButton_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(161, 165);
            this.countLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(0, 16);
            this.countLabel.TabIndex = 9;
            // 
            // primeLabel
            // 
            this.primeLabel.AutoSize = true;
            this.primeLabel.Location = new System.Drawing.Point(161, 210);
            this.primeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.primeLabel.Name = "primeLabel";
            this.primeLabel.Size = new System.Drawing.Size(0, 16);
            this.primeLabel.TabIndex = 10;
            // 
            // tokenBox
            // 
            this.tokenBox.Location = new System.Drawing.Point(826, 349);
            this.tokenBox.Margin = new System.Windows.Forms.Padding(4);
            this.tokenBox.Multiline = true;
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.ReadOnly = true;
            this.tokenBox.Size = new System.Drawing.Size(228, 192);
            this.tokenBox.TabIndex = 11;
            // 
            // usersBox
            // 
            this.usersBox.Location = new System.Drawing.Point(164, 243);
            this.usersBox.Margin = new System.Windows.Forms.Padding(4);
            this.usersBox.Multiline = true;
            this.usersBox.Name = "usersBox";
            this.usersBox.ReadOnly = true;
            this.usersBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.usersBox.Size = new System.Drawing.Size(299, 298);
            this.usersBox.TabIndex = 12;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcomeLabel.Location = new System.Drawing.Point(771, 30);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.welcomeLabel.Size = new System.Drawing.Size(287, 22);
            this.welcomeLabel.TabIndex = 13;
            this.welcomeLabel.Text = "Witaj Andrzej";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.welcomeLabel.Visible = false;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(925, 60);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(134, 28);
            this.logoutButton.TabIndex = 14;
            this.logoutButton.Text = "Log out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Visible = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.usersBox);
            this.Controls.Add(this.tokenBox);
            this.Controls.Add(this.primeLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.allUsersButton);
            this.Controls.Add(this.primeNumberButton);
            this.Controls.Add(this.countButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button countButton;
        private System.Windows.Forms.Button primeNumberButton;
        private System.Windows.Forms.Button allUsersButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label primeLabel;
        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.TextBox usersBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button logoutButton;
    }
}

