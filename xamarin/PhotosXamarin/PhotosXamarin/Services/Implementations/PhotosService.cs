using System.Collections.Generic;
using System.Threading.Tasks;
using PhotosXamarin.Models;

namespace PhotosXamarin.Services
{
    public class PhotosService : IPhotosService
    {
        public Task<IEnumerable<Photo>> GetPhotosAsync(string url = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Photo>> GetFavoritePhotosAsync(string url = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
