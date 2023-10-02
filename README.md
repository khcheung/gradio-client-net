# gradio-client-net
Gradio Client (.NET)

## Experimental Client
Only support text in and text out.


## Testing Gradio API on HuggingFace Space
Url: https://huggingface.co/spaces/alexkhcheung/gradiotest
```python
import gradio as gr

def greet_return(name):
    return "Hello " + name + "!!"
...
with gr.Blocks() as iface:    
    with gr.Row():
        inp = gr.Textbox(placeholder="Name Return")
        out = gr.Textbox()
    btn = gr.Button("Run")
    btn.click(fn=greet_return, inputs=inp, outputs=out)
...
iface.queue().launch()
```

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
