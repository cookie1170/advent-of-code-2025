namespace Shared;

public abstract class DaySolution
{
    public abstract string Solve(string[] input);

    public string SolveFromFile(string filePath) {
        string[] lines = File.ReadAllLines(filePath);

        return Solve(lines);
    }

    public void SolveToFile(string inPath = "input", string outPath = "output") {
        File.WriteAllText(outPath, SolveFromFile(inPath));
    }
}