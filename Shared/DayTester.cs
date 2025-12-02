using NUnit.Framework;

namespace Shared;

public static class DayTester
{
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

        string[] text = File.ReadAllLines(path);

        if (text.Length <= 0) {
            throw new ArgumentException($"File {path} is empty");
        }
        
        int outputStart = text.IndexOf("#EXPECTED#");
        if (outputStart == -1) {
            throw new ArgumentException($"File {path} doesn't contain #EXPECTED#");
        }
        
        string input = text.Where((_, index) => index < outputStart).Aggregate((a, b) => a + '\n' + b);
        string expectedOutput = text.Where((_, index) => index > outputStart).Aggregate((current, next) => current + '\n' + next);
        string output = day.SolveTimed(input);

        Assert.That(output == expectedOutput, $"Expected '{expectedOutput}' but got '{output}'");
    }
}