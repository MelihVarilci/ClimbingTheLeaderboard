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
    7,
    6,
    5,
    1
};
List<int> players = new()
{
    5,
    8,
    25,
    50,
    100,
    120
};

static long[] largeInputFileTransfer()
{
    var inputTxt = File.ReadAllText(@"C:\Users\Dell5501-1\source\repos\ClimbingTheLeaderboard\ClimbingTheLeaderboard\input06.txt");
    var splitInputTxt = Regex.Replace(inputTxt, @"\t|\n|\r", "")
        .Split(" ").ToList();

    return new HashSet<long>(splitInputTxt.ConvertAll(s => Int64.Parse(s))).OrderBy(x => x).ToArray();
}

static List<long> largeOutputFileTransfer()
{
    var outputTxt = File.ReadAllText(@"C:\Users\Dell5501-1\source\repos\ClimbingTheLeaderboard\ClimbingTheLeaderboard\output06.txt");
    var splitOutputTxt = Regex.Replace(outputTxt, @"\t|\n|\r", " ")
        .Split(" ").ToList();

    return new HashSet<long>(splitOutputTxt.ConvertAll(s => Int64.Parse(s))).ToList();
}

static int binarySearch(long[] arr, long x)
{
    int l = 0, r = arr.Length - 1;
    while (l <= r)
    {
        int m = l + (r - l) / 2;

        // Check if x is present at mid
        if (arr[m] == x)
            return m;

        // If x greater, ignore left half
        if (arr[m] < x)
            r = m - 1;

        // If x is smaller, ignore right half
        else
            l = m + 1;
        //r = m - 1;
    }

    // if we reach here, then element was
    // not present
    return r + 1;
}

static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
{
    // Terminated due to timeout :(
    var rankedArray = largeInputFileTransfer();
    var playerList = largeOutputFileTransfer();

    // Congratulations!
    //var rankedList = new HashSet<int>(ranked).OrderBy(x => x).Reverse().ToArray();

    // Linear Search
    //return playerList.Select(x => rankedList.Count(y => y > x) + 1).ToList();

    // Binary Search
    return playerList.Select(x => binarySearch(rankedArray, x))
        .Select(y => y + 1)
        .ToList();
}

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
climbingLeaderboard(rankeds, players).ForEach(x => Console.WriteLine(x));
stopwatch.Stop();
Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);