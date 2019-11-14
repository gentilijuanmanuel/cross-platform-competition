using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PhotosXamarin.Helpers;
using PhotosXamarin.Models;
using PhotosXamarin.Rest;

namespace PhotosXamarin.Services
{
    public class PhotosService : IPhotosService
    {
        private readonly IRestClient restClient;

        private const string URL_SUFFIX = "photos";

        public PhotosService()
        {
            this.restClient = new RestClient();
        }

        public Task<IEnumerable<Photo>> GetPhotosAsync(string url = null)
        {
            return this.restClient.MakeApiCall<IEnumerable<Photo>>($"{Constants.BASE_URL}{URL_SUFFIX}", HttpMethod.Get);
        }

        public Task<IEnumerable<Photo>> GetFavoritePhotosAsync(string url = null)
        {
            // TODO: Get local favorite photos
            return null;
        }
    }
}
