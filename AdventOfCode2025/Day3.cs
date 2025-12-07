namespace AdventOfCode2025;

public class Day3 : IDay
{
    public static void RunSolution()
    {
        var fileInput = File.ReadAllLines("../../../joltages.txt");
        //var fileInput = File.ReadAllLines("../../../exampleJoltages.txt");

        int totalOutputJoltage = 0;
        int largestFirstValue = 0;
        int largestSecondValue = 0;
        int index = 0;
        int currentValue = 0;

        foreach (var line in fileInput)
        {
            while (index < line.Length)
            {
                currentValue = int.Parse(line.Substring(index, 1));
                if (index < line.Length - 1 && currentValue > largestFirstValue)
                {
                    largestFirstValue = currentValue;
                    largestSecondValue = 0;
                }
                else if (currentValue > largestSecondValue)
                {
                    largestSecondValue = currentValue;
                }
                index++;
            }

            totalOutputJoltage += int.Parse(largestFirstValue.ToString() + largestSecondValue.ToString());
            index = 0;
            largestFirstValue = 0;
            largestSecondValue = 0;
        }

        Console.WriteLine("Total output joltage: " + totalOutputJoltage);
    }
}
