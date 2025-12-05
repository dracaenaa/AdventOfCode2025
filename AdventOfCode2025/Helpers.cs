namespace AdventOfCode2025;

public class Helpers
{
    public static void RunDaySolution(string dayToRun)
    {
        if (int.TryParse(dayToRun, out var day))
        {
            switch (day)
            {
                case 1:
                    Day1.RunSolution();
                    break;
                case 2:
                    Day2.RunSolution();
                    break;
                default:
                    Console.WriteLine("Solution not available, days complete: 1 & 2");
                    break;
            }
        } else
        {
            Console.WriteLine("Input not valid, please enter a numeric value or 'exit' to exit.");
        }
    }

    public static string GetUserInput()
    {
        Console.Write("Enter positive numeric day to run, enter 'exit' to exit: ");

        return Console.ReadLine() ?? "";
    }
}
