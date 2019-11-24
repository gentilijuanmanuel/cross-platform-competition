using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PhotosXamarin.Models;
using PhotosXamarin.Services;
using Xamarin.Forms;

namespace PhotosXamarin.ViewModels
{
    public class PhotosViewModel : BaseViewModel
    {
        #region Private properties

        private readonly IPhotosService photosService;

        #endregion

        #region Public properties

        private ObservableCollection<Photo> photos;
        public ObservableCollection<Photo> Photos
        {
            get => photos;
            set
            {
                photos = value;
                OnPropertyChanged(nameof(Photos));
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

        public PhotosViewModel()
        {
            this.photosService = new PhotosService();
            this.RefreshCommand = new Command(async () => await this.GetPhotosAsync());
            this.ShowPhotoDetailCommand = new Command(async () => await this.ShowPhotoDetailAsync());
        }

        public override async Task OnAppearing() => await GetPhotosAsync();

        #endregion ViewModel life-cycle

        #region Private methods

        private async Task GetPhotosAsync()
        {
            try
            {
                this.Photos = new ObservableCollection<Photo>();
                Loading = true;
                var result = await this.photosService.GetPhotosAsync();
                foreach (var photo in result)
                    Photos.Add(photo);
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

        private async Task ShowPhotoDetailAsync() => await this.Navigation.PushModalAsync(new NavigationPage(new Views.PhotoDetailView(SelectedPhoto)));

        #endregion Private methods
    }
}
