namespace YouTubeToMP3.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.donateAtKoFiLinkLabel = new System.Windows.Forms.LinkLabel();
            this.gitHubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.youTubeToMP3Label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Red;
            this.mainPanel.Controls.Add(this.donateAtKoFiLinkLabel);
            this.mainPanel.Controls.Add(this.gitHubLinkLabel);
            this.mainPanel.Controls.Add(this.descriptionLabel);
            this.mainPanel.Controls.Add(this.youTubeToMP3Label);
            this.mainPanel.Controls.Add(this.pictureBox1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(639, 281);
            this.mainPanel.TabIndex = 0;
            // 
            // donateAtKoFiLinkLabel
            // 
            this.donateAtKoFiLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.donateAtKoFiLinkLabel.AutoSize = true;
            this.donateAtKoFiLinkLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donateAtKoFiLinkLabel.ForeColor = System.Drawing.Color.White;
            this.donateAtKoFiLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.donateAtKoFiLinkLabel.Location = new System.Drawing.Point(12, 251);
            this.donateAtKoFiLinkLabel.Name = "donateAtKoFiLinkLabel";
            this.donateAtKoFiLinkLabel.Size = new System.Drawing.Size(334, 21);
            this.donateAtKoFiLinkLabel.TabIndex = 4;
            this.donateAtKoFiLinkLabel.TabStop = true;
            this.donateAtKoFiLinkLabel.Text = "Please consider donating to the creator at Ko-fi";
            this.donateAtKoFiLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DonateAtKoFiLinkLabelLinkClickedEvent);
            // 
            // gitHubLinkLabel
            // 
            this.gitHubLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gitHubLinkLabel.AutoSize = true;
            this.gitHubLinkLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gitHubLinkLabel.ForeColor = System.Drawing.Color.White;
            this.gitHubLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.gitHubLinkLabel.Location = new System.Drawing.Point(12, 230);
            this.gitHubLinkLabel.Name = "gitHubLinkLabel";
            this.gitHubLinkLabel.Size = new System.Drawing.Size(134, 21);
            this.gitHubLinkLabel.TabIndex = 3;
            this.gitHubLinkLabel.TabStop = true;
            this.gitHubLinkLabel.Text = "GitHub repository";
            this.gitHubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLinkLabelLinkClicked);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.White;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 135);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(563, 63);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "YouTube to MP3 allows users to download their music from YouTube.\r\n\r\nThis softwar" +
    "e should be used for educational or personal backup purposes only!";
            // 
            // youTubeToMP3Label
            // 
            this.youTubeToMP3Label.AutoSize = true;
            this.youTubeToMP3Label.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.youTubeToMP3Label.ForeColor = System.Drawing.Color.White;
            this.youTubeToMP3Label.Location = new System.Drawing.Point(138, 12);
            this.youTubeToMP3Label.Name = "youTubeToMP3Label";
            this.youTubeToMP3Label.Size = new System.Drawing.Size(267, 45);
            this.youTubeToMP3Label.TabIndex = 1;
            this.youTubeToMP3Label.Text = "YouTube to MP3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YouTubeToMP3.Properties.Resources.YouTubeIconSquare;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 281);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(655, 320);
            this.Name = "AboutForm";
            this.Text = "About - YouTube to MP3";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel gitHubLinkLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label youTubeToMP3Label;
        private System.Windows.Forms.LinkLabel donateAtKoFiLinkLabel;
    }
}