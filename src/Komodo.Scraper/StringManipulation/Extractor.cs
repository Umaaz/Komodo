using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Komodo.Scraper.Net;

namespace Komodo.Scraper.StringManipulation
{
    public static class Extractor
    {
        //expression = title=\"{X}\" date=\"{X}\"
        //value = title="Matrix" date="2003"
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
            
            var s = expression.Remove(expression.IndexOf("{X}"));
            value = value.Remove(0, value.IndexOf(s));
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

        public static string[] ExtractAndDecode(string expression, string value)
        {
            if (string.IsNullOrEmpty(expression) || string.IsNullOrWhiteSpace(expression))
                throw new ArgumentNullException("expression");
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("value");
            if (!expression.Contains("{X}"))
                throw new ArgumentException("expression");
            var values = Extract(expression, value);
            for (var index = 0; index < values.Length; index++)
            {
                var s = values[index].Trim();
                s = s.Replace('\n', ' ');
                s = s.Replace("  ", " ");
                s = Regex.Replace(s, @"(\s)*\(", " (");
                values[index] = HtmlEscapeCharConverter.Decode(s);
            }
            return values;
        }

        public static string RemoveBetween(char delimiterStart, char delimiterEnd, string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("value");
            if (char.IsLetterOrDigit(delimiterStart))
                throw new ArgumentException("delimiterStart, can not be letter or digit");
            if (char.IsLetterOrDigit(delimiterEnd))
                throw new ArgumentException("delimiterEnd, can not be letter or digit");
            if (value.LastIndexOf(delimiterEnd) < value.IndexOf(delimiterStart))
                throw new ArgumentException("delimiterEnd must appear after delimiterStart in value");
            var regex = "\\" + delimiterStart + ".*\\" + delimiterEnd;
            var output = Regex.Replace(value, regex, "");
            while (output.Contains("  "))
                output = output.Replace("  ", " ");
            return output;
        }
    }
}
