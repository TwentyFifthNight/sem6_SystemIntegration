using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace IS8_Klient
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient;
        private string token = "";

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            var Username = username.Text;
            var Password = password.Text;

            var json = JsonConvert.SerializeObject(new { Username, Password });
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await this.httpClient.PostAsync("http://localhost:8080/api/users/authenticate", body);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Błędny login lub hasło.", "Błąd", MessageBoxButtons.OK);
                    return;
                }
                
                var result = await response.Content.ReadAsStringAsync();
                var authenticationResponse = JsonConvert.DeserializeObject<dynamic>(result);
                
                if (authenticationResponse == null)
                {
                    MessageBox.Show("Błędna odpowiedź serwera", "Błąd", MessageBoxButtons.OK);
                }
                else
                {
                    this.token = authenticationResponse.token;
                    tokenBox.Text = this.token;
                    this.httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.token}");

                    username.Visible = false;
                    password.Visible = false;
                    usernameLabel.Visible = false;
                    passwordLabel.Visible = false;
                    loginButton.Visible = false;
                    welcomeLabel.Text = "Witaj " + Username;
                    welcomeLabel.Visible = true;
                    logoutButton.Visible = true;

                    countButton.Enabled = true;
                    primeNumberButton.Enabled = true;
                    allUsersButton.Enabled = true;
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd przy próbie połączenia z serwerem", "Błąd", MessageBoxButtons.OK);
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            tokenBox.Text = "";
            countLabel.Text = "";
            primeLabel.Text = "";
            usersBox.Text = "";
            this.token = "";
            this.httpClient.DefaultRequestHeaders.Remove("Authorization");

            username.Text = "";
            password.Text = "";

            username.Visible = true;
            password.Visible = true;
            usernameLabel.Visible = true;
            passwordLabel.Visible = true;
            loginButton.Visible = true;
            welcomeLabel.Text = "";
            welcomeLabel.Visible = false;
            logoutButton.Visible = false;

            countButton.Enabled = false;
            primeNumberButton.Enabled = false;
            allUsersButton.Enabled = false;
        }

        private bool IsForbidden(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                MessageBox.Show( "Brak uprawnień!", "Niedozwolona akcja", MessageBoxButtons.OK);
                return true;
            }
            return false;
        }

        private async void countButton_Click(object sender, EventArgs e)
        {
            var response = await this.httpClient.GetAsync("http://localhost:8080/api/users/count");

            if (IsForbidden(response)) return;
            if (!response.IsSuccessStatusCode)
            {
                countLabel.Text = "";
                MessageBox.Show("Błąd przy próbie pobrania liczby użytkowników", "Błąd", MessageBoxButtons.OK);
                return;
            }

            var result = response.Content.ReadAsStringAsync().Result;
            var count = JsonConvert.DeserializeObject<dynamic>(result).count;

            if (count == null)
            {
                MessageBox.Show("Błędna odpowiedź serwera", "Błąd", MessageBoxButtons.OK);
            }
            else
            {
                countLabel.Text = count;
            }
        }

        private async void primeNumberButton_Click(object sender, EventArgs e)
        {
            var response = await this.httpClient.GetAsync("http://localhost:8080/api/prime");

            if (IsForbidden(response)) return;
            if (!response.IsSuccessStatusCode)
            {
                primeLabel.Text = "";
                MessageBox.Show("Błąd przy próbie pobrania liczby pierwszej", "Błąd", MessageBoxButtons.OK);
                return;
            }

            var result = response.Content.ReadAsStringAsync().Result;
            var prime = JsonConvert.DeserializeObject<dynamic>(result).primeNumber;

            if (prime == null)
            {
                MessageBox.Show("Błędna odpowiedź serwera", "Błąd", MessageBoxButtons.OK);
            }
            else
            {
                primeLabel.Text = prime;
            }
        }

        private async void allUsersButton_Click(object sender, EventArgs e)
        {
            var response = await this.httpClient.GetAsync("http://localhost:8080/api/users/getAll");

            if (IsForbidden(response)) return;
            if (!response.IsSuccessStatusCode) 
            {
                usersBox.Text = "";
                MessageBox.Show("Błąd przy próbie pobrania użytkowników", "Błąd", MessageBoxButtons.OK);
                return;
            }

            var result = response.Content.ReadAsStringAsync().Result;
            var users = JsonConvert.DeserializeObject<List<dynamic>>(result);

            if(users == null)
            {
                MessageBox.Show("Błędna odpowiedź serwera", "Błąd", MessageBoxButtons.OK);
            }
            else
            {
                var usersString = string.Join("\n", users);
                usersBox.Text = usersString;
            }
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                loginButton_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
