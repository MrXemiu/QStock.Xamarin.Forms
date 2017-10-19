using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityModel.Client;
using MvvmCross.Core.Navigation;
using QStock.Xamarin.Core.Models.App;
using QStock.Xamarin.Core.ServiceInterfaces;
using QStock.Xamarin.Core.Util;

namespace QStock.Xamarin.Core.ServiceImplimentations
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Private Fields

        private const string ClientId = "com.qstock.mobile";
        private const string ClientSecret = "qmAVCa3yFq1C1evxlJzzntKWPO9ojUQagSS8hFlLLltM2wOYGRxoYxLa0aqk1mjm";
        private const string Scopes = "openid profile email qsprofile roles qstockapi.read qstockapi.write";
        private const string ServiceId = "QStockMobile";
        private readonly ISessionService _sessionService;
        private readonly IMvxNavigationService _navigationService;

        #endregion Private Fields

        #region Private Properties

        private Uri QsIdentityServerUri => new Uri("https://qsidentityserver.azurewebsites.net");

        private Uri TokenPath => new Uri("/connect/token", UriKind.Relative);

        private Uri TokenService => new Uri(QsIdentityServerUri, TokenPath);

        #endregion Private Properties

        #region Public Constructors

        public AuthenticationService(ISessionService sessionService, IMvxNavigationService navigationService)
        {
            _sessionService = sessionService;
            _navigationService = navigationService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<TokenResponse> TrySignIn(LoginModel loginModel)
        {
            var extra = new Dictionary<string, string> { { "company", loginModel.Company } };

            var tokenClient = new TokenClient(TokenService.ToString(), ClientId, ClientSecret);

            var response = await tokenClient.RequestResourceOwnerPasswordAsync(loginModel.Username, loginModel.Password, Scopes, extra);

            if (response.IsError)
                throw new Exception($"{response.HttpStatusCode} {response.HttpErrorReason} {response.Error}");

            _sessionService.SetCurrentUserSession(response.ToUserSession(loginModel.Username));

            return response;
        }

        /// <inheritdoc />
        public void Logout()
        {
            _sessionService.ClearUserSession();
            
        }

        #endregion Public Methods
    }
}