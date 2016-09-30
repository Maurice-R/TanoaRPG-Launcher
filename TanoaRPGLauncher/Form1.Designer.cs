using System;

namespace TanoaRPG_Launcher
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.top_bar = new System.Windows.Forms.PictureBox();
            this.cancel_not_hovered = new System.Windows.Forms.PictureBox();
            this.cancel_hovered_texture = new System.Windows.Forms.PictureBox();
            this.cancel_not_hovered_texture = new System.Windows.Forms.PictureBox();
            this.top_bar_divider = new System.Windows.Forms.PictureBox();
            this.buttons_download = new System.Windows.Forms.PictureBox();
            this.buttons_playbutton = new System.Windows.Forms.PictureBox();
            this.bar_downloadprogress = new System.Windows.Forms.ProgressBar();
            this.buttons_settings = new System.Windows.Forms.PictureBox();
            this.text_a3running = new System.Windows.Forms.Label();
            this.text_MissionsFile = new System.Windows.Forms.Label();
            this.text_newestmissionfile = new System.Windows.Forms.Label();
            this.text_dlspeed = new System.Windows.Forms.Label();
            this.text_dltime = new System.Windows.Forms.Label();
            this.box_settings = new System.Windows.Forms.PictureBox();
            this.settings_text_A3Pfad = new System.Windows.Forms.Label();
            this.settings_textbox_a3pfad = new System.Windows.Forms.TextBox();
            this.settings_button_durchsuchen = new System.Windows.Forms.Button();
            this.settings_checkbox_nosplash = new System.Windows.Forms.CheckBox();
            this.settings_text_startparameter = new System.Windows.Forms.Label();
            this.settings_checkbox_nolog = new System.Windows.Forms.CheckBox();
            this.settings_checkbox_skipintro = new System.Windows.Forms.CheckBox();
            this.settings_checkbox_nopause = new System.Windows.Forms.CheckBox();
            this.settings_checkbox_windowed = new System.Windows.Forms.CheckBox();
            this.settings_checkbox_hyperthreading = new System.Windows.Forms.CheckBox();
            this.settings_text_profile = new System.Windows.Forms.Label();
            this.settings_combobox_profiles = new System.Windows.Forms.ComboBox();
            this.settings_text_ram = new System.Windows.Forms.Label();
            this.settings_combobox_ram = new System.Windows.Forms.ComboBox();
            this.settings_text_vram = new System.Windows.Forms.Label();
            this.settings_combobox_vram = new System.Windows.Forms.ComboBox();
            this.settings_text_cpucores = new System.Windows.Forms.Label();
            this.settings_combobox_cpucores = new System.Windows.Forms.ComboBox();
            this.settings_text_startparameters = new System.Windows.Forms.Label();
            this.settings_textbox_startparameters = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.settings_button_save = new System.Windows.Forms.Button();
            this.text_changelog = new System.Windows.Forms.Label();
            this.buttons_teamspeak = new System.Windows.Forms.PictureBox();
            this.buttons_tanoarpglogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel_not_hovered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel_hovered_texture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel_not_hovered_texture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar_divider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_download)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_playbutton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_teamspeak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_tanoarpglogo)).BeginInit();
            this.SuspendLayout();
            // 
            // top_bar
            // 
            this.top_bar.BackColor = System.Drawing.Color.Black;
            this.top_bar.Location = new System.Drawing.Point(0, 0);
            this.top_bar.Name = "top_bar";
            this.top_bar.Size = new System.Drawing.Size(835, 28);
            this.top_bar.TabIndex = 0;
            this.top_bar.TabStop = false;
            this.top_bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_bar_MouseDown);
            this.top_bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.top_bar_MouseMove);
            this.top_bar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.top_bar_MouseUp);
            // 
            // cancel_not_hovered
            // 
            this.cancel_not_hovered.BackColor = System.Drawing.Color.Black;
            this.cancel_not_hovered.Image = ((System.Drawing.Image)(resources.GetObject("cancel_not_hovered.Image")));
            this.cancel_not_hovered.Location = new System.Drawing.Point(834, 0);
            this.cancel_not_hovered.Name = "cancel_not_hovered";
            this.cancel_not_hovered.Size = new System.Drawing.Size(28, 28);
            this.cancel_not_hovered.TabIndex = 1;
            this.cancel_not_hovered.TabStop = false;
            this.cancel_not_hovered.Click += new System.EventHandler(this.cancel_not_hovered_Click);
            this.cancel_not_hovered.MouseEnter += new System.EventHandler(this.cancel_not_hovered_MouseEnter);
            this.cancel_not_hovered.MouseLeave += new System.EventHandler(this.cancel_not_hovered_MouseLeave);
            // 
            // cancel_hovered_texture
            // 
            this.cancel_hovered_texture.BackColor = System.Drawing.Color.Black;
            this.cancel_hovered_texture.Image = ((System.Drawing.Image)(resources.GetObject("cancel_hovered_texture.Image")));
            this.cancel_hovered_texture.Location = new System.Drawing.Point(834, 0);
            this.cancel_hovered_texture.Name = "cancel_hovered_texture";
            this.cancel_hovered_texture.Size = new System.Drawing.Size(28, 28);
            this.cancel_hovered_texture.TabIndex = 2;
            this.cancel_hovered_texture.TabStop = false;
            this.cancel_hovered_texture.Visible = false;
            // 
            // cancel_not_hovered_texture
            // 
            this.cancel_not_hovered_texture.BackColor = System.Drawing.Color.Black;
            this.cancel_not_hovered_texture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel_not_hovered_texture.Image = ((System.Drawing.Image)(resources.GetObject("cancel_not_hovered_texture.Image")));
            this.cancel_not_hovered_texture.Location = new System.Drawing.Point(834, 0);
            this.cancel_not_hovered_texture.Name = "cancel_not_hovered_texture";
            this.cancel_not_hovered_texture.Size = new System.Drawing.Size(28, 28);
            this.cancel_not_hovered_texture.TabIndex = 3;
            this.cancel_not_hovered_texture.TabStop = false;
            this.cancel_not_hovered_texture.Visible = false;
            // 
            // top_bar_divider
            // 
            this.top_bar_divider.BackColor = System.Drawing.Color.Gray;
            this.top_bar_divider.Location = new System.Drawing.Point(0, 27);
            this.top_bar_divider.Name = "top_bar_divider";
            this.top_bar_divider.Size = new System.Drawing.Size(863, 2);
            this.top_bar_divider.TabIndex = 4;
            this.top_bar_divider.TabStop = false;
            // 
            // buttons_download
            // 
            this.buttons_download.BackColor = System.Drawing.Color.Transparent;
            this.buttons_download.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttons_download.BackgroundImage")));
            this.buttons_download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttons_download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttons_download.Location = new System.Drawing.Point(405, 213);
            this.buttons_download.Name = "buttons_download";
            this.buttons_download.Size = new System.Drawing.Size(75, 75);
            this.buttons_download.TabIndex = 5;
            this.buttons_download.TabStop = false;
            this.buttons_download.Visible = false;
            this.buttons_download.Click += new System.EventHandler(this.buttons_download_Click);
            // 
            // buttons_playbutton
            // 
            this.buttons_playbutton.BackColor = System.Drawing.Color.Transparent;
            this.buttons_playbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttons_playbutton.BackgroundImage")));
            this.buttons_playbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttons_playbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttons_playbutton.Location = new System.Drawing.Point(405, 213);
            this.buttons_playbutton.Name = "buttons_playbutton";
            this.buttons_playbutton.Size = new System.Drawing.Size(75, 75);
            this.buttons_playbutton.TabIndex = 6;
            this.buttons_playbutton.TabStop = false;
            this.buttons_playbutton.Visible = false;
            this.buttons_playbutton.Click += new System.EventHandler(this.buttons_playbutton_Click);
            // 
            // bar_downloadprogress
            // 
            this.bar_downloadprogress.ForeColor = System.Drawing.Color.Black;
            this.bar_downloadprogress.Location = new System.Drawing.Point(292, 375);
            this.bar_downloadprogress.Name = "bar_downloadprogress";
            this.bar_downloadprogress.Size = new System.Drawing.Size(306, 23);
            this.bar_downloadprogress.TabIndex = 7;
            this.bar_downloadprogress.Visible = false;
            // 
            // buttons_settings
            // 
            this.buttons_settings.BackColor = System.Drawing.Color.Transparent;
            this.buttons_settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttons_settings.BackgroundImage")));
            this.buttons_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttons_settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttons_settings.Location = new System.Drawing.Point(-1, 394);
            this.buttons_settings.Name = "buttons_settings";
            this.buttons_settings.Size = new System.Drawing.Size(75, 75);
            this.buttons_settings.TabIndex = 8;
            this.buttons_settings.TabStop = false;
            this.buttons_settings.Visible = false;
            this.buttons_settings.Click += new System.EventHandler(this.buttons_settings_Click);
            // 
            // text_a3running
            // 
            this.text_a3running.AutoSize = true;
            this.text_a3running.BackColor = System.Drawing.Color.Transparent;
            this.text_a3running.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_a3running.ForeColor = System.Drawing.Color.Red;
            this.text_a3running.Location = new System.Drawing.Point(227, 241);
            this.text_a3running.Name = "text_a3running";
            this.text_a3running.Size = new System.Drawing.Size(443, 17);
            this.text_a3running.TabIndex = 9;
            this.text_a3running.Text = "Bitte beende Arma 3 um den Launcher benutzen zu können!";
            this.text_a3running.Visible = false;
            // 
            // text_MissionsFile
            // 
            this.text_MissionsFile.AutoSize = true;
            this.text_MissionsFile.BackColor = System.Drawing.Color.Transparent;
            this.text_MissionsFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_MissionsFile.Location = new System.Drawing.Point(315, 315);
            this.text_MissionsFile.Name = "text_MissionsFile";
            this.text_MissionsFile.Size = new System.Drawing.Size(0, 15);
            this.text_MissionsFile.TabIndex = 10;
            // 
            // text_newestmissionfile
            // 
            this.text_newestmissionfile.AutoSize = true;
            this.text_newestmissionfile.BackColor = System.Drawing.Color.Transparent;
            this.text_newestmissionfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_newestmissionfile.Location = new System.Drawing.Point(320, 295);
            this.text_newestmissionfile.Name = "text_newestmissionfile";
            this.text_newestmissionfile.Size = new System.Drawing.Size(0, 15);
            this.text_newestmissionfile.TabIndex = 11;
            // 
            // text_dlspeed
            // 
            this.text_dlspeed.AutoSize = true;
            this.text_dlspeed.BackColor = System.Drawing.Color.Transparent;
            this.text_dlspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_dlspeed.Location = new System.Drawing.Point(285, 355);
            this.text_dlspeed.Name = "text_dlspeed";
            this.text_dlspeed.Size = new System.Drawing.Size(0, 15);
            this.text_dlspeed.TabIndex = 12;
            // 
            // text_dltime
            // 
            this.text_dltime.AutoSize = true;
            this.text_dltime.BackColor = System.Drawing.Color.Transparent;
            this.text_dltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_dltime.Location = new System.Drawing.Point(435, 355);
            this.text_dltime.Name = "text_dltime";
            this.text_dltime.Size = new System.Drawing.Size(0, 15);
            this.text_dltime.TabIndex = 13;
            // 
            // box_settings
            // 
            this.box_settings.BackColor = System.Drawing.Color.Transparent;
            this.box_settings.Location = new System.Drawing.Point(0, 91);
            this.box_settings.Name = "box_settings";
            this.box_settings.Size = new System.Drawing.Size(333, 307);
            this.box_settings.TabIndex = 14;
            this.box_settings.TabStop = false;
            this.box_settings.Visible = false;
            // 
            // settings_text_A3Pfad
            // 
            this.settings_text_A3Pfad.AutoSize = true;
            this.settings_text_A3Pfad.BackColor = System.Drawing.Color.Transparent;
            this.settings_text_A3Pfad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_text_A3Pfad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings_text_A3Pfad.Location = new System.Drawing.Point(13, 100);
            this.settings_text_A3Pfad.Name = "settings_text_A3Pfad";
            this.settings_text_A3Pfad.Size = new System.Drawing.Size(170, 17);
            this.settings_text_A3Pfad.TabIndex = 15;
            this.settings_text_A3Pfad.Text = "Arma 3 Pfad (Ordner):";
            this.settings_text_A3Pfad.Visible = false;
            // 
            // settings_textbox_a3pfad
            // 
            this.settings_textbox_a3pfad.Location = new System.Drawing.Point(16, 116);
            this.settings_textbox_a3pfad.Name = "settings_textbox_a3pfad";
            this.settings_textbox_a3pfad.Size = new System.Drawing.Size(218, 20);
            this.settings_textbox_a3pfad.TabIndex = 16;
            this.settings_textbox_a3pfad.Visible = false;
            // 
            // settings_button_durchsuchen
            // 
            this.settings_button_durchsuchen.BackColor = System.Drawing.Color.Transparent;
            this.settings_button_durchsuchen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.settings_button_durchsuchen.Location = new System.Drawing.Point(240, 116);
            this.settings_button_durchsuchen.Name = "settings_button_durchsuchen";
            this.settings_button_durchsuchen.Size = new System.Drawing.Size(88, 21);
            this.settings_button_durchsuchen.TabIndex = 17;
            this.settings_button_durchsuchen.Text = "Durchsuchen";
            this.settings_button_durchsuchen.UseVisualStyleBackColor = false;
            this.settings_button_durchsuchen.Visible = false;
            this.settings_button_durchsuchen.Click += new System.EventHandler(this.settings_button_durchsuchen_Click_1);
            // 
            // settings_checkbox_nosplash
            // 
            this.settings_checkbox_nosplash.AutoSize = true;
            this.settings_checkbox_nosplash.BackColor = System.Drawing.Color.Transparent;
            this.settings_checkbox_nosplash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_checkbox_nosplash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings_checkbox_nosplash.Location = new System.Drawing.Point(26, 160);
            this.settings_checkbox_nosplash.Name = "settings_checkbox_nosplash";
            this.settings_checkbox_nosplash.Size = new System.Drawing.Size(84, 17);
            this.settings_checkbox_nosplash.TabIndex = 19;
            this.settings_checkbox_nosplash.Text = "No Splash";
            this.settings_checkbox_nosplash.UseVisualStyleBackColor = false;
            this.settings_checkbox_nosplash.Visible = false;
            this.settings_checkbox_nosplash.CheckedChanged += new System.EventHandler(this.settings_checkbox_nosplash_CheckedChanged);
            // 
            // settings_text_startparameter
            // 
            this.settings_text_startparameter.AutoSize = true;
            this.settings_text_startparameter.BackColor = System.Drawing.Color.Transparent;
            this.settings_text_startparameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_text_startparameter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings_text_startparameter.Location = new System.Drawing.Point(13, 140);
            this.settings_text_startparameter.Name = "settings_text_startparameter";
            this.settings_text_startparameter.Size = new System.Drawing.Size(122, 17);
            this.settings_text_startparameter.TabIndex = 20;
            this.settings_text_startparameter.Text = "Startparameter:";
            this.settings_text_startparameter.Visible = false;
            // 
            // settings_checkbox_nolog
            // 
            this.settings_checkbox_nolog.AutoSize = true;
            this.settings_checkbox_nolog.BackColor = System.Drawing.Color.Transparent;
            this.settings_checkbox_nolog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_checkbox_nolog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings_checkbox_nolog.Location = new System.Drawing.Point(124, 160);
            this.settings_checkbox_nolog.Name = "settings_checkbox_nolog";
            this.settings_checkbox_nolog.Size = new System.Drawing.Size(67, 17);
            this.settings_checkbox_nolog.TabIndex = 21;
            this.settings_checkbox_nolog.Text = "No Log";
            this.settings_checkbox_nolog.UseVisualStyleBackColor = false;
            this.settings_checkbox_nolog.Visible = false;
            this.settings_checkbox_nolog.CheckedChanged += new System.EventHandler(this.settings_checkbox_nolog_CheckedChanged);
            // 
            // settings_checkbox_skipintro
            // 
            this.settings_checkbox_skipintro.AutoSize = true;
            this.settings_checkbox_skipintro.BackColor = System.Drawing.Color.Transparent;
            this.settings_checkbox_skipintro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_checkbox_skipintro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings_checkbox_skipintro.Location = new System.Drawing.Point(212, 160);
            this.settings_checkbox_skipintro.Name = "settings_checkbox_skipintro";
            this.settings_checkbox_skipintro.Size = new System.Drawing.Size(81, 17);
            this.settings_checkbox_skipintro.TabIndex = 22;
            this.settings_checkbox_skipintro.Text = "Skip Intro";
            this.settings_checkbox_skipintro.UseVisualStyleBackColor = false;
            this.settings_checkbox_skipintro.Visible = false;
            this.settings_checkbox_skipintro.CheckedChanged += new System.EventHandler(this.settings_checkbox_skipintro_CheckedChanged);
            // 
            // settings_checkbox_nopause
            // 
            this.settings_checkbox_nopause.AutoSize = true;
            this.settings_checkbox_nopause.BackColor = System.Drawing.Color.Transparent;
            this.settings_checkbox_nopause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_checkbox_nopause.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings_checkbox_nopause.Location = new System.Drawing.Point(26, 183);
            this.settings_checkbox_nopause.Name = "settings_checkbox_nopause";
            this.settings_checkbox_nopause.Size = new System.Drawing.Size(81, 17);
            this.settings_checkbox_nopause.TabIndex = 23;
            this.settings_checkbox_nopause.Text = "No Pause";
            this.settings_checkbox_nopause.UseVisualStyleBackColor = false;
            this.settings_checkbox_nopause.Visible = false;
            this.settings_checkbox_nopause.CheckedChanged += new System.EventHandler(this.settings_checkbox_nopause_CheckedChanged);
            // 
            // settings_checkbox_windowed
            // 
            this.settings_checkbox_windowed.AutoSize = true;
            this.settings_checkbox_windowed.BackColor = System.Drawing.Color.Transparent;
            this.settings_checkbox_windowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_checkbox_windowed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings_checkbox_windowed.Location = new System.Drawing.Point(124, 183);
            this.settings_checkbox_windowed.Name = "settings_checkbox_windowed";
            this.settings_checkbox_windowed.Size = new System.Drawing.Size(85, 17);
            this.settings_checkbox_windowed.TabIndex = 24;
            this.settings_checkbox_windowed.Text = "Windowed";
            this.settings_checkbox_windowed.UseVisualStyleBackColor = false;
            this.settings_checkbox_windowed.Visible = false;
            this.settings_checkbox_windowed.CheckedChanged += new System.EventHandler(this.settings_checkbox_windowed_CheckedChanged);
            // 
            // settings_checkbox_hyperthreading
            // 
            this.settings_checkbox_hyperthreading.AutoSize = true;
            this.settings_checkbox_hyperthreading.BackColor = System.Drawing.Color.Transparent;
            this.settings_checkbox_hyperthreading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_checkbox_hyperthreading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settings_checkbox_hyperthreading.Location = new System.Drawing.Point(212, 183);
            this.settings_checkbox_hyperthreading.Name = "settings_checkbox_hyperthreading";
            this.settings_checkbox_hyperthreading.Size = new System.Drawing.Size(120, 17);
            this.settings_checkbox_hyperthreading.TabIndex = 25;
            this.settings_checkbox_hyperthreading.Text = "Hyper-Threading";
            this.settings_checkbox_hyperthreading.UseVisualStyleBackColor = false;
            this.settings_checkbox_hyperthreading.Visible = false;
            this.settings_checkbox_hyperthreading.CheckedChanged += new System.EventHandler(this.settings_checkbox_hyperthreading_CheckedChanged);
            // 
            // settings_text_profile
            // 
            this.settings_text_profile.AutoSize = true;
            this.settings_text_profile.BackColor = System.Drawing.Color.Transparent;
            this.settings_text_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_text_profile.Location = new System.Drawing.Point(12, 213);
            this.settings_text_profile.Name = "settings_text_profile";
            this.settings_text_profile.Size = new System.Drawing.Size(51, 17);
            this.settings_text_profile.TabIndex = 26;
            this.settings_text_profile.Text = "Profil:";
            this.settings_text_profile.Visible = false;
            // 
            // settings_combobox_profiles
            // 
            this.settings_combobox_profiles.FormattingEnabled = true;
            this.settings_combobox_profiles.Location = new System.Drawing.Point(69, 212);
            this.settings_combobox_profiles.Name = "settings_combobox_profiles";
            this.settings_combobox_profiles.Size = new System.Drawing.Size(224, 21);
            this.settings_combobox_profiles.TabIndex = 27;
            this.settings_combobox_profiles.Visible = false;
            this.settings_combobox_profiles.SelectedIndexChanged += new System.EventHandler(this.settings_combobox_profiles_SelectedIndexChanged);
            // 
            // settings_text_ram
            // 
            this.settings_text_ram.AutoSize = true;
            this.settings_text_ram.BackColor = System.Drawing.Color.Transparent;
            this.settings_text_ram.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_text_ram.Location = new System.Drawing.Point(13, 241);
            this.settings_text_ram.Name = "settings_text_ram";
            this.settings_text_ram.Size = new System.Drawing.Size(126, 17);
            this.settings_text_ram.TabIndex = 28;
            this.settings_text_ram.Text = "Arbeitsspeicher:";
            this.settings_text_ram.Visible = false;
            // 
            // settings_combobox_ram
            // 
            this.settings_combobox_ram.FormattingEnabled = true;
            this.settings_combobox_ram.Items.AddRange(new object[] {
            "512MB",
            "1024MB",
            "1536MB",
            "2048MB",
            "2560MB",
            "3072MB",
            "3584MB",
            "4096MB",
            "4608MB",
            "5120MB",
            "5632MB",
            "6144MB",
            "6656MB",
            "7168MB",
            "7680MB",
            "8192MB",
            "8704MB",
            "9216MB",
            "9728MB",
            "10240MB"});
            this.settings_combobox_ram.Location = new System.Drawing.Point(16, 262);
            this.settings_combobox_ram.Name = "settings_combobox_ram";
            this.settings_combobox_ram.Size = new System.Drawing.Size(121, 21);
            this.settings_combobox_ram.TabIndex = 29;
            this.settings_combobox_ram.Visible = false;
            // 
            // settings_text_vram
            // 
            this.settings_text_vram.AutoSize = true;
            this.settings_text_vram.BackColor = System.Drawing.Color.Transparent;
            this.settings_text_vram.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_text_vram.Location = new System.Drawing.Point(167, 241);
            this.settings_text_vram.Name = "settings_text_vram";
            this.settings_text_vram.Size = new System.Drawing.Size(119, 17);
            this.settings_text_vram.TabIndex = 30;
            this.settings_text_vram.Text = "Grafikspeicher:";
            this.settings_text_vram.Visible = false;
            // 
            // settings_combobox_vram
            // 
            this.settings_combobox_vram.FormattingEnabled = true;
            this.settings_combobox_vram.Items.AddRange(new object[] {
            "512MB",
            "1024MB",
            "1536MB",
            "2048MB",
            "2560MB",
            "3072MB",
            "3584MB",
            "4096MB",
            "4608MB",
            "5120MB",
            "5632MB",
            "6144MB",
            "6656MB",
            "7168MB",
            "7680MB",
            "8192MB"});
            this.settings_combobox_vram.Location = new System.Drawing.Point(170, 262);
            this.settings_combobox_vram.Name = "settings_combobox_vram";
            this.settings_combobox_vram.Size = new System.Drawing.Size(121, 21);
            this.settings_combobox_vram.TabIndex = 31;
            this.settings_combobox_vram.Visible = false;
            // 
            // settings_text_cpucores
            // 
            this.settings_text_cpucores.AutoSize = true;
            this.settings_text_cpucores.BackColor = System.Drawing.Color.Transparent;
            this.settings_text_cpucores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_text_cpucores.Location = new System.Drawing.Point(13, 300);
            this.settings_text_cpucores.Name = "settings_text_cpucores";
            this.settings_text_cpucores.Size = new System.Drawing.Size(93, 17);
            this.settings_text_cpucores.TabIndex = 32;
            this.settings_text_cpucores.Text = "CPU-Kerne:";
            this.settings_text_cpucores.Visible = false;
            // 
            // settings_combobox_cpucores
            // 
            this.settings_combobox_cpucores.FormattingEnabled = true;
            this.settings_combobox_cpucores.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.settings_combobox_cpucores.Location = new System.Drawing.Point(112, 300);
            this.settings_combobox_cpucores.Name = "settings_combobox_cpucores";
            this.settings_combobox_cpucores.Size = new System.Drawing.Size(71, 21);
            this.settings_combobox_cpucores.TabIndex = 33;
            this.settings_combobox_cpucores.Visible = false;
            // 
            // settings_text_startparameters
            // 
            this.settings_text_startparameters.AutoSize = true;
            this.settings_text_startparameters.BackColor = System.Drawing.Color.Transparent;
            this.settings_text_startparameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_text_startparameters.Location = new System.Drawing.Point(13, 328);
            this.settings_text_startparameters.Name = "settings_text_startparameters";
            this.settings_text_startparameters.Size = new System.Drawing.Size(190, 17);
            this.settings_text_startparameters.TabIndex = 34;
            this.settings_text_startparameters.Text = "Sonstige Startparameter:";
            this.settings_text_startparameters.Visible = false;
            // 
            // settings_textbox_startparameters
            // 
            this.settings_textbox_startparameters.Location = new System.Drawing.Point(15, 348);
            this.settings_textbox_startparameters.Name = "settings_textbox_startparameters";
            this.settings_textbox_startparameters.Size = new System.Drawing.Size(300, 20);
            this.settings_textbox_startparameters.TabIndex = 35;
            this.settings_textbox_startparameters.Visible = false;
            // 
            // settings_button_save
            // 
            this.settings_button_save.Location = new System.Drawing.Point(256, 373);
            this.settings_button_save.Name = "settings_button_save";
            this.settings_button_save.Size = new System.Drawing.Size(75, 23);
            this.settings_button_save.TabIndex = 36;
            this.settings_button_save.Text = "Speichern";
            this.settings_button_save.UseVisualStyleBackColor = true;
            this.settings_button_save.Visible = false;
            this.settings_button_save.Click += new System.EventHandler(this.settings_button_save_Click);
            // 
            // text_changelog
            // 
            this.text_changelog.AutoSize = true;
            this.text_changelog.BackColor = System.Drawing.Color.Transparent;
            this.text_changelog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_changelog.Location = new System.Drawing.Point(407, 335);
            this.text_changelog.Name = "text_changelog";
            this.text_changelog.Size = new System.Drawing.Size(0, 15);
            this.text_changelog.TabIndex = 37;
            this.text_changelog.Click += new System.EventHandler(this.text_changelog_Click);
            // 
            // buttons_teamspeak
            // 
            this.buttons_teamspeak.BackColor = System.Drawing.Color.Transparent;
            this.buttons_teamspeak.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttons_teamspeak.BackgroundImage")));
            this.buttons_teamspeak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttons_teamspeak.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttons_teamspeak.Location = new System.Drawing.Point(788, 394);
            this.buttons_teamspeak.Name = "buttons_teamspeak";
            this.buttons_teamspeak.Size = new System.Drawing.Size(75, 75);
            this.buttons_teamspeak.TabIndex = 38;
            this.buttons_teamspeak.TabStop = false;
            this.buttons_teamspeak.Click += new System.EventHandler(this.buttons_teamspeak_Click);
            // 
            // buttons_tanoarpglogo
            // 
            this.buttons_tanoarpglogo.BackColor = System.Drawing.Color.Transparent;
            this.buttons_tanoarpglogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttons_tanoarpglogo.Location = new System.Drawing.Point(665, 35);
            this.buttons_tanoarpglogo.Name = "buttons_tanoarpglogo";
            this.buttons_tanoarpglogo.Size = new System.Drawing.Size(180, 50);
            this.buttons_tanoarpglogo.TabIndex = 39;
            this.buttons_tanoarpglogo.TabStop = false;
            this.buttons_tanoarpglogo.Click += new System.EventHandler(this.buttons_tanoarpglogo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(863, 469);
            this.Controls.Add(this.buttons_tanoarpglogo);
            this.Controls.Add(this.buttons_teamspeak);
            this.Controls.Add(this.text_changelog);
            this.Controls.Add(this.settings_button_save);
            this.Controls.Add(this.settings_textbox_startparameters);
            this.Controls.Add(this.settings_text_startparameters);
            this.Controls.Add(this.settings_combobox_cpucores);
            this.Controls.Add(this.settings_text_cpucores);
            this.Controls.Add(this.settings_combobox_vram);
            this.Controls.Add(this.settings_text_vram);
            this.Controls.Add(this.settings_combobox_ram);
            this.Controls.Add(this.settings_text_ram);
            this.Controls.Add(this.settings_combobox_profiles);
            this.Controls.Add(this.settings_text_profile);
            this.Controls.Add(this.settings_checkbox_hyperthreading);
            this.Controls.Add(this.settings_checkbox_windowed);
            this.Controls.Add(this.settings_checkbox_nopause);
            this.Controls.Add(this.settings_checkbox_skipintro);
            this.Controls.Add(this.settings_checkbox_nolog);
            this.Controls.Add(this.settings_text_startparameter);
            this.Controls.Add(this.settings_checkbox_nosplash);
            this.Controls.Add(this.settings_button_durchsuchen);
            this.Controls.Add(this.settings_textbox_a3pfad);
            this.Controls.Add(this.settings_text_A3Pfad);
            this.Controls.Add(this.box_settings);
            this.Controls.Add(this.text_dltime);
            this.Controls.Add(this.text_dlspeed);
            this.Controls.Add(this.text_newestmissionfile);
            this.Controls.Add(this.text_MissionsFile);
            this.Controls.Add(this.text_a3running);
            this.Controls.Add(this.buttons_settings);
            this.Controls.Add(this.bar_downloadprogress);
            this.Controls.Add(this.buttons_playbutton);
            this.Controls.Add(this.buttons_download);
            this.Controls.Add(this.top_bar_divider);
            this.Controls.Add(this.cancel_not_hovered_texture);
            this.Controls.Add(this.cancel_hovered_texture);
            this.Controls.Add(this.cancel_not_hovered);
            this.Controls.Add(this.top_bar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.top_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel_not_hovered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel_hovered_texture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancel_not_hovered_texture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_bar_divider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_download)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_playbutton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_teamspeak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttons_tanoarpglogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox top_bar;
        private System.Windows.Forms.PictureBox cancel_not_hovered;
        private System.Windows.Forms.PictureBox cancel_hovered_texture;
        private System.Windows.Forms.PictureBox cancel_not_hovered_texture;
        private System.Windows.Forms.PictureBox top_bar_divider;
        private System.Windows.Forms.PictureBox buttons_download;
        private System.Windows.Forms.PictureBox buttons_playbutton;
        private System.Windows.Forms.ProgressBar bar_downloadprogress;
        private System.Windows.Forms.PictureBox buttons_settings;
        private System.Windows.Forms.Label text_a3running;
        private System.Windows.Forms.Label text_MissionsFile;
        private System.Windows.Forms.Label text_newestmissionfile;
        private System.Windows.Forms.Label text_dlspeed;
        private System.Windows.Forms.Label text_dltime;
        private System.Windows.Forms.PictureBox box_settings;
        private System.Windows.Forms.Label settings_text_A3Pfad;
        private System.Windows.Forms.TextBox settings_textbox_a3pfad;
        private System.Windows.Forms.Button settings_button_durchsuchen;
        private System.Windows.Forms.CheckBox settings_checkbox_nosplash;
        private System.Windows.Forms.Label settings_text_startparameter;
        private System.Windows.Forms.CheckBox settings_checkbox_nolog;
        private System.Windows.Forms.CheckBox settings_checkbox_skipintro;
        private System.Windows.Forms.CheckBox settings_checkbox_nopause;
        private System.Windows.Forms.CheckBox settings_checkbox_windowed;
        private System.Windows.Forms.CheckBox settings_checkbox_hyperthreading;
        private System.Windows.Forms.Label settings_text_profile;
        private System.Windows.Forms.ComboBox settings_combobox_profiles;
        private System.Windows.Forms.Label settings_text_ram;
        private System.Windows.Forms.ComboBox settings_combobox_ram;
        private System.Windows.Forms.Label settings_text_vram;
        private System.Windows.Forms.ComboBox settings_combobox_vram;
        private System.Windows.Forms.Label settings_text_cpucores;
        private System.Windows.Forms.ComboBox settings_combobox_cpucores;
        private System.Windows.Forms.Label settings_text_startparameters;
        private System.Windows.Forms.TextBox settings_textbox_startparameters;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button settings_button_save;
        private System.Windows.Forms.Label text_changelog;
        private System.Windows.Forms.PictureBox buttons_teamspeak;
        private System.Windows.Forms.PictureBox buttons_tanoarpglogo;
    }
}

