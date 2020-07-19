using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CatchMe.Services;
using Com.Mapbox.Mapboxsdk.Maps;

namespace CatchMe.Droid
{
    [Activity(Label = "CatchMe", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, cert, chain, errors) => true;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Com.Mapbox.Mapboxsdk.Mapbox.GetInstance(this, MapBoxService.AccessToken);
            Com.Mapbox.Mapboxsdk.Mapbox.Telemetry.SetDebugLoggingEnabled(true);            

            System.Diagnostics.Debug.WriteLine("Mapbox version: " + Com.Mapbox.Mapboxsdk.BuildConfig.MAPBOX_VERSION_STRING);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}