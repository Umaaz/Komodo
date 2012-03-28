using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Komodo.App.Contorllers
{
    public class SettingsController
    {
        public static string[] GetFileExtensionsAsArray()
        {
            var ext = GetFileExtensions();
            var extArry = new string[ext.Count];
            ext.CopyTo(extArry,0);
            return extArry;
        }

        public static StringCollection GetFileExtensions()
        {
            return Properties.Settings.Default.Extensions ??
                   (Properties.Settings.Default.Extensions = new StringCollection());
        }

        public static bool AddFileExtension(string extension)
        {
            if (string.IsNullOrEmpty(extension) || string.IsNullOrWhiteSpace(extension))
                throw new ArgumentNullException("extension");
            if (!Regex.IsMatch(extension, @"\*\.[\w]*$", RegexOptions.IgnoreCase))
                return false;
            if (GetFileExtensions().Contains(extension))
                return false;
            Properties.Settings.Default.Extensions.Add(extension);
            Properties.Settings.Default.Save();
            return true;
        }

        public static bool RemoveFileExtension(string extension)
        {
            if (string.IsNullOrEmpty(extension) || string.IsNullOrWhiteSpace(extension))
                throw new ArgumentNullException("extension");
            if (!Regex.IsMatch(extension, @"\*\.[\w]*$", RegexOptions.IgnoreCase))
                return false;
            if(!GetFileExtensions().Contains(extension))
                return false;
            GetFileExtensions().Remove(extension);
            Properties.Settings.Default.Save();
            return true;
        }

        public static string[] GetWatchedFoldersAsArray()
        {
            var ext = GetWatchedFolders();
            var extArry = new string[ext.Count];
            ext.CopyTo(extArry, 0);
            return extArry;
        }

        public static StringCollection GetWatchedFolders()
        {
            return Properties.Settings.Default.WatchedFolders ??
                   (Properties.Settings.Default.WatchedFolders = new StringCollection());
        }

        public static bool AddWatchedFolders(string folder)
        {
            if (string.IsNullOrEmpty(folder) || string.IsNullOrWhiteSpace(folder))
                throw new ArgumentNullException("folder");
            if (GetWatchedFolders().Contains(folder))
                return false;
            GetWatchedFolders().Add(folder);
            Properties.Settings.Default.Save();
            return true;
        }

        public static bool RemoveWatchedFolders(string folder)
        {
            if (string.IsNullOrEmpty(folder) || string.IsNullOrWhiteSpace(folder))
                throw new ArgumentNullException("folder");
            if (!GetWatchedFolders().Contains(folder))
                return false;
            GetWatchedFolders().Remove(folder);
            Properties.Settings.Default.Save();
            return true;
        }

        public static bool GetDetialsShowen()
        {
            return Properties.Settings.Default.DetailsShow;
        }

        public static void ToggleDetailsShowen()
        {
            Properties.Settings.Default.DetailsShow = !Properties.Settings.Default.DetailsShow;
            Properties.Settings.Default.Save();
        }
    }
}