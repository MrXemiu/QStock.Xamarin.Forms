using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using QStock.Xamarin.Core.Models.Common;

namespace QStock.Xamarin.Core.ServiceInterfaces
{
    public interface IHttpClientService
    {
        #region Public Methods

        Uri GetRoute(string key);

        Task<HttpResponseMessage> GetJsonAsync(Uri apiAddress, Dictionary<string, object> queryStringArgs = null);

        Task<DtoWrapper<T>> GetJsonAsync<T>(Uri apiAddress, Dictionary<string, object> queryStringArgs = null);

        Task<HttpResponseMessage> PostJsonAsync<T>(Uri apiAddress, T data);

        Task<DtoWrapper<T>> PostJsonAsync<V, T>(Uri apiAddress, V data) where T : new();

        Task<HttpResponseMessage> PutJsonAsync<T>(Uri apiAddress, T data);

        #endregion Public Methods
    }
}