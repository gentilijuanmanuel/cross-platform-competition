using System;
using System.IO;
using PhotosXamarin.Database;
using Xamarin.Forms;

namespace PhotosXamarin
{
    public partial class App : Application
    {
        static PhotosDatabase database;

        public static PhotosDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PhotosDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PhotosDatabase.db3"));
                }   
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
