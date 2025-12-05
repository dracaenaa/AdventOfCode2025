namespace AdventOfCode2025;

public class Day1 : IDay
{
    public static void RunSolution()
    {
        var fileInput = File.ReadAllLines("../../../entranceCombination.txt");

        var dialLocation = 50;
        var password = 0;

        Part1(fileInput, dialLocation, password);
        Part2(fileInput, dialLocation, password);
    }

    private static void Part1(string[] fileInput, int dialLocation, int password)
    {
        foreach (var line in fileInput)
        {
            dialLocation += line[0] == 'L' ? (int.Parse(line.Substring(1)) * -1) : int.Parse(line.Substring(1));

            while (dialLocation < 0)
            {
                dialLocation = 100 + dialLocation;
            }
            while (dialLocation > 99)
            {
                dialLocation -= 100;
            }
            if (dialLocation == 0)
            {
                password++;
            }
        }
        Console.WriteLine("Part 1: Password: " + password);
    }

    private static void Part2(string[] fileInput, int dialLocation, int password)
    {
        foreach (var line in fileInput)
        {
            dialLocation += line[0] == 'L' ? (int.Parse(line.Substring(1)) * -1) : int.Parse(line.Substring(1));

            if (dialLocation == 0)
            {
                password++;
            }
            else if (dialLocation > 99 || dialLocation < 0)
            {
                while (dialLocation < 0)
                {
                    if (dialLocation != (int.Parse(line.Substring(1)) * -1))
                    {
                        password++;
                    }
                    dialLocation = 100 + dialLocation;

                    if (dialLocation == 0)
                    {
                        password++;
                    }
                }
                while (dialLocation > 99)
                {
                    dialLocation -= 100;
                    password++;
                }
            }
        }
        Console.WriteLine("Part 2: Password: " + password);
    }
}  

