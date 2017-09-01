using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSWire2Twitch
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void RemoveItemFromListByStatus(string status)
        {

            foreach(string listItem in listBoxFlightStatus.Items)
            {
                string[] listItemArray = listItem.Split(Char.Parse(">"));
                if(listItemArray[0] == (status))
                {
                    listBoxFlightStatus.Items.Remove(listItem);
                    return;
                }
            }
        }

        private bool RemoveItemFromListByName(string name)
        {
            bool isRemoved = false;

            foreach (string listItem in listBoxFlightStatus.Items)
            {
                
                if (listItem == name)
                {
                    listBoxFlightStatus.Items.Remove(listItem);
                    isRemoved = true;
                }
            }

            return isRemoved;
        }

        private void buttonDeleteStatus_Click(object sender, EventArgs e)
        {
            if(listBoxFlightStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a created flightstatus", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxFlightStatus.Items.RemoveAt(listBoxFlightStatus.SelectedIndex);
        }

        private void buttonSaveFlightStatus_Click(object sender, EventArgs e)
        {
            if(comboBoxFlightStatus.SelectedIndex < 0 || openFileDialog.FileName == "")
            {
                MessageBox.Show("Please select a flightstatus", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RemoveItemFromListByStatus(comboBoxFlightStatus.SelectedText);
            
            listBoxFlightStatus.Items.Add(comboBoxFlightStatus.SelectedText + ">" + openFileDialog.FileName);
        }

        private void comboBoxFlightStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxFlightStatus.SelectedItem != null)
            {
                openFileDialog.ShowDialog();
                if(openFileDialog.FileName == "")
                {
                    MessageBox.Show("Please select an audio file in .wav format", "FSWire2Twitch error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }
    }
}
