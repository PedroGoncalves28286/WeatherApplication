using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
using WeatherApplication.Prism.Services;
using WeatherApplication.Prism.ViewModels;
using WeatherApplication.Prism.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using CitiesPage = WeatherApplication.Prism.Views.CitiesPage;
using LoginPage = WeatherApplication.Prism.Views.LoginPage;
using RegisterConfirmationPage = WeatherApplication.Prism.Views.RegisterConfirmationPage;
using RegisterPage = WeatherApplication.Prism.Views.RegisterPage;

namespace WeatherApplication.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
          : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWH9cdHRdR2VeUkZwVkE=");

            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/CitiesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterConfirmationPage, RegisterConfirmationPageViewModel>();
            containerRegistry.RegisterForNavigation<CitiesPage, CitiesPageViewModel>();
            containerRegistry.RegisterForNavigation<CityDetailPage, CityDetailPageViewModel>();

        }
    }
}
