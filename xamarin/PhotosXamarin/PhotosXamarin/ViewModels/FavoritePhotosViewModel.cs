using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PhotosXamarin.Models;
using PhotosXamarin.Services;
using Xamarin.Forms;

namespace PhotosXamarin.ViewModels
{
    public class FavoritePhotosViewModel : BaseViewModel
    {
        #region Private properties

        private readonly IPhotosService photosService;

        #endregion Private properties

        #region Public properties

        private ObservableCollection<Photo> favoritePhotos = new ObservableCollection<Photo>();
        public ObservableCollection<Photo> FavoritePhotos
        {
            get => favoritePhotos;
            set
            {
                favoritePhotos = value;
                OnPropertyChanged(nameof(FavoritePhotos));
            }
        }

        private bool loading = true;
        public bool Loading
        {
            get => loading;
            set
            {
                loading = value;
                OnPropertyChanged(nameof(Loading));
            }
        }

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

        public ICommand RefreshCommand { get; set; }
        public ICommand ShowPhotoDetailCommand { get; set; }

        #endregion Public properties

        #region ViewModel life-cycle

        public FavoritePhotosViewModel()
        {
            this.photosService = new PhotosService();

            this.RefreshCommand = new Command(async () => await this.GetFavoritePhotosAsync());
            this.ShowPhotoDetailCommand = new Command(async () => await this.ShowPhotoDetailAsync());
        }

        public async Task OnAppearing() => await GetFavoritePhotosAsync();

        #endregion ViewModel life-cycle

        #region Private methods

        private async Task GetFavoritePhotosAsync()
        {
            try
            {
                FavoritePhotos.Clear();
                Loading = true;
                var result = await this.photosService.GetFavoritePhotosLocalAsync();
                foreach (var photo in result)
                    FavoritePhotos.Add(photo);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
            }
            finally
            {
                Loading = false;
            }
        }

        private async Task ShowPhotoDetailAsync()
        {
            var navigationPage = new NavigationPage(new Views.PhotoDetailView(SelectedPhoto));
            navigationPage.BarBackgroundColor = Color.FromHex("#2A2A2A");
            navigationPage.BarTextColor = Color.FromHex("#FFFFFF");
            await this.Navigation.PushModalAsync(navigationPage);
        }

        #endregion Private methods
    }
}
