using NUnit.Framework;

namespace Shared;

public static class DayTester
{
    private const string ExpectedText = "#EXPECTED#";
    
    public static void Test<T>(string path, bool fromBinary = true) where T : DaySolution, new() {
        if (fromBinary) path = Path.Join("..", "..", "..",  path);
        bool dirExists = Directory.Exists(path);
        bool fileExists = File.Exists(path);
        
        Console.WriteLine(Directory.GetCurrentDirectory());
        
        if (!fileExists && !dirExists) {
            throw new ArgumentException($"File {path} does not exist");
        }

        if (dirExists) {
            string[] files = Directory.GetFiles(path);

            if (files.Length <= 0) {
                throw new ArgumentException($"Directory {path} has no files!");
            }

            foreach (string file in files) {
                Test<T>(file, false);
            }

            return;
        }

        T day = new();

        string text = File.ReadAllText(path);

        if (text.Length <= 0) {
            throw new ArgumentException($"File {path} is empty");
        }

        if (!text.Contains(ExpectedText)) {
            throw new ArgumentException($"File {path} doesn't contain #EXPECTED#");
        }

        string[] split = text.Split(ExpectedText, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        
        if (split.Length != 2) {
            throw new ArgumentException($"File {path} didn't get split in two by #EXPECTED#!");
        }
        
        string input = split[0];
        string output = day.SolveTimed(input);
        string expectedOutput = split[1];

        Assert.That(output == expectedOutput, $"Expected '{expectedOutput}' but got '{output}'");
    }
}