namespace Simple.GradioClient.ConfigModels
{
    public class Dependency
    {
        public List<object[]> targets { get; set; }
        public string trigger { get; set; }
        public int?[] inputs { get; set; }
        public int?[] outputs { get; set; }
        public bool backend_fn { get; set; }
        public string js { get; set; }
        public bool? queue { get; set; }
        public string api_name { get; set; }
        public bool scroll_to_output { get; set; }
        public string show_progress { get; set; }
        public object every { get; set; }
        public bool batch { get; set; }
        public int max_batch_size { get; set; }
        public int?[] cancels { get; set; }
        public Types types { get; set; }
        public bool collects_event_data { get; set; }
        public int? trigger_after { get; set; }
        public bool trigger_only_on_success { get; set; }
    }

}
