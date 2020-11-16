using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VideoGameListApp.Models;
using Xamarin.Forms;

namespace VideoGameListApp.ViewModel
{
    public class GameListViewModel : INotifyPropertyChanged
    {
        private readonly VideoGameRepository _gameRepository;
        public ObservableCollection<VideoGame> Games { get; set; }
        public ICommand AddCommand { get; } 
        public ICommand DeleteCommand { get; } 

        public GameListViewModel()
        {
            _gameRepository = new VideoGameRepository();
            Games = _gameRepository.GetAllGames();
            AddCommand = new Command(OnAddCommand);
            DeleteCommand = new Command(OnDeleteCommand);
        }

        private void OnDeleteCommand(object obj)
        {
            _gameRepository.DeleteGame(obj as VideoGame);
            Games.Remove(obj as VideoGame);
        }

        private async void OnAddCommand(object obj)
        {
            VideoGame newGame = new VideoGame();
            Games.Add(newGame);
            _gameRepository.SaveOrUpdateGame(newGame);

            VideoGameDetailViewModel viewmodel = new VideoGameDetailViewModel(newGame);
            GameDetailPage page = new GameDetailPage();
            page.BindingContext = viewmodel;

            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseChangedEvent(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
