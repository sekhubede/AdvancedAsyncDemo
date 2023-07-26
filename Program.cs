using System.Diagnostics;
using AdvancedAsyncDemo;

bool running = true;

Initialize();

while (running)
{
    Console.Write("> ");
    Int32.TryParse(Console.ReadLine(), out int input);
    ProcessInput(input);
}

Console.WriteLine();
Console.WriteLine("Press any key to exit.");
Console.ReadKey(true);
Environment.Exit(0);


void ExecuteSync()
{
    var watch = Stopwatch.StartNew();

    var results = DemoMethods.RunDownloadSync();
    PrintResults(results);

    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;

    Console.WriteLine($"Total execution time: {elapsedMs}");
}

async Task ExecuteAsync()
{
    var watch = Stopwatch.StartNew();

    var results = await DemoMethods.RunDownloadAsync();
    PrintResults(results);

    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;

    Console.WriteLine($"Total execution time: {elapsedMs}");
}

async Task ExecuteParallelAsync()
{
    var watch = Stopwatch.StartNew();

    var results = await DemoMethods.RunDownloadParallelAsync();
    PrintResults(results);

    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;

    Console.WriteLine($"Total execution time: {elapsedMs}");
}

void CancelOperation()
{
    throw new NotImplementedException();
}

void PrintResults(List<WebsiteDataModel> results)
{
    Console.Clear();
    foreach (var item in results)
    {
        Console.WriteLine($"{item.WebsiteUrl} downloaded: {item.WebsiteData.Length} characters long");
    }
}

void Initialize()
{
    Console.Title = "Simple Async Demo App V.1.0.0";

    PrintHeader();

    PrintHelp();
}

void PrintHeader()
{
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Welcome to the Async/Await Demo");
    Console.WriteLine("Type \"0\" for available commands.");
    Console.WriteLine("----------------------------------");
}

void ProcessInput(int input)
{
    switch (input)
    {
        case 0:
            PrintHelp();
            break;
        case 1:
            ExecuteSync();
            break;
        case 2:
            ExecuteAsync();
            break;
        case 3:
            ExecuteParallelAsync();
            break;
        case 4:
            CancelOperation();
            break;
        default:
            PrintInvalidCommand();
            break;
    }
}

void PrintHelp()
{
    Console.WriteLine("\tAvailable Commands:");
    Console.WriteLine("\t1 - Normal Execute");
    Console.WriteLine("\t2 - Async Execute");
    Console.WriteLine("\t3 - Async Parallel Execute");
    Console.WriteLine("\t4 - Cancel Operation");
    Console.WriteLine();
}

void PrintInvalidCommand()
{
    Console.WriteLine();
    Console.WriteLine("Command not recognized, please try again.");
    Console.WriteLine("Type \"0\" for available commands.");
    Console.WriteLine();
}