using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient;
        private string token = "";
        private static string choosenIndustry = "GórnictwoIWydobywanie";

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yearRange.RangeValues = "0,0";
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            var Username = username.Text;
            var Password = password.Text;

            var User = JsonConvert.SerializeObject(new { Username, Password });
            var content = new StringContent(User, Encoding.UTF8, "application/json");

            try
            {
                var response = await this.httpClient.PostAsync("http://localhost:8080/api/users/authenticate", content);

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
                    return;
                }
                else
                {
                    this.token = authenticationResponse.token;
                    this.httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.token}");

                    username.Visible = false;
                    password.Visible = false;
                    usernameLabel.Visible = false;
                    passwordLabel.Visible = false;
                    loginButton.Visible = false;
                    welcomeLabel.Text = "Witaj " + Username;
                    welcomeLabel.Visible = true;
                    logoutButton.Visible = true;
                    dataButton.Visible = true;
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd przy próbie połączenia z serwerem", "Błąd", MessageBoxButtons.OK);
                return;
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
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
            dataButton.Visible = false;
            ClearGraphData();
        }

        private bool IsForbidden(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Brak uprawnień!", "Niedozwolona akcja", MessageBoxButtons.OK);
                return true;
            }
            return false;
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private async Task<string> GetData(string urlCompletion = "industries")
        {
            try
            {
                var response = await this.httpClient.GetAsync("http://localhost:8080/api/data/" + urlCompletion);
                if (IsForbidden(response))
                {
                    return null;
                }
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Błąd prz odbieraniu danych", "Błąd", MessageBoxButtons.OK);
                    return null;
                }
                return await response.Content.ReadAsStringAsync();
            } catch (Exception)
            {
                MessageBox.Show("Błąd przy próbie połączenia z serwerem", "Błąd", MessageBoxButtons.OK);
                return null;
            }
        }


        private void CreatePollutionChecBoxes()
        {
            int i = 0;
            foreach (var series in this.graph.Series.ToList())
            {
                CheckBox box = new CheckBox
                {
                    Tag = i.ToString(),
                    Text = series.Name,
                    Name = "Pollutions",
                    AutoSize = true,
                    Checked = true,
                    Location = new Point(graph.Right + 10, graph.Top + 20 + i * 20)
                };
                box.CheckedChanged += new EventHandler(CheckBox_Checked);
                this.Controls.Add(box);
                i++;
            }
        }

        private void CreateIndustriesButtons(string data)
        {
            var industries = JsonConvert.DeserializeObject<dynamic>(data);

            int i = 0;
            foreach (var industry in industries)
            {
                RadioButton button = new RadioButton
                {
                    Tag = i.ToString(),
                    Text = industry.Name,
                    Name = "Industries",
                    Location = new Point(yearRange.Right + 50, yearRange.Top + 30 + i * 20),
                    Width = 1000
                };
                button.MouseClick += new MouseEventHandler(Radio_Clicked);
                if(i == 0)
                    button.Checked = true;
                this.Controls.Add(button);
                i++;
            }

            Label listLabel = new Label
            {
                Text = "Przemysły:",
                Name = "Industries",
                Location = new Point(yearRange.Right + 50, yearRange.Top + 10)
            };
            this.Controls.Add(listLabel);
        }

        
        private dynamic industries;
        private dynamic pollutions;

        private async void dataButton_Click(object sender, EventArgs e)
        {
            industries = await GetData();
            if (industries == null)
                return;
            pollutions = await GetData("pollutions");
            if (pollutions == null)
                return;

            graph.Series.Clear();
            try
            {
                if (yearRange.Range1 != "0")
                {
                    Graph.FillGraphWithPollutions(pollutions, this.graph, choosenIndustry,
                        int.Parse(yearRange.Range1), int.Parse(yearRange.Range2));
                    Graph.FillGraphWithIndustry(industries, choosenIndustry, this.graph, 
                        int.Parse(yearRange.Range1), int.Parse(yearRange.Range2));
                    graph.Invalidate();
                }
                else if (yearRange.Range1 == "0")
                {
                    Dictionary<string, int> graphData = Graph.FillGraphWithPollutions(pollutions, this.graph, choosenIndustry) ?? throw new Exception();
                    
                    //generowanie przedziału lat
                    IEnumerable<int> range = Enumerable.Range(graphData["floorYearRange"], graphData["ceilYearRange"] - graphData["floorYearRange"] + 1);
                    yearRange.RangeValues = string.Join(",", range);

                    CreatePollutionChecBoxes();

                    Graph.FillGraphWithIndustry(industries, choosenIndustry, this.graph, 
                        int.Parse(yearRange.Range1), int.Parse(yearRange.Range2));

                    graph.Invalidate();
                    graph.ChartAreas[0].AxisX.Interval = 1;
                    graph.ChartAreas[0].AxisX.Title = "Rok";
                    graph.ChartAreas[0].AxisX.TitleFont = SystemFonts.CaptionFont;
                    graph.ChartAreas[0].AxisY.Title = "Średnie stężenie(µg/m3)";
                    graph.ChartAreas[0].AxisY2.Title = "Wynik finansowy(tys. zł)";
                    graph.ChartAreas[0].AxisY2.TitleForeColor = Color.Brown;
                    graph.ChartAreas[0].AxisY.TitleFont = SystemFonts.CaptionFont;
                    graph.ChartAreas[0].AxisY2.TitleFont = SystemFonts.CaptionFont;
                    graph.ChartAreas[0].AxisX.IsMarginVisible = false;

                    CreateIndustriesButtons(industries);
                    saveButton.Visible = true;
                }
                foreach (CheckBox checkbox in Controls.Find("Pollutions", false).Cast<CheckBox>())
                {
                    checkbox.Checked = true;
                }

                yearRange.Visible = true;
                graph.Visible = true;
            }
            catch (Exception)
            {
                ClearGraphData();
                MessageBox.Show("Błąd przy tworzeniu grafu", "Błąd", MessageBoxButtons.OK);
            }
        }

        private void rangeSelectorControl1_Load(object sender, EventArgs e)
        {
        }

        private void CheckBox_Checked(object sender, EventArgs e)
        {
            CheckBox chk = (sender as CheckBox);
            this.graph.Series.FindByName(chk.Text).Enabled = chk.Checked;
            this.graph.ChartAreas[0].RecalculateAxesScale();
        }

        private void Radio_Clicked(object sender, EventArgs e)
        {
            RadioButton radio = (sender as RadioButton);
            choosenIndustry = radio.Text;
        }

        private void ClearGraphData()
        {
            saveButton.Visible = false;
            this.yearRange.Visible = false;
            this.yearRange.RangeValues = "0,0";
            this.graph.Series.Clear();
            graph.Visible = false;
            choosenIndustry = "GórnictwoIWydobywanie";
            foreach (Control checkbox in this.Controls.Find("Pollutions", false)
                .Concat(this.Controls.Find("Industries", false)))
            {
                checkbox.Dispose();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "json|*.json";
            saveFileDialog.Title = "Zapisz dane do pliku";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    //tworzenie słownika z widocznymi na grafie zanieczyszczeniami
                    Dictionary<string, JObject> choosenPollutions = new Dictionary<string, JObject>();
                    var pollutionsJson = JsonConvert.DeserializeObject(pollutions);
                    foreach (CheckBox checbox in Controls.Find("Pollutions", false).Cast<CheckBox>())
                    {
                        if (checbox.Checked)
                        {
                            choosenPollutions[checbox.Text] = pollutionsJson[checbox.Text];
                        }
                    }

                    try
                    {
                        //tworzenie słownika z danymi widocznych zanieczyszczeń i przemysłu
                        Dictionary<string, object> data = new Dictionary<string, object>()
                        {
                            [choosenIndustry] = JsonConvert.DeserializeObject(industries)[choosenIndustry],
                            ["pollutions"] = choosenPollutions
                        };

                        //zapis danych do pliku o podanej przez użytkownika nazwie
                        var json = JsonConvert.SerializeObject(data);
                        File.WriteAllText(saveFileDialog.FileName, json);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Błąd przy zapisie danych", "Błąd", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }
}
