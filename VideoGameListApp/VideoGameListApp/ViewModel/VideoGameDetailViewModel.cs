using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VideoGameListApp.Models;
using Xamarin.Forms;

namespace VideoGameListApp.ViewModel
{
    public class VideoGameDetailViewModel : INotifyPropertyChanged
    {
        private VideoGameRepository _videoGameRepository;
        private VideoGame _selectedGame;

        public ICommand SaveCommand { get; }
        public ICommand AddPictureCommand { get; }

        public VideoGameDetailViewModel(VideoGame game)
        {
            _videoGameRepository = new VideoGameRepository();
            Game = game;
            SaveCommand = new Command(OnSaveCommand);
            AddPictureCommand = new Command(OnAddPicture);
        }

        private void OnSaveCommand()
        {
            _videoGameRepository.SaveOrUpdateGame(Game);
            _selectedGame.RaiseChangedEvent(nameof(Game.Title));
            _selectedGame.RaiseChangedEvent(nameof(Game.Genre));
            _selectedGame.RaiseChangedEvent(nameof(Game.ReleaseDate));
            _selectedGame.RaiseChangedEvent(nameof(Game.CoverPictureURL));
            
        }


        public VideoGame Game
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                RaiseChangedEvent(nameof(Game));
            }
        }

       

        private async void OnAddPicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await App.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

            Game.CoverPictureURL = file.Path;
            _selectedGame.RaiseChangedEvent(nameof(Game.CoverPictureURL));
            _videoGameRepository.SaveOrUpdateGame(Game);
            //image.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseChangedEvent(string propname)
        {
            
        }
    }
}
