﻿using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace PhotosXamarin.ViewModels
{
    public class FavoritePhotosViewModel : BasePhotosViewModel
    {
        #region ViewModel life-cycle

        public FavoritePhotosViewModel()
        {
            this.RefreshCommand = new Command(async () => await this.GetFavoritePhotosAsync());
            this.ShowPhotoDetailCommand = new Command(async () => await this.ShowPhotoDetailAsync());
        }

        public async Task OnAppearing() => await GetFavoritePhotosAsync();

        #endregion ViewModel life-cycle

        #region Private methods

        private async Task GetFavoritePhotosAsync()
        {
            try
            {
                Loading = true;
                var result = await this.photosService.GetFavoritePhotosLocalAsync();
                lock (Photos)
                {
                    Photos.Clear();
                    foreach (var photo in result)
                        Photos.Add(photo);
                }
            }
            catch (System.Exception ex)
            {
                UserDialogs.Instance.Toast("Cannot get favorite photos. Please try again.");
            }
            finally
            {
                Loading = false;
            }
        }

        private async Task ShowPhotoDetailAsync()
        {
            var navigationPage = new NavigationPage(new Views.PhotoDetailView(SelectedPhoto, true));
            navigationPage.BarBackgroundColor = Color.FromHex("#2A2A2A");
            navigationPage.BarTextColor = Color.FromHex("#FFFFFF");
            await this.Navigation.PushModalAsync(navigationPage);
        }

        #endregion Private methods
    }
}
