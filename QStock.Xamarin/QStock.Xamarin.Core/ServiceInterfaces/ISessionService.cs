using QStock.Xamarin.Core.Models.Common;

namespace QStock.Xamarin.Core.ServiceInterfaces
{
    public interface ISessionService
    {
        #region Public Methods

        UserSession CurrentUserSession();

        void SetCurrentUserSession(UserSession session);

        void ClearUserSession();

        #endregion Public Methods
    }
}