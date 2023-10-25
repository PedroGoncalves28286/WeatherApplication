using Newtonsoft.Json;
using WeatherApplication.Prism.Helpers;
using WeatherApplication.Prism.Models;
using WeatherApplication.Prism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WeatherApplication.Prism.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _loginCommand;
        private DelegateCommand _registerCommand;
        private string _password;
        private string _passwordConfirm;

        public RegisterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(Register));
    
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string Confirm
        {
            get => _passwordConfirm;
            set => SetProperty(ref _passwordConfirm, value);
        }

        private async void Login()
        {
            await NavigationService.NavigateAsync($"/NavigationPage/{nameof(LoginPage)}");
        }

        private async void Register()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter your first name.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter your last name.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter an email.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter a password.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Confirm))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter a confirm password.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }

            if (Password != Confirm)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "password and confirmation password must be identical.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }
            var model = new RegisterResponse
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();

            var response = await client.PostAsync("https://weatherapplication28286.azurewebsites.net/api/Users/", httpContent);
       

            if (response != null)
            {
                await NavigationService.NavigateAsync($"/NavigationPage/{nameof(RegisterConfirmationPage)}");
            }
        }
    }
}