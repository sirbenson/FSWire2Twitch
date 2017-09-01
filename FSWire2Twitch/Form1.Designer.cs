namespace FSWire2Twitch
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOutputDir = new System.Windows.Forms.TextBox();
            this.comboBoxFlightStatus = new System.Windows.Forms.ComboBox();
            this.buttonSaveFlightStatus = new System.Windows.Forms.Button();
            this.listBoxFlightStatus = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonDeleteStatus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonSelectOutput = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FSWire username:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BackColor = System.Drawing.Color.DimGray;
            this.textBoxUsername.ForeColor = System.Drawing.Color.White;
            this.textBoxUsername.Location = new System.Drawing.Point(242, 10);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(237, 21);
            this.textBoxUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File output directory:";
            // 
            // textBoxOutputDir
            // 
            this.textBoxOutputDir.BackColor = System.Drawing.Color.DimGray;
            this.textBoxOutputDir.ForeColor = System.Drawing.Color.White;
            this.textBoxOutputDir.Location = new System.Drawing.Point(242, 44);
            this.textBoxOutputDir.Name = "textBoxOutputDir";
            this.textBoxOutputDir.Size = new System.Drawing.Size(156, 21);
            this.textBoxOutputDir.TabIndex = 3;
            // 
            // comboBoxFlightStatus
            // 
            this.comboBoxFlightStatus.BackColor = System.Drawing.Color.DimGray;
            this.comboBoxFlightStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFlightStatus.ForeColor = System.Drawing.Color.White;
            this.comboBoxFlightStatus.FormattingEnabled = true;
            this.comboBoxFlightStatus.Items.AddRange(new object[] {
            "Preflight",
            "Pushing Back",
            "Taxiing to Runway",
            "Taking Off",
            "Climbing",
            "Cruising",
            "Descending",
            "Approaching",
            "Final Approach",
            "Landing",
            "Arrived"});
            this.comboBoxFlightStatus.Location = new System.Drawing.Point(242, 75);
            this.comboBoxFlightStatus.Name = "comboBoxFlightStatus";
            this.comboBoxFlightStatus.Size = new System.Drawing.Size(156, 21);
            this.comboBoxFlightStatus.TabIndex = 4;
            this.comboBoxFlightStatus.Text = "Select flight status";
            this.comboBoxFlightStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxFlightStatus_SelectedIndexChanged);
            // 
            // buttonSaveFlightStatus
            // 
            this.buttonSaveFlightStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveFlightStatus.Location = new System.Drawing.Point(404, 75);
            this.buttonSaveFlightStatus.Name = "buttonSaveFlightStatus";
            this.buttonSaveFlightStatus.Size = new System.Drawing.Size(75, 21);
            this.buttonSaveFlightStatus.TabIndex = 5;
            this.buttonSaveFlightStatus.Text = "Save";
            this.buttonSaveFlightStatus.UseVisualStyleBackColor = true;
            this.buttonSaveFlightStatus.Click += new System.EventHandler(this.buttonSaveFlightStatus_Click);
            // 
            // listBoxFlightStatus
            // 
            this.listBoxFlightStatus.BackColor = System.Drawing.Color.DimGray;
            this.listBoxFlightStatus.ForeColor = System.Drawing.Color.White;
            this.listBoxFlightStatus.FormattingEnabled = true;
            this.listBoxFlightStatus.Location = new System.Drawing.Point(242, 102);
            this.listBoxFlightStatus.Name = "listBoxFlightStatus";
            this.listBoxFlightStatus.Size = new System.Drawing.Size(237, 95);
            this.listBoxFlightStatus.TabIndex = 6;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.Black;
            this.buttonStart.Location = new System.Drawing.Point(399, 203);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(80, 24);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonDeleteStatus
            // 
            this.buttonDeleteStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteStatus.Location = new System.Drawing.Point(242, 203);
            this.buttonDeleteStatus.Name = "buttonDeleteStatus";
            this.buttonDeleteStatus.Size = new System.Drawing.Size(115, 24);
            this.buttonDeleteStatus.TabIndex = 8;
            this.buttonDeleteStatus.Text = "Delete flight status";
            this.buttonDeleteStatus.UseVisualStyleBackColor = true;
            this.buttonDeleteStatus.Click += new System.EventHandler(this.buttonDeleteStatus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Status sound:";
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.Color.DimGray;
            this.textBoxLog.ForeColor = System.Drawing.Color.White;
            this.textBoxLog.Location = new System.Drawing.Point(16, 102);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(220, 125);
            this.textBoxLog.TabIndex = 11;
            // 
            // buttonSelectOutput
            // 
            this.buttonSelectOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectOutput.Location = new System.Drawing.Point(404, 44);
            this.buttonSelectOutput.Name = "buttonSelectOutput";
            this.buttonSelectOutput.Size = new System.Drawing.Size(75, 21);
            this.buttonSelectOutput.TabIndex = 12;
            this.buttonSelectOutput.Text = "Select";
            this.buttonSelectOutput.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Audio files|*.wav";
            this.openFileDialog.Title = "Please seelct an audio file in .wav format";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(491, 235);
            this.Controls.Add(this.buttonSelectOutput);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDeleteStatus);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listBoxFlightStatus);
            this.Controls.Add(this.buttonSaveFlightStatus);
            this.Controls.Add(this.comboBoxFlightStatus);
            this.Controls.Add(this.textBoxOutputDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(507, 274);
            this.MinimumSize = new System.Drawing.Size(507, 274);
            this.Name = "Form1";
            this.Text = "FSWire2Twitch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOutputDir;
        private System.Windows.Forms.ComboBox comboBoxFlightStatus;
        private System.Windows.Forms.Button buttonSaveFlightStatus;
        private System.Windows.Forms.ListBox listBoxFlightStatus;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonDeleteStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonSelectOutput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

