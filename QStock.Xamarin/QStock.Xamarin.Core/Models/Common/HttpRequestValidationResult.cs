using System;

namespace QStock.Xamarin.Core.Models.Common
{
    internal class HttpRequestValidationResult
    {
        #region Public Properties

        public bool IsValid => Exception == null;

        public Exception Exception { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public HttpRequestValidationResult()
        {
            Exception = null;
        }

        #endregion Public Constructors
    }
}