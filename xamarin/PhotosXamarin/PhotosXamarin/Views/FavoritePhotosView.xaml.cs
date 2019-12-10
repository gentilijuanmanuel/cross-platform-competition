using CommonServiceLocator;
using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Views
{
    public partial class FavoritePhotosView : ContentPage
    {
        public FavoritePhotosView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vm = ServiceLocator.Current.GetInstance<FavoritePhotosViewModel>();
            await vm.OnAppearing();
        }
    }
}
