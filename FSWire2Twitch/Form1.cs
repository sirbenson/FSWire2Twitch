using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace FSWire2Twitch
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDeleteStatus_Click(object sender, EventArgs e)
        {
            if (listBoxFlightStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a created flightstatus", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxFlightStatus.Items.RemoveAt(listBoxFlightStatus.SelectedIndex);
        }

        private void buttonSaveFlightStatus_Click(object sender, EventArgs e)
        {
            if (comboBoxFlightStatus.SelectedIndex < 0 || openFileDialog.FileName == "")
            {
                MessageBox.Show("Please select a flightstatus", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxFlightStatus.Items.Add(comboBoxFlightStatus.SelectedItem + "|" + openFileDialog.FileName);
        }

        private void comboBoxFlightStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFlightStatus.SelectedItem != null)
            {
                openFileDialog.ShowDialog();

                if (openFileDialog.FileName == "")
                {
                    MessageBox.Show("Please select an audio file in .wav format", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text.Length < 1)
            {
                MessageBox.Show("You must set your username from FSWire!", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxOutputDir.Text.Length < 1)
            {
                MessageBox.Show("You must choose a output directory!", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReadJson();
        }

        private void buttonSelectOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();

            if (folderBrowserDialog.SelectedPath == "")
            {
                MessageBox.Show("Please select a correct output directory!", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBoxOutputDir.Text = folderBrowserDialog.SelectedPath;
        }

        private void ReadJson()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("https://vas.fswire.net/api/v1/acars/data");

                var jObject = JObject.Parse(json);

                var acarsData = jObject.Value<JToken>("ACARSData");

                foreach (var x in acarsData)
                {
                    var jsonUser = x.Value<JToken>("user");
                    string username = jsonUser.Value<string>("username");

                    if (username == textBoxUsername.Text)
                    {

                        string airplaneHeading = jsonUser.Value<string>("heading");
                        string airplaneAltitude = jsonUser.Value<string>("altitude");
                        string airplaneGroundspeed = jsonUser.Value<string>("groundspeed");
                        string airplanePhase = jsonUser.Value<string>("phase");
                        string flightDistRemain = jsonUser.Value<string>("distremain");
                        string timeRemain = jsonUser.Value<string>("timeremaining");

                        var jsonBid = x.Value<JToken>("bid");

                        string flightNumer = jsonBid.Value<string>("flightnum");
                        string flightDepTime = jsonBid.Value<string>("deptime");
                        string flightArrTime = jsonBid.Value<string>("arrtime");

                        var jsonDepapt = jsonBid.Value<JToken>("depapt");
                        var jsonArrapt = jsonBid.Value<JToken>("arrapt");

                        string airportStart = jsonDepapt.Value<string>("name");
                        string airportStartICAO = jsonDepapt.Value<string>("icao");
                        string airportStop = jsonArrapt.Value<string>("name");
                        string airportStopICAO = jsonArrapt.Value<string>("icao");

                        return;
                    }

                }

            }

            textBoxLog.AppendText("Error: username not found!");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ReadJson();
        }
    }
}
