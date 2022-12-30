namespace YouTubeToMP3.Forms
{
    partial class PreferencesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
            this.generalFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.maximalConcurrentlyRunningProcessCountLabel = new System.Windows.Forms.Label();
            this.maximalConcurrentlyRunningProcessCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.outputDirectoryLabel = new System.Windows.Forms.Label();
            this.outputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.selectOutputDirectoryButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.generalFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximalConcurrentlyRunningProcessCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // generalFlowLayoutPanel
            // 
            this.generalFlowLayoutPanel.Controls.Add(this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox);
            this.generalFlowLayoutPanel.Controls.Add(this.maximalConcurrentlyRunningProcessCountLabel);
            this.generalFlowLayoutPanel.Controls.Add(this.maximalConcurrentlyRunningProcessCountNumericUpDown);
            this.generalFlowLayoutPanel.Controls.Add(this.outputDirectoryLabel);
            this.generalFlowLayoutPanel.Controls.Add(this.outputDirectoryTextBox);
            this.generalFlowLayoutPanel.Controls.Add(this.selectOutputDirectoryButton);
            this.generalFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.generalFlowLayoutPanel.Name = "generalFlowLayoutPanel";
            this.generalFlowLayoutPanel.Size = new System.Drawing.Size(572, 104);
            this.generalFlowLayoutPanel.TabIndex = 1;
            // 
            // disableMaximalConcurrentlyRunningProcessCountLimitCheckBox
            // 
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.AutoSize = true;
            this.generalFlowLayoutPanel.SetFlowBreak(this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox, true);
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.Location = new System.Drawing.Point(3, 3);
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.Name = "disableMaximalConcurrentlyRunningProcessCountLimitCheckBox";
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.Size = new System.Drawing.Size(290, 17);
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.TabIndex = 1;
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.Text = "Disable maximal concurrently running process count limit";
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.UseVisualStyleBackColor = true;
            this.disableMaximalConcurrentlyRunningProcessCountLimitCheckBox.CheckedChanged += new System.EventHandler(this.DisableMaximalConcurrentlyRunningProcessCountLimitCheckBoxCheckedChangedEvent);
            // 
            // maximalConcurrentlyRunningProcessCountLabel
            // 
            this.maximalConcurrentlyRunningProcessCountLabel.AutoSize = true;
            this.maximalConcurrentlyRunningProcessCountLabel.Location = new System.Drawing.Point(3, 23);
            this.maximalConcurrentlyRunningProcessCountLabel.Name = "maximalConcurrentlyRunningProcessCountLabel";
            this.maximalConcurrentlyRunningProcessCountLabel.Size = new System.Drawing.Size(214, 13);
            this.maximalConcurrentlyRunningProcessCountLabel.TabIndex = 3;
            this.maximalConcurrentlyRunningProcessCountLabel.Text = "Maximal concurrently running process count";
            // 
            // maximalConcurrentlyRunningProcessCountNumericUpDown
            // 
            this.generalFlowLayoutPanel.SetFlowBreak(this.maximalConcurrentlyRunningProcessCountNumericUpDown, true);
            this.maximalConcurrentlyRunningProcessCountNumericUpDown.Location = new System.Drawing.Point(223, 26);
            this.maximalConcurrentlyRunningProcessCountNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maximalConcurrentlyRunningProcessCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maximalConcurrentlyRunningProcessCountNumericUpDown.Name = "maximalConcurrentlyRunningProcessCountNumericUpDown";
            this.maximalConcurrentlyRunningProcessCountNumericUpDown.Size = new System.Drawing.Size(80, 20);
            this.maximalConcurrentlyRunningProcessCountNumericUpDown.TabIndex = 2;
            this.maximalConcurrentlyRunningProcessCountNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.maximalConcurrentlyRunningProcessCountNumericUpDown.ValueChanged += new System.EventHandler(this.MaximalConcurrentlyRunningProcessCountNumericUpDownValueChangedEvent);
            // 
            // outputDirectoryLabel
            // 
            this.outputDirectoryLabel.AutoSize = true;
            this.generalFlowLayoutPanel.SetFlowBreak(this.outputDirectoryLabel, true);
            this.outputDirectoryLabel.Location = new System.Drawing.Point(3, 49);
            this.outputDirectoryLabel.Name = "outputDirectoryLabel";
            this.outputDirectoryLabel.Size = new System.Drawing.Size(82, 13);
            this.outputDirectoryLabel.TabIndex = 6;
            this.outputDirectoryLabel.Text = "Output directory";
            // 
            // outputDirectoryTextBox
            // 
            this.outputDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirectoryTextBox.Location = new System.Drawing.Point(3, 78);
            this.outputDirectoryTextBox.Name = "outputDirectoryTextBox";
            this.outputDirectoryTextBox.Size = new System.Drawing.Size(400, 20);
            this.outputDirectoryTextBox.TabIndex = 4;
            this.outputDirectoryTextBox.Text = "./MP3";
            this.outputDirectoryTextBox.TextChanged += new System.EventHandler(this.OutputDirectoryTextBoxTextChangedEvent);
            // 
            // selectOutputDirectoryButton
            // 
            this.selectOutputDirectoryButton.Location = new System.Drawing.Point(409, 78);
            this.selectOutputDirectoryButton.Name = "selectOutputDirectoryButton";
            this.selectOutputDirectoryButton.Size = new System.Drawing.Size(160, 23);
            this.selectOutputDirectoryButton.TabIndex = 5;
            this.selectOutputDirectoryButton.Text = "Select output directory...";
            this.selectOutputDirectoryButton.UseVisualStyleBackColor = true;
            this.selectOutputDirectoryButton.Click += new System.EventHandler(this.SelectOutputDirectoryButtonClickEvent);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 104);
            this.Controls.Add(this.generalFlowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(588, 143);
            this.MinimumSize = new System.Drawing.Size(588, 143);
            this.Name = "PreferencesForm";
            this.Text = "Preferences - YouTube to MP3";
            this.generalFlowLayoutPanel.ResumeLayout(false);
            this.generalFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximalConcurrentlyRunningProcessCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel generalFlowLayoutPanel;
        private System.Windows.Forms.CheckBox disableMaximalConcurrentlyRunningProcessCountLimitCheckBox;
        private System.Windows.Forms.Label maximalConcurrentlyRunningProcessCountLabel;
        private System.Windows.Forms.NumericUpDown maximalConcurrentlyRunningProcessCountNumericUpDown;
        private System.Windows.Forms.Label outputDirectoryLabel;
        private System.Windows.Forms.TextBox outputDirectoryTextBox;
        private System.Windows.Forms.Button selectOutputDirectoryButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}