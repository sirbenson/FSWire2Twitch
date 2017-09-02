using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Diagnostics;
using System.IO;

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
            if(timer.Enabled)
            {
                buttonStart.BackColor = Color.Green;
                buttonStart.Text = "Start";

                timer.Enabled = false;
                timer.Stop();

                textBoxOutputDir.Enabled = true;
                textBoxUsername.Enabled = true;
                comboBoxFlightStatus.Enabled = true;
                listBoxFlightStatus.Enabled = true;
                buttonSaveFlightStatus.Enabled = true;
                buttonSelectOutput.Enabled = true;
                buttonDeleteStatus.Enabled = true;

                toolStripStatusLabel.Text = "Not running";

                return;
            }

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

            if(!Directory.Exists(textBoxOutputDir.Text + "/FSWire2Twitch"))
            {
                Directory.CreateDirectory(textBoxOutputDir.Text + " /FSWire2Twitch");
            }

            textBoxOutputDir.Enabled = false;
            textBoxUsername.Enabled = false;
            comboBoxFlightStatus.Enabled = false;
            listBoxFlightStatus.Enabled = false;
            buttonSaveFlightStatus.Enabled = false;
            buttonSelectOutput.Enabled = false;
            buttonDeleteStatus.Enabled = false;

            toolStripStatusLabel.Text = "Running. Intervall: 10 seconds";

            buttonStart.BackColor = Color.Red;
            buttonStart.Text = "Stop";

            ReadJson();

            timer.Enabled = true;
            timer.Start();
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
                        string airplaneHeading = x.Value<string>("heading");
                        string airplaneAltitude = x.Value<string>("altitude");
                        string airplaneGroundspeed = x.Value<string>("groundspeed");
                        string airplanePhase = x.Value<string>("phase");
                        string flightDistRemain = x.Value<string>("distremain");
                        string timeRemain = x.Value<string>("timeremaining");

                        var jsonBid = x.Value<JToken>("bid");

                        string flightNumber = jsonBid.Value<string>("flightnum");
                        string flightDepTime = jsonBid.Value<string>("deptime");
                        string flightArrTime = jsonBid.Value<string>("arrtime");

                        var jsonDepapt = jsonBid.Value<JToken>("depapt");
                        var jsonArrapt = jsonBid.Value<JToken>("arrapt");

                        string airportStart = jsonDepapt.Value<string>("name");
                        string airportStartICAO = jsonDepapt.Value<string>("icao");
                        string airportStop = jsonArrapt.Value<string>("name");
                        string airportStopICAO = jsonArrapt.Value<string>("icao");

                        listBoxFlightData.Items.Clear();

                        listBoxFlightData.Items.Add("Heading: " + airplaneHeading);
                        listBoxFlightData.Items.Add("Altitude: " + airplaneAltitude);
                        listBoxFlightData.Items.Add("Groundspeed: " + airplaneGroundspeed);
                        listBoxFlightData.Items.Add("Phase: " + airplanePhase);
                        listBoxFlightData.Items.Add("DistRemain: " + flightDistRemain);
                        listBoxFlightData.Items.Add("TimeRemain: " + timeRemain);
                        listBoxFlightData.Items.Add("flightNumber: " + flightNumber);
                        listBoxFlightData.Items.Add("DepTime: " + flightDepTime);
                        listBoxFlightData.Items.Add("ArrTime: " + flightArrTime);
                        listBoxFlightData.Items.Add("Start: " + airportStart);
                        listBoxFlightData.Items.Add("StartICAO: " + airportStartICAO);
                        listBoxFlightData.Items.Add("Stop: " + airportStop);
                        listBoxFlightData.Items.Add("StopICAO: " + airportStopICAO);

                        if (!Directory.Exists(textBoxOutputDir.Text + "/FSWire2Twitch"))
                        {
                            Directory.CreateDirectory(textBoxOutputDir.Text + " /FSWire2Twitch");
                        }

                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/airplaneHeading.txt", airplaneHeading);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/airplaneAltitude.txt", airplaneAltitude);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/airplaneGroundspeed.txt", airplaneGroundspeed);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/airplanePhase.txt", airplanePhase);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/flightDistRemain.txt", flightDistRemain);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/timeRemain.txt", timeRemain);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/flightNumber.txt", flightNumber);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/flightDepTime.txt", flightDepTime);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/flightArrTime.txt", flightArrTime);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/airportStart.txt", airportStart);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/airportStartICAO.txt", airportStartICAO);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/airportStop.txt", airportStop);
                        System.IO.File.WriteAllText(textBoxOutputDir.Text + "/FSWire2Twitch/airportStopICAO.txt", airportStopICAO);

                        return;
                    }

                }

            }

            textBoxLog.AppendText("Error: username not found!\n" );
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ReadJson();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/sirbenson.official/?fref=ts");
        }
    }
}
