namespace Komodo.Scraper.StringManipulation
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this string source, string toCheck)
        {
            if (string.IsNullOrEmpty(source))
                return false;
            source = source.ToUpper().ToLower();
            return source.Contains(toCheck.ToUpper().ToLower());
        }

        public static bool Contains3ConsecutiveCharacters(this string source)
        {
            var str = source.ToUpper().ToLower();
            var rtn = false;
            for (var i = 0; i < (str.Length - 2); i++)
            {
                var c1 = str[i];
                var c2 = str[i+1];
                var c3 = str[i+2];
                if (c1 == c2 && c2 == c3)
                    rtn = true;
            }
            return rtn;
        }

        public static bool ContainsAllWords(this string source, string wordsString)
        {
            var rtn = true;
            wordsString = wordsString.Replace(":", " ").Replace("-", " ").Replace("'","");
            var words = wordsString.Split(' ');
            var source2 = source.Replace(":", " ").Replace("-", " ").Replace("'", "");
            foreach (var word in words)
            {
                if (word == " ")
                    continue;
                if(!source2.Trim().ContainsIgnoreCase(word.Trim()))
                    rtn = false;
            }
            return rtn;
        }
    }
}