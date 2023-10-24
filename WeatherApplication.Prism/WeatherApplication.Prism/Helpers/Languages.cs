using WeatherApplication.Prism.Interfaces;
using WeatherApplication.Prism.Resources;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherApplication.Prism.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            Culture = ci.Name;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Culture { get; set; }

        public static string Accept => Resource.Accept;

        public static string ConnectionError => Resource.ConnectionError;

        public static string Error => Resource.Error;

        public static string Name => Resource.Name;

        public static string City => Resource.City;

        public static string Cities => Resource.Cities;

        public static string Loading => Resource.Loading;

        public static string SearchCity => Resource.SearchCity;

        public static string Login => Resource.Login;

        public static string ModifyUser => Resource.ModifyUser;
    }
}
