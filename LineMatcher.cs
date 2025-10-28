using System.Text.RegularExpressions; // <-- Add this

namespace MiniGrep
{
    class LineMatcher
    {
        private readonly Regex _regex;

        public LineMatcher(string pattern, bool ignoreCase)
        {
            RegexOptions options = RegexOptions.Compiled;
            if (ignoreCase)
            {
                options |= RegexOptions.IgnoreCase;
            }

            _regex = new Regex(pattern, options);
        }

        public bool IsMatch(string line)
        {
            return _regex.IsMatch(line);
        }
    }
}