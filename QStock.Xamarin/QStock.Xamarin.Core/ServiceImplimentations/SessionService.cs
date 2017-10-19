using QStock.Xamarin.Core.Models.Common;
using QStock.Xamarin.Core.ServiceInterfaces;
using QStock.Xamarin.Core.Util;

namespace QStock.Xamarin.Core.ServiceImplimentations
{
    public class SessionService : ISessionService
    {
        #region Private Fields

        private readonly ICacheService _cacheService;

        private UserSession _userSession;

        #endregion Private Fields

        #region Public Constructors

        public SessionService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        #endregion Public Constructors

        #region Public Methods

        public UserSession CurrentUserSession()
        {
            return _userSession;
        }

        public void SetCurrentUserSession(UserSession session)
        {
            _userSession = session;
        }

        /// <inheritdoc />
        public void ClearUserSession()
        {
            _cacheService.DeleteObject(CacheKeys.UserSession);
        }

        public void CacheUserSession()
        {
            _cacheService.InsertObject(CacheKeys.UserSession, CurrentUserSession());
        }

        public void RestoreUserSession()
        {
            var userSession = _cacheService.GetObject<UserSession>(CacheKeys.UserSession).Result;
            SetCurrentUserSession(userSession);
        }

        #endregion Public Methods
    }
}