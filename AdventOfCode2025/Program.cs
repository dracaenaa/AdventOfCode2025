using AdventOfCode2025;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter positive numeric day to run, enter 'exit' to exit: ");
        var dayToRun = Console.ReadLine();
        while (!string.Equals(dayToRun?.ToLower(), "exit"))
        {
            Helpers.CheckInputAndRunDaySolution(dayToRun);

            Console.Write("Enter positive numeric day to run, enter 'exit' to exit: ");
            dayToRun = Console.ReadLine();
        }

    }
}