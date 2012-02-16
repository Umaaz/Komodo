using System;
using System.Collections.Generic;

namespace Komodo.Scraper.StringManipulation
{
    public static class Extractor
    {
        //expression = title=\"{X}\" date=\"{X}\"
        //value = title=Matrix date="2003"
        //return {Matrix, 2003}
        public static string[] Extract(string expression, string value)
        {
            if (string.IsNullOrEmpty(expression) || string.IsNullOrWhiteSpace(expression))
                throw new ArgumentNullException("expression");
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("value");
            if (!expression.Contains("{X}"))
                throw new ArgumentException("expression");
            var values = new List<string>();
            while(expression.Contains("{X}"))
            {
                var start = expression.IndexOf("{X}");
                var endChar = expression[start + 3];
                expression = expression.Remove(0, start);
                value = value.Remove(0, start);
                values.Add(value.Remove(value.IndexOf(endChar)));
                value = value.Remove(0,value.IndexOf(endChar)).Trim();
                expression = expression.Remove(0, expression.IndexOf(endChar));
            }
            return values.ToArray();
        }
    }
}
