using System;
using QStock.Xamarin.Core.Models.Common;

namespace QStock.Xamarin.Core.Exceptions
{
    public class DataTransportException<T> : Exception
    {
        #region Public Constructors

        public DataTransportException(DtoWrapper<T> dto) : base($"{dto.Error}:  {dto.ErrorDescription}")
        {
        }

        #endregion Public Constructors
    }
}