using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using QStock.Xamarin.Core.ServiceInterfaces;

namespace QStock.Xamarin.Droid.Services
{
    public class DialogService : IDialogService
    {
        public void Alert(string title, string message, string dismissButtonTitle, Action dismissed)

        {

            AlertDialog.Builder builder = new AlertDialog.Builder(Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);

            AlertDialog alertdialog = builder.Create();

            builder.SetTitle(title);

            builder.SetMessage(message);

            builder.SetNegativeButton(dismissButtonTitle, (senderAlert, args) =>

            {
                //ToDo::Prevent from Null Reference Error beacuse somewhere Action set as null

                dismissed?.Invoke();
            });

            builder.Show();
        }

        public void Confirm(string title, string message, string okButtonTitle, string dismissButtonTitle, Action confirmed, Action dismissed)

        {

            AlertDialog.Builder builder = new AlertDialog.Builder(Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);

            AlertDialog alertdialog = builder.Create();

            builder.SetTitle(title);

            builder.SetMessage(message);

            builder.SetNegativeButton(dismissButtonTitle, (senderAlert, args) =>

            {
                //ToDo::Prevent from Null Reference Error beacuse somewhere Action set as null

                dismissed?.Invoke();
            });

            builder.SetPositiveButton(okButtonTitle, (senderAlert, args) =>

            {
                //ToDo::Prevent from Null Reference Error beacuse somewhere Action set as null

                confirmed?.Invoke();
            });

            builder.Show();
        }
    }
}