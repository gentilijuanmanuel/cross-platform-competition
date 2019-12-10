using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmHelpers.Commands;
using PhotosXamarin.NavParameters;
using PhotosXamarin.Services;

namespace PhotosXamarin.ViewModels
{
    public class FavoritePhotosViewModel : BasePhotosViewModel
    {
        #region ViewModel life-cycle

        public FavoritePhotosViewModel(IPhotosService photosService, INavigationService navigationService) : base(photosService, navigationService)
        {
            this.RefreshCommand = new AsyncCommand(async () => await this.GetFavoritePhotosAsync(), (_) => !this.Loading);
            this.ShowPhotoDetailCommand = new AsyncCommand(async () => await this.ShowPhotoDetailAsync());
        }

        public override async Task OnAppearing() => await GetFavoritePhotosAsync();

        #endregion ViewModel life-cycle

        #region Private methods

        private async Task GetFavoritePhotosAsync()
        {
            try
            {
                this.Loading = true;
                var result = await this.photosService.GetFavoritePhotosLocalAsync();
                this.Photos.ReplaceRange(result);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Toast("Cannot get favorite photos. Please try again.");
            }
            finally
            {
                this.Loading = false;
            }
        }

        private async Task ShowPhotoDetailAsync()
        {
            var navParameter = new PhotoDetailNavParameter
            {
                SelectedPhoto = SelectedPhoto,
                IsFavoritePhoto = true
            };

            await this.navigationService.NavigateToModalAsync<PhotoDetailViewModel>(navParameter);
        }

        #endregion Private methods
    }
}
