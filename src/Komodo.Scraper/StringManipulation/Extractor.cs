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
            while(expression.Contains("{X}")) //while there are still items to get
            {
                //get characters to mark start of string to extract
                //startmark = title=\"
                string startMark = expression.Remove(expression.IndexOf("{X}"));
                
                //remove to startmark
                value = value.Remove(0, value.IndexOf(startMark) + startMark.Length);
                //remove {X} from expression
                //expression = \" date\"{X}\"
                expression = expression.Remove(0,expression.IndexOf("{X}"));
                expression = expression.Remove(0, 3);
                //get charactes to mark end of string to extract
                string endMark;
                if (expression.Contains("{X}")) //three is another expression
                {
                    /*example
                     * expression = "({X}) title="
                     * endmark = "("
                     * 
                     * expression = ") title={X}"
                     * endmark = ") t"
                     */
                    endMark = expression.Remove(expression.IndexOf("{X}") > 3 ? 3 : expression.IndexOf("{X}"));
                }
                else
                {
                    /*example
                     * expression = ")"
                     * endmark = ")"
                     * 
                     * expression = ") title"
                     * endmark = ") t"
                     */
                    endMark = expression.Length < 3 ? expression : expression.Remove(3);
                }
                //expression = \" date\"{X}\"
                //value = Matrix\" date=\"2003\"
                //endmark = \" 
                var valueToUse = value.Remove(value.IndexOf(endMark));
                //valueToUse = Matrix
                values.Add(valueToUse);
                //expression = {X}\"
                //value = 2003\"
                if (expression.Contains("{X}"))
                {
                    value = value.Remove(0,value.IndexOf(endMark));
                    value = value.Remove(0, expression.IndexOf("{X}"));
                    expression = expression.Remove(0, expression.IndexOf("{X}"));
                }
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
