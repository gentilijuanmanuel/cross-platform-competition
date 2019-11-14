using System.Threading.Tasks;
using PhotosXamarin.Services;

namespace PhotosXamarin.ViewModels
{
    public class FavoritePhotosViewModel : BaseViewModel
    {
        private readonly IPhotosService photosService;

        public FavoritePhotosViewModel()
        {
            this.photosService = new PhotosService();
        }

        public async Task OnAppearing()
        {
            // Make API call
        }
    }
}
