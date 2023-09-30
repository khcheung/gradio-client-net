#nullable disable

namespace Simple.GradioClient.ConfigModels
{
    public class Component
    {
        public int id { get; set; }
        public string type { get; set; }
        public Props props { get; set; }
        public string serializer { get; set; }
        public Api_Info api_info { get; set; }
        public Example_Inputs example_inputs { get; set; }
    }

}
