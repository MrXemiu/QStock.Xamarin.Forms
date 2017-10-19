using IdentityModel.Client;
using QStock.Xamarin.Core.Models.Common;

namespace QStock.Xamarin.Core.Util
{
    public static class TokenExtensions
    {
        #region Public Methods

        public static UserSession ToUserSession(this TokenResponse tokenResponse, string username)
        {
            return new UserSession(username)
            {
                AccessToken = tokenResponse.AccessToken,
                ExpiresIn = tokenResponse.ExpiresIn,
                IdentityToken = tokenResponse.IdentityToken,
                RefreshToken = tokenResponse.RefreshToken,
                TokenType = tokenResponse.TokenType
            };
        }

        #endregion Public Methods
    }
}