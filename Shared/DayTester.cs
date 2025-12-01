using NUnit.Framework;

namespace Shared;

public static class DayTester
{
    public static void Test<T>(string path) where T : DaySolution, new() {
        path = Path.Join("../../../", path);
        
        Console.WriteLine(Directory.GetCurrentDirectory());
        if (!File.Exists(path)) {
            throw new ArgumentException($"File {path} does not exist");
        }

        if (Directory.Exists(path)) {
            string[] files = Directory.GetFiles(path);

            if (files.Length <= 0) {
                throw new ArgumentException($"Directory {path} has no files!");
            }

            foreach (string file in files) {
                Test<T>(file);
            }

            return;
        }

        T day = new();

        string[] text = File.ReadAllLines(path);

        if (text.Length <= 0) {
            throw new ArgumentException($"File {path} is empty");
        }
        
        int outputStart = text.IndexOf("#EXPECTED_OUTPUT_START#");
        string[] input = text.Where((_, index) => index < outputStart).ToArray();
        string expectedOutput = text.Where((_, index) => index > outputStart).Aggregate((current, next) => current + '\n' + next);
        string output = day.SolveTimed(input);

        Assert.That(output == expectedOutput, $"Expected '{expectedOutput}' but got '{output}'");
    }
}