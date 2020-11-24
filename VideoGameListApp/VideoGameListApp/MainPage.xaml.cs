using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;
using VideoGameListApp.ViewModel;
using VideoGameListApp.Views;
using Xamarin.Forms;

namespace VideoGameListApp
{
    public partial class MainPage : ContentPage
    {
        private ContentPage _pageWithTheList = new GameListPage();
        private StarWarFilmRepository swRepo = new StarWarFilmRepository();
        private RandomPersonRepository repoPersons = new RandomPersonRepository();
        private MyAppRepository myAppRepo = new MyAppRepository();

        private RUser _user; 
        public MainPage()
        {
            InitializeComponent();
            _user = new RUser();
            this.BindingContext = _user;
        }

        private async void GoToGamePage(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(_pageWithTheList);
        }

        private async void GoToFilms(object sender, EventArgs e)
        {
            IList<Movie> allFilms = swRepo.GetAllMovies();
            StarWarsListViewModel viewM = new StarWarsListViewModel();
            viewM.AllMovies = allFilms;

            StarWarsListView swlView = new StarWarsListView();
            swlView.BindingContext = viewM;
            await this.Navigation.PushAsync(swlView);
        }

        private void RandomPersonGet(object sender, EventArgs e)
        {
            _user = repoPersons.GetSingleDummyUser();
            this.BindingContext = _user;
        }

        private async void GoToGebruikers(object sender, EventArgs e)
        {
            List<Gebruiker> alleGebruikers = myAppRepo.GetGebruikers();
            GebruikersListViewModel viewM = new GebruikersListViewModel();
            viewM.AlleGebruikers = alleGebruikers;

            GebruikersListView gebruikersView = new GebruikersListView();
            gebruikersView.BindingContext = viewM;
            await this.Navigation.PushAsync(gebruikersView);
        }
    }
}
