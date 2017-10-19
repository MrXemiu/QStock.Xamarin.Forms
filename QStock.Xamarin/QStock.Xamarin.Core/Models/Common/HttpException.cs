using System;
using System.Net.Http;

namespace QStock.Xamarin.Core.Models.Common
{
    public class HttpException : Exception
    {
        #region Public Properties

        public HttpResponseMessage HttpResponse { get; }

        #endregion Public Properties

        #region Public Constructors

        public HttpException(string message, HttpResponseMessage httpResponse) : base(message)
        {
            HttpResponse = httpResponse;
        }

        #endregion Public Constructors
    }
}