using WeatherApplication.Prism.Helpers;
using WeatherApplication.Prism.Models;
using WeatherApplication.Prism.Services;
using WeatherApplication.Prism.Views;
using Prism.Commands;
using Prism.Navigation;

namespace WeatherApplication.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _password;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;
        private DelegateCommand _donthaveanaccountCommand;
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public LoginPageViewModel(INavigationService navigationService, IApiService apiService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public DelegateCommand DontHaveAnAccountCommand => _donthaveanaccountCommand ?? (_donthaveanaccountCommand = new DelegateCommand((DontHaveAnAccount)));

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void DontHaveAnAccount()
        {
            await NavigationService.NavigateAsync($"/NavigationPage/{nameof(RegisterPage)}");
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter an email.", Languages.Accept);
                Password = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter a password.", Languages.Accept);
                Password = string.Empty;
                return;
            }

            string url = "https://openweather25853.azurewebsites.net/";

            string email = Email;

            string password = Password;

            Response response = await _apiService.CheckUser(url, "api/Users/", email + "/" + password);

            var user = (bool)response.Result;

            if (!user)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "Email or Password are incorrect!", Languages.Accept);
                return;
            }

            await NavigationService.NavigateAsync($"/{nameof(LoginPage)}/NavigationPage/{nameof(MainPage)}");
        }
    }
}