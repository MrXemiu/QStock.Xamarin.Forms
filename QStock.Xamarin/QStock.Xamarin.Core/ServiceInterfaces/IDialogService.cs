using System;
using System.Collections.Generic;
using System.Text;

namespace QStock.Xamarin.Core.ServiceInterfaces
{
    public interface IDialogService
    {
        void Alert(string title, string message, string dismissButtonTitle, Action dismissed);

        void Confirm(string title, string message, string okButtonTitle, string dismissButtonTitle, Action confirmed, Action dismissed);
    }
}
