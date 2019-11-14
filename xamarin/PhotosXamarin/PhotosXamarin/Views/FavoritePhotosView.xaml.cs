using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Views
{
    public partial class FavoritePhotosView : ContentPage
    {
        private readonly FavoritePhotosViewModel favoritePhotosViewModel;

        public FavoritePhotosView()
        {
            InitializeComponent();
            this.BindingContext = this.favoritePhotosViewModel = new FavoritePhotosViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.favoritePhotosViewModel.OnAppearing();
        }
    }
}
