using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
using QStock.Xamarin.Core.Models.Common;
using QStock.Xamarin.Core.Models.Messages;
using QStock.Xamarin.Core.ServiceInterfaces;

namespace QStock.Xamarin.Core.ServiceImplimentations
{
    public class HttpClientService : IHttpClientService
    {
        #region Private Fields

        private static readonly Dictionary<string, Uri> RouteDictionary = new Dictionary<string, Uri>
        {
            //{
            //    nameof(IPurchaseOrderService.GetAllByWarehouse),
            //    new Uri(App.ApiBaseUri, "purchaseorders/bywarehouse")
            //},
            //{
            //    nameof(IPurchaseOrderService.GetByNumber),
            //    new Uri(App.ApiBaseUri, "purchaseorders/byponumber")
            //},
            //{
            //    nameof(IPurchaseOrderService.GetLineItems),
            //    new Uri(App.ApiBaseUri, "purchaseorders/purchaseorderlineitems")
            //},
            //{
            //    nameof(IPurchaseOrderService.GetLineItemsByStockCode),
            //    new Uri(App.ApiBaseUri, "purchaseorders/PurchaseOrderLineItemsByStockCode")
            //},
            //{
            //    nameof(IBinService.GetBinInfo),
            //    new Uri(App.ApiBaseUri, "binne/bininfo")
            //},
            //{
            //    nameof(IBinService.GetBinStockItems),
            //    new Uri(App.ApiBaseUri, "binne/stockitems")
            //},
            //{
            //    nameof(IReceivingService.ExecutePurchaseOrderReceive),
            //    new Uri(App.ApiBaseUri, "receiving/executereceive")
            //},
            //{
            //    nameof(IReceivingService.GetDefaultReceivingBin),
            //    new Uri(App.ApiBaseUri, "receiving/defaultreceivingbin")
            //},
            //{
            //    nameof(IMoveService.ExecuteDirectMove),
            //    new Uri(App.ApiBaseUri, "move/item")
            //},
            //{
            //    nameof(IPickingService.GetPickTicket),
            //    new Uri(App.ApiBaseUri, "picktickets/selectby")
            //},
            //{
            //    nameof(IPickingService.GetUnpickedPickTickets),
            //    new Uri(App.ApiBaseUri, "picktickets/unpickedtickets")
            //},
            //{
            //    nameof(IPickingService.GetPickItemsByPickTicket),
            //    new Uri(App.ApiBaseUri, "picktickets/items")
            //},
            //{
            //    nameof(IPickingService.ExecutePick),
            //    new Uri(App.ApiBaseUri, "pick/item")
            //},
            //{
            //    nameof(IInventoryService.LookupItemCode),
            //    new Uri(App.ApiBaseUri, "inventory/lookupxref")
            //}
        };

        private readonly IMvxMessenger _messenger;

        private readonly ISessionService _sessionService;

        private HttpClient _httpClient;

        #endregion Private Fields

        #region Public Properties

        public HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());

        #endregion Public Properties

        #region Public Constructors

