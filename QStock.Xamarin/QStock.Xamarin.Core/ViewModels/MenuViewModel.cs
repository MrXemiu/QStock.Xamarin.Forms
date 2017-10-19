using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using QStock.Xamarin.Core.ServiceInterfaces;

namespace QStock.Xamarin.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMvxNavigationService _navigationService;

        #region Public Methods

        public MenuViewModel(IAuthenticationService authenticationService, IMvxNavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
        }

        public void ShowViewModelAndroid(Type viewModel)
        {
            ShowViewModel(viewModel);
        }

        public void Logout()
        {
            _authenticationService.Logout();
            _navigationService.Navigate<LoginViewModel>();
        }

        #endregion Public Methods
    }
}