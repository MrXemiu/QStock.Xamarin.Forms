using System.Net;
using Newtonsoft.Json;

namespace QStock.Xamarin.Core.Models.Common
{
    public class DtoWrapper<T>
    {
        #region Public Properties

        [JsonProperty("content")]
        public T Content { get; }

        [JsonProperty("isError")]
        public bool IsError { get; }

        [JsonProperty("httpStatusCode")]
        public HttpStatusCode HttpStatusCode { get; }

        [JsonProperty("errorDescription")]
        public string ErrorDescription { get; }

        [JsonProperty("error")]
        public string Error { get; }

        #endregion Public Properties

        #region Public Constructors

        public DtoWrapper()
        {
        }

        [JsonConstructor]
        public DtoWrapper(T content, bool isError, HttpStatusCode httpStatusCode, string errorDescription, string error)
        {
            Content = content;
            IsError = isError;
            HttpStatusCode = httpStatusCode;
            ErrorDescription = errorDescription;
            Error = error;
        }

        public DtoWrapper(T content)
        {
            Content = content;
            IsError = false;
        }

        public DtoWrapper(HttpStatusCode statusCode, string error, string errorDescription)
        {
            IsError = true;
            HttpStatusCode = statusCode;
            Error = error;
            ErrorDescription = errorDescription;
        }

        #endregion Public Constructors
    }
}