using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Droid.Platform;
using MvvmCross.Forms.Platform;
using MvvmCross.Platform;
using QStock.Xamarin.Core;
using QStock.Xamarin.Droid.Services;
using QStock.Xamarin.Core.ServiceInterfaces;

namespace QStock.Xamarin.Droid
{
    public class Setup : MvxFormsAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new CoreApp();
        }

        /// <inheritdoc />
        protected override MvxFormsApplication CreateFormsApplication()
        {
            return new Core.App();
        }

        /// <inheritdoc />
        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<ICacheService, CacheService>();
        }
    }
}
