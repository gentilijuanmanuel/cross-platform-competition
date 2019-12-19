using System.Collections.Generic;
using System.Threading.Tasks;
using PhotosXamarin.DTO;
using PhotosXamarin.Models;

namespace PhotosXamarin.Services
{
    public interface IPhotosService
    {
        Task<PhotosDTO> GetPhotosAsync(string url = null);

        Task<List<Photo>> GetFavoritePhotosLocalAsync();

        Task SaveFavoritePhotoLocalAsync(Photo photo);

        Task DeleteFavoritePhotoLocalAsync(Photo photo);
    }
}
