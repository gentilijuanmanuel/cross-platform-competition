﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PhotosXamarin.Models;

namespace PhotosXamarin.Services
{
    public interface IPhotosService
    {
        Task<IEnumerable<Photo>> GetPhotosAsync(string url = null);

        Task<IEnumerable<Photo>> GetFavoritePhotosAsync(string url = null);
    }
}