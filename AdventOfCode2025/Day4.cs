namespace AdventOfCode2025;

public class Day4 : IDay
{
    public static void RunSolution()
    {
        var fileInput = File.ReadAllLines("../../../paperRolls.txt");

        Part1(fileInput);
        Part2(fileInput);
    }

    private static void Part1(string[] fileInput)
    {
        var accessiblePaperRolls = 0;

        for (int i = 0, j = 0; i < fileInput.Length;)
        {
            if (fileInput[i][j] == '@')
            {
                if (CountAdjacentRolls(fileInput, i, j) < 4)
                {
                    accessiblePaperRolls++;
                }
            }

            if (j < fileInput[i].Length - 1)
            {
                j++;
            }
            else
            {
                j = 0;
                i++;
            }
        }

        Console.WriteLine("Part 1: Accessible paper rolls: " + accessiblePaperRolls);
    }

    private static void Part2(string[] fileInput)
    {
        var accessiblePaperRolls = 0;
        var newRow = "";
        int i = 0;
        int j = 0;
        bool removedRollsThisRepetition = true;
        int rollsRemovedAtStartOfRepitition = 0;

        while (removedRollsThisRepetition)
        {
            newRow += fileInput[i][j];

            if (fileInput[i][j] == '@')
            {
                if (CountAdjacentRolls(fileInput, i, j) < 4)
                {
                    accessiblePaperRolls++;
                    rollsRemovedAtStartOfRepitition++;
                    newRow = newRow[..j] + ".";
                }
            }

            if (j < fileInput[i].Length - 1)
            {
                j++;
            }
            else
            {
                fileInput[i] = newRow;
                newRow = "";
                j = 0;
                if (i < fileInput.Length - 1)
                {
                    i++;
                }
                else if (rollsRemovedAtStartOfRepitition == 0)
                {
                    removedRollsThisRepetition = false;
                }
                else
                {
                    rollsRemovedAtStartOfRepitition = 0;
                    i = 0;
                }
            }
        }

        Console.WriteLine("Part 1: Accessible paper rolls: " + accessiblePaperRolls);
    }

    private static int CountAdjacentRolls(string[] lines, int placeInLines, int placeInLine)
    {
        int i = placeInLines > 0 ? placeInLines - 1 : placeInLines;
        int j = placeInLine > 0 ? placeInLine - 1 : placeInLine;

        int numberOfAdjacentRolls = 0;

        while (i <= placeInLines + 1 && i < lines.Length && numberOfAdjacentRolls < 4)
        {
            if (lines[i][j] == '@') numberOfAdjacentRolls++;

            if (j < lines[placeInLines].Length - 1 && (j < placeInLine + 1 && (i != placeInLines || j < placeInLine && j < lines[placeInLines].Length - 2)))
            {
                j += i == placeInLines ? 2 : 1;
            }
            else
            {
                i++;
                j = placeInLine > 0 ? placeInLine - 1 : i == placeInLines ? placeInLine + 1 : placeInLine;
            }
        }

        return numberOfAdjacentRolls;
    }
}
