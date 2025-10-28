using System;
using System.IO;
using System.Collections.Generic;

namespace MiniGrep
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new SearchOptions();


            if (args.Length == 0)
            {
                Console.WriteLine("Usage: minigrep [options] <pattern> <file(s)/folder>");
                Console.WriteLine("Options:");
                Console.WriteLine("  -r   Search recursively");
                Console.WriteLine("  -i   Ignore case");
                Console.WriteLine("  -n   Show line numbers");
                Console.WriteLine("  -c   Count only");
                return;
            }


            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];

                if (arg == "-r")
                    options.Recursive = true;
                else if (arg == "-i")
                    options.IgnoreCase = true;
                else if (arg == "-n")
                    options.ShowLineNumbers = true;
                else if (arg == "-c")
                    options.CountOnly = true;
                else if (options.Pattern == "")
                    options.Pattern = arg;
                else
                    options.Paths.Add(arg);
            }


            Console.WriteLine("Search Options:");
            Console.WriteLine($"  Pattern: {options.Pattern}");
            Console.WriteLine($"  Paths: {string.Join(", ", options.Paths)}");
            Console.WriteLine($"  Recursive: {options.Recursive}");
            Console.WriteLine($"  IgnoreCase: {options.IgnoreCase}");
            Console.WriteLine($"  ShowLineNumbers: {options.ShowLineNumbers}");
            Console.WriteLine($"  CountOnly: {options.CountOnly}");
            Console.WriteLine();


            var matcher = new LineMatcher(options.Pattern, options.IgnoreCase);


            var files = FileSearcher.GetFiles(options);


            foreach (var file in files)
            {
                int matchCount = 0;
                int lineNum = 0;


                foreach (var line in File.ReadLines(file))
                {
                    lineNum++;
                    if (matcher.IsMatch(line))
                    {
                        matchCount++;

                        if (!options.CountOnly)
                        {
                            OutputFormatter.PrintMatch(file, lineNum, line, options.ShowLineNumbers, options.Pattern, options.IgnoreCase);

                        }
                    }
                }


                if (options.CountOnly)
                {
                    Console.WriteLine($"{file}: {matchCount}");
                }
            }
        }
    }
}
