using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MvvmHelpers.Commands;
using PhotosXamarin.Models;
using PhotosXamarin.Services;

namespace PhotosXamarin.ViewModels
{
    public class PhotoDetailViewModel : BaseViewModel
    {
        #region Public properties

        Photo selectedPhoto;
        public Photo SelectedPhoto
        {
            get => selectedPhoto;
            set
            {
                selectedPhoto = value;
                OnPropertyChanged(nameof(SelectedPhoto));
            }
        }

        bool isFavoritePhoto;
        public bool IsFavoritePhoto
        {
            get => isFavoritePhoto;
            set
            {
                isFavoritePhoto = value;
                OnPropertyChanged(nameof(IsFavoritePhoto));
            }
        }

        public ICommand ClosePhotoDetailCommand { get; private set; }
        public ICommand AddPhotoToFavoriteCommand { get; private set; }
        public ICommand RemoveFavoritePhotoCommand { get; private set; }

        #endregion Public properties

        #region ViewModel life-cycle

        public PhotoDetailViewModel(IPhotosService photosService, INavigationService navigationService) : base(photosService, navigationService)
        {
            this.ClosePhotoDetailCommand = new AsyncCommand(async () => await this.navigationService.CloseModalAsync());
            this.AddPhotoToFavoriteCommand = new AsyncCommand(async () => await this.SavePhotoToFavorites());
            this.RemoveFavoritePhotoCommand = new AsyncCommand(async () => await this.RemoveFavoritePhoto());
        }

        public override Task InitializeAsync(object navigationData)
        {
            UserDialogs.Instance.ShowLoading();

            var parameter = (PhotoDetailNavParameter)navigationData;

            SelectedPhoto = parameter.SelectedPhoto;
            IsFavoritePhoto = parameter.IsFavoritePhoto;
            UserDialogs.Instance.HideLoading();

            return base.InitializeAsync(navigationData);
        }

        #endregion ViewModel life-cycle

        #region Private methods

        private async Task SavePhotoToFavorites()
        {
            try
            {
                await this.photosService.SaveFavoritePhotoLocalAsync(SelectedPhoto);
                UserDialogs.Instance.Toast("Saved to favorites!");
                await this.navigationService.CloseModalAsync();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Toast("Cannot save photo. Please try again.");
            }
        }

        private async Task RemoveFavoritePhoto()
        {
            try
            {
                await this.photosService.DeleteFavoritePhotoLocalAsync(SelectedPhoto);
                UserDialogs.Instance.Toast("Deleted photo!");
                await this.navigationService.CloseModalAsync();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Toast("Cannot delete favorite photo. Please try again.");
            }
        }

        #endregion Private methods
    }
}
