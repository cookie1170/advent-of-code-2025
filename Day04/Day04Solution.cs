using Shared;

namespace Day04;

using Position = (int y, int x);

public class Day04Solution : DaySolution
{
    private const char Roll = '@';
    
    public override string Solve(string input) {
        string[] lines = input.Split('\n');
        bool[,] map = new bool[lines.Length, lines[0].Length];
        for (int y = 0; y < lines.Length; y++) {
            string line = lines[y];
            for (int x = 0; x < line.Length; x++) {
                char c = line[x];
                bool isRoll = c == Roll;
                map[y, x] = isRoll;
            }
        }

        int validCount = 0;

        for (int y = 0; y < map.GetLength(0); y++) {
            for (int x = 0; x < map.GetLength(1); x++) {
                if (map[y, x] && IsRollValid(map, y, x)) validCount++;
            }
        }

        return validCount.ToString();
    }

    private bool IsRollValid(bool[,] map, int y, int x) {
        Position[] positions = [
            (y - 1, x), // up
            (y + 1, x), // down
            (y, x - 1), // left
            (y, x + 1), // right
            (y - 1, x + 1), // up-right
            (y - 1, x - 1), // up-left
            (y + 1, x + 1), // down-right
            (y + 1, x - 1), // down-left
        ];

        int adjacent = 0;
        
        foreach (Position position in positions) {
            if (IsInMap(map, position) && map[position.y, position.x]) {
                adjacent++;
            }
        }

        return adjacent < 4;
    }

    private bool IsInMap(bool[,] map, Position pos) {
        if (pos.y < 0 || pos.y >= map.GetLength(0)) return false;
        if (pos.x < 0 || pos.x >= map.GetLength(1)) return false;

        return true;
    }
}