namespace QStock.Xamarin.Core.Models.Common
{
    public class UserSession
    {
        #region Public Properties

        public string Username { get; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string IdentityToken { get; set; }

        public long ExpiresIn { get; set; }

        public string TokenType { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public UserSession(string username)
        {
            Username = username;
        }

        #endregion Public Constructors
    }
}