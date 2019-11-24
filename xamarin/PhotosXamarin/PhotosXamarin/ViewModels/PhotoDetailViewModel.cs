using System.Windows.Input;
using PhotosXamarin.Models;
using Xamarin.Forms;

namespace PhotosXamarin.ViewModels
{
    public class PhotoDetailViewModel : BaseViewModel
    {
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

        #endregion Public properties

        #region ViewModel life-cycle

        public PhotoDetailViewModel()
        {
            this.ClosePhotoDetailCommand = new Command(async () => await this.Navigation.PopModalAsync());
        }

        #endregion ViewModel life-cycle

        #region Private methods

        #endregion Private methods
    }
}
