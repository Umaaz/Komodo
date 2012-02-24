using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Komodo.DatabaseBuilder.Builder
{
    public static class FileFetcher
    {
        public static List<string> GetVideoFiles(string path)
        {
            var ext = new [] {"*.avi", "*.mkv"};
            var files = new List<string>();
            return ext.Aggregate(files, (current, s) => current.Union(Directory.GetFiles(path, s, SearchOption.AllDirectories)).ToList())
                .Where(x => !Regex.IsMatch(x, @"\\extra(s)?", RegexOptions.IgnoreCase))
                .Select(x => x.Remove(0, x.LastIndexOf("\\")+1))
                .Select(x => x.Remove(x.LastIndexOf('.')))
                .Select(x => Regex.Replace(x, "(-)?(\\s)?part(\\s)?[\\d]*((\\s)?of(\\s)?[\\d]*)?", "", RegexOptions.IgnoreCase))
                .Select(x => Regex.Replace(x, "(-)?(\\s)?cd(\\s)?[\\d]*((\\s)?of(\\s)?[\\d]*)?", "", RegexOptions.IgnoreCase))
                .Select(x => Regex.Replace(x, "(-)?(\\s)?dis(k|c)(\\s)?[\\d]*((\\s)?of(\\s)?[\\d]*)?", "", RegexOptions.IgnoreCase))
                .Select(x => x.Trim())
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }
    }
}
