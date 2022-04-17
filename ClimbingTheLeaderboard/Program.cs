using System.Diagnostics;
using System.Text.RegularExpressions;

List<int> rankeds = new()
{
    100,
    90,
    90,
    80,
    75,
    60
};
List<int> players = new()
{
    50,
    65,
    77,
    90,
    102
};

static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
{
    //List<int> rankedList = ranked.Distinct().ToList();
    List<int> result = new List<int>();
    var inputTxt = File.ReadAllText(@"C:\Users\Dell5501-1\source\repos\ConsoleApp1\ConsoleApp1\input06.txt");
    var splitInputTxt = Regex.Replace(inputTxt, @"\t|\n|\r", "")
        .Split(" ").ToList();

    var outputTxt = File.ReadAllText(@"C:\Users\Dell5501-1\source\repos\ConsoleApp1\ConsoleApp1\output06.txt");
    var splitOutputTxt = Regex.Replace(inputTxt, @"\t|\n|\r", "")
        .Split(" ").ToList();

    var rankedList = splitInputTxt.ConvertAll(s => Int64.Parse(s));
    var playerList = splitOutputTxt.ConvertAll(s => Int64.Parse(s));

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    player.ForEach(x =>
    {
        ranked.Add(x);
        ranked.Sort();
        var newRankedList = ranked.Distinct().ToList();
        newRankedList.Reverse();
        result.Add(newRankedList.IndexOf(x) + 1);
    }
    );
    stopwatch.Stop();

    Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

    return result;
}

climbingLeaderboard(rankeds, players).ForEach(x => Console.WriteLine(x));