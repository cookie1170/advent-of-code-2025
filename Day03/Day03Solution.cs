using Shared;

public class Day03Solution : DaySolution
{
    private const int Length = 12;
    
    public override string Solve(string input) {
        string[] stringBanks = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        List<byte[]> banks = new(stringBanks.Length);
        Span<byte> buffer = stackalloc byte[Length];
        long sum = 0;

        foreach (string stringBank in stringBanks) {
            byte[] bank = new byte[stringBank.Length];
            for (int i = 0; i < stringBank.Length; i++) {
                bank[i] = (byte)(stringBank[i] - '0');
            }

            banks.Add(bank);
        }

        foreach (byte[] bank in banks) {
            long joltage = GetBankJoltage(bank, buffer);
            sum += joltage;
        }

        return sum.ToString();
    }

    private static long GetBankJoltage(byte[] bank, Span<byte> buffer) {
        buffer.Fill(0);
        
        for (int i = 0; i < bank.Length; i++) {
            byte b = bank[i];
            for (int j = 0; j < buffer.Length; j++) {
                if (b <= buffer[j] || bank.Length - i < Length - j) continue;
                
                for (int k = j + 1; k < buffer.Length; k++) {
                    buffer[k] = 0; 
                }
                
                buffer[j] = b;
                
                break;
            }
        }

        long result = 0;
        for (int i = 0; i < buffer.Length; i++) {
            result += buffer[^(i + 1)] * (long)Math.Pow(10, i);
        }

        return result;
    }
}