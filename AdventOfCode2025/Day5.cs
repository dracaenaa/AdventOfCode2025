namespace AdventOfCode2025;

public class Day5 : IDay
{
    public static void RunSolution()
    {
        var fileInput = File.ReadAllLines("../../../ingredientIds.txt");
        //var fileInput = File.ReadAllLines("../../../sampleIngredientIds.txt");
        var ranges = new List<(double, double)>();
        double[] ingredientsToCheck = [];

        foreach (var item in fileInput)
        {
            if (item.Contains('-'))
            {
                ranges.Add((double.Parse(item.Split("-")[0]), double.Parse(item.Split('-')[1])));
            }
            else
            {
                if (double.TryParse(item, out var ingredientId))
                {
                    ingredientsToCheck = ingredientsToCheck.Append(ingredientId).ToArray();
                }
            }
        }

        Part1(ranges, ingredientsToCheck);
    }

    private static void Part1(List<(double, double)> ranges, double[] ingredientsToCheck)
    {
        var freshAvailableIngredientIds = 0;

        foreach (var ingredient in ingredientsToCheck)
        {
            if (ranges.Any(range =>
            {
                return ingredient >= range.Item1 && ingredient <= range.Item2;
            }))
            {
                freshAvailableIngredientIds++;
            }
        }

        Console.WriteLine("Part 1: Number of fresh available ingredient IDs: " + freshAvailableIngredientIds);
    }
}
