using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Views
{
    public partial class FavoritePhotosView : ContentPage
    {
        public FavoritePhotosView()
        {
            InitializeComponent();
            this.BindingContext = new FavouritePhotosViewModel();
        }
    }
}
