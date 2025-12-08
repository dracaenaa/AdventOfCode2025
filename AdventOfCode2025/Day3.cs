namespace AdventOfCode2025;

public class Day3 : IDay
{
    public static void RunSolution()
    {
        var fileInput = Helpers.ReadFile("../../../joltages.txt");

        Part1(fileInput);
        Part2(fileInput);
    }

    public static void Part1(string[] fileInput)
    {
        int totalOutputJoltage = 0;
        int largestFirstValue = 0;
        int largestSecondValue = 0;
        int index = 0;
        int currentValue;

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

    public static void Part2(string[] fileInput)
    {
        double totalOutputJoltage = 0;
        int[] largestValues = [0,0,0,0,0,0,0,0,0,0,0,0];
        int arrayLength = largestValues.Length;
        int currentValue;
        int previousLargestValueIndex = 0;

        for (int i = 0, j = 0, k = arrayLength; i < fileInput.Length;) 
        {
            currentValue = int.Parse(fileInput[i].Substring(j, 1));
            if (currentValue > largestValues[arrayLength - k] && j <= fileInput[i].Length - k)
            {
                largestValues[arrayLength - k] = currentValue;
                previousLargestValueIndex = j;
            }

            if (j < fileInput[i].Length - k)
            {
                j++;
            }
            else if (j == fileInput[i].Length - k && k > 1)
            {
                k--;
                j = previousLargestValueIndex + 1;
            }
            else if (k == 1 && j == fileInput[i].Length - 1)
            {
                var joltage = "";
                largestValues.Select(value => value.ToString()).ToList().ForEach(value => joltage += value.ToString());
                totalOutputJoltage += double.Parse(joltage);

                k = arrayLength;
                i++;
                j = 0;
                largestValues = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
            }
        }

        Console.WriteLine("Total output joltage: " + totalOutputJoltage);
    }
}
