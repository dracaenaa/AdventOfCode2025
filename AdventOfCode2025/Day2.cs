namespace AdventOfCode2025;

public class Day2 : IDay
{
    public static void RunSolution()
    {
        var fileInput = File.ReadAllLines("../../../entranceCombination.txt");
        //var fileInput = File.ReadAllLines("../../../testInput.txt");

        var dialLocation = 50;
        var password = 0;

        foreach (var line in fileInput)
        {
            dialLocation += line[0] == 'L' ? (int.Parse(line.Substring(1)) * -1) : int.Parse(line.Substring(1));
            
            if (dialLocation == 0)
            {
                password++;
            }
            else if (dialLocation > 99 ||  dialLocation < 0) 
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
        Console.WriteLine("Solution: " + password);
    }
}
