using System.Collections.Generic;
using Newtonsoft.Json;
using PhotosXamarin.Models;

namespace PhotosXamarin.DTO
{
    public class PhotosDTO
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("results")]
        public IEnumerable<Photo> Results { get; set; }
    }
}
