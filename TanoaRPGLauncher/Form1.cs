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
        string profile;
        string a3p;
        double ra;
        double gra;
        int cor;
        public int startProfileName = 0;

        #endregion

        #region Load

        public Form1()
        {
            InitializeComponent();

            string str = Convert.ToString(this.startProfileName);
            int num1 = 1;
            int num2 = 0;
            string str4 = string.Concat(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents"), "\\Arma 3 - Other Profiles\\");

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini"))
            {

                par = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(1).First();
                allpar = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(1).First();
                profile = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini").Skip(5).First();

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

                startProfileName = Convert.ToInt32(profile);

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
                LAUNCHERNoPath2.Visible = false;

            }
            else
            {

                LAUNCHERNoPath.Visible = true;
                LAUNCHERNoPath2.Visible = true;

            }

            Process[] pname = Process.GetProcessesByName("arma3");
            if (pname.Length == 0)
            {
                LAUNCHERA3Running.Visible = false;
            }
            else
            {

                LAUNCHERA3Running.Visible = true;
                LAUNCHERA3Running.Text = "Arma 3 ist bereits gestartet!";
            }


            if (File.Exists(downloadlocation))
            {

                LAUNCHERMissionsVersion.Text = "      Deine Missionsdatei ist aktuell";
                LAUNCHERDlSpeedLabel.Visible = false;
                LAUNCHERDlServerLabel.Visible = false;
                LAUNCHERDlTime.Visible = false;
                LAUNCHERMissionsVersion.Visible = true;
                LAUNCHERProgressBar.Visible = false;

            }
            else
            {

                LAUNCHERMissionsVersion.Text = "Deine Missionsdatei ist NICHT aktuell";

            }

            LAUNCHERNVersion.Visible = true;
            LAUNCHERNVersion.Text = "Aktuellste Missionsdatei Version: " + getnewestversion();
            LAUNCHERChangelog.Visible = true;
            LAUNCHERChangelog.Text = "Changelog";
            this.SetBounds(100, 100, 772, 490);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.OPTIONENProfilComboBox.Items.Add("Default");
            string str1 = string.Concat(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents"), "\\Arma 3\\");
            if (Directory.Exists(str1))
            {
                bool flag = true;
                FileInfo[] files = (new DirectoryInfo(str1)).GetFiles("*.vars.Arma3Profile");
                for (int i = 0; i < (int)files.Length; i++)
                {
                    FileInfo fileInfo = files[i];
                    if (flag)
                    {
                        string str2 = fileInfo.ToString();
                        str2 = str2.Substring(0, str2.Length - 18);
                        string str3 = Form1.decode(str2);
                        if ((str3.IndexOf("ä") + str3.IndexOf("Ä") + str3.IndexOf("ö") + str3.IndexOf("Ö") + str3.IndexOf("ü") + str3.IndexOf("Ü") + str3.IndexOf("ß") != -7 ? false : str3 != "Default"))
                        {
                            this.OPTIONENProfilComboBox.Items.Add(str3);
                            if (str3 == str)
                            {
                                num2 = num1;
                            }
                            num1++;
                        }
                        flag = false;
                    }
                }
            }
        
            if (Directory.Exists(str4))
            {
                DirectoryInfo[] directories = (new DirectoryInfo(str4)).GetDirectories("*");
                for (int j = 0; j < (int)directories.Length; j++)
                {
                    string str5 = Form1.decode(directories[j].ToString());
                    if ((str5.IndexOf("ä") + str5.IndexOf("Ä") + str5.IndexOf("ö") + str5.IndexOf("Ö") + str5.IndexOf("ü") + str5.IndexOf("Ü") + str5.IndexOf("ß") != -7 ? false : str5 != "Default"))
                    {
                        this.OPTIONENProfilComboBox.Items.Add(str5);
                        if (str5 == str)
                        {
                            num2 = num1;
                        }
                        num1++;
                    }
                }
            }
            tabControl1.SelectedTab = tabPage3;
            OPTIONENProfilComboBox.SelectedIndex = startProfileName;
            allpar = allpar + " \"-name=" + OPTIONENProfilComboBox.SelectedItem + "\"";
            tabControl1.SelectedTab = tabPage1;

            Gametracker.Load("http://cache.www.gametracker.com/server_info/89.163.144.28:2302/b_350_20_692108_381007_FFFFFF_000000.png");
            Gametracker2.Load("http://cache.www.gametracker.com/server_info/89.163.144.28:2302/b_350_20_692108_381007_FFFFFF_000000.png");

        }

        public static string decode(string toDecode)
        {
            string str;
            while (true)
            {
                string str1 = Uri.UnescapeDataString(toDecode);
                str = str1;
                if (str1 == toDecode)
                {
                    break;
                }
                toDecode = str;
            }
            return str;
        }

        #endregion

        #endregion

        #region Launcher


        #region LaunchButton

        private String a3path = "";
        private Process a3be = new Process();

        #endregion

        #region MissionsUpdate

        Stopwatch sw = new Stopwatch();

        private void startDownload()
        {

            Thread thread = new Thread(() =>
            {

                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("http://89.163.144.28/MissionPreload/" + getcontent2()), downloadlocation);
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
                LAUNCHERLAUNCHBUTTOn2.Enabled = true;
                pictureBox1.Enabled = true;
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
                a3p = OPTIONENTextBoxPF.Text;

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

            string a3exe = @"C:\Program Files (x86)\Steam\steamapps\common\Arma 3\arma3.exe";

            if (!string.IsNullOrWhiteSpace(OPTIONENTextBoxPF.Text)) { a3pfad = OPTIONENTextBoxPF.Text; LAUNCHERNoPath.Visible = false; LAUNCHERNoPath2.Visible = false; }
            else { if (File.Exists(a3exe)) { OPTIONENTextBoxPF.Text = @"C:\Program Files (x86)\Steam\steamapps\commong\Arma 3"; a3pfad = @"C:\Program Files (x86)\Steam\steamapps\commong\Arma 3"; LAUNCHERNoPath.Visible = false; LAUNCHERNoPath2.Visible = false; } else { MessageBox.Show("Bitte wähle einen Arma 3 Pfad aus!"); return; } }

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

            string selectedItem = (string)this.OPTIONENProfilComboBox.SelectedItem;
            if ((string.IsNullOrEmpty(selectedItem) ? false : selectedItem != "Default"))
            {
                int str2 = this.OPTIONENProfilComboBox.SelectedIndex;
                savefile.WriteLine(str2);
            }
            startProfileName = OPTIONENProfilComboBox.SelectedIndex;
            savefile.Close();
            allpar = alleparameter + " \"-name=" + OPTIONENProfilComboBox.SelectedItem + "\"";
        }

        #endregion

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void LAUNCHERDownloadPicBox_Click(object sender, EventArgs e)
        {

            Thread download = new Thread(() =>
            {
                startDownload();
            });
            download.Start();
            LAUNCHERProgressBar.Visible = true;
            LAUNCHERDlSpeedLabel.Visible = true;
            LAUNCHERDlServerLabel.Visible = true;
            LAUNCHERDlTime.Visible = true;
            LAUNCHERDlFinished.Visible = false;
            pictureBox1.Enabled = false;
            LAUNCHERLAUNCHBUTTOn2.Enabled = false;
        }

        private void LAUNCHERLAUNCHBUTTOn2_Click(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\settings.ini"))
            {
                if (!File.Exists(downloadlocation))
                {

                    MessageBox.Show("Es ist eine neue Version verfügbar. Bitte klicke auf Download, um die Mission zu aktualisieren.", "Warnung!");
                    return;

                }

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

        private void LAUNCHEROPTIONENBUTTON_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void LAUNCHERFORUMBUTTON_Click(object sender, EventArgs e) => Process.Start("http://tanoarpg.de");

        private void pictureBox2_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("ts3server://ts.tanoarpg.de?port=9987");

        private void OPTIONENZURUECKBUTTON_Click(object sender, EventArgs e) => tabControl1.SelectedTab = tabPage1;

        private void OPTIONENProfilComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.startProfileName = this.OPTIONENProfilComboBox.SelectedIndex;

        }
    }

}
