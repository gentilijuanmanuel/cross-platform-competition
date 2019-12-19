using CommonServiceLocator;
using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Views
{
    public partial class PhotosView : ContentPage
    {
        public PhotosView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vm = ServiceLocator.Current.GetInstance<PhotosViewModel>();
            await vm.OnAppearing();
        }
    }
}
