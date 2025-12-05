namespace AdventOfCode2025;

public class Helpers
{
    public static void CheckInputAndRunDaySolution(string dayToRun)
    {
        if (int.TryParse(dayToRun, out var day))
        {
            switch (day)
            {
                case 1:
                    Day1.RunSolution();
                    break;
                default:
                    Console.WriteLine("Solution not available, days complete: 1");
                    break;
            }
        } else
        {
            Console.WriteLine("Input not valid, please enter a numeric value.");
        }
    }
}
