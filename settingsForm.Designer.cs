namespace FikaRunner
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblHomeDir = new Label();
            lblPlayerDir = new Label();
            rightPanel = new Panel();
            chkDisplayPopup = new CheckBox();
            btnResetSettings = new PictureBox();
            statusConfirmed = new Label();
            btnDisplayMode = new Button();
            dropdownDisplay = new Panel();
            valueProfile = new TextBox();
            valueHomeDir = new TextBox();
            btnBrowsePlayerDir = new PictureBox();
            valuePlayerDir = new TextBox();
            panel1.SuspendLayout();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnResetSettings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnBrowsePlayerDir).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblHomeDir);
            panel1.Controls.Add(lblPlayerDir);
            panel1.Location = new Point(12, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(159, 408);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.Font = new Font("Bender", 11F, FontStyle.Bold);
            label3.Location = new Point(3, 164);
            label3.Name = "label3";
            label3.Size = new Size(153, 26);
            label3.TabIndex = 4;
            label3.Text = "Invalid profile";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Bender", 11F, FontStyle.Bold);
            label2.Location = new Point(3, 226);
            label2.Name = "label2";
            label2.Size = new Size(153, 26);
            label2.TabIndex = 3;
            label2.Text = "Game display mode";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Bender", 11F, FontStyle.Bold);
            label1.Location = new Point(3, 116);
            label1.Name = "label1";
            label1.Size = new Size(153, 26);
            label1.TabIndex = 2;
            label1.Text = "Active profile";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHomeDir
            // 
            lblHomeDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHomeDir.Font = new Font("Bender", 11F, FontStyle.Bold);
            lblHomeDir.Location = new Point(6, 76);
            lblHomeDir.Name = "lblHomeDir";
            lblHomeDir.Size = new Size(150, 26);
            lblHomeDir.TabIndex = 1;
            lblHomeDir.Text = "Home directory";
            lblHomeDir.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPlayerDir
            // 
            lblPlayerDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPlayerDir.Font = new Font("Bender", 11F, FontStyle.Bold);
            lblPlayerDir.Location = new Point(3, 10);
            lblPlayerDir.Name = "lblPlayerDir";
            lblPlayerDir.Size = new Size(153, 26);
            lblPlayerDir.TabIndex = 0;
            lblPlayerDir.Text = "Player directory";
            lblPlayerDir.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rightPanel
            // 
            rightPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rightPanel.Controls.Add(chkDisplayPopup);
            rightPanel.Controls.Add(btnResetSettings);
            rightPanel.Controls.Add(statusConfirmed);
            rightPanel.Controls.Add(btnDisplayMode);
            rightPanel.Controls.Add(dropdownDisplay);
            rightPanel.Controls.Add(valueProfile);
            rightPanel.Controls.Add(valueHomeDir);
            rightPanel.Controls.Add(btnBrowsePlayerDir);
            rightPanel.Controls.Add(valuePlayerDir);
            rightPanel.Location = new Point(177, 54);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(426, 408);
            rightPanel.TabIndex = 1;
            // 
            // chkDisplayPopup
            // 
            chkDisplayPopup.AutoSize = true;
            chkDisplayPopup.Cursor = Cursors.Hand;
            chkDisplayPopup.Location = new Point(3, 159);
            chkDisplayPopup.Name = "chkDisplayPopup";
            chkDisplayPopup.Size = new Size(382, 40);
            chkDisplayPopup.TabIndex = 16;
            chkDisplayPopup.Text = "Display pop-up warning for incomplete/invalid profile\r\nwhen running the game";
            chkDisplayPopup.UseVisualStyleBackColor = true;
            chkDisplayPopup.CheckedChanged += chkDisplayPopup_CheckedChanged;
            // 
            // btnResetSettings
            // 
            btnResetSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnResetSettings.Cursor = Cursors.Hand;
            btnResetSettings.Image = Properties.Resources.reset;
            btnResetSettings.Location = new Point(341, 365);
            btnResetSettings.Name = "btnResetSettings";
            btnResetSettings.Size = new Size(30, 30);
            btnResetSettings.SizeMode = PictureBoxSizeMode.StretchImage;
            btnResetSettings.TabIndex = 14;
            btnResetSettings.TabStop = false;
            btnResetSettings.Click += btnResetSettings_Click;
            btnResetSettings.MouseEnter += btnResetSettings_MouseEnter;
            btnResetSettings.MouseLeave += btnResetSettings_MouseLeave;
            // 
            // statusConfirmed
            // 
            statusConfirmed.Font = new Font("Bahnschrift", 14F);
            statusConfirmed.Location = new Point(310, 220);
            statusConfirmed.Name = "statusConfirmed";
            statusConfirmed.Size = new Size(35, 35);
            statusConfirmed.TabIndex = 13;
            statusConfirmed.Text = "✔️";
            statusConfirmed.TextAlign = ContentAlignment.MiddleCenter;
            statusConfirmed.Visible = false;
            // 
            // btnDisplayMode
            // 
            btnDisplayMode.Cursor = Cursors.Hand;
            btnDisplayMode.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnDisplayMode.FlatStyle = FlatStyle.Flat;
            btnDisplayMode.Font = new Font("Bender", 14F);
            btnDisplayMode.ForeColor = Color.DarkOrange;
            btnDisplayMode.Image = Properties.Resources.btn_art;
            btnDisplayMode.ImageAlign = ContentAlignment.MiddleLeft;
            btnDisplayMode.Location = new Point(3, 217);
            btnDisplayMode.Name = "btnDisplayMode";
            btnDisplayMode.Padding = new Padding(5, 0, 0, 0);
            btnDisplayMode.Size = new Size(292, 44);
            btnDisplayMode.TabIndex = 11;
            btnDisplayMode.Text = "> Windowed";
            btnDisplayMode.TextAlign = ContentAlignment.MiddleLeft;
            btnDisplayMode.UseVisualStyleBackColor = true;
            btnDisplayMode.Click += btnDisplayMode_Click;
            // 
            // dropdownDisplay
            // 
            dropdownDisplay.Cursor = Cursors.Hand;
            dropdownDisplay.Font = new Font("Bender", 11F, FontStyle.Bold);
            dropdownDisplay.Location = new Point(3, 261);
            dropdownDisplay.Name = "dropdownDisplay";
            dropdownDisplay.Size = new Size(292, 133);
            dropdownDisplay.TabIndex = 12;
            dropdownDisplay.Visible = false;
            dropdownDisplay.Paint += dropdownDisplay_Paint;
            dropdownDisplay.MouseClick += dropdownDisplay_MouseClick;
            dropdownDisplay.MouseLeave += dropdownDisplay_MouseLeave;
            dropdownDisplay.MouseMove += dropdownDisplay_MouseMove;
            // 
            // valueProfile
            // 
            valueProfile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valueProfile.Font = new Font("Bender", 11F, FontStyle.Bold);
            valueProfile.Location = new Point(3, 117);
            valueProfile.Name = "valueProfile";
            valueProfile.ReadOnly = true;
            valueProfile.Size = new Size(368, 24);
            valueProfile.TabIndex = 10;
            // 
            // valueHomeDir
            // 
            valueHomeDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valueHomeDir.Font = new Font("Bender", 11F, FontStyle.Bold);
            valueHomeDir.Location = new Point(3, 77);
            valueHomeDir.Name = "valueHomeDir";
            valueHomeDir.ReadOnly = true;
            valueHomeDir.Size = new Size(368, 24);
            valueHomeDir.TabIndex = 1;
            // 
            // btnBrowsePlayerDir
            // 
            btnBrowsePlayerDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowsePlayerDir.Cursor = Cursors.Hand;
            btnBrowsePlayerDir.Image = Properties.Resources.browse;
            btnBrowsePlayerDir.Location = new Point(351, 41);
            btnBrowsePlayerDir.Name = "btnBrowsePlayerDir";
            btnBrowsePlayerDir.Size = new Size(20, 20);
            btnBrowsePlayerDir.SizeMode = PictureBoxSizeMode.StretchImage;
            btnBrowsePlayerDir.TabIndex = 8;
            btnBrowsePlayerDir.TabStop = false;
            btnBrowsePlayerDir.Click += btnBrowsePlayerDir_Click;
            btnBrowsePlayerDir.MouseEnter += btnBrowsePlayerDir_MouseEnter;
            btnBrowsePlayerDir.MouseLeave += btnBrowsePlayerDir_MouseLeave;
            // 
            // valuePlayerDir
            // 
            valuePlayerDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valuePlayerDir.Font = new Font("Bender", 11F, FontStyle.Bold);
            valuePlayerDir.Location = new Point(3, 11);
            valuePlayerDir.Name = "valuePlayerDir";
            valuePlayerDir.ReadOnly = true;
            valuePlayerDir.Size = new Size(368, 24);
            valuePlayerDir.TabIndex = 0;
            // 
            // settingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 41, 44);
            ClientSize = new Size(615, 474);
            Controls.Add(rightPanel);
            Controls.Add(panel1);
            Font = new Font("Bahnschrift", 11F);
            ForeColor = Color.Silver;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(631, 513);
            Name = "settingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            Load += settingsForm_Load;
            panel1.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnResetSettings).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnBrowsePlayerDir).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblPlayerDir;
        private Panel rightPanel;
        private Label lblHomeDir;
        private TextBox valuePlayerDir;
        private TextBox valueHomeDir;
        private PictureBox btnBrowsePlayerDir;
        private TextBox valueProfile;
        private Label label1;
        private Label label2;
        private Button btnDisplayMode;
        private Panel dropdownDisplay;
        private Label statusConfirmed;
        private PictureBox btnResetSettings;
        private Label label3;
        private CheckBox chkDisplayPopup;
    }
}