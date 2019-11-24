﻿using PhotosXamarin.ViewModels;
using Xamarin.Forms;

namespace PhotosXamarin.Views
{
    public partial class PhotosView : ContentPage
    {
        private readonly PhotosViewModel photosViewModel;

        public PhotosView()
        {
            InitializeComponent();
            this.BindingContext = this.photosViewModel = new PhotosViewModel();
            this.photosViewModel.Navigation = this.Navigation;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.photosViewModel.OnAppearing();
        }
    }
}
