using AdventOfCode2025.enums;

namespace AdventOfCode2025;

public class Day6 : IDay
{
    public static void RunSolution()
    {
        var fileInput = Helpers.ReadFile("../../../fileInputs/mathProblems.txt");

        Part1(fileInput);
        Part2(fileInput);
    }

    private static void Part1(string[] fileInput)
    {
        List<string[]> numberGroups = [];
        List<MathMethod> mathFunctions = [];

        foreach (var line in fileInput)
        {
            var entries = line.Split(' ').ToList();
            entries.RemoveAll(entry => entry == string.Empty);

            if (fileInput.LastOrDefault() == line)
            {
                mathFunctions = AddToMathFunctions(entries, mathFunctions);
            }
            else
            {
                numberGroups = AddToNumberGroups(entries, numberGroups);
            }
        }

        double total = 0;

        numberGroups.ForEach(group =>
        {
            group = group.Select(number => number.Trim()).ToArray();
        });

        foreach (var numberGroup in numberGroups)
        {
            switch (mathFunctions[numberGroups.IndexOf(numberGroup)])
            {
                case MathMethod.Add:
                    total += numberGroup.Sum(double.Parse);
                    break;
                case MathMethod.Multiply:
                    total += double.Parse(numberGroup.Aggregate((a, x) => (double.Parse(a) * double.Parse(x)).ToString()));
                    break;
            
            }
        }

        Console.WriteLine("Part 1: Total from math answers: " + total);
    }

    private static void Part2(string[] fileInput)
    {
        List<string[]> numberGroups = [];
        List<MathMethod> mathFunctions = [];

        for (int i = 0, j = fileInput.Max(line => line.Length) - 1, k = 0; j >= 0;)
        {
            if (i == fileInput.Length - 1)
            {
                if (fileInput[i][j] == '*' || fileInput[i][j] == '+')
                {
                    mathFunctions.Add(fileInput[i][j] == '*' ? MathMethod.Multiply : MathMethod.Add);
                    k = 0;
                }
                else
                {
                    k++;
                }
                j--;
                i = 0;
            }
            else if (numberGroups.Count == mathFunctions.Count)
            {
                numberGroups.Add([fileInput[i][j].ToString()]);
                i++;
            }
            else if (numberGroups[numberGroups.Count - 1].Length == k)
            {
                numberGroups[numberGroups.Count - 1] = numberGroups[numberGroups.Count - 1].Append(fileInput[i][j].ToString()).ToArray();
                i++;
            }
            else if (numberGroups.Last().Length == i)
            {
                numberGroups[numberGroups.Count - 1][k] += fileInput[i][j];
                i++;
            }
            else
            {
                numberGroups[numberGroups.Count - 1][k] += fileInput[i][j].ToString();
                i++;
            }
        }

        double total = 0;
        var columnNumber = "";
        double multipliedNumber = 1;

        foreach (var numberGroup in numberGroups)
        {
            switch (mathFunctions[numberGroups.IndexOf(numberGroup)])
            {
                case MathMethod.Add:
                    foreach (var number in numberGroup)
                    {
                        if (double.TryParse(number.Trim(), out var value))
                        {
                            total += value;
                        }
                    }
                    break;
                case MathMethod.Multiply:
                    foreach (var number in numberGroup)
                    {
                        if (double.TryParse(number.Trim(), out var value))
                        {
                            multipliedNumber *= value;
                        }
                    }
                    total += multipliedNumber == 1 ? 0 : multipliedNumber;
                    multipliedNumber = 1;
                    break;

            }
        }

        Console.WriteLine("Part 2: Total from math answers: " + total);
    }

    private static List<MathMethod> AddToMathFunctions(List<string> entries, List<MathMethod> mathFunctions)
    {
        mathFunctions.AddRange(entries.Select(entry => entry[0].ToString() == string.Empty ? 0 : (MathMethod)entry[0]));
        return mathFunctions;
    }

    private static List<string[]> AddToNumberGroups(List<string> entries, List<string[]> numberGroups) 
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if (numberGroups.Count < i + 1)
            {
                numberGroups.Add([]);
            }

            if (numberGroups[i].Length > 0)
            {
                numberGroups[i] = numberGroups[i].Append(entries[i]).ToArray();
            }
            else
            {
                numberGroups[i] = [entries[i]];
            }
        }

        return numberGroups;
    }
}
