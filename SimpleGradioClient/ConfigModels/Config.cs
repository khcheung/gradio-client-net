#nullable disable

namespace Simple.GradioClient.ConfigModels
{
    public class Config
    {
        public string version { get; set; }
        public string mode { get; set; }
        public bool dev_mode { get; set; }
        public bool analytics_enabled { get; set; }
        public Component[] components { get; set; }
        public List<Dependency> dependencies { get; set; }

    }

}
