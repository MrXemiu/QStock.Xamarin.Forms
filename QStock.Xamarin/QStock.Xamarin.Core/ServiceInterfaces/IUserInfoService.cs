using System.Threading.Tasks;
using QStock.Xamarin.Core.Models.Common;

namespace QStock.Xamarin.Core.ServiceInterfaces
{
    public interface IUserInfoService
    {
        #region Public Methods

        Task<UserInfo> GetUserInfo(string accessToken);

        #endregion Public Methods
    }
}