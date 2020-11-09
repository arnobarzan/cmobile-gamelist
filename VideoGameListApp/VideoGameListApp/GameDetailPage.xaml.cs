using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoGameListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameDetailPage : ContentPage
    {
        private VideoGame _game;

        public GameDetailPage(VideoGame selectedGame)
        {
            InitializeComponent();
            _game = selectedGame;
            this.BindingContext = selectedGame;
        }

        private async void TimeForDebug(object sender, EventArgs e)
        {
            /* change the properties of our game-object here and investigate the 
             changes in the objects AND the UI-elements */
            await App.Database.SaveGameAsync(_game);
        }
    }
}