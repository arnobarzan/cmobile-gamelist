using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VideoGameListApp.Models
{
    public class VideoGame: INotifyPropertyChanged
    {
        private string _title;
        public string Title { get => _title; 
            set
            {
                _title = value;
                RaiseChangedEvent(nameof(Title));
            } 
        }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverPictureURL { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseChangedEvent(string propname) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
        /*public override string ToString()
        {
            return Title + "(" + Rating + ")";
        }*/
    }

    
}
