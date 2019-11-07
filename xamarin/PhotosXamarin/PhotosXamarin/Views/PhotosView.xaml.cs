using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Views
{
    public partial class PhotosView : ContentPage
    {
        public PhotosView()
        {
            InitializeComponent();
            this.BindingContext = new PhotosViewModel();
        }
    }
}
