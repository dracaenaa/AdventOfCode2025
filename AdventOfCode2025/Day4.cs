namespace AdventOfCode2025;

public class Day4 : IDay
{
    public static void RunSolution()
    {
        var fileInput = File.ReadAllLines("../../../paperRolls.txt");
        //var fileInput = File.ReadAllLines("../../../examplePaperRolls.txt");

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

        Console.WriteLine("Accessible paper rolls: " + accessiblePaperRolls);
    }

    public static int CountAdjacentRolls(string[] lines, int placeInLines, int placeInLine)
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
