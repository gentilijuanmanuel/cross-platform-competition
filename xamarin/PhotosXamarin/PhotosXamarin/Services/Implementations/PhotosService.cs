using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PhotosXamarin.DTO;
using PhotosXamarin.Helpers;
using PhotosXamarin.Models;
using PhotosXamarin.Rest;

namespace PhotosXamarin.Services
{
    public class PhotosService : IPhotosService
    {
        private readonly IRestClient restClient;

        private const string URL_SUFFIX = "search/photos?query=star%20wars";

        public PhotosService()
        {
            this.restClient = new RestClient();
        }

        public Task<PhotosDTO> GetPhotosAsync(string url = null)
        {
            var photosTask = this.restClient.MakeApiCall<PhotosDTO>($"{Constants.BASE_URL}{URL_SUFFIX}", HttpMethod.Get);

            foreach (var photo in photosTask.Result.Results)
            {
                photo.UserFirstName = photo.User.FirstName;
                photo.Path = photo.Urls.Regular;
            }

            return photosTask;
        }

        public async Task<List<Photo>> GetFavoritePhotosLocalAsync()
        {
            return await App.Database.GetFavoritePhotosAsync();
        }

        public async Task SaveFavoritePhotoLocalAsync(Photo photo)
        {
            await App.Database.SaveFavoritePhotoAsync(photo);
        }

        public async Task DeleteFavoritePhotoLocalAsync(Photo photo)
        {
            await App.Database.DeleteFavoritePhotoAsync(photo);
        }
    }
}
