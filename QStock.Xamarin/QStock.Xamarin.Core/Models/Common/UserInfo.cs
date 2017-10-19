using System.Collections.Generic;
using System.Security.Claims;

namespace QStock.Xamarin.Core.Models.Common
{
    public class UserInfo
    {
        #region Public Properties

        public string Username { get; set; }

        public string Company { get; set; }

        public List<Claim> Roles { get; set; }

        #endregion Public Properties
    }
}