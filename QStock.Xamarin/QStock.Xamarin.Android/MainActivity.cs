using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Droid.Views;
using MvvmCross.Forms.Views;
using MvvmCross.Platform;

namespace QStock.Xamarin.Droid
{
    [Activity(Label = "QStock.Xamarin", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        /// <inheritdoc />
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var formsPresenter = (MvxFormsPagePresenter)Mvx.Resolve<IMvxAndroidViewPresenter>();
            LoadApplication(formsPresenter.FormsApplication);
        }
    }
}

