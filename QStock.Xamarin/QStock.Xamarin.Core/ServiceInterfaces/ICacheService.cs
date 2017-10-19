using System.Threading.Tasks;

namespace QStock.Xamarin.Core.ServiceInterfaces
{
    public interface ICacheService
    {
        #region Public Methods

        Task InsertObject<T>(string key, T obj);

        Task<T> GetObject<T>(string key);

        Task DeleteObject(string key);

        #endregion Public Methods
    }
}