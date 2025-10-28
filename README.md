# 🔍 MiniGrep

**MiniGrep** is a lightweight command-line tool written in **C# (.NET)** that mimics the basic behavior of the Unix `grep` command. It allows you to search for text patterns inside files or folders, with options for recursive search, case-insensitive matching, line numbering, counting matches, and color highlighting.

---

## 🚀 Features

- 🔎 **Search text** in files or directories
- 🔁 **Recursive search** through folders using `-r`
- 🔠 **Case-insensitive search** with `-i`
- 🔢 **Show line numbers** using `-n`
- 🔢 **Count matches only** with `-c`
- 🎨 **Colored output** (file names, line numbers, and matched text highlighted)

---

## 🗂️ Project Structure

```
MiniGrep/
│
├── MiniGrep.csproj
├── Program.cs
├── SearchOptions.cs
├── FileSearcher.cs
├── LineMatcher.cs
└── OutputFormatter.cs
```

**Files Overview:**
- `Program.cs` → Main entry point; parses arguments and runs the search.
- `SearchOptions.cs` → Holds all CLI options (pattern, paths, flags).
- `FileSearcher.cs` → Finds files to search through.
- `LineMatcher.cs` → Uses regular expressions for pattern matching.
- `OutputFormatter.cs` → Displays output with color formatting.

---

## ⚙️ Requirements

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or later
- Works on **Windows**, **macOS**, or **Linux**

Check your version:

```bash
dotnet --version
```

---

## 🧠 Usage

Run MiniGrep from the directory containing your `.csproj` file:

```bash
dotnet run -- [options] <pattern> <file(s)/folder>
```

---

## 📋 Options

| Option | Description |
|--------|-------------|
| `-r` | Search recursively through subfolders |
| `-i` | Ignore case when matching |
| `-n` | Show line numbers |
| `-c` | Show only the number of matches per file |

---

## 🧩 Examples

### 🔹 Simple search in a file

```bash
dotnet run -- "error" logs.txt
```

### 🔹 Recursive search in a folder

```bash
dotnet run -- -r "error" ./logs
```

### 🔹 Case-insensitive search

```bash
dotnet run -- -i "warning" logs.txt
```

### 🔹 Show line numbers

```bash
dotnet run -- -n "error" logs.txt
```

### 🔹 Count matches only

```bash
dotnet run -- -c "error" logs.txt
```

### 🔹 Combine multiple options

```bash
dotnet run -- -r -i -n "error" ./logs
```

---

## 🎨 Colored Output

MiniGrep highlights matches in the terminal:
- 🟡 **File names** → Yellow
- 🟦 **Line numbers** → Cyan
- 🔴 **Matched text** → Red

Example output:

```
logs.txt:12:  An unexpected ERROR occurred
```

In this example, `"ERROR"` will appear red, `logs.txt` in yellow, and `12` in cyan.

---

## 🧰 Example Folder Setup

```
D:\projects\minigrep\minigrep\
│
├── MiniGrep.csproj
├── Program.cs
├── SearchOptions.cs
├── FileSearcher.cs
├── LineMatcher.cs
├── OutputFormatter.cs
└── logs.txt
```

To test:

```bash
dotnet run -- -i "error" logs.txt
```

---

## 🧩 How It Works (Under the Hood)

1. **Program.cs** → Parses CLI arguments and sets `SearchOptions`.
2. **FileSearcher.cs** → Collects all files to process.
3. **LineMatcher.cs** → Uses regex to detect matching lines.
4. **OutputFormatter.cs** → Handles colored output and highlighting.
5. **Program.cs** → Coordinates everything and prints results.

---

## 🧱 Build Instructions

To build the project:

```bash
dotnet build
```

This creates an executable in:

```
bin/Debug/net9.0/
```

Then you can run it directly:

```bash
dotnet bin/Debug/net9.0/MiniGrep.dll -- "pattern" file.txt
```

---

## 🖥️ Example Demo (Console Preview)

```
$ dotnet run -- -r -i "error" D:\test

Search Options:
  Pattern: error
  Paths: D:\test
  Recursive: True
  IgnoreCase: True
  ShowLineNumbers: False
  CountOnly: False

D:\test\logs.txt: pavan pavan ERROR occurred during execution
D:\test\system\output.log: error detected in the process
```

---

## 🧑💻 Author

👤 **R Pavan**
💼 **MiniGrep Project** — C# Console Application
📅 **Built using .NET 9.0**

---

## 🪪 License

This project is open-source and available under the **MIT License**. You are free to use, modify, and distribute it with attribution.

---

## 🌟 Contributing

Contributions are welcome! If you'd like to enhance the tool (add regex options, output formatting, etc.), feel free to:

```
fork → modify → pull request
```

---

## 💡 Future Enhancements

- Support for multiple search patterns
- Regex groups highlighting
- Output to JSON or CSV format
- Parallel file processing for large directories
- Support for `.gitignore` file patterns
- Export results to file



## 🔧 Quick Start

```bash
# Clone or create the project
dotnet new console -n MiniGrep
cd MiniGrep

# Create the necessary files (copy the C# source code into these files)
# Then run:
dotnet run -- "search_term" file.txt

# For recursive search:
dotnet run -- -r -i "search_term" ./folder

# Build for distribution:
dotnet publish -c Release
```

---

**"A small, fast, and colorful grep clone — made in C# for everyone learning .NET CLI development."** 🚀
