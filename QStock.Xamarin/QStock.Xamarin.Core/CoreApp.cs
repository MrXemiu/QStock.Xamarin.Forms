using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using QStock.Xamarin.Core.ViewModels;

namespace QStock.Xamarin.Core
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
