﻿using Joebidotchi.Services;
using Joebidotchi.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joebidotchi
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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