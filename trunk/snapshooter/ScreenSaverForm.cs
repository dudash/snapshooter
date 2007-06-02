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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Snapshooter
{
   public partial class ScreenSaverForm : Form
   {
      private int m_ScreenNumber = 0;
      private Point m_MouseXY;
      private string m_SnapsPath = "C:\\";

      public ScreenSaverForm(int screen, string snapsPath)
      {
         InitializeComponent();
         m_ScreenNumber = screen;
         m_SnapsPath = snapsPath;
      }

      private void ScreenSaverForm_Load(object sender, EventArgs e)
      {
         Bounds = Screen.AllScreens[m_ScreenNumber].Bounds;
         Cursor.Hide();
         TopMost = true;
         LoadRandomImage();
         m_ChangeScreenTimer.Start();
      }

      private void m_ChangeScreenTimer_Tick(object sender, EventArgs e)
      {
         LoadRandomImage();
      }

      private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
      {
         if (!m_MouseXY.IsEmpty)
         {
            if (m_MouseXY != new Point(e.X, e.Y))
            {
               Cursor.Show();
               m_ChangeScreenTimer.Stop();
               Close();
            }
         }
         m_MouseXY = new Point(e.X, e.Y);
      }

      private void LoadRandomImage()
      {
         if (!Directory.Exists(m_SnapsPath)) return;

         // get list of image files in the snapshot directory
         try
         {
            string[] fileList = Directory.GetFiles(m_SnapsPath);
            // TODO filter the list to images with supported extensions
            ArrayList filteredFileArrayList = new ArrayList();
            for (int i = fileList.GetLowerBound(0); i <= fileList.GetUpperBound(0); i++)
            {
               if (fileList[i].Contains(".bmp") || fileList[i].Contains(".jpg") || fileList[i].Contains(".gif") || fileList[i].Contains(".png"))
                  filteredFileArrayList.Add(fileList[i]);
            }
            // Load one of those images into m_PictureBox;
            string[] filteredFileList = filteredFileArrayList.ToArray(typeof(string)) as string[];
            Random randomObject = new Random();
            int randomIndex = randomObject.Next(filteredFileList.GetLowerBound(0), filteredFileList.GetUpperBound(0));
            string imagePath = filteredFileList[randomIndex];
            m_PictureBox.Load(imagePath);
         }
         catch (Exception e)
         {
            Console.WriteLine("Load screen saver image error: " + e.Message);
         }
      }

      private void ScreenSaverForm_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Clicks > 0)
         {
            Cursor.Show();
            m_ChangeScreenTimer.Stop();
            Close();
         }
      }
   }
}