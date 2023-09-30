# gradio-client-net
Gradio Client (.NET)

## Experimental Client
Only support text in and text out.


## Testing on HuggingFace Space
Url: https://huggingface.co/spaces/alexkhcheung/gradiotest


## Sample Code

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var client = new Simple.GradioClient.Client(new Uri("https://alexkhcheung-gradiotest.hf.space/"));
        var result1 = await client.PredictAsync("/namedyield", "Test");
        Console.WriteLine(result1);
        var result2 = await client.PredictAsync(0, "Test");
        Console.WriteLine(result2);
    }
}
```
