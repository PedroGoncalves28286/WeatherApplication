using WeatherApplication.Prism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherApplication.Prism.ViewModels
{
    public class RegisterConfirmationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _goToLoginCommand;

        public RegisterConfirmationPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand GoToLoginCommand => _goToLoginCommand ?? (_goToLoginCommand = new DelegateCommand(GoToLogin));

        private async void GoToLogin()
        {
            await NavigationService.NavigateAsync($"/NavigationPage/{nameof(LoginPage)}");
        }
    }
}
