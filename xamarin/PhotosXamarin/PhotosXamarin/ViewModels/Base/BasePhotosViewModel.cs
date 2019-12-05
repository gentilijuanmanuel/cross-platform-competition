using System.Collections.ObjectModel;
using System.Windows.Input;
using PhotosXamarin.Models;
using PhotosXamarin.Services;

namespace PhotosXamarin.ViewModels
{
    public class BasePhotosViewModel : BaseViewModel
    {
        #region Private properties

        public readonly IPhotosService photosService;

        #endregion

        #region Public properties

        private ObservableCollection<Photo> photos = new ObservableCollection<Photo>();
        public ObservableCollection<Photo> Photos
        {
            get => photos;
            set
            {
                photos = value;
                OnPropertyChanged(nameof(Photos));
            }
        }

        private bool loading;
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

        public BasePhotosViewModel()
        {
            this.photosService = new PhotosService();
        }
    }
}
