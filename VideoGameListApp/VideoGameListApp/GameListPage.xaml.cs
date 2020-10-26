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
    public partial class GameListPage : ContentPage
    {
        private List<VideoGame> listInCSharp = new List<VideoGame>
        {
            new VideoGame {Title="GTA5", Genre="Action", Rating=95, ReleaseDate=new DateTime(2013,01,01), CoverPictureURL="https://gamegasm.files.wordpress.com/2013/04/actual_1364906194.jpg"},
            new VideoGame {Title="Fortnite", Genre="Shooter", Rating=85, ReleaseDate=new DateTime(2017,01,01), CoverPictureURL="https://gamegasm.files.wordpress.com/2013/04/actual_1364906194.jpg"},
            new VideoGame {Title="Skyrim", Genre="RPG", Rating=98, ReleaseDate=new DateTime(2011,01,01), CoverPictureURL="https://gamegasm.files.wordpress.com/2013/04/actual_1364906194.jpg"}
        };

        public GameListPage()
        {
            InitializeComponent();

            /* Bind the List to the ListView (xaml) */
            GameListElement.ItemsSource = listInCSharp;
        }

        private async void VideoGameTapped(object sender, ItemTappedEventArgs e)
        {
            VideoGame selectedGame = e.Item as VideoGame;
            /* // Or do:
             * VideoGame selectedGame = (VideoGame) e.Item; 
             */
            await this.Navigation.PushAsync(new GameDetailPage(selectedGame));
        }
    }
}