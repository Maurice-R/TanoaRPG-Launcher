using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanoaRPG_Launcher
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        #region Variables

        public static string _currentVersionFile() => new StreamReader(new WebClient().OpenRead("http://cdn.cat24max.de/tanoarpg/currentVersionFile.txt")).ReadToEnd();
        public static string _missionFiledownloadlocation() => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\Local\\Arma 3\\MPMissionsCache\\" + _currentVersionFile();
        public static string _getnewestversion() => new StreamReader(new WebClient().OpenRead("http://cdn.cat24max.de/tanoarpg/currentVersionString.txt")).ReadToEnd();

        string par;
        string allpar;
        string profile;
        string a3p;
        double ra;
        double gra;
        int cor;
        public int startProfileName = 0;


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


        private String a3path = "";
        private Process a3be = new Process();


        #endregion

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            string str = Convert.ToString(this.startProfileName);
            int num1 = 1;
            int num2 = 0;
            string str4 = string.Concat(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents"), "\\Arma 3 - Other Profiles\\");

            text_changelog.Visible = true;
            text_changelog.Text = "Changelog";

            #region LauncherSettings

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.a3path))
            {

                a3pfad = Properties.Settings.Default.a3path;
                a3p = Properties.Settings.Default.a3path;
                settings_textbox_a3pfad.Text = Properties.Settings.Default.a3path;

            }
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.parameters))
            {

                profile = Properties.Settings.Default.profileid.ToString();
                par = Properties.Settings.Default.parameters;
                allpar = Properties.Settings.Default.parameters;

                if (par.Contains("-noSplash"))
                {

                    par = par.Replace(" -noSplash", "");

                    NoSplash = true;
                    settings_checkbox_nosplash.Checked = true;
                }
                if (par.Contains("-noLogs"))
                {
                    par = par.Replace(" -noLogs", "");

                    NoLog = true;
                    settings_checkbox_nolog.Checked = true;
                }
                if (par.Contains("-noPause"))
                {
                    par = par.Replace(" -noPause", "");

                    NoPause = true;
                    settings_checkbox_nopause.Checked = true;
                }
                if (par.Contains("-windowed"))
                {
                    par = par.Replace(" -windowed", "");

                    Windowed = true;
                    settings_checkbox_windowed.Checked = true;
                }
                if (par.Contains("-skipIntro"))
                {
                    par = par.Replace(" -skipIntro", "");

                    SkipIntro = true;
                    settings_checkbox_skipintro.Checked = true;
                }
                if (par.Contains("-enableHT"))
                {
                    par = par.Replace(" -enableHT", "");

                    HyperThreading = true;
                    settings_checkbox_hyperthreading.Checked = true;
                }

                startProfileName = Properties.Settings.Default.profileid;

                par = par.Replace(" -connect=89.163.144.28 -port=2302", "");
                par = par.Replace(" -noLauncher", "");

                settings_textbox_startparameters.Text = par;

                ra = Properties.Settings.Default.ram;
                settings_combobox_ram.SelectedItem = Convert.ToString(ra) + "MB";

                gra = Properties.Settings.Default.vram;
                settings_combobox_vram.SelectedItem = Convert.ToString(gra) + "MB";

                cor = Properties.Settings.Default.cpucores;
                settings_combobox_cpucores.SelectedItem = Convert.ToString(cor);
            }

            startProfileName = Properties.Settings.Default.profileid;

            this.settings_combobox_profiles.Items.Add("Default");
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
                            this.settings_combobox_profiles.Items.Add(str3);
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
                        this.settings_combobox_profiles.Items.Add(str5);
                        if (str5 == str)
                        {
                            num2 = num1;
                        }
                        num1++;
                    }
                }
            }


            settings_combobox_profiles.SelectedIndex = startProfileName;
            settings_combobox_profiles.SelectedIndex = Properties.Settings.Default.profileid;
            allpar = allpar + " \"-name=" + settings_combobox_profiles.SelectedItem + "\"";


            #endregion

            #region DefaultVisualSettings

            bar_downloadprogress.Visible = false;


            buttons_download.Visible = false;
            buttons_playbutton.Visible = false;
            buttons_settings.Visible = true;

            text_a3running.Visible = false;
            text_MissionsFile.Visible = false;
            text_newestmissionfile.Visible = false;

            box_settings.Visible = false;

            #endregion

            #region CheckA3RunningAndMissionFile

            Process[] a3 = Process.GetProcessesByName("arma3");

            if (a3.Length == 0)
            {

                text_a3running.Visible = false;

                if (File.Exists(_missionFiledownloadlocation()))
                {

                    int ContentLength;

                    System.Net.WebRequest req = System.Net.HttpWebRequest.Create("http://89.163.144.28/MissionPreload/" + _currentVersionFile());
                    req.Method = "HEAD";

                    using (System.Net.WebResponse resp = req.GetResponse())
                    {
                        if (int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                        {

                        }
                    }

                    if (GetFileSizeOnDisk(_missionFiledownloadlocation()) / 104857 != ContentLength / 104857)
                    {

                        text_MissionsFile.Visible = true;
                        text_MissionsFile.Text = "  Deine Missionsdatei ist NICHT aktuell";

                        buttons_playbutton.Visible = false;
                        buttons_download.Visible = true;


                        text_newestmissionfile.Visible = true;
                        text_newestmissionfile.Text = "Aktuellste Missionsdatei Version: " + _getnewestversion();

                        return;

                    }

                    text_MissionsFile.Visible = true;
                    text_MissionsFile.Text = "       Deine Missionsdatei ist aktuell";

                    buttons_playbutton.Visible = true;
                    buttons_download.Visible = false;

                }
                else
                {

                    text_MissionsFile.Visible = true;
                    text_MissionsFile.Text = "  Deine Missionsdatei ist NICHT aktuell";

                    buttons_playbutton.Visible = false;
                    buttons_download.Visible = true;

                }

                text_newestmissionfile.Visible = true;
                text_newestmissionfile.Text = "Aktuellste Missionsdatei Version: " + _getnewestversion();

            }
            else
            {

                text_a3running.Visible = true;

            }

            #endregion

            #region SettingsBox_RoundedEdges

            box_settings.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, box_settings.Width, box_settings.Height, 25, 25));

            box_settings.BackColor = Color.FromArgb(90, 128, 128, 128);


            #endregion

            Label ov = overlayLabel(settings_text_A3Pfad, box_settings);
            TextBox ov1 = overlayTextBox(settings_textbox_a3pfad, box_settings);
            Button ov2 = overlayButton(settings_button_durchsuchen, box_settings);
            Label ov3 = overlayLabel(settings_text_startparameter, box_settings);
            CheckBox ov4 = overlayCheckBox(settings_checkbox_nosplash, box_settings);
            CheckBox ov5 = overlayCheckBox(settings_checkbox_nolog, box_settings);
            CheckBox ov6 = overlayCheckBox(settings_checkbox_skipintro, box_settings);
            CheckBox ov7 = overlayCheckBox(settings_checkbox_nopause, box_settings);
            CheckBox ov8 = overlayCheckBox(settings_checkbox_windowed, box_settings);
            CheckBox ov9 = overlayCheckBox(settings_checkbox_hyperthreading, box_settings);
            Label ov10 = overlayLabel(settings_text_profile, box_settings);
            ComboBox ov11 = overlayComboBox(settings_combobox_profiles, box_settings);
            Label ov12 = overlayLabel(settings_text_ram, box_settings);
            Label ov13 = overlayLabel(settings_text_vram, box_settings);
            Label ov14 = overlayLabel(settings_text_cpucores, box_settings);
            ComboBox ov15 = overlayComboBox(settings_combobox_ram, box_settings);
            ComboBox ov16 = overlayComboBox(settings_combobox_vram, box_settings);
            ComboBox ov17 = overlayComboBox(settings_combobox_cpucores, box_settings);
            Label ov18 = overlayLabel(settings_text_startparameters, box_settings);
            TextBox ov19 = overlayTextBox(settings_textbox_startparameters, box_settings);
            Button ov20 = overlayButton(settings_button_save, box_settings);

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


        #region Top-Bar

        #region Cancel_Button

        private void cancel_not_hovered_MouseEnter(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cancel_not_hovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancel_hovered_texture.Image")));
        }

        private void cancel_not_hovered_MouseLeave(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cancel_not_hovered.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancel_not_hovered_texture.Image")));
        }

        private void cancel_not_hovered_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Move_Window_Function

        public bool isMouseDown = false;
        public int xLast;
        public int yLast;

        private void top_bar_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void top_bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int newY = this.Top + (e.Y - yLast);
                int newX = this.Left + (e.X - xLast);

                this.Location = new Point(newX, newY);
            }
        }

        private void top_bar_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            xLast = e.X;
            yLast = e.Y;
        }

        #endregion

        #endregion

        #region Download

        Stopwatch sw = new Stopwatch();

        private void startDownload()
        {

            Thread thread = new Thread(() =>
            {

                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri("http://89.163.144.28/MissionPreload/" + _currentVersionFile()), _missionFiledownloadlocation());
                sw.Start();
            });
            thread.Start();
            downloading = true;

        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                bar_downloadprogress.Value = int.Parse(Math.Truncate(percentage).ToString());
                text_dlspeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
                text_dltime.Text = string.Format("{0} Sekunden verbleibend", Math.Round(((e.TotalBytesToReceive / 1024) - (e.BytesReceived / 1024d)) / (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds)));

            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                sw.Reset();
                text_dlspeed.Visible = false;
                text_dltime.Visible = false;
                text_MissionsFile.Text = "    Deine Missionsdatei ist nun aktuell";

                bar_downloadprogress.Visible = false;

                buttons_download.Visible = false;
                buttons_playbutton.Visible = true;
                downloading = false;

            });
        }

        #endregion

        #region Buttons_MainMenu

        #region DownloadButton

        public bool downloading = false;

        private void buttons_download_Click(object sender, EventArgs e)
        {
            if (buttons_download.Visible == false)
                return;

            if (downloading)
                return;

            bar_downloadprogress.Visible = true;
            startDownload();
        }

        #region MouseEvent

        /*private void buttons_download_MouseEnter(object sender, EventArgs e)
        {
            if (buttons_download.Visible == false)
                return;

            if (buttons_download.ClientRectangle.Contains(buttons_download.PointToClient(Control.MousePosition)))
            {

                buttons_download.BorderStyle = BorderStyle.FixedSingle;

            }
            else
            {

                buttons_download.BorderStyle = BorderStyle.None;

            }

        }


        private void buttons_download_MouseLeave(object sender, EventArgs e)
        {
            if (buttons_download.Visible == false)
                return;

            if (buttons_download.ClientRectangle.Contains(buttons_download.PointToClient(Control.MousePosition)))
            {

                buttons_download.BorderStyle = BorderStyle.FixedSingle;

            }
            else
            {

                buttons_download.BorderStyle = BorderStyle.None;

            }

        }*/

        #endregion

        #endregion

        #region PlayButton

        private void buttons_playbutton_Click(object sender, EventArgs e)
        {
            if (buttons_playbutton.Visible == false)
                return;
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.a3path))
            {

                if (File.Exists(_missionFiledownloadlocation()))
                {

                    int ContentLength;

                    System.Net.WebRequest req = System.Net.HttpWebRequest.Create("http://89.163.144.28/MissionPreload/" + _currentVersionFile());
                    req.Method = "HEAD";

                    using (System.Net.WebResponse resp = req.GetResponse())
                    {
                        if (int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                        {

                        }
                    }

                    if (GetFileSizeOnDisk(_missionFiledownloadlocation()) / 104857 != ContentLength / 104857)
                    {

                        text_MissionsFile.Visible = true;
                        text_MissionsFile.Text = "  Deine Missionsdatei ist NICHT aktuell";

                        buttons_playbutton.Visible = false;
                        buttons_download.Visible = true;


                        text_newestmissionfile.Visible = true;
                        text_newestmissionfile.Text = "Aktuellste Missionsdatei Version: " + _getnewestversion();

                        return;

                    }

                    text_MissionsFile.Visible = true;
                    text_MissionsFile.Text = "       Deine Missionsdatei ist aktuell";

                    buttons_playbutton.Visible = true;
                    buttons_download.Visible = false;

                }
                else
                {

                    text_MissionsFile.Visible = true;
                    text_MissionsFile.Text = "  Deine Missionsdatei ist NICHT aktuell";

                    buttons_playbutton.Visible = false;
                    buttons_download.Visible = true;

                }

                text_newestmissionfile.Visible = true;
                text_newestmissionfile.Text = "Aktuellste Missionsdatei Version: " + _getnewestversion();

                a3path = a3p + "\\arma3battleye.exe";

                a3be.StartInfo.FileName = @a3path;
                a3be.StartInfo.Arguments = allpar;
                a3be.Start();

            }
            else
            {
                MessageBox.Show("Bitte lege deinen Arma 3 Pfad unter Optionen fest!");
            }

        }

        #region MouseEvents

        /*private void buttons_playbutton_MouseEnter(object sender, EventArgs e)
        {
            if (buttons_playbutton.Visible == false)
                return;

            if (buttons_playbutton.ClientRectangle.Contains(buttons_playbutton.PointToClient(Control.MousePosition)))
            {

                buttons_playbutton.BorderStyle = BorderStyle.FixedSingle;

            }
            else
            {

                buttons_playbutton.BorderStyle = BorderStyle.None;

            }

        }

        private void buttons_playbutton_MouseLeave(object sender, EventArgs e)
        {
            if (buttons_playbutton.Visible == false)
                return;

            if (buttons_playbutton.ClientRectangle.Contains(buttons_playbutton.PointToClient(Control.MousePosition)))
            {

                buttons_playbutton.BorderStyle = BorderStyle.FixedSingle;

            }
            else
            {

                buttons_playbutton.BorderStyle = BorderStyle.None;

            }

        }*/

        #endregion

        #endregion

        #region Settings

        bool settings_opened = false;

        private void buttons_settings_Click(object sender, EventArgs e)
        {
            if (buttons_settings.Visible == false)
                return;

            if (settings_opened)
            {

                buttons_settings.BorderStyle = BorderStyle.None;
                settings_opened = false;

                settings_text_A3Pfad.Visible = false;
                settings_textbox_a3pfad.Visible = false;
                settings_button_durchsuchen.Visible = false;
                settings_text_startparameter.Visible = false;
                settings_checkbox_nosplash.Visible = false;
                settings_checkbox_nolog.Visible = false;
                settings_checkbox_skipintro.Visible = false;
                settings_checkbox_nopause.Visible = false;
                settings_checkbox_windowed.Visible = false;
                settings_checkbox_hyperthreading.Visible = false;
                settings_text_profile.Visible = false;
                settings_combobox_profiles.Visible = false;
                settings_text_ram.Visible = false;
                settings_text_vram.Visible = false;
                settings_text_cpucores.Visible = false;
                settings_combobox_ram.Visible = false;
                settings_combobox_vram.Visible = false;
                settings_combobox_cpucores.Visible = false;
                settings_text_startparameters.Visible = false;
                settings_textbox_startparameters.Visible = false;
                settings_button_save.Visible = false;

                box_settings.Visible = false;

            }
            else
            {

                buttons_settings.BorderStyle = BorderStyle.Fixed3D;
                settings_opened = true;
                box_settings.Visible = true;



                settings_text_A3Pfad.Visible = true;
                settings_textbox_a3pfad.Visible = true;
                settings_button_durchsuchen.Visible = true;
                settings_text_startparameter.Visible = true;
                settings_checkbox_nosplash.Visible = true;
                settings_checkbox_nolog.Visible = true;
                settings_checkbox_skipintro.Visible = true;
                settings_checkbox_nopause.Visible = true;
                settings_checkbox_windowed.Visible = true;
                settings_checkbox_hyperthreading.Visible = true;
                settings_text_profile.Visible = true;
                settings_combobox_profiles.Visible = true;
                settings_text_ram.Visible = true;
                settings_text_vram.Visible = true;
                settings_text_cpucores.Visible = true;
                settings_combobox_ram.Visible = true;
                settings_combobox_vram.Visible = true;
                settings_combobox_cpucores.Visible = true;
                settings_text_startparameters.Visible = true;
                settings_textbox_startparameters.Visible = true;
                settings_button_save.Visible = true;

            }

        }


        #region MouseEvents

        /*private void buttons_settings_MouseEnter(object sender, EventArgs e)
        {
            if (buttons_settings.Visible == false)
                return;

            if (settings_opened)
            {

                buttons_settings.BorderStyle = BorderStyle.Fixed3D;
                return;

            }
            else
            {
                if(buttons_settings.ClientRectangle.Contains(buttons_settings.PointToClient(Control.MousePosition)))
                {

                    buttons_settings.BorderStyle = BorderStyle.FixedSingle;

                }
                else
                {

                    buttons_settings.BorderStyle = BorderStyle.None;

                }

            }

        }

        private void buttons_settings_MouseLeave(object sender, EventArgs e)
        {
            if (buttons_settings.Visible == false)
                return;

            if (settings_opened)
            {

                buttons_settings.BorderStyle = BorderStyle.Fixed3D;
                return;

            }
            else
            {
                if (buttons_settings.ClientRectangle.Contains(buttons_settings.PointToClient(Control.MousePosition)))
                {

                    buttons_settings.BorderStyle = BorderStyle.FixedSingle;

                }
                else
                {

                    buttons_settings.BorderStyle = BorderStyle.None;

                }

            }

        }*/

        #endregion

        #endregion

        #endregion

        #region FileSize

        public static long GetFileSizeOnDisk(string file)
        {
            FileInfo info = new FileInfo(file);
            uint dummy, sectorsPerCluster, bytesPerSector;
            int result = GetDiskFreeSpaceW(info.Directory.Root.FullName, out sectorsPerCluster, out bytesPerSector, out dummy, out dummy);
            if (result == 0) throw new Win32Exception();
            uint clusterSize = sectorsPerCluster * bytesPerSector;
            uint hosize;
            uint losize = GetCompressedFileSizeW(file, out hosize);
            long size;
            size = (long)hosize << 32 | losize;
            return ((size + clusterSize - 1) / clusterSize) * clusterSize;
        }

        [DllImport("kernel32.dll")]
        static extern uint GetCompressedFileSizeW([In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
           [Out, MarshalAs(UnmanagedType.U4)] out uint lpFileSizeHigh);

        [DllImport("kernel32.dll", SetLastError = true, PreserveSig = true)]
        static extern int GetDiskFreeSpaceW([In, MarshalAs(UnmanagedType.LPWStr)] string lpRootPathName,
           out uint lpSectorsPerCluster, out uint lpBytesPerSector, out uint lpNumberOfFreeClusters,
           out uint lpTotalNumberOfClusters);

        #endregion

        #region OverLay

        #region Label

        Label overlayLabel(Label source, Control target)
        {
            Label old = source.Tag as Label;
            if (old != null && old.Parent == target) target.Controls.Remove(old);
            Label lbl = new Label();
            // copy all necessary properties here:
            lbl.Text = source.Text;
            lbl.Font = source.Font;
            lbl.AutoSize = source.AutoSize;
            lbl.Size = source.Size;
            lbl.Anchor = source.Anchor;  // may work or not!
            lbl.BackColor = source.BackColor;
            lbl.ForeColor = source.ForeColor;
            // etc..
            Point pt = source.Location;
            pt.Offset(-target.Left, -target.Top);
            lbl.Location = pt;
            lbl.Parent = target;
            source.Tag = lbl;
            return lbl;
        }

        #endregion

        #region TextBox

        TextBox overlayTextBox(TextBox source, Control target)
        {
            TextBox old = source.Tag as TextBox;
            if (old != null && old.Parent == target) target.Controls.Remove(old);
            TextBox lbl = new TextBox();
            // copy all necessary properties here:
            lbl.Text = source.Text;
            lbl.Font = source.Font;
            lbl.AutoSize = source.AutoSize;
            lbl.Size = source.Size;
            lbl.Anchor = source.Anchor;  // may work or not!
            lbl.BackColor = source.BackColor;
            lbl.ForeColor = source.ForeColor;
            lbl = source;
            source = lbl;
            // etc..
            Point pt = source.Location;
            pt.Offset(-target.Left, -target.Top);
            lbl.Location = pt;
            lbl.Parent = target;
            source.Tag = lbl;
            return lbl;
        }

        #endregion

        #region Button

        Button overlayButton(Button source, Control target)
        {
            Button old = source.Tag as Button;
            if (old != null && old.Parent == target) target.Controls.Remove(old);
            Button lbl = new Button();
            // copy all necessary properties here:
            lbl.Text = source.Text;
            lbl.Font = source.Font;
            lbl.AutoSize = source.AutoSize;
            lbl.Size = source.Size;
            lbl.Anchor = source.Anchor;  // may work or not!
            lbl.BackColor = source.BackColor;
            lbl.ForeColor = source.ForeColor;
            if (source.Text == "Durchsuchen")
                lbl.Click += new System.EventHandler(this.settings_button_durchsuchen_Click_1);
            if (source.Text == "Speichern")
                lbl.Click += new System.EventHandler(this.settings_button_save_Click);
            // etc..
            Point pt = source.Location;
            pt.Offset(-target.Left, -target.Top);
            lbl.Location = pt;
            lbl.Parent = target;
            source.Tag = lbl;
            return lbl;
        }

        #endregion

        #region CheckBox

        CheckBox overlayCheckBox(CheckBox source, Control target)
        {
            CheckBox old = source.Tag as CheckBox;
            if (old != null && old.Parent == target) target.Controls.Remove(old);
            CheckBox lbl = new CheckBox();
            // copy all necessary properties here:
            lbl.Text = source.Text;
            lbl.Font = source.Font;
            lbl.AutoSize = source.AutoSize;
            lbl.Size = source.Size;
            lbl.Anchor = source.Anchor;  // may work or not!
            lbl.BackColor = source.BackColor;
            lbl.ForeColor = source.ForeColor;
            lbl.Checked = source.Checked;
            lbl = source;
            // etc..
            Point pt = source.Location;
            pt.Offset(-target.Left, -target.Top);
            lbl.Location = pt;
            lbl.Parent = target;
            source.Tag = lbl;
            return lbl;
        }

        #endregion

        #region ComboBox

        ComboBox overlayComboBox(ComboBox source, Control target)
        {
            ComboBox old = source.Tag as ComboBox;
            if (old != null && old.Parent == target) target.Controls.Remove(old);
            ComboBox lbl = new ComboBox();
            // copy all necessary properties here:
            lbl.Text = source.Text;
            lbl.Font = source.Font;
            lbl.AutoSize = source.AutoSize;
            lbl.Size = source.Size;
            lbl.Anchor = source.Anchor;  // may work or not!
            lbl.BackColor = source.BackColor;
            lbl.ForeColor = source.ForeColor;
            object[] a = new object[source.Items.Count];
            source.Items.CopyTo(a, 0);
            lbl.Items.AddRange(a);
            lbl.SelectedIndex = source.SelectedIndex;
            lbl.SelectedItem = source.SelectedItem;
            lbl = source;
            // etc..
            Point pt = source.Location;
            pt.Offset(-target.Left, -target.Top);
            lbl.Location = pt;
            lbl.Parent = target;
            source.Tag = lbl;
            return lbl;
        }

        #endregion

        #endregion

        #region Save

        private void settings_button_save_Click(object sender, EventArgs e)
        {
            Microsoft.VisualBasic.Devices.ComputerInfo inf = new Microsoft.VisualBasic.Devices.ComputerInfo();

            if (!string.IsNullOrWhiteSpace(settings_textbox_a3pfad.Text))
            {

                a3pfad = settings_textbox_a3pfad.Text;
                text_a3running.Visible = false;

            }
            else
            {

                text_a3running.Text = "                    Bitte wähle ein Arma 3 Pfad aus!";
                text_a3running.Visible = true;
                buttons_playbutton.Visible = false;

            }

            startparameters = settings_textbox_startparameters.Text;
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

            if (!string.IsNullOrWhiteSpace(settings_combobox_ram.Text)) { string r = settings_combobox_ram.Text; r = r.Replace("MB", ""); Double.TryParse(r, out ram); }
            else { ram = Math.Round(Convert.ToDouble(inf.TotalPhysicalMemory) / 1048576 / 2); }

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select AdapterRAM from Win32_VideoController");

            if (!string.IsNullOrWhiteSpace(settings_combobox_vram.Text)) { string r = settings_combobox_vram.Text; r = r.Replace("MB", ""); Double.TryParse(r, out gram); }
            else { foreach (ManagementObject mo in searcher.Get()) { var ram = mo.Properties["AdapterRAM"].Value as UInt32?; if (ram.HasValue) { gram = Math.Round(((double)ram / 1048576 / 2)); } }; }

            if (!string.IsNullOrWhiteSpace(settings_combobox_cpucores.Text)) { string r = settings_combobox_cpucores.Text; int.TryParse(r, out cores); }
            else { cores = Environment.ProcessorCount; }


            alleparameter = alleparameter + " -connect=89.163.144.28 -port=2302 -noLauncher";

            Properties.Settings.Default["a3path"] = a3pfad;
            Properties.Settings.Default["ram"] = ram;
            Properties.Settings.Default["vram"] = gram;
            Properties.Settings.Default["parameters"] = alleparameter;
            Properties.Settings.Default["cpucores"] = cores;


            string selectedItem = (string)this.settings_combobox_profiles.SelectedItem;
            if (string.IsNullOrEmpty(selectedItem) ? false : selectedItem != "Default")
            {
                int str2 = this.settings_combobox_profiles.SelectedIndex;
                Properties.Settings.Default["profileid"] = str2;
            }
            startProfileName = settings_combobox_profiles.SelectedIndex;

            Properties.Settings.Default.Save();


            allpar = alleparameter + " \"-name=" + settings_combobox_profiles.SelectedItem + "\"";

        }

        #endregion

        #region Settings

        private void settings_checkbox_nosplash_CheckedChanged(object sender, EventArgs e)
        {
            if (settings_checkbox_nosplash.Checked)
                NoSplash = true;
            else
                NoSplash = false;
        }

        private void settings_checkbox_nolog_CheckedChanged(object sender, EventArgs e)
        {
            if (settings_checkbox_nolog.Checked)
                NoLog = true;
            else
                NoLog = false;
        }

        private void settings_checkbox_skipintro_CheckedChanged(object sender, EventArgs e)
        {
            if (settings_checkbox_skipintro.Checked)
                SkipIntro = true;
            else
                SkipIntro = false;
        }

        private void settings_checkbox_nopause_CheckedChanged(object sender, EventArgs e)
        {
            if (settings_checkbox_nopause.Checked)
                NoPause = true;
            else
                NoPause = false;
        }

        private void settings_checkbox_windowed_CheckedChanged(object sender, EventArgs e)
        {
            if (settings_checkbox_windowed.Checked)
                Windowed = true;
            else
                Windowed = false;
        }

        private void settings_checkbox_hyperthreading_CheckedChanged(object sender, EventArgs e)
        {
            if (settings_checkbox_hyperthreading.Checked)
                HyperThreading = true;
            else
                HyperThreading = false;
        }

        private void settings_combobox_profiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.startProfileName = this.settings_combobox_profiles.SelectedIndex; this.startProfileName = this.settings_combobox_profiles.SelectedIndex;
        }

        #endregion

        private void settings_button_durchsuchen_Click_1(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                settings_textbox_a3pfad.Text = folderBrowserDialog1.SelectedPath;
                settings_textbox_a3pfad.Refresh();
                a3pfad = settings_textbox_a3pfad.Text;
                a3p = settings_textbox_a3pfad.Text;

            }
        }

        private void text_changelog_Click(object sender, EventArgs e) => Process.Start(new StreamReader(new WebClient().OpenRead("http://cdn.cat24max.de/tanoarpg/currentVersionChangelog.txt")).ReadToEnd());

        private void buttons_teamspeak_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("ts3server://ts.tanoarpg.de?port=9987");

        private void buttons_tanoarpglogo_Click(object sender, EventArgs e) => Process.Start("http://tanoarpg.de");
    }

}

