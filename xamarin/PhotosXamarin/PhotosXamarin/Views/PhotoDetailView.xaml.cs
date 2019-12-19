using CommonServiceLocator;
using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Views
{
    public partial class PhotoDetailView : ContentPage
    {
        public PhotoDetailView()
        {
            InitializeComponent();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var vm = ServiceLocator.Current.GetInstance<PhotoDetailViewModel>();
            await vm.OnDissapearing();
        }
    }
}
