﻿using System.Threading.Tasks;
using PhotosXamarin.Services;

namespace PhotosXamarin.ViewModels
{
    public class PhotosViewModel : BaseViewModel
    {
        private readonly IPhotosService photosService;

        public PhotosViewModel()
        {
            this.photosService = new PhotosService();
        }

        public async Task OnAppearing()
        {
            // Make API call
        }
    }
}
