using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using PhotosXamarin.Models;
using PhotosXamarin.Services;
using Xamarin.Forms;

namespace PhotosXamarin.ViewModels
{
    public class PhotoDetailViewModel : BaseViewModel
    {
        #region Private properties

        private readonly IPhotosService photosService;

        #endregion

        #region Public properties

        Photo selectedPhoto;
        public Photo SelectedPhoto
        {
            get => selectedPhoto;
            set
            {
                selectedPhoto = value;
                OnPropertyChanged(nameof(SelectedPhoto));
            }
        }

        public ICommand ClosePhotoDetailCommand { get; set; }
        public ICommand AddPhotoToFavoriteCommand { get; set; }

        #endregion Public properties

        #region ViewModel life-cycle

        public PhotoDetailViewModel()
        {
            this.photosService = new PhotosService();

            this.ClosePhotoDetailCommand = new Command(async () => await this.Navigation.PopModalAsync());
            this.AddPhotoToFavoriteCommand = new Command(async () => await this.SavePhotoToFavorites());
        }

        #endregion ViewModel life-cycle

        #region Private methods

        private async Task SavePhotoToFavorites()
        {
            try
            {
                await this.photosService.SaveFavoritePhotoLocalAsync(SelectedPhoto);
                UserDialogs.Instance.Toast("Saved to favourites!");
                await this.Navigation.PopModalAsync();
            }
            catch (System.Exception ex)
            {
                UserDialogs.Instance.Toast("Cannot save photo. Please try again.");
            }
        }

        #endregion Private methods
    }
}
