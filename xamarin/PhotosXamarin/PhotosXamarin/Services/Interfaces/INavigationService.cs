using System.Threading.Tasks;
using PhotosXamarin.ViewModels;

namespace PhotosXamarin.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task NavigateToModalAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToModalAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task CloseModalAsync();
        Task DisplayAlertAsync(string title, string message, string cancelOption);
    }
}
