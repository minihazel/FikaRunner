using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FikaRunner
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.globalClientDirectory))
            {
                valuePlayerDir.Text = "Nothing detected, browse for a game directory";
            }
            else
            {
                valuePlayerDir.Text = Properties.Settings.Default.globalClientDirectory;
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.globalHomeDirectory))
            {
                valueHomeDir.Text = "Nothing detected, browse for a game directory";
            }
            else
            {
                valueHomeDir.Text = Properties.Settings.Default.globalHomeDirectory;
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.lastProfile))
            {
                valueProfile.Text = "Nothing detected, select a profile";
            }
            else
            {
                valueProfile.Text = Properties.Settings.Default.lastProfileName;
                valueProfile.Tag = Properties.Settings.Default.lastProfile;
            }

            lblPlayerDir.Select();
        }

        private void btnClearPlayerDir_MouseEnter(object sender, EventArgs e)
        {
            btnClearPlayerDir.Image = Properties.Resources.bin_selected;
        }

        private void btnClearPlayerDir_MouseLeave(object sender, EventArgs e)
        {
            btnClearPlayerDir.Image = Properties.Resources.bin;
        }

        private void btnClearHomeDir_MouseEnter(object sender, EventArgs e)
        {
            btnClearHomeDir.Image = Properties.Resources.bin_selected;
        }

        private void btnClearHomeDir_MouseLeave(object sender, EventArgs e)
        {
            btnClearHomeDir.Image = Properties.Resources.bin;
        }

        private void btnClearPlayerDir_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowsePlayerDir_MouseEnter(object sender, EventArgs e)
        {
            btnBrowsePlayerDir.Image = Properties.Resources.browse_selected;
        }

        private void btnBrowsePlayerDir_MouseLeave(object sender, EventArgs e)
        {
            btnBrowsePlayerDir.Image = Properties.Resources.browse;
        }

        private void btnBrowseHomeDir_MouseEnter(object sender, EventArgs e)
        {
            btnBrowseHomeDir.Image = Properties.Resources.browse_selected;
        }

        private void btnBrowseHomeDir_MouseLeave(object sender, EventArgs e)
        {
            btnBrowseHomeDir.Image = Properties.Resources.browse;
        }

        private void btnBrowsePlayerDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a game install folder (where EscapeFromTarkov.exe is)";
            fbd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string root = fbd.SelectedPath;

                bool doesRootExist = Directory.Exists(root);
                if (doesRootExist)
                {
                    if (mainForm.areThereSPTFilesInThePlayerDirectory(root))
                    {
                        if (mainForm.isFikaCorePresent(root))
                        {
                            mainForm.playerDir = root;
                            valuePlayerDir.Text = root;

                            Properties.Settings.Default.globalClientDirectory = root;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
            }

            return;
        }
    }
}
