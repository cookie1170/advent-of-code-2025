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

        // can't have two repeating sections if it's odd
        if (asString.Length % 2 == 1) {
            return false;
        }
        
        int halfLength = asString.Length / 2;
        string first = asString[..halfLength];
        string last = asString[halfLength..];

        return first == last;
    }
}