namespace AdventOfCode2025;

public class Day2 : IDay
{
    public static void RunSolution()
    {
        var fileInput = Helpers.ReadFile("../../../productIds.txt").FirstOrDefault()?.Split(',');

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
        int currentIndex;

        foreach (var line in fileInput)
        {
            currentIdString = line.Split('-')[0];
            currentId = long.Parse(currentIdString);
            lastId = long.Parse(line.Split("-")[1]);
            currentIndex = 1;

            while (currentId <= lastId)
            {
                if (currentIdString.Length == 1)
                {
                    currentId++;
                    currentIdString = currentId.ToString();
                    continue;
                }

                var list = GetListOfStrings(currentIdString, currentIndex);
                
                if (AreAllInListEmpty(list))
                {
                    invalidIdsTotal += currentId;
                    currentId++;
                    currentIdString = currentId.ToString();
                    currentIndex = 1;
                    continue;
                }

                if (currentIndex >= currentIdString.Length / 2)
                {
                    currentId++;
                    currentIdString = currentId.ToString();
                    currentIndex = 1;
                }
                else
                {
                    currentIndex++;
                }
            }
        }

        Console.WriteLine("Part 2: Total of invalid product IDs: " + invalidIdsTotal);
    }

    private static string[] GetListOfStrings(string input, int index)
    {
        return input.Split(input.Substring(0, index));
    }

    private static bool AreAllInListEmpty(string[] list)
    {
        return string.IsNullOrEmpty(list.FirstOrDefault((item) =>
        {
            return item != "";
        }));
    }
}
