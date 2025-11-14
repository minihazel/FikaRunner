namespace FikaRunner
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            topPanel = new Panel();
            settingsClient = new Label();
            settingsCopyOutput = new Label();
            clientTitle = new Label();
            homeTitle = new Label();
            settingsTitle = new Label();
            panel2 = new Panel();
            btnBrowseClientFolder = new PictureBox();
            panel4 = new Panel();
            btnCopyOutput = new PictureBox();
            panel3 = new Panel();
            btnOpenSettings = new PictureBox();
            watermarkSeparator2 = new Panel();
            watermarkSeparator1 = new Panel();
            btnBrowseClient = new PictureBox();
            btnBrowseServer = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            watermarkTitle = new Label();
            watermarkIcon = new PictureBox();
            mainPanel = new Panel();
            outputPanel = new Panel();
            consoleOutput = new FastColoredTextBoxNS.FastColoredTextBox();
            panelPlayerProfile = new Panel();
            btnPlayerProfile = new Button();
            lblPlayerProfile = new Label();
            dropdownList = new Panel();
            panelProfileInfo = new Panel();
            statusInvalidProfile = new Label();
            profileSeparator3 = new Panel();
            statusGameEdition = new Label();
            profileSeparator2 = new Panel();
            statusAID = new Label();
            profileSeparator1 = new Panel();
            statusDisplayName = new Label();
            errorPanel = new Panel();
            label3 = new Label();
            panelInstruction = new Panel();
            imgInstruction = new PictureBox();
            label2 = new Label();
            topPanel.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBrowseClientFolder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCopyOutput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnOpenSettings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnBrowseClient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnBrowseServer).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)watermarkIcon).BeginInit();
            mainPanel.SuspendLayout();
            outputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)consoleOutput).BeginInit();
            panelPlayerProfile.SuspendLayout();
            panelProfileInfo.SuspendLayout();
            errorPanel.SuspendLayout();
            panelInstruction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgInstruction).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            topPanel.Controls.Add(settingsClient);
            topPanel.Controls.Add(settingsCopyOutput);
            topPanel.Controls.Add(clientTitle);
            topPanel.Controls.Add(homeTitle);
            topPanel.Controls.Add(settingsTitle);
            topPanel.Controls.Add(panel2);
            topPanel.Controls.Add(panel1);
            topPanel.Controls.Add(watermarkIcon);
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(849, 129);
            topPanel.TabIndex = 0;
            // 
            // settingsClient
            // 
            settingsClient.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            settingsClient.Font = new Font("Bahnschrift", 8F, FontStyle.Bold);
            settingsClient.Location = new Point(674, 76);
            settingsClient.Name = "settingsClient";
            settingsClient.Size = new Size(43, 22);
            settingsClient.TabIndex = 6;
            settingsClient.Text = "CLIENT";
            settingsClient.TextAlign = ContentAlignment.MiddleCenter;
            settingsClient.Visible = false;
            // 
            // settingsCopyOutput
            // 
            settingsCopyOutput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            settingsCopyOutput.Font = new Font("Bahnschrift", 8F, FontStyle.Bold);
            settingsCopyOutput.Location = new Point(562, 76);
            settingsCopyOutput.Name = "settingsCopyOutput";
            settingsCopyOutput.Size = new Size(37, 22);
            settingsCopyOutput.TabIndex = 5;
            settingsCopyOutput.Text = "COPY";
            settingsCopyOutput.TextAlign = ContentAlignment.MiddleCenter;
            settingsCopyOutput.Visible = false;
            // 
            // clientTitle
            // 
            clientTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clientTitle.Font = new Font("Bahnschrift", 8F, FontStyle.Bold);
            clientTitle.Location = new Point(792, 76);
            clientTitle.Name = "clientTitle";
            clientTitle.Size = new Size(33, 22);
            clientTitle.TabIndex = 3;
            clientTitle.Text = "PLAY";
            clientTitle.TextAlign = ContentAlignment.MiddleCenter;
            clientTitle.Visible = false;
            // 
            // homeTitle
            // 
            homeTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            homeTitle.Font = new Font("Bahnschrift", 8F, FontStyle.Bold);
            homeTitle.Location = new Point(733, 76);
            homeTitle.Name = "homeTitle";
            homeTitle.Size = new Size(37, 22);
            homeTitle.TabIndex = 4;
            homeTitle.Text = "HOME";
            homeTitle.TextAlign = ContentAlignment.MiddleCenter;
            homeTitle.Visible = false;
            // 
            // settingsTitle
            // 
            settingsTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            settingsTitle.Font = new Font("Bahnschrift", 8F, FontStyle.Bold);
            settingsTitle.Location = new Point(609, 76);
            settingsTitle.Name = "settingsTitle";
            settingsTitle.Size = new Size(57, 22);
            settingsTitle.TabIndex = 2;
            settingsTitle.Text = "SETTINGS";
            settingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            settingsTitle.Visible = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(btnBrowseClientFolder);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(btnCopyOutput);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(btnOpenSettings);
            panel2.Controls.Add(watermarkSeparator2);
            panel2.Controls.Add(watermarkSeparator1);
            panel2.Controls.Add(btnBrowseClient);
            panel2.Controls.Add(btnBrowseServer);
            panel2.Location = new Point(558, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(269, 36);
            panel2.TabIndex = 2;
            // 
            // btnBrowseClientFolder
            // 
            btnBrowseClientFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseClientFolder.Cursor = Cursors.Hand;
            btnBrowseClientFolder.Image = Properties.Resources.player;
            btnBrowseClientFolder.Location = new Point(122, 3);
            btnBrowseClientFolder.Name = "btnBrowseClientFolder";
            btnBrowseClientFolder.Size = new Size(30, 30);
            btnBrowseClientFolder.SizeMode = PictureBoxSizeMode.StretchImage;
            btnBrowseClientFolder.TabIndex = 9;
            btnBrowseClientFolder.TabStop = false;
            btnBrowseClientFolder.Click += btnBrowseClientFolder_Click;
            btnBrowseClientFolder.MouseEnter += btnBrowseClientFolder_MouseEnter;
            btnBrowseClientFolder.MouseLeave += btnBrowseClientFolder_MouseLeave;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.Location = new Point(44, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(15, 30);
            panel4.TabIndex = 8;
            // 
            // btnCopyOutput
            // 
            btnCopyOutput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCopyOutput.Cursor = Cursors.Hand;
            btnCopyOutput.Image = Properties.Resources.copy;
            btnCopyOutput.Location = new Point(8, 3);
            btnCopyOutput.Name = "btnCopyOutput";
            btnCopyOutput.Size = new Size(30, 30);
            btnCopyOutput.SizeMode = PictureBoxSizeMode.StretchImage;
            btnCopyOutput.TabIndex = 7;
            btnCopyOutput.TabStop = false;
            btnCopyOutput.Click += btnCopyOutput_Click;
            btnCopyOutput.MouseEnter += btnCopyOutput_MouseEnter;
            btnCopyOutput.MouseLeave += btnCopyOutput_MouseLeave;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Location = new Point(101, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(15, 30);
            panel3.TabIndex = 6;
            // 
            // btnOpenSettings
            // 
            btnOpenSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenSettings.Cursor = Cursors.Hand;
            btnOpenSettings.Image = Properties.Resources.settings;
            btnOpenSettings.Location = new Point(65, 3);
            btnOpenSettings.Name = "btnOpenSettings";
            btnOpenSettings.Size = new Size(30, 30);
            btnOpenSettings.SizeMode = PictureBoxSizeMode.StretchImage;
            btnOpenSettings.TabIndex = 5;
            btnOpenSettings.TabStop = false;
            btnOpenSettings.Click += btnOpenSettings_Click;
            btnOpenSettings.MouseEnter += btnOpenSettings_MouseEnter;
            btnOpenSettings.MouseLeave += btnOpenSettings_MouseLeave;
            // 
            // watermarkSeparator2
            // 
            watermarkSeparator2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            watermarkSeparator2.Location = new Point(158, 3);
            watermarkSeparator2.Name = "watermarkSeparator2";
            watermarkSeparator2.Size = new Size(15, 30);
            watermarkSeparator2.TabIndex = 4;
            // 
            // watermarkSeparator1
            // 
            watermarkSeparator1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            watermarkSeparator1.Location = new Point(215, 3);
            watermarkSeparator1.Name = "watermarkSeparator1";
            watermarkSeparator1.Size = new Size(15, 30);
            watermarkSeparator1.TabIndex = 1;
            // 
            // btnBrowseClient
            // 
            btnBrowseClient.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseClient.Cursor = Cursors.Hand;
            btnBrowseClient.Image = Properties.Resources.client;
            btnBrowseClient.Location = new Point(236, 3);
            btnBrowseClient.Name = "btnBrowseClient";
            btnBrowseClient.Size = new Size(30, 30);
            btnBrowseClient.SizeMode = PictureBoxSizeMode.StretchImage;
            btnBrowseClient.TabIndex = 3;
            btnBrowseClient.TabStop = false;
            btnBrowseClient.Click += btnBrowseClient_Click;
            btnBrowseClient.MouseEnter += btnBrowseClient_MouseEnter;
            btnBrowseClient.MouseLeave += btnBrowseClient_MouseLeave;
            // 
            // btnBrowseServer
            // 
            btnBrowseServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseServer.Cursor = Cursors.Hand;
            btnBrowseServer.Image = Properties.Resources.home;
            btnBrowseServer.Location = new Point(179, 3);
            btnBrowseServer.Name = "btnBrowseServer";
            btnBrowseServer.Size = new Size(30, 30);
            btnBrowseServer.SizeMode = PictureBoxSizeMode.StretchImage;
            btnBrowseServer.TabIndex = 2;
            btnBrowseServer.TabStop = false;
            btnBrowseServer.Click += btnBrowseServer_Click;
            btnBrowseServer.MouseEnter += btnBrowseServer_MouseEnter;
            btnBrowseServer.MouseLeave += btnBrowseServer_MouseLeave;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(watermarkTitle);
            panel1.Location = new Point(127, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 123);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Bahnschrift", 9F);
            label1.Location = new Point(3, 70);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 0, 0, 0);
            label1.Size = new Size(419, 22);
            label1.TabIndex = 1;
            label1.Text = "For use with SPT 4.X.X or above";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // watermarkTitle
            // 
            watermarkTitle.Font = new Font("Bender", 30F);
            watermarkTitle.Location = new Point(3, 31);
            watermarkTitle.Name = "watermarkTitle";
            watermarkTitle.Size = new Size(419, 45);
            watermarkTitle.TabIndex = 0;
            watermarkTitle.Text = "SPT Fika - Launcher";
            watermarkTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // watermarkIcon
            // 
            watermarkIcon.Image = Properties.Resources.fika1;
            watermarkIcon.Location = new Point(24, 24);
            watermarkIcon.Name = "watermarkIcon";
            watermarkIcon.Size = new Size(80, 80);
            watermarkIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            watermarkIcon.TabIndex = 0;
            watermarkIcon.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.Controls.Add(outputPanel);
            mainPanel.Controls.Add(panelPlayerProfile);
            mainPanel.Location = new Point(12, 135);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(825, 381);
            mainPanel.TabIndex = 1;
            // 
            // outputPanel
            // 
            outputPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            outputPanel.BackColor = Color.FromArgb(26, 30, 34);
            outputPanel.BorderStyle = BorderStyle.FixedSingle;
            outputPanel.Controls.Add(consoleOutput);
            outputPanel.Location = new Point(3, 26);
            outputPanel.Name = "outputPanel";
            outputPanel.Size = new Size(489, 346);
            outputPanel.TabIndex = 1;
            // 
            // consoleOutput
            // 
            consoleOutput.AccessibleDescription = "Textbox control";
            consoleOutput.AccessibleName = "Fast Colored Text Box";
            consoleOutput.AccessibleRole = AccessibleRole.Text;
            consoleOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleOutput.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            consoleOutput.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            consoleOutput.AutoScrollMinSize = new Size(2, 17);
            consoleOutput.BackBrush = null;
            consoleOutput.BackColor = Color.FromArgb(26, 30, 34);
            consoleOutput.CaretColor = Color.White;
            consoleOutput.CharHeight = 17;
            consoleOutput.CharWidth = 8;
            consoleOutput.DefaultMarkerSize = 8;
            consoleOutput.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            consoleOutput.FindForm = null;
            consoleOutput.FoldingHighlightColor = Color.LightGray;
            consoleOutput.FoldingHighlightEnabled = false;
            consoleOutput.Font = new Font("Consolas", 11F);
            consoleOutput.GoToForm = null;
            consoleOutput.Hotkeys = resources.GetString("consoleOutput.Hotkeys");
            consoleOutput.IsReplaceMode = false;
            consoleOutput.Location = new Point(5, 5);
            consoleOutput.Name = "consoleOutput";
            consoleOutput.Paddings = new Padding(0);
            consoleOutput.ReadOnly = true;
            consoleOutput.ReplaceForm = null;
            consoleOutput.SelectionColor = Color.FromArgb(60, 192, 192, 192);
            consoleOutput.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("consoleOutput.ServiceColors");
            consoleOutput.ShowLineNumbers = false;
            consoleOutput.Size = new Size(477, 333);
            consoleOutput.TabIndex = 0;
            consoleOutput.ToolTipDelay = 100;
            consoleOutput.Zoom = 100;
            // 
            // panelPlayerProfile
            // 
            panelPlayerProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelPlayerProfile.Controls.Add(btnPlayerProfile);
            panelPlayerProfile.Controls.Add(lblPlayerProfile);
            panelPlayerProfile.Controls.Add(dropdownList);
            panelPlayerProfile.Controls.Add(panelProfileInfo);
            panelPlayerProfile.Font = new Font("Bender", 14F);
            panelPlayerProfile.Location = new Point(508, 3);
            panelPlayerProfile.Name = "panelPlayerProfile";
            panelPlayerProfile.Size = new Size(314, 369);
            panelPlayerProfile.TabIndex = 0;
            // 
            // btnPlayerProfile
            // 
            btnPlayerProfile.Cursor = Cursors.Hand;
            btnPlayerProfile.FlatAppearance.BorderColor = SystemColors.WindowFrame;
            btnPlayerProfile.FlatStyle = FlatStyle.Flat;
            btnPlayerProfile.Font = new Font("Bender", 14F);
            btnPlayerProfile.ForeColor = Color.DarkOrange;
            btnPlayerProfile.Image = Properties.Resources.btn_art;
            btnPlayerProfile.ImageAlign = ContentAlignment.MiddleLeft;
            btnPlayerProfile.Location = new Point(11, 53);
            btnPlayerProfile.Name = "btnPlayerProfile";
            btnPlayerProfile.Padding = new Padding(5, 0, 0, 0);
            btnPlayerProfile.Size = new Size(292, 44);
            btnPlayerProfile.TabIndex = 2;
            btnPlayerProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnPlayerProfile.UseVisualStyleBackColor = true;
            btnPlayerProfile.Click += btnPlayerProfile_Click;
            // 
            // lblPlayerProfile
            // 
            lblPlayerProfile.Font = new Font("Bender", 16F);
            lblPlayerProfile.Location = new Point(11, 15);
            lblPlayerProfile.Name = "lblPlayerProfile";
            lblPlayerProfile.Size = new Size(292, 35);
            lblPlayerProfile.TabIndex = 0;
            lblPlayerProfile.Text = "Select player profile";
            lblPlayerProfile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dropdownList
            // 
            dropdownList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dropdownList.Cursor = Cursors.Hand;
            dropdownList.Location = new Point(11, 97);
            dropdownList.Name = "dropdownList";
            dropdownList.Size = new Size(292, 265);
            dropdownList.TabIndex = 3;
            dropdownList.Visible = false;
            dropdownList.Paint += dropdownList_Paint;
            dropdownList.MouseClick += dropdownList_MouseClick;
            dropdownList.MouseLeave += dropdownList_MouseLeave;
            dropdownList.MouseMove += dropdownList_MouseMove;
            // 
            // panelProfileInfo
            // 
            panelProfileInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelProfileInfo.Controls.Add(statusInvalidProfile);
            panelProfileInfo.Controls.Add(profileSeparator3);
            panelProfileInfo.Controls.Add(statusGameEdition);
            panelProfileInfo.Controls.Add(profileSeparator2);
            panelProfileInfo.Controls.Add(statusAID);
            panelProfileInfo.Controls.Add(profileSeparator1);
            panelProfileInfo.Controls.Add(statusDisplayName);
            panelProfileInfo.Location = new Point(11, 97);
            panelProfileInfo.Name = "panelProfileInfo";
            panelProfileInfo.Size = new Size(292, 265);
            panelProfileInfo.TabIndex = 4;
            // 
            // statusInvalidProfile
            // 
            statusInvalidProfile.Font = new Font("Bender", 12F, FontStyle.Bold);
            statusInvalidProfile.ForeColor = Color.IndianRed;
            statusInvalidProfile.Location = new Point(3, 187);
            statusInvalidProfile.Name = "statusInvalidProfile";
            statusInvalidProfile.Size = new Size(286, 42);
            statusInvalidProfile.TabIndex = 12;
            statusInvalidProfile.Text = "Invalid profile! Launching this profile may break.";
            statusInvalidProfile.TextAlign = ContentAlignment.MiddleLeft;
            statusInvalidProfile.Visible = false;
            // 
            // profileSeparator3
            // 
            profileSeparator3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profileSeparator3.Location = new Point(3, 165);
            profileSeparator3.Name = "profileSeparator3";
            profileSeparator3.Size = new Size(286, 10);
            profileSeparator3.TabIndex = 11;
            profileSeparator3.Paint += profileSeparator3_Paint;
            // 
            // statusGameEdition
            // 
            statusGameEdition.Font = new Font("Bender", 12F, FontStyle.Bold);
            statusGameEdition.Location = new Point(3, 128);
            statusGameEdition.Name = "statusGameEdition";
            statusGameEdition.Size = new Size(286, 25);
            statusGameEdition.TabIndex = 10;
            statusGameEdition.Text = "Game edition:";
            statusGameEdition.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // profileSeparator2
            // 
            profileSeparator2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profileSeparator2.Location = new Point(3, 107);
            profileSeparator2.Name = "profileSeparator2";
            profileSeparator2.Size = new Size(286, 10);
            profileSeparator2.TabIndex = 9;
            profileSeparator2.Paint += profileSeparator2_Paint;
            // 
            // statusAID
            // 
            statusAID.Font = new Font("Bender", 12F, FontStyle.Bold);
            statusAID.Location = new Point(3, 70);
            statusAID.Name = "statusAID";
            statusAID.Size = new Size(286, 25);
            statusAID.TabIndex = 8;
            statusAID.Text = "Profile AID:";
            statusAID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // profileSeparator1
            // 
            profileSeparator1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profileSeparator1.Location = new Point(3, 49);
            profileSeparator1.Name = "profileSeparator1";
            profileSeparator1.Size = new Size(286, 10);
            profileSeparator1.TabIndex = 7;
            profileSeparator1.Paint += profileSeparator1_Paint;
            // 
            // statusDisplayName
            // 
            statusDisplayName.Font = new Font("Bender", 12F, FontStyle.Bold);
            statusDisplayName.Location = new Point(3, 12);
            statusDisplayName.Name = "statusDisplayName";
            statusDisplayName.Size = new Size(286, 25);
            statusDisplayName.TabIndex = 0;
            statusDisplayName.Text = "Display name:";
            statusDisplayName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // errorPanel
            // 
            errorPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            errorPanel.Controls.Add(label3);
            errorPanel.Controls.Add(panelInstruction);
            errorPanel.Controls.Add(label2);
            errorPanel.Location = new Point(12, 135);
            errorPanel.Name = "errorPanel";
            errorPanel.Size = new Size(825, 381);
            errorPanel.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.Font = new Font("Bender", 14F);
            label3.Location = new Point(23, 75);
            label3.Name = "label3";
            label3.Size = new Size(778, 124);
            label3.TabIndex = 4;
            label3.Text = "Or the path to your player install was cleared.\r\n\r\n\r\nClick 'PLAY' and browse to the game install you will play from.";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelInstruction
            // 
            panelInstruction.Anchor = AnchorStyles.None;
            panelInstruction.BorderStyle = BorderStyle.FixedSingle;
            panelInstruction.Controls.Add(imgInstruction);
            panelInstruction.Location = new Point(306, 202);
            panelInstruction.Name = "panelInstruction";
            panelInstruction.Size = new Size(213, 127);
            panelInstruction.TabIndex = 3;
            // 
            // imgInstruction
            // 
            imgInstruction.BorderStyle = BorderStyle.FixedSingle;
            imgInstruction.Image = Properties.Resources.I4BIgA9emk;
            imgInstruction.Location = new Point(4, 4);
            imgInstruction.Name = "imgInstruction";
            imgInstruction.Size = new Size(203, 117);
            imgInstruction.SizeMode = PictureBoxSizeMode.CenterImage;
            imgInstruction.TabIndex = 2;
            imgInstruction.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Bender", 24F, FontStyle.Bold);
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(819, 68);
            label2.TabIndex = 1;
            label2.Text = "First game launch detected";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 41, 44);
            ClientSize = new Size(849, 528);
            Controls.Add(topPanel);
            Controls.Add(mainPanel);
            Controls.Add(errorPanel);
            Font = new Font("Bahnschrift", 11F);
            ForeColor = Color.Silver;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(865, 567);
            Name = "mainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Activated += mainForm_Activated;
            FormClosing += mainForm_FormClosing;
            Load += mainForm_Load;
            topPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnBrowseClientFolder).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCopyOutput).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnOpenSettings).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnBrowseClient).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnBrowseServer).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)watermarkIcon).EndInit();
            mainPanel.ResumeLayout(false);
            outputPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)consoleOutput).EndInit();
            panelPlayerProfile.ResumeLayout(false);
            panelProfileInfo.ResumeLayout(false);
            errorPanel.ResumeLayout(false);
            panelInstruction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgInstruction).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private PictureBox watermarkIcon;
        private Panel panel1;
        private Label watermarkTitle;
        private Label label1;
        private PictureBox btnBrowseServer;
        private Panel panel2;
        private PictureBox btnBrowseClient;
        private Panel watermarkSeparator1;
        private PictureBox btnOpenSettings;
        private Panel watermarkSeparator2;
        private Label settingsTitle;
        private Label clientTitle;
        private Label homeTitle;
        private Panel mainPanel;
        private Panel errorPanel;
        private Panel panelPlayerProfile;
        private Label lblPlayerProfile;
        private Button btnPlayerProfile;
        private Panel outputPanel;
        private FastColoredTextBoxNS.FastColoredTextBox consoleOutput;
        private PictureBox btnCopyOutput;
        private Panel panel3;
        private Label settingsCopyOutput;
        private Panel dropdownList;
        private Label label2;
        private PictureBox imgInstruction;
        private Panel panelInstruction;
        private Label label3;
        private Panel panelProfileInfo;
        private Label statusDisplayName;
        private Panel profileSeparator2;
        private Label statusAID;
        private Panel profileSeparator1;
        private Panel profileSeparator3;
        private Label statusGameEdition;
        private PictureBox btnBrowseClientFolder;
        private Panel panel4;
        private Label settingsClient;
        private Label statusInvalidProfile;
    }
}
