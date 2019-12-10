using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmHelpers.Commands;
using PhotosXamarin.Models;
using PhotosXamarin.Services;

namespace PhotosXamarin.ViewModels
{
    public class PhotosViewModel : BasePhotosViewModel
    {
        #region ViewModel life-cycle

        public PhotosViewModel(IPhotosService photosService, INavigationService navigationService) : base(photosService, navigationService)
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
                this.Photos.ReplaceRange(result);
            }
            catch (Exception ex)
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
            var navParameter = new PhotoDetailNavParameter
            {
                SelectedPhoto = SelectedPhoto,
                IsFavoritePhoto = false
            };

            await this.navigationService.NavigateToModalAsync<PhotoDetailViewModel>(navParameter);
        }

        #endregion Private methods
    }

    public class PhotoDetailNavParameter
    {
        public Photo SelectedPhoto { get; set; }
        public bool IsFavoritePhoto { get; set; }
    }
}
