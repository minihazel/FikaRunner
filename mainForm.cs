using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FikaRunner
{
    public partial class mainForm : Form, IMessageFilter
    {

        // strings and lists
        public static string? currentEnv = "D:\\SPT Iterations\\4.0.0 Host";
        public static string? playerDir = string.Empty;
        public static string? homeDir = string.Empty;
        public static string? selectedAID = string.Empty;
        public static string? fikaHeadlessAID = string.Empty;

        public Dictionary<string, string> profiles = new Dictionary<string, string>();
        public List<string> profileNames = new List<string>();

        // bools
        public bool isDropdownOpen = false;
        public bool firstLaunch = true;
        public bool isServerRunning = false;

        // ints
        private int dropdownItemHeight = 40;
        private int hoveredDropdownIndex = -1;
        private const int SW_HIDE = 0;

        // processes
        public Process? sptServerProcess = null;
        public Process? playerClientProcess = null;
        public Process? fikaClientProcess = null;

        /* backgroundservices - organized */

        // server workers
        public BackgroundWorker? sptServerWorker = null;
        public BackgroundWorker? checkServerWorker = null;

        // player workers
        // public BackgroundWorker? playerWorker = null;
        public BackgroundWorker? playerEndDetectWorker = null;

        // fika workers
        // public BackgroundWorker? fikaWorker = null;
        public BackgroundWorker? fikaEndDetectWorker = null;

        // notify icons
        public NotifyIcon? serverNotifyIcon;

        public UserInfo getProfileInfo(string filePath)
        {
            UserInfo? userInfo = null;

            using (StreamReader file = File.OpenText(filePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JsonSerializer serializer = new JsonSerializer();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName && (string?)reader.Value == "info")
                    {
                        reader.Read();
                        userInfo = serializer.Deserialize<UserInfo>(reader);
                        break;
                    }
                }
            }

            return userInfo;
        }

        public mainForm()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, dropdownList, new object[] { true });

            // initialize notify icon
            serverNotifyIcon = new NotifyIcon();
            serverNotifyIcon.Icon = Icon;
            serverNotifyIcon.Visible = true;
        }

        public bool PreFilterMessage(ref Message m)
        {
            // WM_LBUTTONDOWN = 0x0201 (left mouse button down)
            if (m.Msg == 0x0201 && dropdownList.Visible)
            {
                Point clickPos = dropdownList.PointToClient(Cursor.Position);
                if (!dropdownList.ClientRectangle.Contains(clickPos))
                {
                    dropdownList.Invalidate();
                    dropdownList.Visible = false;
                    isDropdownOpen = false;
                    return false; // allow message to continue
                }
            }

            return false; // don't block any messages
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.RemoveMessageFilter(this);
            base.OnFormClosing(e);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.firstLaunch)
            {
                firstLaunch = false;
            }

            if (string.IsNullOrEmpty(currentEnv))
            {
                Environment.Exit(0);
            }

            if (areThereSPTFiles(currentEnv))
            {
                if (areThereFikaFiles(currentEnv))
                {
                    if (firstLaunch || string.IsNullOrEmpty(Properties.Settings.Default.globalClientDirectory))
                    {
                        showFirstLaunch();
                    }
                    else
                    {
                        showMainPanel(false);
                    }
                }
            }

            Debug.WriteLine("globalHomeDirectory: '" + Properties.Settings.Default.globalHomeDirectory + "'");
            Debug.WriteLine("globalClientDirectory: '" + Properties.Settings.Default.globalClientDirectory + "'");
            Debug.WriteLine("lastProfile: '" + Properties.Settings.Default.lastProfile + "'");
            Debug.WriteLine("lastProfileName: '" + Properties.Settings.Default.lastProfileName + "'");
            Debug.WriteLine("currentPath: '" + Properties.Settings.Default.currentPath + "'");
            Debug.WriteLine("firstLaunch: '" + Properties.Settings.Default.firstLaunch + "'");
        }

        private void showFirstLaunch()
        {
            errorPanel.BringToFront();
        }

        public static bool areThereSPTFilesInThePlayerDirectory(string path)
        {
            string fullPath = Path.Join(path, "SPT");

            string SPTServer = "SPT.Server.exe";
            string SPTLauncher = "SPT.Launcher.exe";

            bool doesSPTServerExist = File.Exists(Path.Join(fullPath, SPTServer));
            bool doesSPTLauncherExist = File.Exists(Path.Join(fullPath, SPTLauncher));

            if (doesSPTServerExist && doesSPTLauncherExist)
            {
                return true;
            }

            return false;
        }

        public static bool areThereSPTFiles(string path)
        {
            string fullPath = Path.Join(path, "SPT");

            string SPTServer = "SPT.Server.exe";
            string SPTLauncher = "SPT.Launcher.exe";
            string FikaHeadlessManager = "FikaHeadlessManager.exe";

            bool doesSPTServerExist = File.Exists(Path.Join(fullPath, SPTServer));
            bool doesSPTLauncherExist = File.Exists(Path.Join(fullPath, SPTLauncher));
            bool doesFikaHeadlessManagerExist = File.Exists(Path.Join(path, FikaHeadlessManager));

            if (doesSPTServerExist && doesSPTLauncherExist && doesFikaHeadlessManagerExist)
            {
                return true;
            }

            return false;
        }

        public static bool areThereFikaFiles(string path)
        {
            string fullPath = Path.Join(path, "BepInEx", "plugins", "Fika");

            string fikaCore = "Fika.Core.dll";
            string fikaHeadless = "Fika.Headless.dll";
            bool doesfikaCoreExist = File.Exists(Path.Join(fullPath, fikaCore));
            bool doesfikaHeadlessExist = File.Exists(Path.Join(fullPath, fikaHeadless));

            if (doesfikaCoreExist && doesfikaHeadlessExist)
            {
                return true;
            }

            return false;
        }

        public static bool isFikaCorePresent(string path)
        {
            string fullPath = Path.Join(path, "BepInEx", "plugins", "Fika");

            string fikaCore = "Fika.Core.dll";
            bool doesfikaCoreExist = File.Exists(Path.Join(fullPath, fikaCore));

            if (doesfikaCoreExist)
            {
                return true;
            }

            return false;
        }

        public bool isValidSPTProfile(string path)
        {
            try
            {
                using (StreamReader file = File.OpenText(path))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject json = (JObject)JToken.ReadFrom(reader);

                    return json["info"] != null &&
                           json["characters"]?["pmc"] != null &&
                           json["characters"]?["pmc"]?["Info"] != null &&
                           json["characters"]?["pmc"]?["_id"] != null &&
                           json["characters"]?["scav"] != null &&
                           json["dialogues"] != null &&
                           json["inraid"] != null &&
                           json["insurance"] != null;
                }
            }
            catch
            {
                return false;
            }
        }

        public void showMainPanel(bool isSwitchingPlayerDir)
        {
            homeDir = currentEnv;

            if (isSwitchingPlayerDir)
            {
                Properties.Settings.Default.globalClientDirectory = playerDir;
            }
            else
            {
                playerDir = Properties.Settings.Default.globalClientDirectory;
            }

            Properties.Settings.Default.globalHomeDirectory = homeDir;
            Properties.Settings.Default.firstLaunch = false;
            Properties.Settings.Default.Save();

            firstLaunch = false;
            mainPanel.BringToFront();

            fetchProfiles();
        }

        public void showProfileDropdown()
        {
            dropdownList.Size = new Size(dropdownList.Width, dropdownItemHeight * profileNames.Count);
            dropdownList.Refresh();
            dropdownList.Visible = true;
            isDropdownOpen = true;
        }

        public void closeProfileDropdown()
        {
            dropdownList.Invalidate();
            dropdownList.Visible = false;
            isDropdownOpen = false;
        }

        public string fetchMostRecentProfile(string path)
        {
            var files = Directory.GetFiles(path, "*.json");

            if (!files.Any())
            {
                return null; // No files found
            }

            string? mostRecentFile = files
                .Select(filePath => new FileInfo(filePath))
                .OrderByDescending(f => f.LastWriteTime)
                .Select(f => f.FullName)
                .FirstOrDefault();

            return mostRecentFile;
        }

        private void fetchProfiles()
        {
            profiles.Clear();
            string profilesPath = Path.Join(currentEnv, "SPT", "user", "profiles");
            string[] profileJsons = Directory.GetFiles(profilesPath, "*.json");

            for (int i = 0; i < profileJsons.Length; i++)
            {
                string fullPath = Path.GetFullPath(profileJsons[i]);
                UserInfo userInfo = getProfileInfo(fullPath);

                string profileAID = userInfo.id.ToString();
                string profileDisplayName = userInfo.username.ToString();
                string profileEdition = userInfo.edition.ToString();

                if (profileDisplayName.StartsWith("headless_"))
                {
                    fikaHeadlessAID = profileAID;
                    continue;
                }

                profiles.Add(profileDisplayName, profileAID);
                profileNames.Add(profileDisplayName);
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.lastProfile))
            {
                string recentProfileFile = fetchMostRecentProfile(profilesPath);
                if (recentProfileFile == null) return;

                UserInfo recentProfile = getProfileInfo(recentProfileFile);
                displayProfileDetails(recentProfile, recentProfileFile);
            }
            else
            {
                string fullPath = Path.Join(profilesPath, Properties.Settings.Default.lastProfile + ".json");
                UserInfo fetchedProfile = getProfileInfo(fullPath);
                displayProfileDetails(fetchedProfile, fullPath);
            }
        }

        private void displayProfileDetails(UserInfo fetchedProfile, string path)
        {
            string recentProfileDisplayName = fetchedProfile.username.ToString();
            string recentProfileAID = fetchedProfile.id.ToString();
            string recentProfileEdition = fetchedProfile.edition.ToString();

            btnPlayerProfile.Text = "> " + recentProfileDisplayName;
            btnPlayerProfile.Tag = recentProfileAID;

            statusDisplayName.Text = "Name > " + recentProfileDisplayName;
            statusAID.Text = "AID > " + recentProfileAID;
            statusGameEdition.Text = "Game version > " + recentProfileEdition;

            if (!isValidSPTProfile(path))
            {
                statusInvalidProfile.Visible = true;
            }
            else
            {
                statusInvalidProfile.Visible = false;
            }

            Properties.Settings.Default.lastProfile = recentProfileAID;
            Properties.Settings.Default.lastProfileName = recentProfileDisplayName;
            Properties.Settings.Default.Save();
        }

        private void btnBrowseClient_Click(object sender, EventArgs e)
        {
            if (firstLaunch)
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
                        if (areThereSPTFilesInThePlayerDirectory(root))
                        {
                            if (isFikaCorePresent(root))
                            {
                                playerDir = root;
                                showMainPanel(true);
                            }
                        }
                    }
                }

                return;
            }

            // initialize bgworkers and procs
            terminateAllProcesses();
            Task.Delay(1000);
            sptServerProcess = startSPTServerProcess();
        }

        // process management

        private async Task terminateSPTServer()
        {
            if (sptServerProcess == null)
            {
                return;
            }

            try
            {
                if (!sptServerProcess.CloseMainWindow())
                {
                    if (!sptServerProcess.WaitForExit(100))
                    {
                        sptServerProcess.Kill();
                        sptServerProcess.WaitForExit();
                    }
                }

                sptServerProcess.WaitForExit();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sptServerProcess.Dispose();
                sptServerProcess = null;
            }
        }

        private async Task terminateFikaClientGracefully()
        {
            if (fikaEndDetectWorker != null && fikaEndDetectWorker.WorkerSupportsCancellation)
            {
                fikaEndDetectWorker.CancelAsync();
            }

            Thread.Sleep(50);
            terminateFikaClient();

            if (fikaEndDetectWorker != null)
            {
                fikaEndDetectWorker.Dispose();
                fikaEndDetectWorker = null;
            }
        }

        private async Task terminateFikaClient()
        {
            if (fikaClientProcess == null || fikaClientProcess.HasExited)
            {
                return;
            }

            try
            {
                if (!fikaClientProcess.CloseMainWindow())
                {
                    if (!fikaClientProcess.WaitForExit(100))
                    {
                        fikaClientProcess.Kill();
                        fikaClientProcess.WaitForExit();
                    }
                }

                fikaClientProcess.WaitForExit();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                fikaClientProcess.Dispose();
                fikaClientProcess = null;
            }
        }

        private async Task terminatePlayerClient()
        {
            if (playerClientProcess == null || playerClientProcess.HasExited)
            {
                return;
            }

            try
            {
                if (!playerClientProcess.CloseMainWindow())
                {
                    if (!playerClientProcess.WaitForExit(100))
                    {
                        playerClientProcess.Kill();
                        playerClientProcess.WaitForExit();
                    }
                }

                playerClientProcess.WaitForExit();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (playerClientProcess != null)
                {
                    playerClientProcess.Dispose();
                    playerClientProcess = null;
                }
            }
        }

        private async Task terminateAllProcesses()
        {
            await terminateSPTServer();
            await terminateFikaClientGracefully();
            await terminatePlayerClient();
        }

        private Process startPlayerClientProcess()
        {
            string port = "6969";
            string ipAddress = "127.0.0.1";

            if (btnPlayerProfile.Tag == null) return null;
            string? profileAID = btnPlayerProfile.Tag?.ToString();
            string? profileName = btnPlayerProfile.Text.Replace("> ", "");

            ProcessStartInfo? _playerClientProcess = new ProcessStartInfo();
            string args = $"-token={profileAID} " +
                $"-config={{'BackendUrl':'https://{ipAddress}:{port}','Version':'live','MatchingVersion':'live'}}";

            _playerClientProcess.FileName = Path.Join(playerDir, "EscapeFromTarkov.exe");
            _playerClientProcess.WorkingDirectory = playerDir;
            _playerClientProcess.Arguments = args;

            playerClientProcess = new Process();
            playerClientProcess.StartInfo = _playerClientProcess;
            playerClientProcess.EnableRaisingEvents = true;
            playerClientProcess.Exited += playerClient_Exited;

            try
            {
                playerClientProcess.Start();
                attachPlayerMonitor();
            }
            catch (Exception ex)
            {
            }

            return playerClientProcess;
        }

        private Process startFikaClientProcess()
        {
            string port = "6969";
            string ipAddress = "127.0.0.1";

            string args = $"-token={fikaHeadlessAID} " +
                $"-config={{'BackendUrl':'https://{ipAddress}:{port}','Version':'live','MatchingVersion':'live'}}";

            ProcessStartInfo? _fikaClientProcess = new ProcessStartInfo();
            _fikaClientProcess.FileName = Path.Join(currentEnv, "EscapeFromTarkov.exe");
            _fikaClientProcess.WorkingDirectory = currentEnv;
            _fikaClientProcess.Arguments = args;
            _fikaClientProcess.CreateNoWindow = true;
            _fikaClientProcess.UseShellExecute = false;

            fikaClientProcess = new Process();
            fikaClientProcess.StartInfo = _fikaClientProcess;
            fikaClientProcess.EnableRaisingEvents = true;
            fikaClientProcess.Exited += fikaClient_Exited;

            try
            {
                fikaClientProcess.Start();
                attachFikaMonitor();
            }
            catch (Exception ex)
            {
            }

            return fikaClientProcess;
        }

        private Process startSPTServerProcess()
        {
            string serverDirectory = Path.Join(currentEnv, "SPT");
            Environment.SetEnvironmentVariable("DISABLE_VIRTUAL_TERMINAL", "1");

            bool doesServerDirExist = Directory.Exists(serverDirectory);
            if (!doesServerDirExist)
            {
                return null;
            }

            Environment.CurrentDirectory = serverDirectory;
            sptServerProcess = new Process();
            sptServerProcess.StartInfo.WorkingDirectory = serverDirectory;
            sptServerProcess.StartInfo.FileName = "SPT.Server.exe";
            sptServerProcess.StartInfo.CreateNoWindow = false;
            sptServerProcess.StartInfo.UseShellExecute = false;
            sptServerProcess.StartInfo.RedirectStandardOutput = true;
            sptServerProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            sptServerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            sptServerProcess.OutputDataReceived += sptServer_OutputDataReceived;
            sptServerProcess.Exited += sptServer_Exited;

            try
            {
                // initializing
                sptServerProcess.Start();
                sptServerProcess.BeginOutputReadLine();

                // features
                isServerRunning = true;
                btnBrowseClient.Enabled = false;
                checkServerUptime();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to start server: " + ex.Message.ToString());
            }

            Environment.CurrentDirectory = currentEnv;
            return sptServerProcess;
        }

        /*
        private void startSPTServer()
        {
            // start spt server process
            Task.Delay(300);
            terminateSPTServer();

            string currentDirectory = Directory.GetCurrentDirectory();
            string serverDirectory = Path.Join(currentEnv, "SPT");

            bool doesServerDirExist = Directory.Exists(serverDirectory);
            if (!doesServerDirExist)
            {
                return;
            }

            Directory.SetCurrentDirectory(serverDirectory);
            sptServerProcess = new Process();

            sptServerProcess.StartInfo.WorkingDirectory = serverDirectory;
            sptServerProcess.StartInfo.FileName = "SPT.Server.exe";
            sptServerProcess.StartInfo.CreateNoWindow = true;
            sptServerProcess.StartInfo.UseShellExecute = false;
            sptServerProcess.StartInfo.RedirectStandardOutput = true;
            sptServerProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            sptServerProcess.OutputDataReceived += sptServer_OutputDataReceived;
            sptServerProcess.Exited += sptServer_Exited;

            try
            {
                sptServerProcess.Start();
                sptServerProcess.BeginOutputReadLine();
                isServerRunning = true;
                btnBrowseClient.Enabled = false;
                checkServerUptime();
            }
            catch (Exception ex)
            {
            }

            Directory.SetCurrentDirectory(currentEnv);
        }
        */

        /*
        private void startFikaClient()
        {
            // start fika client process
            if (string.IsNullOrEmpty(currentEnv)) return;

            Task.Delay(300);
            terminateFikaClient();

            string currentDirectory = Directory.GetCurrentDirectory();
            Environment.CurrentDirectory = currentEnv;

            string port = "6969";
            string ipAddress = "127.0.0.1";

            string args = $"-token={fikaHeadlessAID} " +
                $"-config={{'BackendUrl':'https://{ipAddress}:{port}','Version':'live','MatchingVersion':'live'}}";

            fikaClientProcess = new Process();
            fikaClientProcess.StartInfo.WorkingDirectory = currentEnv;
            fikaClientProcess.StartInfo.FileName = Path.Join(currentEnv, "EscapeFromTarkov.exe");
            fikaClientProcess.StartInfo.Arguments = args;
            fikaClientProcess.StartInfo.CreateNoWindow = true;
            fikaClientProcess.StartInfo.UseShellExecute = false;
            fikaClientProcess.EnableRaisingEvents = true;
            fikaClientProcess.Exited += playerClient_Exited;

            try
            {
                fikaClientProcess.Start();
                attachFikaMonitor();
            }
            catch (Exception ex)
            {
            }

            Environment.CurrentDirectory = currentEnv;
        }
        */

        /*
        private void startPlayerClient()
        {
            // start player client process
            if (string.IsNullOrEmpty(playerDir)) return;
            if (string.IsNullOrEmpty(currentEnv)) return;

            Task.Delay(300);
            terminatePlayerClient();

            string currentDirectory = Directory.GetCurrentDirectory();
            Environment.CurrentDirectory = playerDir;

            string port = "6969";
            string ipAddress = "127.0.0.1";

            if (btnPlayerProfile.Tag == null) return;
            string? profileAID = btnPlayerProfile.Tag?.ToString();
            string? profileName = btnPlayerProfile.Text.Replace("> ", "");

            ProcessStartInfo? _playerClientProcess = new ProcessStartInfo();
            string args = $"-token={profileAID} " +
                $"-config={{'BackendUrl':'https://{ipAddress}:{port}','Version':'live','MatchingVersion':'live'}}";

            _playerClientProcess.FileName = Path.Join(playerDir, "EscapeFromTarkov.exe");
            _playerClientProcess.Arguments = args;

            playerClientProcess = new Process();
            playerClientProcess.StartInfo = _playerClientProcess;
            playerClientProcess.EnableRaisingEvents = true;
            playerClientProcess.Exited += playerClient_Exited;

            try
            {
                playerClientProcess.Start();
                attachPlayerMonitor();
            }
            catch (Exception ex)
            {
            }

            Environment.CurrentDirectory = currentEnv;
        }
        */

        private void attachPlayerMonitor()
        {
            playerEndDetectWorker = new BackgroundWorker();
            playerEndDetectWorker.DoWork += playerEndDetectWorker_DoWork;
            playerEndDetectWorker.RunWorkerCompleted += playerEndDetectWorker_RunWorkerCompleted;
            playerEndDetectWorker.WorkerSupportsCancellation = true;
            playerEndDetectWorker.RunWorkerAsync();

            /*
            if (playerWorker != null)
            {
                playerWorker.CancelAsync();
                playerWorker.Dispose();
                playerWorker = null;
            }
            */
        }

        private void attachFikaMonitor()
        {
            fikaEndDetectWorker = new BackgroundWorker();
            fikaEndDetectWorker.DoWork += fikaEndDetectWorker_DoWork;
            fikaEndDetectWorker.RunWorkerCompleted += fikaEndDetectWorker_RunWorkerCompleted;
            fikaEndDetectWorker.WorkerSupportsCancellation = true;
            fikaEndDetectWorker.RunWorkerAsync();

            /*
            if (fikaWorker != null)
            {
                fikaWorker.CancelAsync();
                fikaWorker.Dispose();
                fikaWorker = null;
            }
            */
        }

        private void checkServerUptime()
        {
            if (checkServerWorker != null)
            {
                checkServerWorker.CancelAsync();
                checkServerWorker.Dispose();
                checkServerWorker = null;
            }

            checkServerWorker = new BackgroundWorker();
            checkServerWorker.WorkerSupportsCancellation = true;
            checkServerWorker.WorkerReportsProgress = false;
            checkServerWorker.DoWork += checkServerWorker_DoWork;
            checkServerWorker.RunWorkerCompleted += checkServerWorker_RunWorkerCompleted;

            try
            {
                checkServerWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            Debug.WriteLine("success 2");
        }

        private void printServerData(string data)
        {
            string res = data;
            if (string.IsNullOrEmpty(res)) return;
            const string ANSI_REGEX = @"\x1b\[[0-?]*[ -/]*[@-~]";

            // res = Regex.Replace(res, @"\[[0-1];[0-9][a-z]|\[[0-9][0-9][a-z]|\[[0-9][a-z]|\[[0-9][A-Z]", String.Empty);
            string cleanData = Regex.Replace(data, ANSI_REGEX, String.Empty);

            BeginInvoke((MethodInvoker)delegate
            {
                consoleOutput.AppendText(cleanData + Environment.NewLine);
                consoleOutput.GoEnd();
                consoleOutput.Selection.Start = consoleOutput.Selection.End;
            });
        }

        private void sptServer_Exited(object sender, EventArgs e)
        {
            if (sptServerProcess == null) return;
            if (serverNotifyIcon == null) return;

            int exitCode = sptServerProcess.ExitCode;
            string title;
            string message;
            ToolTipIcon icon;

            if (exitCode == 0)
            {
                title = "Server Shutdown";
                message = "The game server closed successfully.";
                icon = ToolTipIcon.Info;
            }
            else
            {
                title = "Server crashed!";
                message = $"Unexpected termination (Code: {exitCode}). See logs for details.";
                icon = ToolTipIcon.Error;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    serverNotifyIcon.BalloonTipTitle = title;
                    serverNotifyIcon.BalloonTipText = message;
                    serverNotifyIcon.BalloonTipIcon = icon;
                    serverNotifyIcon.ShowBalloonTip(5000);
                }));
            }

            sptServerProcess.Dispose();
        }

        private void sptServer_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.Invoke(new Action(() =>
                {
                    printServerData(e.Data);
                }));
            }
        }

        private void sptServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker == null) return;
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            // string? serverProcess = "SPT.Server";
            // bool isServerRunning = Process.GetProcesses().Any(p => p.ProcessName.Equals(serverProcess, StringComparison.OrdinalIgnoreCase));
        }

        private void sptServerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sptServerWorker != null)
            {
                sptServerWorker.CancelAsync();
                sptServerWorker.Dispose();
                sptServerWorker = null;
            }
        }

        private void checkServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) return;
            Debug.WriteLine("success 3");

            string serverFolder = Path.Join(currentEnv, "SPT");
            int elapsed = 0; // the time elapsed since starting to check the port
            int interval = 1000;
            int timeout = 600 * interval; // the maximum time to wait for the port to open, the number is in seconds
            int delay = 1000;

            while (!isPortListening(6969))
            {
                Debug.WriteLine("success 4");
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (elapsed >= timeout)
                {
                    e.Result = "Timeout";
                    return;
                }

                elapsed += delay;
                Thread.Sleep(delay);
            }

            fikaClientProcess = startFikaClientProcess();
            playerClientProcess = startPlayerClientProcess();
            e.Result = "ClientsStarted";
        }

        private void checkServerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                string title = "Server stopped";
                string message = "Cancellation was requested.";
                ToolTipIcon icon = ToolTipIcon.Info;
                if (serverNotifyIcon == null) return;

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        serverNotifyIcon.BalloonTipTitle = title;
                        serverNotifyIcon.BalloonTipText = message;
                        serverNotifyIcon.BalloonTipIcon = icon;
                        serverNotifyIcon.ShowBalloonTip(5000);
                    }));
                }

                // cancellation was requested
                Debug.WriteLine("Server check canceled.");
            }
            else if (e.Error != null)
            {
                // exception occurred during DoWork
                
                string title = "Server exception occurred";
                string message = "An error occurred with SPT's Server application.";
                ToolTipIcon icon = ToolTipIcon.Info;
                if (serverNotifyIcon == null) return;

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        serverNotifyIcon.BalloonTipTitle = title;
                        serverNotifyIcon.BalloonTipText = message;
                        serverNotifyIcon.BalloonTipIcon = icon;
                        serverNotifyIcon.ShowBalloonTip(5000);
                    }));
                }

                Debug.WriteLine("Server check failed with an unhandled error: " + e.Error.ToString());
                terminateAllProcesses();
            }
            else if (e.Result != null && e.Result.ToString() == "Timeout")
            {
                // shut down on timeout

                string title = "Server timed out";
                string message = "Server timed out and we could not detect any signal after 5 minutes.";
                ToolTipIcon icon = ToolTipIcon.Info;
                if (serverNotifyIcon == null) return;

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        serverNotifyIcon.BalloonTipTitle = title;
                        serverNotifyIcon.BalloonTipText = message;
                        serverNotifyIcon.BalloonTipIcon = icon;
                        serverNotifyIcon.ShowBalloonTip(5000);
                    }));
                }

                Debug.WriteLine("Server did not become ready within the timeout period.");
                terminateAllProcesses();
            }
            else
            {
                string title = "Launching...";
                string message = "Single-Player Tarkov is launching!";
                ToolTipIcon icon = ToolTipIcon.Info;
                if (serverNotifyIcon == null) return;

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        serverNotifyIcon.BalloonTipTitle = title;
                        serverNotifyIcon.BalloonTipText = message;
                        serverNotifyIcon.BalloonTipIcon = icon;
                        serverNotifyIcon.ShowBalloonTip(5000);
                    }));
                }
                Debug.WriteLine("server ready and clients launched");
            }

            if (checkServerWorker != null)
            {
                checkServerWorker.Dispose();
                checkServerWorker = null;
            }
        }

        private bool isPortListening(int port)
        {
            try
            {
                IPGlobalProperties globalProps = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] listeners = globalProps.GetActiveTcpListeners();

                bool isListening = listeners.Any(endpoint =>
                    endpoint.Port == port &&
                    (
                        endpoint.Address.Equals(IPAddress.Loopback) ||
                        endpoint.Address.ToString() == "127.0.0.1" ||
                        endpoint.Address.ToString() == "0.0.0.0"
                    )
                );

                if (isListening)
                {
                    if (checkServerWorker != null)
                    {
                        checkServerWorker.Dispose();
                        checkServerWorker = null;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*
        private void playerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (playerWorker != null && playerWorker.IsBusy)
            {
                playerWorker.CancelAsync();
                playerWorker.Dispose();
                playerWorker = null;
            }
        }

        private void playerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (playerWorker != null && playerWorker.IsBusy)
            {
                playerWorker.CancelAsync();
                playerWorker.Dispose();
                playerWorker = null;
            }
        }
        */

        private void playerEndDetectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker == null) return;

            if (playerClientProcess == null)
            {
                e.Result = "ProcessReferenceMissing";
                return;
            }

            while (!worker.CancellationPending)
            {
                try
                {
                    if (playerClientProcess == null)
                    {
                        e.Result = "PlayerExited";
                        return;
                    }

                    playerClientProcess.WaitForExit();
                    e.Result = "PlayerExited";
                    return;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(3000);
                }
            }
        }

        public void playerEndDetectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (playerEndDetectWorker == null) return;
            playerEndDetectWorker.Dispose();

            if (e.Result != null && (e.Result.ToString() == "PlayerExited" || e.Result.ToString() == "ProcessReferenceMissing"))
            {
                WindowState = FormWindowState.Normal;
                terminateAllProcesses();
            }
        }

        private void fikaEndDetectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker == null) return;
            while (!worker.CancellationPending)
            {
                if (fikaClientProcess == null || fikaClientProcess.HasExited)
                {
                    fikaClientProcess = startFikaClientProcess();
                }

                try
                {
                    fikaClientProcess.WaitForExit();
                }
                catch (Exception ex)
                {
                    Thread.Sleep(5000);
                }
            }
        }

        public void fikaEndDetectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (fikaEndDetectWorker == null) return;

            fikaEndDetectWorker.Dispose();
            fikaEndDetectWorker = null;
        }

        private void playerClient_Exited(object sender, EventArgs e)
        {
            if (playerClientProcess != null)
            {
                playerClientProcess.Dispose();
                playerClientProcess = null;
            }

            consoleOutput.Clear();
            btnBrowseClient.Enabled = true;
        }

        private void fikaClient_Exited(object sender, EventArgs e)
        {
            if (fikaClientProcess != null)
            {
                fikaClientProcess.Dispose();
                fikaClientProcess = null;
            }
        }

        // process management

        private void btnBrowseServer_MouseEnter(object sender, EventArgs e)
        {
            btnBrowseServer.Image = Properties.Resources.home_selected;
            homeTitle.Visible = true;
        }

        private void btnBrowseServer_MouseLeave(object sender, EventArgs e)
        {
            btnBrowseServer.Image = Properties.Resources.home;
            homeTitle.Visible = false;
        }

        private void btnBrowseClient_MouseEnter(object sender, EventArgs e)
        {
            btnBrowseClient.Image = Properties.Resources.client_selected;
            clientTitle.Visible = true;
        }

        private void btnBrowseClient_MouseLeave(object sender, EventArgs e)
        {
            btnBrowseClient.Image = Properties.Resources.client;
            clientTitle.Visible = false;
        }

        private void btnOpenSettings_MouseEnter(object sender, EventArgs e)
        {
            btnOpenSettings.Image = Properties.Resources.settings_selected;
            settingsTitle.Visible = true;
        }

        private void btnOpenSettings_MouseLeave(object sender, EventArgs e)
        {
            btnOpenSettings.Image = Properties.Resources.settings;
            settingsTitle.Visible = false;
        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            settingsForm frm = new settingsForm();
            frm.ShowDialog();
        }

        private void btnCopyOutput_Click(object sender, EventArgs e)
        {
            if (firstLaunch)
            {
                MessageBox.Show("This feature can only be used after getting through the first launch procedure. Please do so by browsing for a game folder.", "SPT-Fika Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (consoleOutput.Text.Length > 0)
            {
                string textToCopy = consoleOutput.Text;
                Clipboard.SetText(textToCopy);
            }

            /*
            if (outputPanel.Visible)
            {
                outputPanel.Visible = false;
                Properties.Settings.Default.outputVisible = false;
                btnCopyOutput.Image = Properties.Resources.hide_selected;
            }
            else
            {
                outputPanel.Visible = true;
                Properties.Settings.Default.outputVisible = true;
                btnCopyOutput.Image = Properties.Resources.visible_selected;
            }
            */
        }

        private void btnCopyOutput_MouseEnter(object sender, EventArgs e)
        {
            btnCopyOutput.Image = Properties.Resources.copy_selected;
            settingsCopyOutput.Visible = true;
        }

        private void btnCopyOutput_MouseLeave(object sender, EventArgs e)
        {
            btnCopyOutput.Image = Properties.Resources.copy;

            settingsCopyOutput.Visible = false;
        }

        private async void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            await terminateAllProcesses();
        }

        private void btnPlayerProfile_Click(object sender, EventArgs e)
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

        private void profileSeparator1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            int centerY = panel.Height / 2;

            using (Pen pen = new Pen(Color.FromArgb(100, 100, 100), 1))
            {
                e.Graphics.DrawLine(pen, 0, centerY, panel.Width, centerY);
            }
        }

        private void profileSeparator2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            int centerY = panel.Height / 2;

            using (Pen pen = new Pen(Color.FromArgb(100, 100, 100), 1))
            {
                e.Graphics.DrawLine(pen, 0, centerY, panel.Width, centerY);
            }
        }

        private void profileSeparator3_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            int centerY = panel.Height / 2;

            using (Pen pen = new Pen(Color.FromArgb(100, 100, 100), 1))
            {
                e.Graphics.DrawLine(pen, 0, centerY, panel.Width, centerY);
            }
        }

        private void profileSeparator4_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            int centerY = panel.Height / 2;

            using (Pen pen = new Pen(Color.FromArgb(100, 100, 100), 1))
            {
                e.Graphics.DrawLine(pen, 0, centerY, panel.Width, centerY);
            }
        }

        private void dropdownList_Paint(object sender, PaintEventArgs e)
        {
            if (!isDropdownOpen) return;
            Panel panel = (Panel)sender;

            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(28, 30, 32));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            for (int i = 0; i < profileNames.Count; i++)
            {
                Rectangle itemRect = new Rectangle(0, i * dropdownItemHeight, panel.Width, dropdownItemHeight);

                bool isHovered = (i == hoveredDropdownIndex);

                // Background
                Color backColor = isHovered ? Color.FromArgb(40, 42, 44) : Color.FromArgb(28, 30, 32);
                using (Brush backBrush = new SolidBrush(backColor))
                {
                    g.FillRectangle(backBrush, itemRect);
                }

                // Text
                using (Brush textBrush = new SolidBrush(Color.Silver))
                using (Font font = new Font("Bender", 11, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    };

                    g.DrawString(profileNames[i], font, textBrush,
                                new RectangleF(itemRect.X + 10, itemRect.Y, itemRect.Width - 10, itemRect.Height), sf);
                }

                // Optional: Draw separator line
                /*
                if (i < profileNames.Count - 1)
                {
                    using (Pen separatorPen = new Pen(Color.FromArgb(40, 42, 44)))
                    {
                        g.DrawLine(separatorPen, 0, (i + 1) * dropdownItemHeight - 1, panel.Width, (i + 1) * dropdownItemHeight - 1);
                    }
                }
                */
            }
        }

        private void dropdownList_MouseMove(object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            int index = e.Y / dropdownItemHeight;

            if (index >= 0 && index < profileNames.Count)
            {
                if (hoveredDropdownIndex != index)
                {
                    hoveredDropdownIndex = index;
                    panel.Invalidate();
                }
            }
        }

        private void dropdownList_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;

            if (hoveredDropdownIndex != -1)
            {
                hoveredDropdownIndex = -1;
                panel.Invalidate();
            }
        }

        private void dropdownList_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            int index = e.Y / dropdownItemHeight;

            if (index >= 0 && index < profileNames.Count)
            {
                profileClick(index);
            }
        }

        private void profileClick(int index)
        {
            string selectedItem = profileNames[index];
            closeProfileDropdown();

            if (btnPlayerProfile.Tag == null) return;

            string fullPath = Path.Join(currentEnv, "SPT", "user", "profiles", profiles[selectedItem] + ".json");
            UserInfo selectedProfile = getProfileInfo(fullPath);
            displayProfileDetails(selectedProfile, fullPath);
        }

        private void btnBrowseServer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentEnv)) return;
            string? fullPath = Path.GetFullPath(currentEnv);

            try
            {
                Process.Start("explorer.exe", fullPath);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBrowseClientFolder_MouseEnter(object sender, EventArgs e)
        {
            btnBrowseClientFolder.Image = Properties.Resources.player_selected;
            settingsClient.Visible = true;
        }

        private void btnBrowseClientFolder_MouseLeave(object sender, EventArgs e)
        {
            btnBrowseClientFolder.Image = Properties.Resources.player;
            settingsClient.Visible = false;
        }

        private void btnBrowseClientFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(playerDir))
            {
                MessageBox.Show("No player game folder was detected, please restart the app or browse for a game folder.", "SPT-Fika Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string? fullPath = Path.GetFullPath(playerDir);

            try
            {
                Process.Start("explorer.exe", fullPath);
            }
            catch (Exception ex)
            {

            }
        }

        private void mainForm_Activated(object sender, EventArgs e)
        {
            string fullPath = Path.Join(currentEnv, "SPT", "user", "profiles");
            bool doesFullPathExist = Directory.Exists(fullPath);
            if (doesFullPathExist)
            {
                string[] profiles = Directory.GetFiles(fullPath, "*.json");

            }
        }
    }

    public class ProfileStructure
    {
        public InfoSection? info { get; set; }
        public CharactersSection? characters { get; set; }
        public Dictionary<string, object>? dialogues { get; set; }
        public InraidSection? inraid { get; set; }
        public object[]? insurance { get; set; }
    }

    public class InfoSection
    {
        public string? id { get; set; }
        public string? scavId { get; set; }
        public int? aid { get; set; }
        public string? username { get; set; }
        public bool? wipe { get; set; }
        public string? edition { get; set; }
    }

    public class CharactersSection
    {
        public CharacterData? pmc { get; set; }
        public CharacterData? scav { get; set; }
    }

    public class CharacterData
    {
        public object? savage { get; set; }
        public object? Encyclopedia { get; set; }
        public object? Hideout { get; set; }
        public object[]? WishList { get; set; }
    }

    public class InraidSection
    {
        public string? location { get; set; }
        public string? character { get; set; }
    }

    public class UserInfo
    {
        public string? id { get; set; }
        public string? scavId { get; set; }
        public int? aid { get; set; }
        public string? username { get; set; }
        public bool? wipe { get; set; }
        public string? edition { get; set; }
    }
}
