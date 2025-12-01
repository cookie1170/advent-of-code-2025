using Shared;

namespace Day01;

public class Day01Solution : DaySolution
{
    private const int WrapLowValue = 0;
    private const int WrapHighValue = 100;
    
    public override string Solve(string[] input) {
        int matchCount = 0;
        int state = 50;
        foreach (string line in input) {
            int sign = line[0] == 'L' ? -1 : 1;
            int value = int.Parse(line[1..]);
            
            // HORRIBLE HACK
            while (value > 0) {
                state += sign;
                value--;

                int abs = Math.Abs(state);
                if (abs % 100 == 0) {
                    matchCount++;
                }
            }
        }

        return matchCount.ToString();
    }
}