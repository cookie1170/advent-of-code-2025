using Shared;

namespace Day02;

/*
 * First attempt: 5000ms
 * Second attempt: 1000ms
 * Third attempt: 700ms
 * Fourth attempt: 600ms
 * Fifth attempt: 530ms
 */

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
        Span<char> buffer = stackalloc char[20];
        id.TryFormat(buffer, out int length);
        
        for (int i = 1; i <= length / 2; i++) {
            if (length % i != 0) continue;
            
            if (AllSame(length, i, buffer)) return true;
        }

        return false;
    }

    private static bool AllSame(int length, int i, Span<char> span) {
        Span<char> first = span[..i];
        for (int j = i; j <= length - i; j += i) {
            Span<char> substring = span.Slice(j, i);
                
            if (!substring.SequenceEqual(first)) return false;
        }

        return true;
    }
}