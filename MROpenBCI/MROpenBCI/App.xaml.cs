using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using MROpenBCI.Helpers;
using MROpenBCI.Interfaces;
using MROpenBCI.Pages.Home;
using MROpenBCI.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinUniversity.Services;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MROpenBCI
{
	public partial class App : Application
	{
		public App ()
		{
            // Register dependencies.
            //DependencyService.Register<IPushTheWorldWifiService, PushTheWorldWifiService>(); //Registers the PTW WiFi Service

            // Register standard XamU services
            var serviceLocator = XamUInfrastructure.Init();
            //Settings.Current.ServiceLocater = serviceLocator;

            //var navSerivice = (FormsNavigationPageService)Settings.Current.ServiceLocater.Get<INavigationService>();


            AppCenter.Start("android=" + ApiKeys.AppCenterAndroid + ";ios=" + ApiKeys.AppCenteriOS + ";uwp=" + ApiKeys.AppCenterUWP,
                typeof(Analytics), typeof(Crashes), typeof(Distribute));
            Analytics.SetEnabledAsync(true);
            AppCenter.LogLevel = LogLevel.Verbose;

            InitializeComponent();

            MainPage = new FeedPage();
            /* TDOD: Uncomment when adding root pages
             and platform specific code for navigation */
            //switch (Xamarin.Forms.Device.RuntimePlatform)
            //{
            //    case Xamarin.Forms.Device.Android:
            //        MainPage = new RootPageAndroid();
            //        break;
            //    case Xamarin.Forms.Device.iOS:
            //        MainPage = new NavigationPage(new RootPageiOS());
            //        break;
            //    case Xamarin.Forms.Device.UWP:
            //        MainPage = new RootPageWindows();
            //        break;
            //    default:
            //        throw new NotImplementedException();
            //}
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
