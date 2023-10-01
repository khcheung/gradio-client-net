using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using Simple.GradioClient.ConfigModels;
using Simple.GradioClient.WebsocketModels;
using System.Runtime.InteropServices;

namespace Simple.GradioClient
{
    public class Client
    {
        private Uri mHost = null!;
        private HttpClient mHttpClient = null!;
        private Boolean mLoadConfig = false;
        private Config mConfig = null!;


        public Client(Uri gradioHost)
        {
            this.mHost = gradioHost;
        }
        public async Task LoadConfigAsync()
        {
            this.mHttpClient = new HttpClient();
            mHttpClient.BaseAddress = mHost;

            var response = await mHttpClient.GetAsync("/config");
            this.mConfig = (await response.Content.ReadFromJsonAsync<Config>())!;
            if (mConfig == null)
            {
                throw new Exception("Load Config Fail.");
            }
            this.mLoadConfig = true;
        }

        public async Task<String[]> PredictAsync(String apiName, params String[] parameters)
        {        
            var apiIndex = await FindFunctionIndex(apiName);
            return await PredictAsync(apiIndex, parameters);
        }

        public async Task<T> PredictAsync<T>(String apiName, params String[] parameters)
        {
            var apiIndex = await FindFunctionIndex(apiName);
            return await PredictAsync<T>(apiIndex, parameters);
        }

        private async Task<Int32> FindFunctionIndex(String apiName)
        {
            // Load Config if not Loaded
            if (mLoadConfig == false)
            {
                await LoadConfigAsync();
            }

            var api = this.mConfig.dependencies.Where(d => d.api_name == apiName).FirstOrDefault();
            if (api == null)
            {
                if (apiName.StartsWith("/"))
                {
                    // Try Remove "/"
                    apiName = apiName.Substring(1);
                    api = this.mConfig.dependencies.Where(d => d.api_name == apiName).FirstOrDefault();
                }
            }

            if (api == null)
            {
                throw new Exception("API Not Found");
            }

            var apiIndex = this.mConfig.dependencies.IndexOf(api);
            return apiIndex;
        }

        public async Task<String[]> PredictAsync(Int32 fnIndex, params String[] parameters)
        {
            // Load Config if not Loaded
            if (mLoadConfig == false)
            {
                await LoadConfigAsync();
            }

            if (fnIndex >= this.mConfig.dependencies.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(fnIndex));
            }
            

            var webSocket = new ClientWebSocket();
            var webSocketUriString = "";
            if (mHost.Scheme == "http")
            {
                webSocketUriString = $"ws://{mHost.Host}:{mHost.Port}/queue/join";
            }
            else if (mHost.Scheme == "https")
            {
                webSocketUriString = $"wss://{mHost.Host}:{mHost.Port}/queue/join";
            }
            else
            {
                throw new Exception("Unknown Scheme");
            }
            await webSocket.ConnectAsync(new Uri(webSocketUriString), CancellationToken.None);

            var result = await Task.Run(async () =>
            {
                String[] output = null!;
                var buffer = new byte[65536];
                //var step = 0;
                var session = Guid.NewGuid().ToString().ToLower();
                while (webSocket.State == WebSocketState.Open)
                {

                    var r = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                    if (r.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);

                    }
                    else
                    {
                        var inMsg = Encoding.UTF8.GetString(buffer, 0, r.Count);
                        //Console.WriteLine($"In: {inMsg}");
                        var inMsgObj = Newtonsoft.Json.JsonConvert.DeserializeObject<WebSocketInMsgBase>(inMsg)!;
                        switch (inMsgObj.msg)
                        {
                            case "send_hash":
                                var obj1 = new
                                {
                                    fn_index = fnIndex,
                                    session_hash = session
                                };
                                var obj1String = System.Text.Json.JsonSerializer.Serialize(obj1);
                                //Console.WriteLine($"Out: {obj1String}");
                                var obj1Buffer = Encoding.UTF8.GetBytes(obj1String);
                                await webSocket.SendAsync(obj1Buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                                break;
                            case "send_data":
                                var objData = new
                                {
                                    data = parameters,
                                    fn_index = fnIndex,
                                    session_hash = session
                                };
                                var obj4String = System.Text.Json.JsonSerializer.Serialize(objData);
                                //Console.WriteLine($"Out: {obj4String}");
                                var obj4Buffer = Encoding.UTF8.GetBytes(obj4String);
                                await webSocket.SendAsync(obj4Buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                                break;
                            case "process_completed":
                                var processCompleted = Newtonsoft.Json.JsonConvert.DeserializeObject<WebSocketProcessCompleted>(inMsg)!;
                                if (processCompleted.output.data != null && processCompleted.output.data.Length > 0)
                                {
                                    output = processCompleted.output.data;
                                }
                                else
                                {
                                    // ToDo: Output RawMessage
                                    output = new[] { inMsg };
                                }
                                break;
                        }
                    }
                }

                return output;
            })!;
            return result;
        }
        
        public async Task<T> PredictAsync<T>(Int32 fnIndex, params String[] parameters)
        {
            T result = default(T)!;
            var predictResult = await PredictAsync(fnIndex, parameters);
            if (predictResult != null && predictResult.Length > 0)
            {
                var jsonString = predictResult[0];
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString)!;
            }
            return result;

        }

     
    }



}