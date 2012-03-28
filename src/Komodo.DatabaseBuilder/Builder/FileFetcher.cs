using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Komodo.App.Contorllers;

namespace Komodo.App.Builder
{
    public static class FileFetcher
    {
        public static List<string> GetFoldersWithVideoFiles(string path)
        {
            var ext = SettingsController.GetFileExtensionsAsArray();
            var files = new List<string>();
            var foldersToReturn = new List<string>();
            var folders = Directory.GetDirectories(path).ToList();
            foreach (var folder in folders)
            {
                var folder1 = folder;
                files = ext.Aggregate(files,(current, s) =>current.Union(Directory.GetFiles(folder1, s, SearchOption.TopDirectoryOnly)).ToList());
                if(files.Count > 0)
                    foldersToReturn.Add(folder);
            }
            return foldersToReturn.OrderBy(x => x).ToList();
        }
        
        public static List<string> GetVideoFiles(string path)
        {
            var ext = SettingsController.GetFileExtensionsAsArray();
            var files = new List<string>();
            return ext
                    .Aggregate(files, (current, s) => current.Union(Directory.GetFiles(path, s, SearchOption.TopDirectoryOnly)).ToList())
                    .Where(x => !Regex.IsMatch(x, @"\\extra(s)", RegexOptions.IgnoreCase))
                    .OrderBy(x => x)
                    .ToList();
        }
    }
}
