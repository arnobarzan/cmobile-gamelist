﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoGameListApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarWarsListView : ContentPage
    {
        public StarWarsListView()
        {
            InitializeComponent();
        }
    }
}