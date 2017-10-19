using System;
using System.Threading.Tasks;
using QStock.Xamarin.Core.Models.Common;
using QStock.Xamarin.Core.ServiceInterfaces;

namespace QStock.Xamarin.Core.ServiceImplimentations
{
    public class UserInfoService : IUserInfoService
    {
        #region Private Properties

        private Uri QsIdentityServerUri => new Uri("https://qsidentityserver.azurewebsites.net");

        private Uri UserInfoPath => new Uri("/connect/userinfo", UriKind.Relative);

        private Uri UserInfoEndPoint => new Uri(QsIdentityServerUri, UserInfoPath);

        #endregion Private Properties

        #region Public Methods

        public async Task<UserInfo> GetUserInfo(string accessToken)
        {
            //var userInfoClient = new UserInfoClient(UserInfoEndPoint, accessToken.Token);
            //var response = await userInfoClient.GetAsync();

            //if (response.IsError)
            //{
            //    throw new Exception($"{response.HttpErrorStatusCode} - {response.HttpErrorReason}: {response.ErrorMessage}");
            //}

            //return response;
            return new UserInfo();
        }

        #endregion Public Methods
    }
}