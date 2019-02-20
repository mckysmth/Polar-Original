﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Polar.Model;
using Polar.ViewModel.Commands;

namespace Polar.ViewModel
{
    public class LogInVM : INotifyPropertyChanged
    {
        public LogInToSignUpNavCommand LogInToSignUpNavCommand { get; set; }
        public LogInCommand LogInCommand { get; set; }

        private User user;

        public User User 
        {
            get { return user; }
            set 
            { 
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string email;

        public string Email 
        { 
            get { return email; }
            set 
            { 
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };

                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public LogInVM()
        {
            User = new User();
            LogInToSignUpNavCommand = new LogInToSignUpNavCommand(this);
            LogInCommand = new LogInCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public async void NavigateToSignUp()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }

        public async void LogIn()
        {

        }
    }
}
