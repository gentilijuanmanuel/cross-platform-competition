using Newtonsoft.Json;

namespace PhotosXamarin.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }
    }
}
