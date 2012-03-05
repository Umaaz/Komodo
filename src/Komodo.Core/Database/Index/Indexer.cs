using System.IO;
using System.Windows.Forms;
using Komodo.Core.Types.Model;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Directory = Lucene.Net.Store.Directory;

namespace Komodo.Core.Database.Index
{
    public class Indexer
    {
        private static IndexWriter _writer;

        public static Directory GetDirectory()
        {
            var appPath = Path.GetDirectoryName(Application.ExecutablePath);
            return FSDirectory.Open(new DirectoryInfo(Properties.Settings.Default.IndexPath));
        }
        
        private static IndexWriter GetWriter()
        {
            return _writer ?? (_writer = new IndexWriter(GetDirectory(), new StandardAnalyzer(Version.LUCENE_29), IndexWriter.MaxFieldLength.LIMITED));
        }

        public static void Index (Film film)
        {
            var writer = GetWriter();
            writer.AddDocument(DocFactory.CreateFilmDocument(film));
            writer.Optimize();
            writer.Commit();
        }
    }
}
