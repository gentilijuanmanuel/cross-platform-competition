using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using PhotosXamarin.Services;
using PhotosXamarin.ViewModels;

namespace PhotosXamarin.IoC
{
    public sealed class Bootstrap
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PhotosViewModel>().SingleInstance();
            builder.RegisterType<PhotoDetailViewModel>().SingleInstance();
            builder.RegisterType<FavoritePhotosViewModel>().SingleInstance();

            builder.RegisterType<PhotosService>().As<IPhotosService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            var container = builder.Build();
            var serviceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }
    }
}
