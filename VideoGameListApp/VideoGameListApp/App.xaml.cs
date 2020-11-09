using System;
using VideoGameListApp.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoGameListApp
{
    public partial class App : Application
    {

        private static SQLiteDataService database;
        public static SQLiteDataService Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteDataService();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            /* Wrap the MainPage in a NavigationPage so we can navigate.. */
            MainPage = new NavigationPage(new MainPage());
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
