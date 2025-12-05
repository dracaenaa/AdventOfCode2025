namespace AdventOfCode2025;

public class Day2 : IDay
{
    public static void RunSolution()
    {
        var fileInput = File.ReadAllText("../../../productIds.txt").Split(',');

        long invalidIdsTotal = 0;
        long currentId;
        string currentIdString;
        long lastId;

        for (int i = 0, j = 1; i < fileInput.Length; i++) 
        {
            currentIdString = fileInput[i].Split('-')[0];
            currentId = long.Parse(currentIdString);
            lastId = long.Parse(fileInput[i].Split("-")[1]);

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

        Console.WriteLine("Total of invalid product IDs: " + invalidIdsTotal);
    }
}
