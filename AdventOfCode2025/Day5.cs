using System;
using System.Security.Cryptography;

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
        Part2(ranges);
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

    private static void Part2(List<(double, double)> ranges)
    {
        ranges = ranges.OrderBy(range => range.Item1).ToList();
        List<double> freshIngredientIds = [];
        double numberOfFreshIngredientIds = 0;
        List<(double, double)> previousRanges = [];
        List<(double, double)> overlappingRanges = [];
        List<(double, double)> rangesToRemove = [];

        foreach (var range in ranges)
        {
            if (previousRanges.Any(prevRange => prevRange.Item1 <= range.Item1 && prevRange.Item2 >= range.Item2))
            {
                continue;
            }

            overlappingRanges.AddRange(previousRanges.FindAll(previousRange => 
                (previousRange.Item1 >= range.Item1 && previousRange.Item1 <= range.Item2) 
                || (previousRange.Item2 >= range.Item1 && previousRange.Item2 <= range.Item2)));

            if (overlappingRanges.Count > 0)
            {
                var tempCurrentRange = (range.Item1, range.Item2);


                overlappingRanges.ForEach(overlappingRange =>
                {
                    if (overlappingRange.Item2 == tempCurrentRange.Item1 || (overlappingRange.Item1 < tempCurrentRange.Item1 
                        && overlappingRange.Item2 >= tempCurrentRange.Item1 
                        && overlappingRange.Item2 < tempCurrentRange.Item2))
                    {
                        tempCurrentRange.Item1 = overlappingRange.Item2 + 1;
                    }
                    else if (overlappingRange.Item1 == tempCurrentRange.Item2 || overlappingRange.Item1 <= tempCurrentRange.Item2 
                        && overlappingRange.Item1 > tempCurrentRange.Item1 
                        && overlappingRange.Item2 > tempCurrentRange.Item2)
                    {
                        tempCurrentRange.Item2 = overlappingRange.Item1 - 1;
                    }
                    else if (rangesToRemove.Any(rangeToRemove => rangeToRemove.Item1 >= overlappingRange.Item1))
                    {
                        rangesToRemove[rangesToRemove.IndexOf(rangesToRemove.First(rangeToRemove => rangeToRemove.Item1 >= overlappingRange.Item1))] 
                            = (overlappingRange.Item1, rangesToRemove[rangesToRemove.IndexOf(rangesToRemove.First(rangeToRemove => rangeToRemove.Item1 >= overlappingRange.Item1))].Item2);
                    }
                    else if (rangesToRemove.Any(rangeToRemove => rangeToRemove.Item2 <= overlappingRange.Item2))
                    {
                        rangesToRemove[rangesToRemove.IndexOf(rangesToRemove.First(rangeToRemove => rangeToRemove.Item2 <= overlappingRange.Item2))]
                            = (rangesToRemove[rangesToRemove.IndexOf(rangesToRemove.First(rangeToRemove => rangeToRemove.Item2 <= overlappingRange.Item2))].Item1, overlappingRange.Item2);
                    }
                    else
                    {
                        rangesToRemove.Add(overlappingRange);
                    }
                });

                double totalToAdd = tempCurrentRange.Item2 - tempCurrentRange.Item1 + 1;
                totalToAdd -= rangesToRemove.Sum(rangeToRemove => rangeToRemove.Item2 - rangeToRemove.Item1 + 1);

                numberOfFreshIngredientIds += totalToAdd;
            }
            else
            {
                numberOfFreshIngredientIds += range.Item2 - range.Item1 + 1;
            }

            previousRanges.Add(range);
            rangesToRemove.Clear();
            overlappingRanges.Clear();
        }

        Console.WriteLine("Part 2: Number of fresh ingredient IDs: " +  numberOfFreshIngredientIds);
    }
}
