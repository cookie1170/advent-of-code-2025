using Shared;

public class Day03Solution : DaySolution
{
    public override string Solve(string input) {
        string[] stringBanks = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        List<byte[]> banks = new(stringBanks.Length);
        int sum = 0;

        foreach (string stringBank in stringBanks) {
            byte[] bank = new byte[stringBank.Length];
            for (int i = 0; i < stringBank.Length; i++) {
                bank[i] = (byte)(stringBank[i] - '0');
            }

            banks.Add(bank);
        }

        foreach (byte[] bank in banks) {
            sum += GetBankJoltage(bank);
        }

        return sum.ToString();
    }

    // ReSharper disable once IdentifierTypo
    private static int GetBankJoltage(byte[] bank) {
        byte largest = 0;
        byte secondLargest = 0;
        for (int i = 0; i < bank.Length - 1; i++) {
            byte b = bank[i];
            if (b > largest) {
                largest = b;
                secondLargest = 0;
            } else if (b > secondLargest) {
                secondLargest = b;
            }
        }

        byte last = bank[^1];
        if (last > secondLargest) {
            secondLargest = last;
        }

        return largest * 10 + secondLargest;
    }
}