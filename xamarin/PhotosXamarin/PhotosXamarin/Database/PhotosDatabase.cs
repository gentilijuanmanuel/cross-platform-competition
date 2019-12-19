using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotosXamarin.Models;
using SQLite;

namespace PhotosXamarin.Database
{
    public class PhotosDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public PhotosDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Photo>().Wait();
        }

        public Task<List<Photo>> GetFavoritePhotosAsync()
        {
            return database.Table<Photo>().ToListAsync();
        }

        public async Task<int> SaveFavoritePhotoAsync(Photo photo)
        {
            var photos = await this.GetFavoritePhotosAsync();

            if (photos.Any(p => p.Id == photo.Id))
                return await database.UpdateAsync(photo);

            return await database.InsertAsync(photo);
        }

        public async Task<int> DeleteFavoritePhotoAsync(Photo photo)
        {
            return await database.DeleteAsync(photo);
        }
    }
}
