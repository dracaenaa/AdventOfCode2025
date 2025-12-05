namespace AdventOfCode2025;

public class Day2 : IDay
{
    public static void RunSolution()
    {
        //var fileInput = File.ReadAllText("../../../productIds.txt").Split(',');
        var fileInput = File.ReadAllText("../../../exampleProductIds.txt").Split(',');

        Part1(fileInput);
        Part2(fileInput);
    }

    private static void Part1(string[] fileInput)
    {
        long invalidIdsTotal = 0;
        long currentId;
        string currentIdString;
        long lastId;

        foreach (var line in fileInput)
        {
            currentIdString = line.Split('-')[0];
            currentId = long.Parse(currentIdString);
            lastId = long.Parse(line.Split("-")[1]);

            while (currentId <= lastId)
            {
                if ((currentIdString.Length % 2 == 0) && currentIdString.Substring(0, currentIdString.Length / 2).Contains(currentIdString.Substring(currentIdString.Length / 2)))
                {
                    invalidIdsTotal += currentId;
                }

                currentId++;
                currentIdString = currentId.ToString();
            }
        }

        Console.WriteLine("Part 1: Total of invalid product IDs: " + invalidIdsTotal);
    }

    private static void Part2(string[] fileInput)
    {
        long invalidIdsTotal = 0;
        long currentId;
        string currentIdString;
        long lastId;

        foreach (var line in fileInput)
        {
            currentIdString = line.Split('-')[0];
            currentId = long.Parse(currentIdString);
            lastId = long.Parse(line.Split("-")[1]);

            while (currentId <= lastId)
            {
                if (currentIdString.Substring(0, currentIdString.Length / 2).Contains(currentIdString.Substring(currentIdString.Length / 2)))
                {
                    invalidIdsTotal += currentId;
                }

                currentId++;
                currentIdString = currentId.ToString();
            }
        }

        Console.WriteLine("Part 2: Total of invalid product IDs: " + invalidIdsTotal);
    }
}
