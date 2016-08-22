using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.Devices;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;
using System.Net;
using System.Threading;
using System.ComponentModel;

namespace TanoaRPGLauncher
{
    public partial class Form1 : Form
    {

        #region FormLoad

        #region Variables

        string par;
        string allpar;
        string a3p;
        double ra;
        double gra;
        int cor;

        #endregion

        #region Load

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini"))
            {

                par = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(1).First();
                allpar = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(1).First();


                if (par.Contains("-noSplash"))
                {

                    par = par.Replace(" -noSplash", "");

                    NoSplash = true;
                    OPTIONENNoSplash.Checked = true;
                }
                if (par.Contains("-noLogs"))
                {
                    par = par.Replace(" -noLogs", "");

                    NoLog = true;
                    OPTIONENNoLog.Checked = true;
                }
                if (par.Contains("-noPause"))
                {
                    par = par.Replace(" -noPause", "");

                    NoPause = true;
                    OPTIONENNoPause.Checked = true;
                }
                if (par.Contains("-windowed"))
                {
                    par = par.Replace(" -windowed", "");

                    Windowed = true;
                    OPTIONENWindowed.Checked = true;
                }
                if (par.Contains("-skipIntro"))
                {
                    par = par.Replace(" -skipIntro", "");

                    SkipIntro = true;
                    OPTIONENSkipIntro.Checked = true;
                }
                if (par.Contains("-enableHT"))
                {
                    par = par.Replace(" -enableHT", "");

                    HyperThreading = true;
                    OPTIONENHyperThreading.Checked = true;
                }

                par = par.Replace(" -connect=89.163.144.28 -port=2302", "");
                par = par.Replace(" -noLauncher", "");

                OPTIONENSonstigeParameterTextBox.Text = par;

                a3p = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(0).First();
                OPTIONENTextBoxPF.Text = a3p;

                Double.TryParse(File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(2).First(), out ra);
                OPTIONENRamBox.SelectedItem = Convert.ToString(ra) + "MB";

                Double.TryParse(File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(3).First(), out gra);
                OPTIONENGRamBox.SelectedItem = Convert.ToString(gra) + "MB";

                int.TryParse(File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(4).First(), out cor);
                OPTIONENCPUKerneBox.SelectedItem = Convert.ToString(cor);

                LAUNCHERNoPath.Visible = false;
                LAUNCHERLaunchButton.Visible = true;

            }
            else
            {

                LAUNCHERNoPath.Visible = true;
                LAUNCHERLaunchButton.Visible = false;

            }

            if (File.Exists(downloadlocation))
            {

                LAUNCHERMissionsVersion.Text = "      Deine Missionsdatei ist aktuell";
                LAUNCHERLaunchButton.Visible = true;
                LAUNCHERMissionsUpdateButton.Visible = false;
                LAUNCHERDlSpeedLabel.Visible = false;
                LAUNCHERDlServerLabel.Visible = false;
                LAUNCHERDlTime.Visible = false;
                LAUNCHERMissionsVersion.Visible = true;
                LAUNCHERProgressBar.Visible = false;

            }
            else
            {

                LAUNCHERMissionsVersion.Text = "Deine Missionsdatei ist NICHT aktuell";
                LAUNCHERLaunchButton.Visible = false;
                LAUNCHERMissionsUpdateButton.Visible = true;

            }

            LAUNCHERNVersion.Visible = true;
            LAUNCHERNVersion.Text = "Aktuellste Missionsdatei Version: " + getnewestversion();
            LAUNCHERChangelog.Visible = true;
            LAUNCHERChangelog.Text = "Changelog";
        }

        #endregion

        #endregion

        #region Launcher


        #region LaunchButton

        private String a3path = "";
        private Process a3be = new Process();

