using Shared;

namespace Day02;

public class Day02Solution : DaySolution
{
    public override string Solve(string input) {
        long sum = 0;
        string[] ranges = input.Split(',');
        foreach (string range in ranges) {
            string[] split = range.Split("-", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            long low = long.Parse(split[0]);
            long high = long.Parse(split[1]);
            for (long id = low; id <= high; id++) {
                if (IsInvalid(id)) {
                    sum += id;
                }
            } 
        }
        
        return sum.ToString();
    }

    private static bool IsInvalid(long id) {
        string asString = id.ToString();
        int length = asString.Length;

        for (int i = 1; i < length; i++) {
            HashSet<string> allSubstrings = [];
            int loopedLength = 0;
            for (int j = 0; j <= length - i; j += i) {
                loopedLength += i;
                allSubstrings.Add(asString.Substring(j, i));
            }

            if (loopedLength == length && allSubstrings.Count == 1) return true;
        }

        return false;
    }
}