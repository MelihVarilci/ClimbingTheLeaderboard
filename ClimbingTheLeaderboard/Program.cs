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
//List<int> rankeds = new()
//{
//    100,
//    100,
//    50,
//    40,
//    40,
//    20,
//    10
//};
//List<int> players = new()
//{
//    5,
//    25,
//    50,
//    120
//};

static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
{
    var inputTxt = File.ReadAllText(@"C:\Users\Dell5501-1\source\repos\ClimbingTheLeaderboard\ClimbingTheLeaderboard\input06.txt");
    var splitInputTxt = Regex.Replace(inputTxt, @"\t|\n|\r", "")
        .Split(" ").ToList();

    var outputTxt = File.ReadAllText(@"C:\Users\Dell5501-1\source\repos\ClimbingTheLeaderboard\ClimbingTheLeaderboard\output06.txt");
    var splitOutputTxt = Regex.Replace(outputTxt, @"\t|\n|\r", " ")
        .Split(" ").ToList();

    // Terminated due to timeout :(
    var rankedList = new HashSet<long>(splitInputTxt.ConvertAll(s => Int64.Parse(s))).OrderBy(x => x).ToList();
    var playerList = new HashSet<long>(splitOutputTxt.ConvertAll(s => Int64.Parse(s))).ToList();

    //var rankedList = new HashSet<int>(ranked).OrderBy(x => x).Reverse().ToList();

    // Collections
    List<int> result = new List<int>();
    Queue<int> resultQueue = new Queue<int>();
    Stack<int> resultStack = new Stack<int>();
    LinkedList<int> resultLinkedList = new LinkedList<int>();
    string stringResult = "";

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    playerList.ForEach(x =>
    {
        //result.Add(rankedList.Count(y => y > x) + 1); // 176095 ms
        //resultQueue.Enqueue(rankedList.Count(y => y > x) + 1); // 177710 ms
        //resultStack.Push(rankedList.Count(y => y > x) + 1); // 179206 ms
        resultLinkedList.AddLast(rankedList.Count(y => y > x) + 1); // 168004 ms
        //stringResult += (rankedList.Count(y => y > x) + 1).ToString() + " "; // 185789 ms
    }
    );
    stopwatch.Stop();

    Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

    return resultLinkedList.ToList();
}

climbingLeaderboard(rankeds, players).ForEach(x => Console.WriteLine(x));