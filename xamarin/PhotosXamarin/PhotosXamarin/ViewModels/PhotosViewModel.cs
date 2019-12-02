using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace PhotosXamarin.ViewModels
{
    public class PhotosViewModel : BasePhotosViewModel
    {
        #region ViewModel life-cycle

        public PhotosViewModel()
        {
            this.RefreshCommand = new Command(async () => await this.GetPhotosAsync());
            this.ShowPhotoDetailCommand = new Command(async () => await this.ShowPhotoDetailAsync());
        }

        public override async Task OnAppearing() => await GetPhotosAsync();

        #endregion ViewModel life-cycle

        #region Private methods

        private async Task GetPhotosAsync()
        {
            try
            {
                Loading = true;
                Photos.Clear();
                var result = await this.photosService.GetPhotosAsync();
                foreach (var photo in result)
                    Photos.Add(photo);
            }
            catch (System.Exception ex)
            {
                UserDialogs.Instance.Toast("Cannot get photos. Please try again.");
            }
            finally
            {
                Loading = false;
            }
        }

        private async Task ShowPhotoDetailAsync()
        {
            var navigationPage = new NavigationPage(new Views.PhotoDetailView(SelectedPhoto, false));
            navigationPage.BarBackgroundColor = Color.FromHex("#2A2A2A");
            navigationPage.BarTextColor = Color.FromHex("#FFFFFF");
            await this.Navigation.PushModalAsync(navigationPage);
        }

        #endregion Private methods
    }
}
