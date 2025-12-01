namespace Shared;

public static class Utils
{
    public static string FormatTimeSpan(TimeSpan span) {
        if (span.TotalMicroseconds < 10000) {
            return $"{span.TotalMicroseconds} us";
        }

        if (span.TotalMilliseconds < 10000) {
            return $"{span.TotalMilliseconds} ms";
        }

        return $"{span.TotalSeconds} sec";
    }
}