using System.Diagnostics;
using System.Drawing.Text;
using FikaRunner.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timer = System.Windows.Forms.Timer;

namespace FikaRunner
{
    public partial class settingsForm : Form, IMessageFilter
    {
        private readonly mainForm _parentForm;
        public static string currentConfigPath = Properties.Settings.Default.globalClientDirectory;
        public string extendedConfigPath = string.Empty;
        public static bool isDropdownOpen = false;
        private int dropdownItemHeight = 40;
        private int hoveredDropdownIndex = -1;
        private List<string> displayModes = new List<string>
        {
            "Windowed", // 2
            "Borderless Fullscreen", // 1
            "Fullscreen" // 0
        };

        public settingsForm(mainForm parent)
        {
            InitializeComponent();
            Application.AddMessageFilter(this);

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, dropdownDisplay, new object[] { true });

            _parentForm = parent;
        }

        public bool PreFilterMessage(ref Message m)
        {
            // WM_LBUTTONDOWN = 0x0201 (left mouse button down)
            if (m.Msg == 0x0201 && dropdownDisplay.Visible)
            {
                Point clickPos = dropdownDisplay.PointToClient(Cursor.Position);
                if (!dropdownDisplay.ClientRectangle.Contains(clickPos))
                {
                    dropdownDisplay.Invalidate();
                    dropdownDisplay.Visible = false;
                    isDropdownOpen = false;
                    return false; // allow message to continue
                }
            }

            return false; // don't block any messages
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.globalClientDirectory))
            {
                valuePlayerDir.Text = "Nothing detected, browse for a game directory";
                btnDisplayMode.Enabled = false;
            }
            else
            {
                valuePlayerDir.Text = Properties.Settings.Default.globalClientDirectory;
                btnDisplayMode.Enabled = true;
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

            if (Properties.Settings.Default.firstLaunch)
            {
                btnBrowsePlayerDir.Enabled = false;
                btnClearPlayerDir.Enabled = false;
            }
            else
            {
                btnBrowsePlayerDir.Enabled = true;
                btnClearPlayerDir.Enabled = true;
            }

            chkDisplayPopup.Checked = Properties.Settings.Default.displayWarning;

            string displayModeSetting = Properties.Settings.Default.displayMode;
            btnDisplayMode.Text = "> " + displayModeSetting;

            extendedConfigPath = Path.Join(currentConfigPath, "SPT", "user", "sptSettings", "Graphics.ini");
            lblPlayerDir.Select();
        }

        private void btnClearPlayerDir_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnClearPlayerDir_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btnClearHomeDir_MouseEnter(object sender, EventArgs e)
        {
            btnClearPlayerDir.Image = Properties.Resources.bin_selected;
        }

        private void btnClearHomeDir_MouseLeave(object sender, EventArgs e)
        {
            btnClearPlayerDir.Image = Properties.Resources.bin;
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

        }

        private void btnBrowseHomeDir_MouseLeave(object sender, EventArgs e)
        {

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
                            Properties.Settings.Default.globalClientDirectory = root;
                            Properties.Settings.Default.Save();

                            mainForm.playerDir = root;
                            valuePlayerDir.Text = root;

                            bool isSwitching = true;
                            _parentForm.showMainPanel(isSwitching);
                        }
                    }
                }
            }

            return;
        }

        private void btnDisplayMode_Click(object sender, EventArgs e)
        {
            if (!isDropdownOpen)
            {
                showProfileDropdown();
            }
            else
            {
                closeProfileDropdown();
            }
        }

        public void showProfileDropdown()
        {
            dropdownDisplay.Size = new Size(dropdownDisplay.Width, dropdownItemHeight * displayModes.Count);
            dropdownDisplay.Refresh();
            dropdownDisplay.Visible = true;
            isDropdownOpen = true;
        }

        public void closeProfileDropdown()
        {
            dropdownDisplay.Invalidate();
            dropdownDisplay.Visible = false;
            isDropdownOpen = false;
        }

        private void dropdownDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (!isDropdownOpen) return;
            Panel panel = (Panel)sender;

            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(28, 30, 32));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            for (int i = 0; i < displayModes.Count; i++)
            {
                Rectangle itemRect = new Rectangle(-1, i * dropdownItemHeight, panel.Width + 1, dropdownItemHeight);

                bool isHovered = (i == hoveredDropdownIndex);

                // bg
                Color backColor = isHovered ? Color.FromArgb(40, 42, 44) : Color.FromArgb(28, 30, 32);
                using (Brush backBrush = new SolidBrush(backColor))
                {
                    g.FillRectangle(backBrush, itemRect);
                }

                // text
                using (Brush textBrush = new SolidBrush(Color.Silver))
                using (Font font = new Font("Bender", 11, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    };

                    g.DrawString(displayModes[i], font, textBrush,
                                new RectangleF(itemRect.X + 10, itemRect.Y, itemRect.Width - 10, itemRect.Height), sf);
                }
            }
        }

        private void dropdownDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            int index = e.Y / dropdownItemHeight;

            if (index >= 0 && index < displayModes.Count)
            {
                if (hoveredDropdownIndex != index)
                {
                    hoveredDropdownIndex = index;
                    panel.Invalidate();
                }
            }
        }

        private void dropdownDisplay_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;

            if (hoveredDropdownIndex != -1)
            {
                hoveredDropdownIndex = -1;
                panel.Invalidate();
            }
        }

        private void dropdownDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            int index = e.Y / dropdownItemHeight;

            if (index >= 0 && index < displayModes.Count)
            {
                displayModeSelected(index);
            }
        }

        private void displayModeSelected(int index)
        {
            string selectedItem = displayModes[index];
            closeProfileDropdown();

            btnDisplayMode.Text = "> " + selectedItem;
            Properties.Settings.Default.displayMode = selectedItem;
            Properties.Settings.Default.Save();

            alterConfigSettings(selectedItem);
        }

        private void alterConfigSettings(string item)
        {
            bool doesGraphicsConfigExist = File.Exists(extendedConfigPath);
            if (doesGraphicsConfigExist)
            {
                string rawContent = File.ReadAllText(extendedConfigPath);
                JObject root = JObject.Parse(rawContent);

                if (root == null)
                {
                    Debug.WriteLine("`root` JObject was null");
                    return;
                }

                if (root["DisplaySettings"] == null)
                {
                    Debug.WriteLine("`DisplaySettings` section was null");
                    return;
                }

                if (root["DisplaySettings"] is JObject displaySettings)
                {
                    if (displaySettings["FullScreenMode"] == null)
                    {
                        Debug.WriteLine("`FullScreenMode` setting was null");
                        return;
                    }

                    string selectedMode = btnDisplayMode.Text.Replace("> ", "");
                    int newModeValue = selectedMode switch
                    {
                        "Windowed" => 2,
                        "Borderless Fullscreen" => 1,
                        "Fullscreen" => 0,
                        _ => 1
                    };

                    try
                    {
                        displaySettings["FullScreenMode"] = newModeValue;

                        string? modifiedJson = JsonConvert.SerializeObject(root, Formatting.Indented);
                        File.WriteAllText(extendedConfigPath, modifiedJson);

                        statusConfirmed.Visible = true;
                        Timer tmr = new Timer();
                        tmr.Interval = 1000;
                        tmr.Tick += (s, args) =>
                        {
                            statusConfirmed.Visible = false;
                            tmr.Stop();
                            tmr.Dispose();
                        };
                        tmr.Start();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error parsing `FullScreenMode` value: " + ex.Message);
                        return;
                    }
                }
            }
        }

        private void btnResetSettings_MouseEnter(object sender, EventArgs e)
        {
            btnResetSettings.Image = Properties.Resources.reset_selected;
        }

        private void btnResetSettings_MouseLeave(object sender, EventArgs e)
        {
            btnResetSettings.Image = Properties.Resources.reset;
        }

        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            string content = "Are you sure you want to reset all the in-app settings? This action is irreversible.";

            if (MessageBox.Show(content, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                string nextContent = "All settings have been reset. The launcher will now restart for changes to take effect.";

                if (MessageBox.Show(nextContent, Text, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        private void chkDisplayPopup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.displayWarning = chkDisplayPopup.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
