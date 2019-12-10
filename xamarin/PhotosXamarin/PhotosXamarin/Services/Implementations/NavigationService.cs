using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Services
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null, false);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter, false);
        }

        public Task NavigateToModalAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null, true);
        }

        public Task NavigateToModalAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter, true);
        }

        public async Task CloseModalAsync()
        {
            var navigationPage = Application.Current.MainPage.Navigation;

            await navigationPage.PopModalAsync();
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter, bool isModal)
        {
            Page page = CreatePage(viewModelType, parameter);

            var navigationPage = Application.Current.MainPage.Navigation;
            if (navigationPage != null)
            {
                if (isModal)
                {
                    var nav = new NavigationPage(page);
                    nav.BarBackgroundColor = Color.FromHex("#2A2A2A");
                    nav.BarTextColor = Color.FromHex("#FFFFFF");

                    await navigationPage.PushModalAsync(nav);
                }
                else
                    await navigationPage.PushAsync(page);
            }
            else
                Application.Current.MainPage = page;

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
