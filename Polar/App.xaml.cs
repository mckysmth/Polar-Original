﻿using System;
using Microsoft.WindowsAzure.MobileServices;
using Polar.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Polar
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static User user;
        //public static MobileServiceClient MobileServiceClient = 
            //new MobileServiceClient("");

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInPage());
        }
        public App(String databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInPage());

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
