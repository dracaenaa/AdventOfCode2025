using AdventOfCode2025;

internal class Program
{
    private static void Main(string[] args)
    {
        var dayToRun = Helpers.GetUserInput();
        while (!string.Equals(dayToRun?.ToLower(), "exit"))
        {
            Helpers.RunDaySolution(dayToRun);

            dayToRun = Helpers.GetUserInput();
        }

    }
}