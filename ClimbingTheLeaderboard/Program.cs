using System.Diagnostics;
using System.Text.RegularExpressions;

//List<int> rankeds = new()
//{
//    100,
//    90,
//    90,
//    80,
//    75,
//    60
//};
//List<int> players = new()
//{
//    50,
//    65,
//    77,
//    90,
//    102
//};
List<int> rankeds = new()
{
    100,
    100,
    50,
    40,
    40,
    20,
    10,
    9,
    8,
    7,
    6,
    5,
    1
};
List<int> players = new()
{
    5,
    25,
    50,
    100,
    120
};

static List<long> largeInputFileTransfer()
{
    var inputTxt = File.ReadAllText(@"C:\Users\Dell5501-1\source\repos\ClimbingTheLeaderboard\ClimbingTheLeaderboard\input06.txt");
    var splitInputTxt = Regex.Replace(inputTxt, @"\t|\n|\r", "")
        .Split(" ").ToList();

    return new HashSet<long>(splitInputTxt.ConvertAll(s => Int64.Parse(s))).OrderBy(x => x).ToList();
}

static List<long> largeOutputFileTransfer()
{
    var outputTxt = File.ReadAllText(@"C:\Users\Dell5501-1\source\repos\ClimbingTheLeaderboard\ClimbingTheLeaderboard\output06.txt");
    var splitOutputTxt = Regex.Replace(outputTxt, @"\t|\n|\r", " ")
        .Split(" ").ToList();

    return new HashSet<long>(splitOutputTxt.ConvertAll(s => Int64.Parse(s))).ToList();
}

static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
{
    // Terminated due to timeout :(
    var rankedList = largeInputFileTransfer();
    var playerList = largeOutputFileTransfer();

    // Congratulations!
    //var rankedList = new HashSet<int>(ranked).OrderBy(x => x).Reverse().ToArray();

    return playerList.Select(x => rankedList.Count(y => y > x) + 1).ToList();
}

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
climbingLeaderboard(rankeds, players).ForEach(x => Console.WriteLine(x));
stopwatch.Stop();
Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);