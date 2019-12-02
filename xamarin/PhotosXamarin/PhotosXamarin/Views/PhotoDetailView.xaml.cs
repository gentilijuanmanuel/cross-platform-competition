using PhotosXamarin.Models;
using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Views
{
    public partial class PhotoDetailView : ContentPage
    {
        private readonly PhotoDetailViewModel photoDetailViewModel;

        public PhotoDetailView(Photo selectedPhoto, bool isFavoritePhoto)
        {
            InitializeComponent();
            this.BindingContext = this.photoDetailViewModel = new PhotoDetailViewModel();
            this.photoDetailViewModel.SelectedPhoto = selectedPhoto;
            this.photoDetailViewModel.IsFavoritePhoto = isFavoritePhoto;
            this.photoDetailViewModel.Navigation = this.Navigation;
        }
    }
}
