using Newtonsoft.Json;

namespace PhotosXamarin.Models
{
    public class Photo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("alt_description")]
        public string AltDescription { get; set; }

        [JsonProperty("urls")]
        public Url Urls { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }
    }
}
