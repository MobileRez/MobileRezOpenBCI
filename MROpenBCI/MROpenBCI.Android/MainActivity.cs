using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Reflection;

namespace MROpenBCI.Droid
{
    [Activity(Label = "MROpenBCI", Icon = "@mipmap/icon", LaunchMode = LaunchMode.SingleTask, 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;

            base.OnCreate(savedInstanceState);

            Forms.Init(this, savedInstanceState);

            typeof(Color).GetProperty("Accent", BindingFlags.Public | BindingFlags.Static).SetValue(null, Color.FromHex("#757575"));

            LoadApplication(new App());
        }
    }
}

