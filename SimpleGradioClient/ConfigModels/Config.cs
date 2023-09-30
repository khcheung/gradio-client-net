using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