        private void LAUNCHERLaunchButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini"))
            {
                a3path = a3p + "\\arma3battleye.exe";

                a3be.StartInfo.FileName = @a3path;
                a3be.StartInfo.Arguments = allpar;
                a3be.Start();
            }
            else
            {
                MessageBox.Show("Bitte lege deinen Arma 3 Pfad unter Optionen fest!");
                tabControl1.SelectedTab = tabPage3;
            }

        }

        #endregion

        #region MissionsUpdate

        string url = "";
        Stopwatch sw = new Stopwatch();

        private void LAUNCHERMissionsUpdateButton_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();
            int srv = rnd.Next(1, 11);

            if (srv == 1) { url = "https://cdn.cat24max.de/tanoarpg/files/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 2"; }
            if (srv == 2) { url = "http://89.163.144.28/MissionPreload/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 1"; }
            if (srv == 3) { url = "http://89.163.144.28/MissionPreload/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 1"; }
            if (srv == 4) { url = "http://89.163.144.28/MissionPreload//"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 1"; }
            if (srv == 5) { url = "http://89.163.144.28/MissionPreload/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 1"; }
            if (srv == 6) { url = "http://89.163.144.28/MissionPreload/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 1"; }
            if (srv == 7) { url = "https://cdn.cat24max.de/tanoarpg/files/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 2"; }
            if (srv == 8) { url = "http://89.163.144.28/MissionPreload/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 1"; }
            if (srv == 9) { url = "http://89.163.144.28/MissionPreload/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 1"; }
            if (srv == 10) { url = "http://89.163.144.28/MissionPreload/"; LAUNCHERDlServerLabel.Text = "Aktuell verwendeter Download-Server: 1"; }

            Thread download = new Thread(() =>
            {
                startDownload();
            });
            download.Start();
            LAUNCHERMissionsUpdateButton.Visible = false;
            LAUNCHERProgressBar.Visible = true;
            LAUNCHERDlSpeedLabel.Visible = true;
            LAUNCHERDlServerLabel.Visible = true;
            LAUNCHERDlTime.Visible = true;

        }

        private void startDownload()
        {

            Thread thread = new Thread(() =>
            {

                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(url + getcontent2()), downloadlocation);
                sw.Start();
            });
            thread.Start();

        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                LAUNCHERProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
                LAUNCHERDlSpeedLabel.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
                LAUNCHERDlTime.Text = string.Format("{0} Sekunden verbleibend", Math.Round(((e.TotalBytesToReceive / 1024) - (e.BytesReceived / 1024d)) / (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds)));

            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                LAUNCHERDlSpeedLabel.Visible = false;
                sw.Reset();
                LAUNCHERMissionsVersion.Text = "  Deine Missionsdatei ist nun aktuell";
                LAUNCHERDlFinished.Visible = true;
                LAUNCHERDlFinished.Text = "Download abgeschlossen";
                LAUNCHERProgressBar.Visible = false;
                LAUNCHERDlServerLabel.Visible = false;
                LAUNCHERDlTime.Visible = false;
                LAUNCHERLaunchButton.Visible = true;
            });
        }

        private void LAUNCHERChangelog_Click(object sender, EventArgs e) => Process.Start(new StreamReader(new WebClient().OpenRead("https://cdn.cat24max.de/tanoarpg/currentVersionChangelog.txt")).ReadToEnd());

        public static string downloadlocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\MPMissionsCache\\" + getcontent2();

        public static string getcontent2() => new StreamReader(new WebClient().OpenRead("https://cdn.cat24max.de/tanoarpg/currentVersionFile.txt")).ReadToEnd();

        public static string getnewestversion() => new StreamReader(new WebClient().OpenRead("https://cdn.cat24max.de/tanoarpg/currentVersionString.txt")).ReadToEnd();

        #endregion

        #endregion

        #region StartParameter

        #region Variablen

        public string startparameters;
        public string alleparameter;
        public string a3pfad;
        public double ram;
        public double gram;
        public int cores;
        public bool NoSplash = false;
        public bool NoLog = false;
        public bool NoPause = false;
        public bool Windowed = false;
        public bool SkipIntro = false;
        public bool HyperThreading = false;

        #endregion

        #region Arma3Pfad

        private void ButtonSP_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                OPTIONENTextBoxPF.Text = folderBrowserDialog1.SelectedPath;
                OPTIONENTextBoxPF.Text = OPTIONENTextBoxPF.Text;

            }

        }

        #endregion

        #region CheckBoxen

        private void OPTIONENNoSplash_CheckedChanged(object sender, EventArgs e)
        {

            if (OPTIONENNoSplash.Checked)
                NoSplash = true;
            else
                NoSplash = false;

        }

        private void OPTIONENNoLog_CheckedChanged(object sender, EventArgs e)
        {

            if (OPTIONENNoLog.Checked)
                NoLog = true;
            else
                NoLog = false;

        }

        private void OPTIONENNoPause_CheckedChanged(object sender, EventArgs e)
        {

            if (OPTIONENNoPause.Checked)
                NoPause = true;
            else
                NoPause = false;

        }

        private void OPTIONENWindowed_CheckedChanged(object sender, EventArgs e)
        {

            if (OPTIONENWindowed.Checked)
                Windowed = true;
            else
                Windowed = false;

        }

        private void OPTIONENSkipIntro_CheckedChanged(object sender, EventArgs e)
        {

            if (OPTIONENSkipIntro.Checked)
                SkipIntro = true;
            else
                SkipIntro = false;

        }

        private void OPTIONENHyperThreading_CheckedChanged(object sender, EventArgs e)
        {

            if (OPTIONENHyperThreading.Checked)
                HyperThreading = true;
            else
                HyperThreading = false;

        }

        #endregion

        #region Speichern

        private void OPTIONENSpeichernButton_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(OPTIONENTextBoxPF.Text)) { a3pfad = OPTIONENTextBoxPF.Text; LAUNCHERNoPath.Visible = false; }
            else { MessageBox.Show("Bitte wähle einen Arma 3 Pfad aus!"); return; }

            Microsoft.VisualBasic.Devices.ComputerInfo inf = new Microsoft.VisualBasic.Devices.ComputerInfo();

            StreamWriter savefile = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini");
            startparameters = OPTIONENSonstigeParameterTextBox.Text;
            alleparameter = startparameters;
            if (NoSplash)
                alleparameter = alleparameter + " -noSplash";
            if (NoLog)
                alleparameter = alleparameter + " -noLogs";
            if (NoPause)
                alleparameter = alleparameter + " -noPause";
            if (Windowed)
                alleparameter = alleparameter + " -windowed";
            if (SkipIntro)
                alleparameter = alleparameter + " -skipIntro";
            if (HyperThreading)
                alleparameter = alleparameter + " -enableHT";

            if (!string.IsNullOrWhiteSpace(OPTIONENRamBox.Text)) { string r = OPTIONENRamBox.Text; r = r.Replace("MB", ""); Double.TryParse(r, out ram); }
            else { ram = Math.Round(Convert.ToDouble(inf.TotalPhysicalMemory) / 1048576 / 2); }

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select AdapterRAM from Win32_VideoController");

            if (!string.IsNullOrWhiteSpace(OPTIONENGRamBox.Text)) { string r = OPTIONENGRamBox.Text; r = r.Replace("MB", ""); Double.TryParse(r, out gram); }
            else { foreach (ManagementObject mo in searcher.Get()) { var ram = mo.Properties["AdapterRAM"].Value as UInt32?; if (ram.HasValue) { gram = Math.Round(((double)ram / 1048576 / 2)); } }; }


            if (!string.IsNullOrWhiteSpace(OPTIONENCPUKerneBox.Text)) { string r = OPTIONENCPUKerneBox.Text; int.TryParse(r, out cores); }
            else { cores = Environment.ProcessorCount; } 

            alleparameter = alleparameter + " -connect=89.163.144.28 -port=2302 -noLauncher";

            savefile.WriteLine(a3pfad);
            savefile.WriteLine(alleparameter);
            savefile.WriteLine(ram);
            savefile.WriteLine(gram);
            savefile.WriteLine(cores);
            savefile.Close();
        }

        #endregion

        #endregion

    }

}
