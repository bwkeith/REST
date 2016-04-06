using Newtonsoft.Json;

namespace WidgetsAPI.Models
{
    public class Widget
    {
        public string Description { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public string Metadata { get; set; }
    }
}
