public class Program
{
    public static async Task Main(string[] args)
    {
        var client = new Simple.GradioClient.Client(new Uri("https://alexkhcheung-gradiotest.hf.space/"));
        var result1 = await client.PredictAsync("/namedyield", "Test");
        Console.WriteLine(result1[0]);
        var result2 = await client.PredictAsync(0, "Test");
        Console.WriteLine(result2[0]);
        var result3 = await client.PredictAsync<double[]>("/dummyvector", "Test");
        Console.WriteLine(result3);        
    }
}