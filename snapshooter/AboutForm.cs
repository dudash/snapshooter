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

namespace Snapshooter
{
   /// <summary>
   /// Summary description for AboutForm.
   /// </summary>
   public class AboutForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label m_SnapshooterLabel;
      private System.Windows.Forms.Label m_VersionLabel;
      private System.Windows.Forms.PictureBox m_PictureBox;
      private System.Windows.Forms.Label m_CopyrightLabel;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public AboutForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
         this.m_SnapshooterLabel = new System.Windows.Forms.Label();
         this.m_PictureBox = new System.Windows.Forms.PictureBox();
         this.m_VersionLabel = new System.Windows.Forms.Label();
         this.m_CopyrightLabel = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).BeginInit();
         this.SuspendLayout();
         // 
         // m_SnapshooterLabel
         // 
         this.m_SnapshooterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.m_SnapshooterLabel.Location = new System.Drawing.Point(152, 16);
         this.m_SnapshooterLabel.Name = "m_SnapshooterLabel";
         this.m_SnapshooterLabel.Size = new System.Drawing.Size(136, 24);
         this.m_SnapshooterLabel.TabIndex = 0;
         this.m_SnapshooterLabel.Text = "Snapshooter";
         // 
         // m_PictureBox
         // 
         this.m_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("m_PictureBox.Image")));
         this.m_PictureBox.Location = new System.Drawing.Point(8, 0);
         this.m_PictureBox.Name = "m_PictureBox";
         this.m_PictureBox.Size = new System.Drawing.Size(96, 96);
         this.m_PictureBox.TabIndex = 1;
         this.m_PictureBox.TabStop = false;
         this.m_PictureBox.DoubleClick += new System.EventHandler(this.m_PictureBox_DoubleClick);
         // 
         // m_VersionLabel
         // 
         this.m_VersionLabel.Location = new System.Drawing.Point(176, 48);
         this.m_VersionLabel.Name = "m_VersionLabel";
         this.m_VersionLabel.Size = new System.Drawing.Size(80, 16);
         this.m_VersionLabel.TabIndex = 2;
         this.m_VersionLabel.Text = "Version X.X.X";
         // 
         // m_CopyrightLabel
         // 
         this.m_CopyrightLabel.Location = new System.Drawing.Point(128, 72);
         this.m_CopyrightLabel.Name = "m_CopyrightLabel";
         this.m_CopyrightLabel.Size = new System.Drawing.Size(199, 23);
         this.m_CopyrightLabel.TabIndex = 3;
         this.m_CopyrightLabel.Text = "(C) 2006 Jason Dudash, GNU GPL 2.0";
         // 
         // AboutForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(362, 104);
         this.Controls.Add(this.m_CopyrightLabel);
         this.Controls.Add(this.m_VersionLabel);
         this.Controls.Add(this.m_PictureBox);
         this.Controls.Add(this.m_SnapshooterLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximumSize = new System.Drawing.Size(368, 128);
         this.MinimumSize = new System.Drawing.Size(368, 128);
         this.Name = "AboutForm";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "About Snapshooter";
         this.TopMost = true;
         this.DoubleClick += new System.EventHandler(this.AboutForm_DoubleClick);
         this.Load += new System.EventHandler(this.AboutForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

      private void AboutForm_Load(object sender, System.EventArgs e)
      {

      }

      private void AboutForm_DoubleClick(object sender, System.EventArgs e)
      {
         Close();
      }

      private void m_PictureBox_DoubleClick(object sender, System.EventArgs e)
      {
         Close();
      }

      public void SetVersion(int major, int minor, int patch)
      {
         m_VersionLabel.Text = String.Format("Version {0}.{1}.{2}", major, minor, patch);
      }
   }
}
