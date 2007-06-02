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
using System.Drawing.Imaging;
using System.Xml;

namespace Snapshooter
{
   /// <summary>
   /// Class to store user preferences and retrieve them.
   /// This class might be better implemented as a serializable class.
   /// </summary>
   public class UserSettings
   {
      #region ReadOnly Settings
      public static readonly int VERSION_MAJOR = 1;
      public static readonly int VERSION_MINOR = 0;
      public static readonly int VERSION_PATCH = 1;
      #endregion

      #region Settings Private Members
      // Logging Settings
      private string m_SnapsDirectory = "C:\\Program Files\\Snapshooter\\snaps";
      private decimal m_SnapInterval = 1.0M;
      private ImageFormat m_ImageFormat = ImageFormat.Png;
      private string m_Prefix = "Snapshot_";
      private string m_Postfix = "";
      private bool m_AutostartSnapping = false;
      private bool m_ShowSettingsOnStartup = true;
      #endregion

      #region Settings Getters and Setters
      public string SnapDirectory
      {
         get { return m_SnapsDirectory; }
         set { m_SnapsDirectory = value; }
      }
      public decimal SnapInterval
      {
         get { return m_SnapInterval; }
         set { m_SnapInterval = value; }
      }
      public ImageFormat ImageFormat
      {
         get { return m_ImageFormat; }
         set { m_ImageFormat = value; }
      }
      public string Prefix
      {
         get { return m_Prefix; }
         set { m_Prefix = value; }
      }
      public string Postfix
      {
         get { return m_Postfix; }
         set { m_Postfix = value; }
      }
      public bool AutoStartSnapping
      {
         get { return m_AutostartSnapping; }
         set { m_AutostartSnapping = value; }
      }
      public bool ShowSettingsOnStartup
      {
         get { return m_ShowSettingsOnStartup; }
         set { m_ShowSettingsOnStartup = value; }
      }
      #endregion

      #region Load/Save Settings
      private const string TAG_TOPMOST = "SnapshooterSettings";
      private const string TAG_SNAPS_DIR = "SnapDir";
      private const string TAG_SNAP_INTERVAL = "SnapInterval";
      private const string TAG_IMAGE_FORMAT = "ImageFormat";
      private const string TAG_PREFIX = "Prefix";
      private const string TAG_POSTFIX = "Postfix";
      private const string TAG_AUTOSTART_SNAPS = "AutostartSnaps";
      private const string TAG_SHOW_SETTINGS = "ShowSettings";
      private const string DEFAULT_SETTINGS_FILE = "snapshooter_settings.xml";
      private static bool ms_LoadSuccessful = false;
      public bool Load()
      {
         try
         {
            XmlTextReader xmlReader = new XmlTextReader(DEFAULT_SETTINGS_FILE);
            xmlReader.MoveToContent();			// skip to the first element
            if (xmlReader.Name != TAG_TOPMOST) return false;
            while (xmlReader.Read())
            {
               string name = xmlReader.Name;
               switch (xmlReader.NodeType)
               {
                  case XmlNodeType.Element:
                     if (name == TAG_SNAPS_DIR) m_SnapsDirectory = xmlReader.ReadString();
                     else if (name == TAG_SNAP_INTERVAL) m_SnapInterval = Convert.ToDecimal(xmlReader.ReadString());
                     else if (name == TAG_IMAGE_FORMAT)
                     {
                        string format = xmlReader.ReadString();
                        if (format.ToLower() == "jpg") m_ImageFormat = ImageFormat.Jpeg;
                        else if (format.ToLower() == "png") m_ImageFormat = ImageFormat.Png;
                        else if (format.ToLower() == "bmp") m_ImageFormat = ImageFormat.Bmp;
                        else if (format.ToLower() == "gif") m_ImageFormat = ImageFormat.Gif;
                     }
                     else if (name == TAG_PREFIX) m_Prefix = xmlReader.ReadString();
                     else if (name == TAG_POSTFIX) m_Postfix = xmlReader.ReadString();
                     else if (name == TAG_AUTOSTART_SNAPS) m_AutostartSnapping = Convert.ToBoolean(xmlReader.ReadString());
                     else if (name == TAG_SHOW_SETTINGS) m_ShowSettingsOnStartup = Convert.ToBoolean(xmlReader.ReadString());
                     break;
                  case XmlNodeType.EndElement:
                     // nothing we care about yet
                     break;
                  case XmlNodeType.Text:
                     // nothing we care about yet
                     break;
               }
            }
            xmlReader.Close();
         }
         catch (XmlException e)
         {
            Console.WriteLine("Error parsing snapshooter settings: " + e.Message);
            return false;
         }
         catch (System.IO.FileNotFoundException e)
         {
            Console.WriteLine("No snapshooter settings loaded: " + e.Message);
            return false;
         }
         return true;
      }
      public bool Save()
      {
         try
         {
            XmlTextWriter xmlWriter = new XmlTextWriter(DEFAULT_SETTINGS_FILE, null);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.Indentation = 3;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement(TAG_TOPMOST);
            //
            xmlWriter.WriteStartElement(TAG_SNAPS_DIR);
            xmlWriter.WriteString(m_SnapsDirectory);
            xmlWriter.WriteEndElement();
            //
            xmlWriter.WriteStartElement(TAG_SNAP_INTERVAL);
            xmlWriter.WriteString(String.Format("{0}", m_SnapInterval));
            xmlWriter.WriteEndElement();
            //
            xmlWriter.WriteStartElement(TAG_IMAGE_FORMAT);
            if (m_ImageFormat == ImageFormat.Jpeg) xmlWriter.WriteString("jpg");
            else if (m_ImageFormat == ImageFormat.Png) xmlWriter.WriteString("png");
            else if (m_ImageFormat == ImageFormat.Bmp) xmlWriter.WriteString("bmp");
            else if (m_ImageFormat == ImageFormat.Gif) xmlWriter.WriteString("gif");
            xmlWriter.WriteEndElement();
            //
            xmlWriter.WriteStartElement(TAG_PREFIX);
            xmlWriter.WriteString(m_Prefix);
            xmlWriter.WriteEndElement();
            //
            xmlWriter.WriteStartElement(TAG_POSTFIX);
            xmlWriter.WriteString(m_Postfix);
            xmlWriter.WriteEndElement();
            //
            xmlWriter.WriteStartElement(TAG_AUTOSTART_SNAPS);
            xmlWriter.WriteString(m_AutostartSnapping.ToString());
            xmlWriter.WriteEndElement();
            //
            xmlWriter.WriteStartElement(TAG_SHOW_SETTINGS);
            xmlWriter.WriteString(m_ShowSettingsOnStartup.ToString());
            xmlWriter.WriteEndElement();
            //
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         catch (XmlException e)
         {
            Console.WriteLine("Error parsing XML: " + e.Message);
            return false;
         }
         return true;
      }
      public static bool UsingDefaults()
      {
         return ms_LoadSuccessful;
      }
      #endregion

      #region Singleton Pattern Members and Methods
      private static UserSettings ms_Settings = null;
      private UserSettings() { }
      /// <summary>
      /// This creates the settings object, or returns the already
      /// created instance.  It also keeps track of how many objects
      /// have created a reference to the settings object.
      /// </summary>
      public static UserSettings Settings
      {
         get
         {
            if (ms_Settings == null)
            {
               ms_Settings = new UserSettings();
            }
            return ms_Settings;
         }
      }
      #endregion
   }
}