        public HttpClientService(ISessionService sessionService, IMvxMessenger messenger)
        {
            _sessionService = sessionService;
            _messenger = messenger;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc />
        public Uri GetRoute(string key)
        {
            return RouteDictionary[key];
        }

        public async Task<HttpResponseMessage> GetJsonAsync(Uri apiAddress,
            Dictionary<string, object> queryStringArgs = null)
        {
            var endPoint = ParameterizedEndPoint(apiAddress, queryStringArgs);
            var response = await SendHttpRequest<HttpResponseMessage>(HttpMethod.Get, endPoint, null);
            return response;
        }

        public async Task<DtoWrapper<T>> GetJsonAsync<T>(Uri apiAddress,
            Dictionary<string, object> queryStringArgs = null)
        {
            var endPoint = ParameterizedEndPoint(apiAddress, queryStringArgs);
            var response = await SendHttpRequest<HttpResponseMessage>(HttpMethod.Get, endPoint, null);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new HttpException("Server call was unsuccessful", response);

            try
            {
                var result = JsonConvert.DeserializeObject<DtoWrapper<T>>(jsonString);
                return result;
            }
            catch (Exception ex)
            {
                var typeName = typeof(T).Name;
                throw new HttpException($"Unable to deserialize request content as DtoWrapper<{typeName}>", response);
            }
        }

        public async Task<HttpResponseMessage> PostJsonAsync<T>(Uri apiAddress, T data)
        {
            return await SendHttpRequest(HttpMethod.Post, apiAddress, data);
        }

        public async Task<DtoWrapper<T>> PostJsonAsync<V, T>(Uri apiAddress, V data) where T : new()
        {
            var response = await SendHttpRequest(HttpMethod.Post, apiAddress, data);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new HttpException("Server call was unsuccessful", response);

            try
            {
                var result = JsonConvert.DeserializeObject<DtoWrapper<T>>(jsonString);
                return result;
            }
            catch (Exception)
            {
                throw new HttpException($"Unable to deserialize request content as DtoWrapper<{typeof(T).Name}>",
                    response);
            }
        }

        public async Task<HttpResponseMessage> PutJsonAsync<T>(Uri apiAddress, T data)
        {
            return await SendHttpRequest(HttpMethod.Put, apiAddress, data);
        }

        #endregion Public Methods

        #region Private Methods

        private static Uri ParameterizedEndPoint(Uri serviceEndPoint, Dictionary<string, object> queryStringArgs = null)
        {
            var endPoint = serviceEndPoint;

            if (queryStringArgs != null && queryStringArgs.Count > 0)
            {
                var qsList = queryStringArgs.ToList();

                var builder = new UriBuilder(serviceEndPoint)
                {
                    Query = string.Join("&", qsList.Select(pair => string.Join("=", pair.Key, pair.Value)))
                };
                endPoint = builder.Uri;
            }
            return endPoint;
        }

        private static async Task<HttpRequestValidationResult> ValidateHttpResponse(HttpResponseMessage response,
            [CallerMemberName] string caller = null)
        {
            if (response == null)
                return new HttpRequestValidationResult
                {
                    Exception = new Exception("HttpResponseMessage was null.")
                    {
                        Source = caller
                    }
                };

            switch (response.StatusCode)
            {
                case 0:
                    {
                        return new HttpRequestValidationResult
                        {
                            Exception = new HttpException("Your device does not have an Internet connection.", response)
                        };
                    }

                case HttpStatusCode.RequestTimeout:
                    return new HttpRequestValidationResult
                    {
                        Exception = new HttpException(
                            "There was a problem communicating with the web server. Please try again.", response)
                    };

                case HttpStatusCode.NotFound:
                    {
                        return new HttpRequestValidationResult
                        {
                            Exception = new HttpException(
                                "The server cannot be reached or your device does not have an Internet connection.",
                                response)
                        };
                    }

                case HttpStatusCode.InternalServerError:
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var httpError = JsonConvert.DeserializeObject<HttpError>(jsonString);
                    var exceptionMessage = !string.IsNullOrEmpty(httpError.ExceptionMessage)
                        ? httpError.ExceptionMessage
                        : httpError.Message;
                    return new HttpRequestValidationResult
                    {
                        Exception = new HttpException(exceptionMessage, response)
                    };
            }
            return null;
        }

        private async Task<HttpResponseMessage> ExecuteRequest<T>(HttpMethod method, Uri serviceEndPoint, T data)
        {
            HttpResponseMessage response;

            //TODO: check for expired token
            //TODO: refresh token if neccessary
            HttpClient.SetBearerToken(_sessionService.CurrentUserSession().AccessToken);
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            switch (method.Method)
            {
                case "PUT":
                    response = await HttpClient.PutAsync(serviceEndPoint.AbsoluteUri, StringContentFrom(data))
                        .ConfigureAwait(false);
                    break;

                case "POST":
                    response = await HttpClient.PostAsync(serviceEndPoint.AbsoluteUri, StringContentFrom(data))
                        .ConfigureAwait(false);
                    break;

                case "DELETE":
                    response = await HttpClient.DeleteAsync(serviceEndPoint.AbsoluteUri).ConfigureAwait(false);
                    break;

                default:
                    response = await HttpClient.GetAsync(serviceEndPoint.AbsoluteUri).ConfigureAwait(false);
                    break;
            }

            var validationResult = await ValidateHttpResponse(response);
            if (validationResult != null && !validationResult.IsValid) throw validationResult.Exception;

            return response;
        }

        private StringContent StringContentFrom<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<HttpResponseMessage> SendHttpRequest<T>(HttpMethod method, Uri serviceEndPoint, T data)
        {
            _messenger.Publish(new BeforeExecuteRequestMsg(this));

            HttpResponseMessage response;

            try
            {
                response = await ExecuteRequest(method, serviceEndPoint, data);
            }
            finally
            {
                _messenger.Publish(new AfterExecuteRequestMsg(this));
            }

            return response;
        }

        #endregion Private Methods
    }
}