using System.Collections.Specialized;
using Newtonsoft.Json;
using SQLite;

namespace PhotosXamarin.Models
{
    public class Photo : INotifyCollectionChanged
    {
        [JsonProperty("id")]
        [PrimaryKey]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("alt_description")]
        public string AltDescription { get; set; }

        [JsonProperty("urls")]
        [Ignore]
        public Url Urls { get; set; }

        [JsonProperty("user")]
        [Ignore]
        public User User { get; set; }

        [JsonProperty("likes")]        
        public int Likes { get; set; }

        // Local db properties

        [JsonIgnore]
        public string Path { get; set; }

        [JsonIgnore]
        public string UserFirstName { get; set; }

        [JsonIgnore]
        public string LocalDescription { get; set; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
