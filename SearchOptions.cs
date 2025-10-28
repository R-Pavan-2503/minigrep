namespace MiniGrep
{
    public class SearchOptions
    {
        public string Pattern { get; set; } = "";
        public List<string> Paths { get; set; } = new();
        public bool Recursive { get; set; }
        public bool IgnoreCase { get; set; }
        public bool ShowLineNumbers { get; set; }
        public bool CountOnly { get; set; }
    }
}