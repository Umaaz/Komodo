using System.Collections.Generic;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Util;

namespace Komodo.Core.Database.Index.Search
{
    public class Search
    {
        private static QueryParser GetQueryParser()
        {
            var fields = new string[Properties.Settings.Default.QueryFields.Count];
            Properties.Settings.Default.QueryFields.CopyTo(fields,0);
            return new MultiFieldQueryParser(Version.LUCENE_29, fields, new StandardAnalyzer(Version.LUCENE_29));
        }

        public static List<string> SearchFilm(string queryText)
        {
            var films = new List<string>();
            var searcher = new IndexSearcher(Indexer.GetDirectory(),true);
            var query = GetQueryParser().Parse(queryText);
            var collection = searcher.Search(query, 20);
            for (int i = 0; i < collection.TotalHits; i++)
            {
                var d = collection.ScoreDocs[i].doc;
                var doc = searcher.Doc(d);
                var dd = doc.Get("Id");
                films.Add(dd);
            }
            return films;
        }
    }
}
