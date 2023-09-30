public class Program
{
    public static async Task Main(string[] args)
    {
        var client = new Simple.GradioClient.Client(new Uri("https://alexkhcheung-gradiotest.hf.space/"));
        //var result = await client.PredictAsync("/namedyield", "Test");
        var result = await client.PredictAsync(0, "Test");
        //var result = await client.PredictAsync(1, "Test");
        //var result = await client.PredictAsync(2, "Test");
        Console.WriteLine(result);
    }
}