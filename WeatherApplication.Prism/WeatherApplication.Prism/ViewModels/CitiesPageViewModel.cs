using WeatherApplication.Prism.Helpers;
using WeatherApplication.Prism.ItemViewModels;
using WeatherApplication.Prism.Models;
using WeatherApplication.Prism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApplication.Prism.ViewModels
{
    public class CitiesPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CityItemViewModel> _cities;
        private bool _isRunning;
        private string _search;
        private List<CityResponse> _myCities;
        private DelegateCommand _searchCommand;


        public CitiesPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.Cities;

            LocalCities();

        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowCities));

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowCities();
            }
        }

        private void ShowCities()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Cities = new ObservableCollection<CityItemViewModel>(_myCities.Select(c =>
               new CityItemViewModel(_navigationService)
               {
                   Key = c.Key,
                   LocalizedName = c.LocalizedName,
                   EnglishName = c.EnglishName,
                   Country = c.Country,
                   TimeZone = c.TimeZone,
                   GeoPosition = c.GeoPosition,
                   LocalObservationDateTime = c.LocalObservationDateTime,
                   EpochTime = c.EpochTime,
                   WeatherText = c.WeatherText,
                   WeatherIcon = c.WeatherIcon,
                   HasPrecipitation = c.HasPrecipitation,
                   PrecipitationType = c.PrecipitationType,
                   IsDayTime = c.IsDayTime,
                   Temperature = c.Temperature,
                   MobileLink = c.MobileLink,
                   Link = c.Link,
                   LocalSource = c.LocalSource,
                   Image = GetImage(c.WeatherIcon)

               }).ToList().OrderBy(c => c.EnglishName));
            }
            else
            {
                Cities = new ObservableCollection<CityItemViewModel>(_myCities.Select(c =>
               new CityItemViewModel(_navigationService)
               {
                   Key = c.Key,
                   LocalizedName = c.LocalizedName,
                   EnglishName = c.EnglishName,
                   Country = c.Country,
                   TimeZone = c.TimeZone,
                   GeoPosition = c.GeoPosition,
                   LocalObservationDateTime = c.LocalObservationDateTime,
                   EpochTime = c.EpochTime,
                   WeatherText = c.WeatherText,
                   WeatherIcon = c.WeatherIcon,
                   HasPrecipitation = c.HasPrecipitation,
                   PrecipitationType = c.PrecipitationType,
                   IsDayTime = c.IsDayTime,
                   Temperature = c.Temperature,
                   MobileLink = c.MobileLink,
                   Link = c.Link,
                   LocalSource = c.LocalSource,
                   Image = GetImage(c.WeatherIcon)
               }).ToList().OrderBy(c => c.EnglishName).Where(p => p.EnglishName.ToLower().Contains(Search.ToLower())));
            }
        }

        private string GetImage(string weatherIcon)
        {
            if (weatherIcon == "1")
            {
                return "ic_1";
            }
            if (weatherIcon == "2")
            {
                return "ic_2";
            }
            if (weatherIcon == "3")
            {
                return "ic_3";
            }
            if (weatherIcon == "4")
            {
                return "ic_4";
            }
            if (weatherIcon == "5")
            {
                return "ic_5";
            }
            if (weatherIcon == "6")
            {
                return "ic_6";
            }
            if (weatherIcon == "7")
            {
                return "ic_7";
            }
            if (weatherIcon == "8")
            {
                return "ic_8";
            }
            if (weatherIcon == "11")
            {
                return "ic_11";
            }
            if (weatherIcon == "12")
            {
                return "ic_12";
            }
            if (weatherIcon == "13")
            {
                return "ic_13";
            }
            if (weatherIcon == "14")
            {
                return "ic_14";
            }
            if (weatherIcon == "15")
            {
                return "ic_15";
            }
            if (weatherIcon == "16")
            {
                return "ic_16";
            }
            if (weatherIcon == "17")
            {
                return "ic_17";
            }
            if (weatherIcon == "18")
            {
                return "ic_18";
            }
            if (weatherIcon == "19")
            {
                return "ic_19";
            }
            if (weatherIcon == "20")
            {
                return "ic_20";
            }
            if (weatherIcon == "21")
            {
                return "ic_21";
            }
            if (weatherIcon == "22")
            {
                return "ic_22";
            }
            if (weatherIcon == "23")
            {
                return "ic_23";
            }
            if (weatherIcon == "24")
            {
                return "ic_24";
            }
            if (weatherIcon == "25")
            {
                return "ic_25";
            }
            if (weatherIcon == "26")
            {
                return "ic_26";
            }
            if (weatherIcon == "29")
            {
                return "ic_29";
            }
            if (weatherIcon == "30")
            {
                return "ic_30";
            }
            if (weatherIcon == "31")
            {
                return "ic_31";
            }
            if (weatherIcon == "32")
            {
                return "ic_32";
            }
            if (weatherIcon == "33")
            {
                return "ic_33";
            }
            if (weatherIcon == "34")
            {
                return "ic_34";
            }
            if (weatherIcon == "35")
            {
                return "ic_35";
            }
            if (weatherIcon == "36")
            {
                return "ic_36";
            }
            if (weatherIcon == "37")
            {
                return "ic_37";
            }
            if (weatherIcon == "38")
            {
                return "ic_38";
            }
            if (weatherIcon == "39")
            {
                return "ic_39";
            }
            if (weatherIcon == "40")
            {
                return "ic_40";
            }
            if (weatherIcon == "41")
            {
                return "ic_41";
            }
            if (weatherIcon == "42")
            {
                return "ic_42";
            }
            if (weatherIcon == "43")
            {
                return "ic_43";
            }
            if (weatherIcon == "44")
            {
                return "ic_44";
            }
            return "ic_2";
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public ObservableCollection<CityItemViewModel> Cities
        {
            get => _cities;
            set => SetProperty(ref _cities, value);
        }

        private async void LocalCities()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                });
                return;
            }
            IsRunning = true;

            string url = "http://dataservice.accuweather.com";

            Response response = await _apiService.GetListAsync<CityResponse>(url, "/currentconditions/v1/topcities", "/150?apikey=mF7AGWCbPcUox84vNLKhtdwIsOLwITQ7");

            IsRunning = false;

            if (!response.IsSuccess)
            {
                return;
            }
            _myCities = (List<CityResponse>)response.Result;
            ShowCities();
        }
    }
}
