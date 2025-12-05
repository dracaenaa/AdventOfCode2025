namespace AdventOfCode2025;

public class Day1 : IDay
{
    public static void RunSolution()
    {
        var fileInput = File.ReadAllLines("../../../entranceCombination.txt");

        var dialLocation = 50;
        var password = 0;

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
        Console.WriteLine("Solution: " + password);
    }
}  

