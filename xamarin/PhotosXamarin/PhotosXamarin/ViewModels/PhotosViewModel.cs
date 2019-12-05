using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmHelpers.Commands;
using PhotosXamarin.Views;
using Xamarin.Forms;

namespace PhotosXamarin.ViewModels
{
    public class PhotosViewModel : BasePhotosViewModel
    {
        #region ViewModel life-cycle

        public PhotosViewModel()
        {
            this.RefreshCommand = new AsyncCommand(async () => await this.GetPhotosAsync(), (_) => !this.Loading);
            this.ShowPhotoDetailCommand = new AsyncCommand(async () => await this.ShowPhotoDetailAsync());
        }

        public override async Task OnAppearing() => await GetPhotosAsync();

        #endregion ViewModel life-cycle

        #region Private methods

        private async Task GetPhotosAsync()
        {
            try
            {
                this.Loading = true;
                var result = await this.photosService.GetPhotosAsync();
                lock (this.Photos)
                {
                    this.Photos.Clear();
                    foreach (var photo in result)
                        this.Photos.Add(photo);
                }
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
            var navigationPage = new NavigationPage(new PhotoDetailView(SelectedPhoto, false));
            navigationPage.BarBackgroundColor = Color.FromHex("#2A2A2A");
            navigationPage.BarTextColor = Color.FromHex("#FFFFFF");
            await this.Navigation.PushModalAsync(navigationPage);
        }

        #endregion Private methods
    }
}
