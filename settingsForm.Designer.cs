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
            lblHomeDir = new Label();
            lblPlayerDir = new Label();
            panel2 = new Panel();
            btnBrowseHomeDir = new PictureBox();
            valueHomeDir = new TextBox();
            btnBrowsePlayerDir = new PictureBox();
            btnClearHomeDir = new PictureBox();
            valuePlayerDir = new TextBox();
            btnClearPlayerDir = new PictureBox();
            valueProfile = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBrowseHomeDir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnBrowsePlayerDir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClearHomeDir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClearPlayerDir).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblHomeDir);
            panel1.Controls.Add(lblPlayerDir);
            panel1.Location = new Point(12, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(159, 264);
            panel1.TabIndex = 0;
            // 
            // lblHomeDir
            // 
            lblHomeDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            lblPlayerDir.Location = new Point(3, 10);
            lblPlayerDir.Name = "lblPlayerDir";
            lblPlayerDir.Size = new Size(153, 26);
            lblPlayerDir.TabIndex = 0;
            lblPlayerDir.Text = "Player directory";
            lblPlayerDir.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(valueProfile);
            panel2.Controls.Add(btnBrowseHomeDir);
            panel2.Controls.Add(valueHomeDir);
            panel2.Controls.Add(btnBrowsePlayerDir);
            panel2.Controls.Add(btnClearHomeDir);
            panel2.Controls.Add(valuePlayerDir);
            panel2.Controls.Add(btnClearPlayerDir);
            panel2.Location = new Point(177, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(426, 264);
            panel2.TabIndex = 1;
            // 
            // btnBrowseHomeDir
            // 
            btnBrowseHomeDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseHomeDir.Cursor = Cursors.Hand;
            btnBrowseHomeDir.Image = Properties.Resources.browse;
            btnBrowseHomeDir.Location = new Point(325, 108);
            btnBrowseHomeDir.Name = "btnBrowseHomeDir";
            btnBrowseHomeDir.Size = new Size(20, 20);
            btnBrowseHomeDir.SizeMode = PictureBoxSizeMode.StretchImage;
            btnBrowseHomeDir.TabIndex = 9;
            btnBrowseHomeDir.TabStop = false;
            btnBrowseHomeDir.Visible = false;
            btnBrowseHomeDir.MouseEnter += btnBrowseHomeDir_MouseEnter;
            btnBrowseHomeDir.MouseLeave += btnBrowseHomeDir_MouseLeave;
            // 
            // valueHomeDir
            // 
            valueHomeDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valueHomeDir.Location = new Point(3, 77);
            valueHomeDir.Name = "valueHomeDir";
            valueHomeDir.ReadOnly = true;
            valueHomeDir.Size = new Size(368, 25);
            valueHomeDir.TabIndex = 1;
            // 
            // btnBrowsePlayerDir
            // 
            btnBrowsePlayerDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowsePlayerDir.Cursor = Cursors.Hand;
            btnBrowsePlayerDir.Image = Properties.Resources.browse;
            btnBrowsePlayerDir.Location = new Point(325, 42);
            btnBrowsePlayerDir.Name = "btnBrowsePlayerDir";
            btnBrowsePlayerDir.Size = new Size(20, 20);
            btnBrowsePlayerDir.SizeMode = PictureBoxSizeMode.StretchImage;
            btnBrowsePlayerDir.TabIndex = 8;
            btnBrowsePlayerDir.TabStop = false;
            btnBrowsePlayerDir.Click += btnBrowsePlayerDir_Click;
            btnBrowsePlayerDir.MouseEnter += btnBrowsePlayerDir_MouseEnter;
            btnBrowsePlayerDir.MouseLeave += btnBrowsePlayerDir_MouseLeave;
            // 
            // btnClearHomeDir
            // 
            btnClearHomeDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearHomeDir.Cursor = Cursors.Hand;
            btnClearHomeDir.Image = Properties.Resources.bin;
            btnClearHomeDir.Location = new Point(351, 42);
            btnClearHomeDir.Name = "btnClearHomeDir";
            btnClearHomeDir.Size = new Size(20, 20);
            btnClearHomeDir.SizeMode = PictureBoxSizeMode.StretchImage;
            btnClearHomeDir.TabIndex = 7;
            btnClearHomeDir.TabStop = false;
            btnClearHomeDir.MouseEnter += btnClearHomeDir_MouseEnter;
            btnClearHomeDir.MouseLeave += btnClearHomeDir_MouseLeave;
            // 
            // valuePlayerDir
            // 
            valuePlayerDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valuePlayerDir.Location = new Point(3, 11);
            valuePlayerDir.Name = "valuePlayerDir";
            valuePlayerDir.ReadOnly = true;
            valuePlayerDir.Size = new Size(368, 25);
            valuePlayerDir.TabIndex = 0;
            // 
            // btnClearPlayerDir
            // 
            btnClearPlayerDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearPlayerDir.Cursor = Cursors.Hand;
            btnClearPlayerDir.Image = Properties.Resources.bin;
            btnClearPlayerDir.Location = new Point(351, 108);
            btnClearPlayerDir.Name = "btnClearPlayerDir";
            btnClearPlayerDir.Size = new Size(20, 20);
            btnClearPlayerDir.SizeMode = PictureBoxSizeMode.StretchImage;
            btnClearPlayerDir.TabIndex = 6;
            btnClearPlayerDir.TabStop = false;
            btnClearPlayerDir.Visible = false;
            btnClearPlayerDir.Click += btnClearPlayerDir_Click;
            btnClearPlayerDir.MouseEnter += btnClearPlayerDir_MouseEnter;
            btnClearPlayerDir.MouseLeave += btnClearPlayerDir_MouseLeave;
            // 
            // valueProfile
            // 
            valueProfile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valueProfile.Location = new Point(3, 143);
            valueProfile.Name = "valueProfile";
            valueProfile.ReadOnly = true;
            valueProfile.Size = new Size(368, 25);
            valueProfile.TabIndex = 10;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(3, 142);
            label1.Name = "label1";
            label1.Size = new Size(153, 26);
            label1.TabIndex = 2;
            label1.Text = "Active profile";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // settingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 41, 44);
            ClientSize = new Size(615, 373);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Bahnschrift", 11F);
            ForeColor = Color.Silver;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "settingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            Load += settingsForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnBrowseHomeDir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnBrowsePlayerDir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClearHomeDir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClearPlayerDir).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblPlayerDir;
        private Panel panel2;
        private Label lblHomeDir;
        private TextBox valuePlayerDir;
        private TextBox valueHomeDir;
        private PictureBox btnClearPlayerDir;
        private PictureBox btnClearHomeDir;
        private PictureBox btnBrowsePlayerDir;
        private PictureBox btnBrowseHomeDir;
        private TextBox valueProfile;
        private Label label1;
    }
}