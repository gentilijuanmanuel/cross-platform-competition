using CommonServiceLocator;
using PhotosXamarin.ViewModels;

namespace PhotosXamarin.IoC
{
    public class ViewModelLocator
    {
        public PhotosViewModel PhotosViewModel
        {
            get => ServiceLocator.Current.GetInstance<PhotosViewModel>();
        }

        public FavoritePhotosViewModel FavoritePhotosViewModel
        {
            get => ServiceLocator.Current.GetInstance<FavoritePhotosViewModel>();
        }

        public PhotoDetailViewModel PhotoDetailViewModel
        {
            get => ServiceLocator.Current.GetInstance<PhotoDetailViewModel>();
        }

        static ViewModelLocator()
        {
            Bootstrap.Initialize();
        }
    }
}
