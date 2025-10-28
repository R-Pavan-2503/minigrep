using System;
using System.Text.RegularExpressions;

namespace MiniGrep
{
    class OutputFormatter
    {
        public static void PrintMatch(string file, int lineNum, string line, bool showLineNum, string pattern, bool ignoreCase)
        {
            // 🧩 1. Print filename (yellow)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(file);

            // 🧩 2. Print line number (cyan if needed)
            if (showLineNum)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($":{lineNum}: ");
            }
            else
            {
                Console.Write(": ");
            }

            // 🧩 3. Reset color before printing the line
            Console.ResetColor();

            // 🧩 4. Highlight matches in the line
            var regexOptions = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            var regex = new Regex(Regex.Escape(pattern), regexOptions);

            int lastIndex = 0;
            foreach (Match match in regex.Matches(line))
            {
                // print the text before the match (normal)
                Console.Write(line.Substring(lastIndex, match.Index - lastIndex));

                // print the matched text (red)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(match.Value);
                Console.ResetColor();

                lastIndex = match.Index + match.Length;
            }

            // print remaining part after last match
            if (lastIndex < line.Length)
            {
                Console.Write(line.Substring(lastIndex));
            }

            Console.WriteLine();
        }
    }
}
