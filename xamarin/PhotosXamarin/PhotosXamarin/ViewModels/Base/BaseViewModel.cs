using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PhotosXamarin.Services;

namespace PhotosXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public readonly IPhotosService photosService;

        public readonly INavigationService navigationService;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BaseViewModel(IPhotosService photosService, INavigationService navigationService)
        {
            this.photosService = photosService;
            this.navigationService = navigationService;
        }

        public virtual async Task OnAppearing()
        {
        }

        public virtual async Task OnDissapearing()
        {
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
