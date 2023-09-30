#nullable disable

namespace Simple.GradioClient.ConfigModels
{
    public class Props
    {
        public bool show_label { get; set; }
        public bool container { get; set; }
        public string name { get; set; }
        public object visible { get; set; }
        public object value { get; set; }
        public bool rtl { get; set; }
        public string variant { get; set; }
        public bool interactive { get; set; }
        public string type { get; set; }
        public bool equal_height { get; set; }
        public int scale { get; set; }
        public int min_width { get; set; }
        public string elem_id { get; set; }
        public bool open { get; set; }
        public string label { get; set; }
        public string[] choices { get; set; }
        public string file_count { get; set; }
        public string[] file_types { get; set; }
        public bool selectable { get; set; }
        public string[] elem_classes { get; set; }
        public int lines { get; set; }
        public int max_lines { get; set; }
        public bool autofocus { get; set; }
        public bool show_copy_button { get; set; }
        public bool multiselect { get; set; }
        public bool allow_custom_value { get; set; }
        public string placeholder { get; set; }
        public string size { get; set; }
        public Latex_Delimiters[] latex_delimiters { get; set; }
        public int height { get; set; }
        public bool show_share_button { get; set; }
        public int[] headers { get; set; }
        public string[] datatype { get; set; }
        public object[] row_count { get; set; }
        public object[] col_count { get; set; }
        public int max_rows { get; set; }
        public string overflow_row_behaviour { get; set; }
        public bool wrap { get; set; }
        public string info { get; set; }
        public float minimum { get; set; }
        public float maximum { get; set; }
        public float step { get; set; }
    }

}
