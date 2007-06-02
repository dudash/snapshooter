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
namespace Snapshooter
{
    partial class ScreenSaverForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenSaverForm));
            this.m_ChangeScreenTimer = new System.Windows.Forms.Timer(this.components);
            this.m_PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ChangeScreenTimer
            // 
            this.m_ChangeScreenTimer.Interval = 60000;
            this.m_ChangeScreenTimer.Tick += new System.EventHandler(this.m_ChangeScreenTimer_Tick);
            // 
            // m_PictureBox
            // 
            this.m_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.m_PictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_PictureBox.BackgroundImage")));
            this.m_PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("m_PictureBox.ErrorImage")));
            this.m_PictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("m_PictureBox.InitialImage")));
            this.m_PictureBox.Location = new System.Drawing.Point(0, 0);
            this.m_PictureBox.Name = "m_PictureBox";
            this.m_PictureBox.Size = new System.Drawing.Size(720, 699);
            this.m_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_PictureBox.TabIndex = 0;
            this.m_PictureBox.TabStop = false;
            this.m_PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseDown);
            this.m_PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(720, 699);
            this.Controls.Add(this.m_PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenSaverForm";
            this.Text = "SnapShooter Screen Saver (The Quadruple S)";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseDown);
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer m_ChangeScreenTimer;
        private System.Windows.Forms.PictureBox m_PictureBox;
    }
}