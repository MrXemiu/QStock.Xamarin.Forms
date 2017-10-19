using System.Threading.Tasks;
using IdentityModel.Client;
using QStock.Xamarin.Core.Models.App;

namespace QStock.Xamarin.Core.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        #region Public Methods

        Task<TokenResponse> TrySignIn(LoginModel loginModel);

        void Logout();

        #endregion Public Methods
    }
}