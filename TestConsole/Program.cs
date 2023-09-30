public class Program
{
    public static async Task Main(string[] args)
    {
        var client = new Simple.GradioClient.Client(new Uri("https://alexkhcheung-gradiotest.hf.space/"));
        var result1 = await client.PredictAsync("/namedyield", "Test");
        Console.WriteLine(result1[0]);
        var result2 = await client.PredictAsync(0, "Test");
        Console.WriteLine(result2[0]);
        //var result = await client.PredictAsync(1, "Test");
        //var result = await client.PredictAsync(2, "Test");
        //Console.WriteLine(result);
    }
}