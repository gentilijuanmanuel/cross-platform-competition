using System.Windows.Input;
using MvvmHelpers;
using PhotosXamarin.Models;
using PhotosXamarin.Services;

namespace PhotosXamarin.ViewModels
{
    public class BasePhotosViewModel : BaseViewModel
    {
        #region Public properties

        private ObservableRangeCollection<Photo> photos = new ObservableRangeCollection<Photo>();
        public ObservableRangeCollection<Photo> Photos
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

        public BasePhotosViewModel(IPhotosService photosService, INavigationService navigationService) : base(photosService, navigationService)
        {
        }
    }
}
