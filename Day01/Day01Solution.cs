using Shared;

namespace Day01;

public class Day01Solution : DaySolution
{
    private const int WrapLow = 0;
    private const int WrapHigh = 100;
    private const int CheckNumber = 0;

    public override string Solve(string[] input) {
        int matchCount = 0;
        int state = 50;
        foreach (string line in input) {
            int sign = line[0] == 'L' ? -1 : 1;
            int value = int.Parse(line[1..]);
            state += sign * value;

            if (state < WrapLow) {
                state = WrapHigh - Math.Abs(state) % WrapHigh;
            }

            if (state >= WrapHigh) {
                state %= WrapHigh;
            }

            if (state == CheckNumber) {
                matchCount++;
            }
        }

        return matchCount.ToString();
    }
}