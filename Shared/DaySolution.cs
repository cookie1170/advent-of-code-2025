namespace Shared;

public abstract class DaySolution
{
    public string SolveTimed(string input) {
        DateTime start = DateTime.Now;
        string result = Solve(input);
        DateTime end = DateTime.Now;
        TimeSpan diff = end - start;

        Console.WriteLine($"Done solving! Took {Utils.FormatTimeSpan(diff)}");
        
        return result;
    }

    public abstract string Solve(string input);

    public string SolveFromFile(string filePath) {
        string text = File.ReadAllText(filePath);

        return SolveTimed(text);
    }

    public void SolveToFile(string inPath = "../../../input", string outPath = "../../../output") {
        File.WriteAllText(outPath, SolveFromFile(inPath));
    }
}