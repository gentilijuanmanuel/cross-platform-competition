using System.ComponentModel;
using System.Runtime.CompilerServices;
using PhotosXamarin.Services;
using Xamarin.Forms;

namespace PhotosXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
