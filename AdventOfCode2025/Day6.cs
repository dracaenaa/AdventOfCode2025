namespace AdventOfCode2025;

public class Day6 : IDay
{
    public static void RunSolution()
    {
        var fileInput = Helpers.ReadFile("../../../mathProblems.txt");
        //var fileInput = Helpers.ReadFile("../../../exampleMathProblems.txt");
        List<double[]> numberGroups = [];
        List<MathMethod> mathFunctions = [];

        foreach (var line in fileInput) 
        {
            var entries = line.Split(' ').Select(entry => entry = entry.Trim()).ToList();
            entries.RemoveAll(entry => entry.Trim() == string.Empty);

            if (fileInput.LastOrDefault() == line)
            {
                mathFunctions = AddToMathFunctions(entries, mathFunctions);
            }
            else
            {
                numberGroups = AddToNumberGroups(entries, numberGroups);
            }
        }

        Part1(numberGroups, mathFunctions);
    }

    private static void Part1(List<double[]> numberGroups, List<MathMethod> mathFunctions)
    {
        double total = 0;

        foreach (var numberGroup in numberGroups)
        {
            switch (mathFunctions[numberGroups.IndexOf(numberGroup)])
            {
                case MathMethod.Add:
                    total += numberGroup.Sum();
                    break;
                case MathMethod.Multiply:
                    total += numberGroup.Aggregate((a, x) => a * x);
                    break;
            
            }
        }

        Console.WriteLine("Part 1: Total from math answers: " + total);
    }

    private static List<MathMethod> AddToMathFunctions(List<string> entries, List<MathMethod> mathFunctions)
    {
        mathFunctions.AddRange(entries.Select(entry => (MathMethod)entry[0]));
        return mathFunctions;
    }

    private static List<double[]> AddToNumberGroups(List<string> entries, List<double[]> numberGroups) 
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if (numberGroups.Count < i + 1)
            {
                numberGroups.Add([]);
            }

            if (numberGroups[i].Length > 0)
            {
                numberGroups[i] = numberGroups[i].Append(double.Parse(entries[i])).ToArray();
            }
            else
            {
                numberGroups[i] = [double.Parse(entries[i])];
            }
        }

        return numberGroups;
    }
}
