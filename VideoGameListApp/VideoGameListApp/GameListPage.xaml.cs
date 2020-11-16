using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;
using VideoGameListApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;

namespace VideoGameListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameListPage : ContentPage
    {
        public GameListPage()
        {
            InitializeComponent();
        }

        private async void VideoGameTapped(object sender, ItemTappedEventArgs e)
        {
            VideoGame selectedGame = e.Item as VideoGame;
            /* // Or do:
             * VideoGame selectedGame = (VideoGame) e.Item; 
             */
            VideoGameDetailViewModel viewmodel = new VideoGameDetailViewModel(selectedGame);
            GameDetailPage page = new GameDetailPage();
            page.BindingContext = viewmodel;

            await this.Navigation.PushAsync(page);
            ((ListView)sender).SelectedItem = null;

        }

    }
}