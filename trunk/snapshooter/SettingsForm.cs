/******************************************************************************
Snapshooter -  A screen capturing utility
Copyright (C) 2006 Jason Dudash

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
******************************************************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.IO;

namespace Snapshooter
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class SettingsForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox m_GeneralGroupBox;
      private System.Windows.Forms.NumericUpDown m_CaptureIntervalUpDown;
      private System.Windows.Forms.Label m_CaptureIntervalLabel;
      private System.Windows.Forms.TextBox m_SnapsDirectoryTextBox;
      private System.Windows.Forms.Label m_SnapsDirectoryLabel;
      private System.Windows.Forms.Button m_BrowseSnapsDirButton;
      private System.Windows.Forms.Label m_PostfixLabel;
      private System.Windows.Forms.TextBox m_PostfixTextBox;
      private System.Windows.Forms.Label m_PrefixLabel;
      private System.Windows.Forms.TextBox m_PrefixTextBox;
      private System.Windows.Forms.Button m_CancelButton;
      private System.Windows.Forms.Button m_OKButton;
      private System.Windows.Forms.GroupBox m_NamingGroupBox;
      private System.Windows.Forms.GroupBox m_ImageGroupBox;
      private System.Windows.Forms.RadioButton m_ImagePngRadioButton;
      private System.Windows.Forms.RadioButton m_ImageBmpRadioButton;
      private System.Windows.Forms.FolderBrowserDialog m_SnapsFolderBrowserDialog;
      private System.Windows.Forms.NotifyIcon m_NotifyIcon;
      private System.Windows.Forms.ContextMenu m_NotifyIconContextMenu;
      private System.Windows.Forms.MenuItem m_ExitMenuItem;
      private System.Windows.Forms.MenuItem m_SettingsMenuItem;
      private System.Windows.Forms.Timer m_SnapTimer;
      private System.Windows.Forms.Timer m_UpdateTimer;
      private System.ComponentModel.IContainer components;
      private System.Windows.Forms.Button m_StartButton;
      private System.Windows.Forms.Button m_SnapNowButton;
      private System.Windows.Forms.RadioButton m_ImageJpgRadioButton;
      private System.Windows.Forms.MenuItem m_HBarMenuItem;
      private System.Windows.Forms.RadioButton m_ImageGifRadioButton;
      private System.Windows.Forms.MenuItem m_AboutMenuItem;
      private System.Windows.Forms.MenuItem m_SnapNowMenuItem;
      private System.Windows.Forms.MenuItem m_30MinutesMenuItem;
      private System.Windows.Forms.MenuItem m_OnceAnHourMenuItem;
      private System.Windows.Forms.MenuItem m_OnceADayMenuItem;
      private System.Windows.Forms.MenuItem m_EveryWeekMenuItem;
      private System.Windows.Forms.MenuItem m_HBarMenuItem2;
      private System.Windows.Forms.MenuItem m_SnapTimeMenuItem;
      private System.Windows.Forms.MenuItem m_StartMenuItem;
      private MenuItem m_SaveTheScreenMenuItem;
      private MenuItem menuItem1;
      private CheckBox m_AutoStartSnapping;
      private CheckBox m_ShowSettingsOnStartup;

      // time of last snapshot
      private DateTime m_LastSnapTime;
      // The object we use to capture the screen
      ScreenCapture m_ScreenCapturer = new ScreenCapture();

      public SettingsForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         m_NotifyIcon.Text = "Snapshooter\nNext snap: Not Running";
         LoadUserSettings();
         if (m_AutoStartSnapping.Checked) StartSnapshots();
         if (m_ShowSettingsOnStartup.Checked) ShowDialog();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
         this.m_GeneralGroupBox = new System.Windows.Forms.GroupBox();
         this.m_AutoStartSnapping = new System.Windows.Forms.CheckBox();
         this.m_ShowSettingsOnStartup = new System.Windows.Forms.CheckBox();
         this.m_BrowseSnapsDirButton = new System.Windows.Forms.Button();
         this.m_SnapsDirectoryLabel = new System.Windows.Forms.Label();
         this.m_SnapsDirectoryTextBox = new System.Windows.Forms.TextBox();
         this.m_CaptureIntervalLabel = new System.Windows.Forms.Label();
         this.m_CaptureIntervalUpDown = new System.Windows.Forms.NumericUpDown();
         this.m_CancelButton = new System.Windows.Forms.Button();
         this.m_OKButton = new System.Windows.Forms.Button();
         this.m_NamingGroupBox = new System.Windows.Forms.GroupBox();
         this.m_PostfixLabel = new System.Windows.Forms.Label();
         this.m_PostfixTextBox = new System.Windows.Forms.TextBox();
         this.m_PrefixLabel = new System.Windows.Forms.Label();
         this.m_PrefixTextBox = new System.Windows.Forms.TextBox();
         this.m_ImageGroupBox = new System.Windows.Forms.GroupBox();
         this.m_ImageGifRadioButton = new System.Windows.Forms.RadioButton();
         this.m_ImageJpgRadioButton = new System.Windows.Forms.RadioButton();
         this.m_ImageBmpRadioButton = new System.Windows.Forms.RadioButton();
         this.m_ImagePngRadioButton = new System.Windows.Forms.RadioButton();
         this.m_SnapsFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
         this.m_NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
         this.m_NotifyIconContextMenu = new System.Windows.Forms.ContextMenu();
         this.m_AboutMenuItem = new System.Windows.Forms.MenuItem();
         this.m_HBarMenuItem = new System.Windows.Forms.MenuItem();
         this.m_SnapTimeMenuItem = new System.Windows.Forms.MenuItem();
         this.m_30MinutesMenuItem = new System.Windows.Forms.MenuItem();
         this.m_OnceAnHourMenuItem = new System.Windows.Forms.MenuItem();
         this.m_OnceADayMenuItem = new System.Windows.Forms.MenuItem();
         this.m_EveryWeekMenuItem = new System.Windows.Forms.MenuItem();
         this.m_SettingsMenuItem = new System.Windows.Forms.MenuItem();
         this.m_HBarMenuItem2 = new System.Windows.Forms.MenuItem();
         this.m_StartMenuItem = new System.Windows.Forms.MenuItem();
         this.m_SnapNowMenuItem = new System.Windows.Forms.MenuItem();
         this.m_SaveTheScreenMenuItem = new System.Windows.Forms.MenuItem();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.m_ExitMenuItem = new System.Windows.Forms.MenuItem();
         this.m_SnapTimer = new System.Windows.Forms.Timer(this.components);
         this.m_UpdateTimer = new System.Windows.Forms.Timer(this.components);
         this.m_StartButton = new System.Windows.Forms.Button();
         this.m_SnapNowButton = new System.Windows.Forms.Button();
         this.m_GeneralGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.m_CaptureIntervalUpDown)).BeginInit();
         this.m_NamingGroupBox.SuspendLayout();
         this.m_ImageGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // m_GeneralGroupBox
         // 
         this.m_GeneralGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.m_GeneralGroupBox.Controls.Add(this.m_AutoStartSnapping);
         this.m_GeneralGroupBox.Controls.Add(this.m_ShowSettingsOnStartup);
         this.m_GeneralGroupBox.Controls.Add(this.m_BrowseSnapsDirButton);
         this.m_GeneralGroupBox.Controls.Add(this.m_SnapsDirectoryLabel);
         this.m_GeneralGroupBox.Controls.Add(this.m_SnapsDirectoryTextBox);
         this.m_GeneralGroupBox.Controls.Add(this.m_CaptureIntervalLabel);
         this.m_GeneralGroupBox.Controls.Add(this.m_CaptureIntervalUpDown);
         this.m_GeneralGroupBox.Location = new System.Drawing.Point(8, 12);
         this.m_GeneralGroupBox.Name = "m_GeneralGroupBox";
         this.m_GeneralGroupBox.Size = new System.Drawing.Size(344, 130);
         this.m_GeneralGroupBox.TabIndex = 0;
         this.m_GeneralGroupBox.TabStop = false;
         this.m_GeneralGroupBox.Text = "General";
         // 
         // m_AutoStartSnapping
         // 
         this.m_AutoStartSnapping.AutoSize = true;
         this.m_AutoStartSnapping.Location = new System.Drawing.Point(19, 97);
         this.m_AutoStartSnapping.Name = "m_AutoStartSnapping";
         this.m_AutoStartSnapping.Size = new System.Drawing.Size(231, 17);
         this.m_AutoStartSnapping.TabIndex = 6;
         this.m_AutoStartSnapping.Text = "Autostart Snapping on Snapshooter Startup";
         this.m_AutoStartSnapping.UseVisualStyleBackColor = true;
         // 
         // m_ShowSettingsOnStartup
         // 
         this.m_ShowSettingsOnStartup.AutoSize = true;
         this.m_ShowSettingsOnStartup.Checked = true;
         this.m_ShowSettingsOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
         this.m_ShowSettingsOnStartup.Location = new System.Drawing.Point(19, 74);
         this.m_ShowSettingsOnStartup.Name = "m_ShowSettingsOnStartup";
         this.m_ShowSettingsOnStartup.Size = new System.Drawing.Size(188, 17);
         this.m_ShowSettingsOnStartup.TabIndex = 5;
         this.m_ShowSettingsOnStartup.Text = "Show Settings Window on Startup";
         this.m_ShowSettingsOnStartup.UseVisualStyleBackColor = true;
         // 
         // m_BrowseSnapsDirButton
         // 
         this.m_BrowseSnapsDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.m_BrowseSnapsDirButton.Location = new System.Drawing.Point(312, 24);
         this.m_BrowseSnapsDirButton.Name = "m_BrowseSnapsDirButton";
         this.m_BrowseSnapsDirButton.Size = new System.Drawing.Size(24, 23);
         this.m_BrowseSnapsDirButton.TabIndex = 4;
         this.m_BrowseSnapsDirButton.Text = ",,,";
         this.m_BrowseSnapsDirButton.Click += new System.EventHandler(this.m_BrowseSnapsDirButton_Click);
         // 
         // m_SnapsDirectoryLabel
         // 
         this.m_SnapsDirectoryLabel.Location = new System.Drawing.Point(16, 24);
         this.m_SnapsDirectoryLabel.Name = "m_SnapsDirectoryLabel";
         this.m_SnapsDirectoryLabel.Size = new System.Drawing.Size(128, 23);
         this.m_SnapsDirectoryLabel.TabIndex = 3;
         this.m_SnapsDirectoryLabel.Text = "Snapshots Directory:";
         // 
         // m_SnapsDirectoryTextBox
         // 
         this.m_SnapsDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.m_SnapsDirectoryTextBox.Location = new System.Drawing.Point(144, 24);
         this.m_SnapsDirectoryTextBox.Name = "m_SnapsDirectoryTextBox";
         this.m_SnapsDirectoryTextBox.Size = new System.Drawing.Size(160, 20);
         this.m_SnapsDirectoryTextBox.TabIndex = 2;
         this.m_SnapsDirectoryTextBox.Text = "C:\\ProgramFiles\\Snapshooter\\snaps";
         // 
         // m_CaptureIntervalLabel
         // 
         this.m_CaptureIntervalLabel.Location = new System.Drawing.Point(16, 48);
         this.m_CaptureIntervalLabel.Name = "m_CaptureIntervalLabel";
         this.m_CaptureIntervalLabel.Size = new System.Drawing.Size(128, 23);
         this.m_CaptureIntervalLabel.TabIndex = 1;
         this.m_CaptureIntervalLabel.Text = "Capture Interval (hours):";
         // 
         // m_CaptureIntervalUpDown
         // 
         this.m_CaptureIntervalUpDown.DecimalPlaces = 2;
         this.m_CaptureIntervalUpDown.Location = new System.Drawing.Point(144, 48);
         this.m_CaptureIntervalUpDown.Maximum = new decimal(new int[] {
            168,
            0,
            0,
            0});
         this.m_CaptureIntervalUpDown.Name = "m_CaptureIntervalUpDown";
         this.m_CaptureIntervalUpDown.Size = new System.Drawing.Size(56, 20);
         this.m_CaptureIntervalUpDown.TabIndex = 0;
         this.m_CaptureIntervalUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
         // 
         // m_CancelButton
         // 
         this.m_CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.m_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.m_CancelButton.Location = new System.Drawing.Point(272, 264);
         this.m_CancelButton.Name = "m_CancelButton";
         this.m_CancelButton.Size = new System.Drawing.Size(75, 23);
         this.m_CancelButton.TabIndex = 2;
         this.m_CancelButton.Text = "&Cancel";
         this.m_CancelButton.Click += new System.EventHandler(this.m_CancelButton_Click);
         // 
         // m_OKButton
         // 
         this.m_OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.m_OKButton.Location = new System.Drawing.Point(184, 264);
         this.m_OKButton.Name = "m_OKButton";
         this.m_OKButton.Size = new System.Drawing.Size(75, 23);
         this.m_OKButton.TabIndex = 3;
         this.m_OKButton.Text = "&OK";
         this.m_OKButton.Click += new System.EventHandler(this.m_OKButton_Click);
         // 
         // m_NamingGroupBox
         // 
         this.m_NamingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.m_NamingGroupBox.Controls.Add(this.m_PostfixLabel);
         this.m_NamingGroupBox.Controls.Add(this.m_PostfixTextBox);
         this.m_NamingGroupBox.Controls.Add(this.m_PrefixLabel);
         this.m_NamingGroupBox.Controls.Add(this.m_PrefixTextBox);
         this.m_NamingGroupBox.Location = new System.Drawing.Point(160, 158);
         this.m_NamingGroupBox.Name = "m_NamingGroupBox";
         this.m_NamingGroupBox.Size = new System.Drawing.Size(192, 88);
         this.m_NamingGroupBox.TabIndex = 2;
         this.m_NamingGroupBox.TabStop = false;
         this.m_NamingGroupBox.Text = "Naming";
         // 
         // m_PostfixLabel
         // 
         this.m_PostfixLabel.Location = new System.Drawing.Point(16, 56);
         this.m_PostfixLabel.Name = "m_PostfixLabel";
         this.m_PostfixLabel.Size = new System.Drawing.Size(48, 23);
         this.m_PostfixLabel.TabIndex = 12;
         this.m_PostfixLabel.Text = "Postfix:";
         // 
         // m_PostfixTextBox
         // 
         this.m_PostfixTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.m_PostfixTextBox.Location = new System.Drawing.Point(64, 56);
         this.m_PostfixTextBox.Name = "m_PostfixTextBox";
         this.m_PostfixTextBox.Size = new System.Drawing.Size(112, 20);
         this.m_PostfixTextBox.TabIndex = 11;
         // 
         // m_PrefixLabel
         // 
         this.m_PrefixLabel.Location = new System.Drawing.Point(16, 24);
         this.m_PrefixLabel.Name = "m_PrefixLabel";
         this.m_PrefixLabel.Size = new System.Drawing.Size(48, 23);
         this.m_PrefixLabel.TabIndex = 10;
         this.m_PrefixLabel.Text = "Prefix:";
         // 
         // m_PrefixTextBox
         // 
         this.m_PrefixTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.m_PrefixTextBox.Location = new System.Drawing.Point(64, 24);
         this.m_PrefixTextBox.Name = "m_PrefixTextBox";
         this.m_PrefixTextBox.Size = new System.Drawing.Size(112, 20);
         this.m_PrefixTextBox.TabIndex = 9;
         this.m_PrefixTextBox.Text = "Snapshot_";
         // 
         // m_ImageGroupBox
         // 
         this.m_ImageGroupBox.Controls.Add(this.m_ImageGifRadioButton);
         this.m_ImageGroupBox.Controls.Add(this.m_ImageJpgRadioButton);
         this.m_ImageGroupBox.Controls.Add(this.m_ImageBmpRadioButton);
         this.m_ImageGroupBox.Controls.Add(this.m_ImagePngRadioButton);
         this.m_ImageGroupBox.Location = new System.Drawing.Point(8, 158);
         this.m_ImageGroupBox.Name = "m_ImageGroupBox";
         this.m_ImageGroupBox.Size = new System.Drawing.Size(136, 88);
         this.m_ImageGroupBox.TabIndex = 4;
         this.m_ImageGroupBox.TabStop = false;
         this.m_ImageGroupBox.Text = "Image Format";
         // 
         // m_ImageGifRadioButton
         // 
         this.m_ImageGifRadioButton.Location = new System.Drawing.Point(72, 48);
         this.m_ImageGifRadioButton.Name = "m_ImageGifRadioButton";
         this.m_ImageGifRadioButton.Size = new System.Drawing.Size(48, 24);
         this.m_ImageGifRadioButton.TabIndex = 3;
         this.m_ImageGifRadioButton.Text = "GIF";
         // 
         // m_ImageJpgRadioButton
         // 
         this.m_ImageJpgRadioButton.Location = new System.Drawing.Point(72, 24);
         this.m_ImageJpgRadioButton.Name = "m_ImageJpgRadioButton";
         this.m_ImageJpgRadioButton.Size = new System.Drawing.Size(48, 24);
         this.m_ImageJpgRadioButton.TabIndex = 2;
         this.m_ImageJpgRadioButton.Text = "JPG";
         // 
         // m_ImageBmpRadioButton
         // 
         this.m_ImageBmpRadioButton.Location = new System.Drawing.Point(16, 48);
         this.m_ImageBmpRadioButton.Name = "m_ImageBmpRadioButton";
         this.m_ImageBmpRadioButton.Size = new System.Drawing.Size(48, 24);
         this.m_ImageBmpRadioButton.TabIndex = 1;
         this.m_ImageBmpRadioButton.Text = "BMP";
         // 
         // m_ImagePngRadioButton
         // 
         this.m_ImagePngRadioButton.Checked = true;
         this.m_ImagePngRadioButton.Location = new System.Drawing.Point(16, 24);
         this.m_ImagePngRadioButton.Name = "m_ImagePngRadioButton";
         this.m_ImagePngRadioButton.Size = new System.Drawing.Size(48, 24);
         this.m_ImagePngRadioButton.TabIndex = 0;
         this.m_ImagePngRadioButton.TabStop = true;
         this.m_ImagePngRadioButton.Text = "PNG";
         // 
         // m_SnapsFolderBrowserDialog
         // 
         this.m_SnapsFolderBrowserDialog.Description = "Please select a folder for storing snapshots.";
         // 
         // m_NotifyIcon
         // 
         this.m_NotifyIcon.ContextMenu = this.m_NotifyIconContextMenu;
         this.m_NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_NotifyIcon.Icon")));
         this.m_NotifyIcon.Text = "Snapshooter";
         this.m_NotifyIcon.Visible = true;
         this.m_NotifyIcon.DoubleClick += new System.EventHandler(this.m_NotifyIcon_DoubleClick);
         // 
         // m_NotifyIconContextMenu
         // 
         this.m_NotifyIconContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_AboutMenuItem,
            this.m_HBarMenuItem,
            this.m_SnapTimeMenuItem,
            this.m_SettingsMenuItem,
            this.m_HBarMenuItem2,
            this.m_StartMenuItem,
            this.m_SnapNowMenuItem,
            this.m_SaveTheScreenMenuItem,
            this.menuItem1,
            this.m_ExitMenuItem});
         // 
         // m_AboutMenuItem
         // 
         this.m_AboutMenuItem.Index = 0;
         this.m_AboutMenuItem.Text = "About...";
         this.m_AboutMenuItem.Click += new System.EventHandler(this.m_AboutMenuItem_Click);
         // 
         // m_HBarMenuItem
         // 
         this.m_HBarMenuItem.Index = 1;
         this.m_HBarMenuItem.Text = "-";
         // 
         // m_SnapTimeMenuItem
         // 
         this.m_SnapTimeMenuItem.Index = 2;
         this.m_SnapTimeMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_30MinutesMenuItem,
            this.m_OnceAnHourMenuItem,
            this.m_OnceADayMenuItem,
            this.m_EveryWeekMenuItem});
         this.m_SnapTimeMenuItem.Text = "Snap Time";
         // 
         // m_30MinutesMenuItem
         // 
         this.m_30MinutesMenuItem.Index = 0;
         this.m_30MinutesMenuItem.Text = "Every 30 Minutes";
         this.m_30MinutesMenuItem.Click += new System.EventHandler(this.m_30MinutesMenuItem_Click);
         // 
         // m_OnceAnHourMenuItem
         // 
         this.m_OnceAnHourMenuItem.Checked = true;
         this.m_OnceAnHourMenuItem.Index = 1;
         this.m_OnceAnHourMenuItem.Text = "Once an Hour";
         this.m_OnceAnHourMenuItem.Click += new System.EventHandler(this.m_OnceAnHourMenuItem_Click);
         // 
         // m_OnceADayMenuItem
         // 
         this.m_OnceADayMenuItem.Index = 2;
         this.m_OnceADayMenuItem.Text = "Once a Day";
         this.m_OnceADayMenuItem.Click += new System.EventHandler(this.m_OnceADayMenuItem_Click);
         // 
         // m_EveryWeekMenuItem
         // 
         this.m_EveryWeekMenuItem.Index = 3;
         this.m_EveryWeekMenuItem.Text = "Every Week";
         this.m_EveryWeekMenuItem.Click += new System.EventHandler(this.m_EveryWeekMenuItem_Click);
         // 
         // m_SettingsMenuItem
         // 
         this.m_SettingsMenuItem.Index = 3;
         this.m_SettingsMenuItem.Text = "Settings...";
         this.m_SettingsMenuItem.Click += new System.EventHandler(this.m_SettingsMenuItem_Click);
         // 
         // m_HBarMenuItem2
         // 
         this.m_HBarMenuItem2.Index = 4;
         this.m_HBarMenuItem2.Text = "-";
         // 
         // m_StartMenuItem
         // 
         this.m_StartMenuItem.Index = 5;
         this.m_StartMenuItem.Text = "Start";
         this.m_StartMenuItem.Click += new System.EventHandler(this.m_StartMenuItem_Click);
         // 
         // m_SnapNowMenuItem
         // 
         this.m_SnapNowMenuItem.Index = 6;
         this.m_SnapNowMenuItem.Text = "Snap Now!";
         this.m_SnapNowMenuItem.Click += new System.EventHandler(this.m_SnapNowMenuItem_Click);
         // 
         // m_SaveTheScreenMenuItem
         // 
         this.m_SaveTheScreenMenuItem.Index = 7;
         this.m_SaveTheScreenMenuItem.Text = "Save the Screen";
         this.m_SaveTheScreenMenuItem.Click += new System.EventHandler(this.m_SaveTheScreenMenuItem_Click);
         // 
         // menuItem1
         // 
         this.menuItem1.Index = 8;
         this.menuItem1.Text = "-";
         // 
         // m_ExitMenuItem
         // 
         this.m_ExitMenuItem.Index = 9;
         this.m_ExitMenuItem.Text = "Exit";
         this.m_ExitMenuItem.Click += new System.EventHandler(this.m_ExitMenuItem_Click);
         // 
         // m_SnapTimer
         // 
         this.m_SnapTimer.Interval = 3600000;
         this.m_SnapTimer.Tick += new System.EventHandler(this.m_SnapTimer_Tick);
         // 
         // m_UpdateTimer
         // 
         this.m_UpdateTimer.Interval = 1000;
         this.m_UpdateTimer.Tick += new System.EventHandler(this.m_UpdateTimer_Tick);
         // 
         // m_StartButton
         // 
         this.m_StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.m_StartButton.Location = new System.Drawing.Point(8, 264);
         this.m_StartButton.Name = "m_StartButton";
         this.m_StartButton.Size = new System.Drawing.Size(75, 23);
         this.m_StartButton.TabIndex = 5;
         this.m_StartButton.Text = "&Start";
         this.m_StartButton.Click += new System.EventHandler(this.m_StartButton_Click);
         // 
         // m_SnapNowButton
         // 
         this.m_SnapNowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.m_SnapNowButton.Location = new System.Drawing.Point(96, 264);
         this.m_SnapNowButton.Name = "m_SnapNowButton";
         this.m_SnapNowButton.Size = new System.Drawing.Size(75, 23);
         this.m_SnapNowButton.TabIndex = 6;
         this.m_SnapNowButton.Text = "Snap &Now!";
         this.m_SnapNowButton.Click += new System.EventHandler(this.m_SnapNowButton_Click);
         // 
         // SettingsForm
         // 
         this.AcceptButton = this.m_OKButton;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.m_CancelButton;
         this.ClientSize = new System.Drawing.Size(360, 302);
         this.Controls.Add(this.m_SnapNowButton);
         this.Controls.Add(this.m_StartButton);
         this.Controls.Add(this.m_ImageGroupBox);
         this.Controls.Add(this.m_OKButton);
         this.Controls.Add(this.m_CancelButton);
         this.Controls.Add(this.m_GeneralGroupBox);
         this.Controls.Add(this.m_NamingGroupBox);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(368, 296);
         this.Name = "SettingsForm";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.Text = "Snapshooter Settings";
         this.Resize += new System.EventHandler(this.SettingsForm_Resize);
         this.Load += new System.EventHandler(this.SettingsForm_Load);
         this.m_GeneralGroupBox.ResumeLayout(false);
         this.m_GeneralGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.m_CaptureIntervalUpDown)).EndInit();
         this.m_NamingGroupBox.ResumeLayout(false);
         this.m_NamingGroupBox.PerformLayout();
         this.m_ImageGroupBox.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         SettingsForm mainWindow = new SettingsForm();
         Application.Run();

      }

      private void m_CancelButton_Click(object sender, System.EventArgs e)
      {
         LoadUserSettings();  // reload the GUI with settings from the settings file
         Hide();
      }

      private void m_OKButton_Click(object sender, System.EventArgs e)
      {
         // set and save changes to user settings file
         UserSettings.Settings.SnapDirectory = m_SnapsDirectoryTextBox.Text;
         UserSettings.Settings.SnapInterval = m_CaptureIntervalUpDown.Value;
         ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
         if (m_ImagePngRadioButton.Checked == true) format = ImageFormat.Png;
         else if (m_ImageGifRadioButton.Checked == true) format = ImageFormat.Gif;
         else if (m_ImageBmpRadioButton.Checked == true) format = ImageFormat.Bmp;
         else if (m_ImageJpgRadioButton.Checked == true) format = ImageFormat.Jpeg;
         UserSettings.Settings.ImageFormat = format;
         UserSettings.Settings.Prefix = m_PrefixTextBox.Text;
         UserSettings.Settings.Postfix = m_PostfixTextBox.Text;
         UserSettings.Settings.AutoStartSnapping = m_AutoStartSnapping.Checked;
         UserSettings.Settings.ShowSettingsOnStartup = m_ShowSettingsOnStartup.Checked;
         UserSettings.Settings.Save();
         UpdateIntervalContextMenu();
         Hide();
      }

      private void SettingsForm_Resize(object sender, System.EventArgs e)
      {
         if (FormWindowState.Minimized == WindowState) Hide();
      }

      private void m_NotifyIcon_DoubleClick(object sender, System.EventArgs e)
      {
         Show();
         WindowState = FormWindowState.Normal;
      }

      private void m_SettingsMenuItem_Click(object sender, System.EventArgs e)
      {
         Show();
         WindowState = FormWindowState.Normal;
      }

      private void m_ExitMenuItem_Click(object sender, System.EventArgs e)
      {
         Close();
         Application.Exit();
      }

      private void m_BrowseSnapsDirButton_Click(object sender, System.EventArgs e)
      {
         if (m_SnapsFolderBrowserDialog.ShowDialog(this) != DialogResult.OK) return;
         m_SnapsDirectoryTextBox.Text = m_SnapsFolderBrowserDialog.SelectedPath;
      }

      private void m_UpdateTimer_Tick(object sender, System.EventArgs e)
      {
         TimeSpan passedTime = DateTime.Now - m_LastSnapTime;
         TimeSpan snapInterval = TimeSpan.FromMilliseconds(m_SnapTimer.Interval);
         TimeSpan timeRemaining = snapInterval - passedTime;
         string nextSnapString = "";
         if (timeRemaining.Days == 1) nextSnapString += timeRemaining.Days + " day, ";
         else if (timeRemaining.Days > 1) nextSnapString += timeRemaining.Days + " days, ";
         if (timeRemaining.Hours == 1) nextSnapString += timeRemaining.Hours + " hour, ";
         else if (timeRemaining.Hours > 1) nextSnapString += timeRemaining.Hours + " hours, ";
         if (timeRemaining.Minutes == 1) nextSnapString += timeRemaining.Minutes + " min, ";
         if (timeRemaining.Minutes > 1) nextSnapString += timeRemaining.Minutes + " min, ";
         nextSnapString += timeRemaining.Seconds + " sec";
         m_NotifyIcon.Text = "Snapshooter\nNext snap: " + nextSnapString;
      }

      private void SettingsForm_Load(object sender, System.EventArgs e)
      {
      }

      private void m_SnapTimer_Tick(object sender, System.EventArgs e)
      {
         m_LastSnapTime = DateTime.Now;
         TakeSnapshot();
      }

      private void m_StartButton_Click(object sender, System.EventArgs e)
      {
         if (m_StartButton.Text == "&Start") StartSnapshots();
         else StopSnapshots();
      }

      private void StartSnapshots()
      {
         if (!Directory.Exists(m_SnapsDirectoryTextBox.Text))
         {
            MessageBox.Show(this, "The snapshots directory is not valid, snapshooting will not start", "Snap Directory Invalid");
            return;
         }
         m_StartButton.Text = "&Stop";
         m_StartMenuItem.Text = "Stop";
         int interval = Convert.ToInt32(Convert.ToDouble(m_CaptureIntervalUpDown.Value) * 3600000.0);  // convert hours to milliseconds;
         if (interval < 1000) interval = 1000; // 1 second is min snap time
         m_SnapTimer.Interval = interval;
         m_UpdateTimer.Start();
         m_SnapTimer.Start();
         m_LastSnapTime = DateTime.Now;
      }

      private void StopSnapshots()
      {
         m_StartButton.Text = "&Start";
         m_StartMenuItem.Text = "Start";
         m_UpdateTimer.Stop();
         m_SnapTimer.Stop();
         m_NotifyIcon.Text = "Snapshooter\nNext snap: Not Running";
      }

      private void m_AboutMenuItem_Click(object sender, System.EventArgs e)
      {
         AboutForm af = new AboutForm();
         af.SetVersion(UserSettings.VERSION_MAJOR, UserSettings.VERSION_MINOR, UserSettings.VERSION_PATCH);
         af.ShowDialog();
      }

      private void m_30MinutesMenuItem_Click(object sender, System.EventArgs e)
      {
         StopSnapshots();
         m_CaptureIntervalUpDown.Value = 0.5M;
         UpdateIntervalContextMenu();
         StartSnapshots();
      }

      private void m_OnceAnHourMenuItem_Click(object sender, System.EventArgs e)
      {
         StopSnapshots();
         m_CaptureIntervalUpDown.Value = 1;
         UpdateIntervalContextMenu();
         StartSnapshots();
      }

      private void m_OnceADayMenuItem_Click(object sender, System.EventArgs e)
      {
         StopSnapshots();
         m_CaptureIntervalUpDown.Value = 24;
         UpdateIntervalContextMenu();
         StartSnapshots();
      }

      private void m_EveryWeekMenuItem_Click(object sender, System.EventArgs e)
      {
         StopSnapshots();
         m_CaptureIntervalUpDown.Value = 168;
         UpdateIntervalContextMenu();
         StartSnapshots();
      }

      private void UpdateIntervalContextMenu()
      {
         // clear all
         m_30MinutesMenuItem.Checked = false;
         m_OnceAnHourMenuItem.Checked = false;
         m_OnceADayMenuItem.Checked = false;
         m_EveryWeekMenuItem.Checked = false;

         // set the checks if needed
         if (m_CaptureIntervalUpDown.Value == 0.5M)
         {
            m_30MinutesMenuItem.Checked = true;
         }
         else if (m_CaptureIntervalUpDown.Value == 1)
         {
            m_OnceAnHourMenuItem.Checked = true;
         }
         else if (m_CaptureIntervalUpDown.Value == 24)
         {
            m_OnceADayMenuItem.Checked = true;
         }
         else if (m_CaptureIntervalUpDown.Value == 168)
         {
            m_EveryWeekMenuItem.Checked = true;
         }
      }

      private void m_StartMenuItem_Click(object sender, System.EventArgs e)
      {
         if (m_StartButton.Text == "&Start") StartSnapshots();
         else StopSnapshots();
      }

      private void LoadUserSettings()
      {
         // load settings from user file
         UserSettings.Settings.Load();
         m_SnapsDirectoryTextBox.Text = UserSettings.Settings.SnapDirectory;
         m_CaptureIntervalUpDown.Value = UserSettings.Settings.SnapInterval;
         m_ImagePngRadioButton.Checked = false;
         m_ImageGifRadioButton.Checked = false;
         m_ImageBmpRadioButton.Checked = false;
         m_ImageJpgRadioButton.Checked = false;
         if (UserSettings.Settings.ImageFormat == ImageFormat.Jpeg)
         {
            m_ImageJpgRadioButton.Checked = true;
         }
         else if (UserSettings.Settings.ImageFormat == ImageFormat.Gif)
         {
            m_ImageGifRadioButton.Checked = true;
         }
         else if (UserSettings.Settings.ImageFormat == ImageFormat.Bmp)
         {
            m_ImageBmpRadioButton.Checked = true;
         }
         else
         {
            m_ImagePngRadioButton.Checked = true;
         }
         m_PrefixTextBox.Text = UserSettings.Settings.Prefix;
         m_PostfixTextBox.Text = UserSettings.Settings.Postfix;
         m_ShowSettingsOnStartup.Checked = UserSettings.Settings.ShowSettingsOnStartup;
         m_AutoStartSnapping.Checked = UserSettings.Settings.AutoStartSnapping;
      }

      private void m_SnapNowButton_Click(object sender, System.EventArgs e)
      {
         if (!Directory.Exists(m_SnapsDirectoryTextBox.Text))
         {
            MessageBox.Show(this, "The snapshots directory is not valid, cannot take snapshot", "Snap Directory Invalid");
            return;
         }
         Hide();
         System.Threading.Thread.Sleep(1000); // wait a second to hide snapshooter windowB
         TakeSnapshot();
      }

      private void TakeSnapshot()
      {
         DateTime snapTime = DateTime.Now;
         string baseFilename = snapTime.ToString("yyyy_MM_dd-HH_mm_ss");
         string fullFilename = m_SnapsDirectoryTextBox.Text + "\\" + m_PrefixTextBox.Text + baseFilename + m_PostfixTextBox.Text;
         ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
         if (m_ImagePngRadioButton.Checked == true)
         {
            format = ImageFormat.Png;
            fullFilename += ".png";
         }
         else if (m_ImageGifRadioButton.Checked == true)
         {
            format = ImageFormat.Gif;
            fullFilename += ".gif";
         }
         else if (m_ImageBmpRadioButton.Checked == true)
         {
            format = ImageFormat.Bmp;
            fullFilename += ".bmp";
         }
         else if (m_ImageJpgRadioButton.Checked == true)
         {
            format = ImageFormat.Jpeg;
            fullFilename += ".jpg";
         }
         m_ScreenCapturer.CaptureScreenToFile(fullFilename, format);
      }

      private void m_SnapNowMenuItem_Click(object sender, System.EventArgs e)
      {
         Hide();
         System.Threading.Thread.Sleep(1000); // wait a second to hide snapshooter window
         TakeSnapshot();
      }

      private void m_SaveTheScreenMenuItem_Click(object sender, EventArgs e)
      {
         StopSnapshots();
         // Multi monitor, create for every screen TODO , but make sure to close all if the mouse moves on any
         for (int i = Screen.AllScreens.GetLowerBound(0); i <= Screen.AllScreens.GetUpperBound(0); i++)
         {
            if (Screen.AllScreens[i].Primary == false) continue;
            ScreenSaverForm ssf = new ScreenSaverForm(i, m_SnapsDirectoryTextBox.Text);
            ssf.ShowDialog();
            break;
         }
      }
   }
}
