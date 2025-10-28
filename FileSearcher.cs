using System;
using System.Collections.Generic;
using System.IO;

namespace MiniGrep
{
    class FileSearcher
    {
        public static IEnumerable<string> GetFiles(SearchOptions options)
        {
            foreach (var path in options.Paths)
            {
                if (Directory.Exists(path))
                {
                    var searchOption = options.Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                    IEnumerable<string> fileEnum;
                    try
                    {
                        // Use "*" to match all files and EnumerateFiles to stream results
                        fileEnum = Directory.EnumerateFiles(path, "*", searchOption);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.Error.WriteLine($"Warning: Access denied to directory '{path}'. Skipping.");
                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Warning: Could not enumerate '{path}': {ex.Message}");
                        continue;
                    }

                    foreach (var f in fileEnum)
                        yield return f;
                }
                else if (File.Exists(path))
                {
                    yield return path;
                }
                else
                {
                    Console.Error.WriteLine($"Warning: Path not found: '{path}'");
                }
            }
        }
    }
}
