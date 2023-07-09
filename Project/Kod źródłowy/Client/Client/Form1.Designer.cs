using System.Reflection;

namespace Client
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.primeLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataButton = new System.Windows.Forms.Button();
            this.yearRange = new CustomRangeSelectorControl.RangeSelectorControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(1350, 5);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(1222, 5);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(1222, 21);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(125, 20);
            this.username.TabIndex = 2;
            this.username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(1353, 22);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(128, 20);
            this.password.TabIndex = 3;
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnterKeyPress);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(1222, 47);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(125, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Log in";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(121, 134);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(0, 13);
            this.countLabel.TabIndex = 9;
            // 
            // primeLabel
            // 
            this.primeLabel.AutoSize = true;
            this.primeLabel.Location = new System.Drawing.Point(121, 171);
            this.primeLabel.Name = "primeLabel";
            this.primeLabel.Size = new System.Drawing.Size(0, 13);
            this.primeLabel.TabIndex = 10;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcomeLabel.Location = new System.Drawing.Point(1222, 21);
            this.welcomeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.welcomeLabel.Size = new System.Drawing.Size(259, 18);
            this.welcomeLabel.TabIndex = 13;
            this.welcomeLabel.Text = "Witaj Andrzej";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.welcomeLabel.Visible = false;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(1353, 47);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(128, 23);
            this.logoutButton.TabIndex = 14;
            this.logoutButton.Text = "Log out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Visible = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // graph
            // 
            this.graph.BackColor = System.Drawing.Color.Transparent;
            this.graph.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graph.Legends.Add(legend1);
            this.graph.Location = new System.Drawing.Point(1, 10);
            this.graph.Margin = new System.Windows.Forms.Padding(2);
            this.graph.Name = "graph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.graph.Series.Add(series1);
            this.graph.Size = new System.Drawing.Size(1106, 524);
            this.graph.TabIndex = 15;
            this.graph.Text = "chart1";
            this.graph.Visible = false;
            // 
            // dataButton
            // 
            this.dataButton.Location = new System.Drawing.Point(340, 10);
            this.dataButton.Name = "dataButton";
            this.dataButton.Size = new System.Drawing.Size(112, 23);
            this.dataButton.TabIndex = 16;
            this.dataButton.Text = "Narysuj wykres";
            this.dataButton.UseVisualStyleBackColor = true;
            this.dataButton.Visible = false;
            this.dataButton.Click += new System.EventHandler(this.dataButton_Click);
            // 
            // yearRange
            // 
            this.yearRange.BackColor = System.Drawing.Color.White;
            this.yearRange.DelimiterForRange = ",";
            this.yearRange.DisabledBarColor = System.Drawing.Color.Gray;
            this.yearRange.DisabledRangeLabelColor = System.Drawing.Color.Gray;
            this.yearRange.GapFromLeftMargin = ((uint)(20u));
            this.yearRange.GapFromRightMargin = ((uint)(20u));
            this.yearRange.HeightOfThumb = 20F;
            this.yearRange.InFocusBarColor = System.Drawing.Color.DodgerBlue;
            this.yearRange.InFocusRangeLabelColor = System.Drawing.Color.Black;
            this.yearRange.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.yearRange.LeftThumbImagePath = null;
            this.yearRange.Location = new System.Drawing.Point(94, 527);
            this.yearRange.MiddleBarWidth = ((uint)(3u));
            this.yearRange.Name = "yearRange";
            this.yearRange.OutputStringFontColor = System.Drawing.Color.Transparent;
            this.yearRange.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.yearRange.Range1 = "2011";
            this.yearRange.Range2 = "2013";
            this.yearRange.RangeString = "Zakres";
            this.yearRange.RangeValues = "2011,2012,2013";
            this.yearRange.RightThumbImagePath = null;
            this.yearRange.Size = new System.Drawing.Size(685, 80);
            this.yearRange.TabIndex = 19;
            this.yearRange.ThumbColor = System.Drawing.Color.DodgerBlue;
            this.yearRange.Visible = false;
            this.yearRange.WidthOfThumb = 10F;
            this.yearRange.XMLFileName = null;
            this.yearRange.Load += new System.EventHandler(this.rangeSelectorControl1_Load);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(458, 11);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Zapisz dane";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 650);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.yearRange);
            this.Controls.Add(this.dataButton);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.primeLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label primeLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph;
        private System.Windows.Forms.Button dataButton;
        private CustomRangeSelectorControl.RangeSelectorControl yearRange;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button saveButton;
    }
}

