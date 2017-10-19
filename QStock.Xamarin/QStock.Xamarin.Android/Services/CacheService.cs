using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using QStock.Xamarin.Core.ServiceInterfaces;

namespace QStock.Xamarin.Droid.Services
{
    public class CacheService : ICacheService
    {
        public async Task InsertObject<T>(string key, T obj)
        {
            await BlobCache.InMemory.InsertObject(key, obj);
        }

        public async Task<T> GetObject<T>(string key)
        {
            return await BlobCache.InMemory.GetObject<T>(key);
        }

        public async Task DeleteObject(string key)
        {
            await BlobCache.InMemory.Invalidate(key);
        }
    }
}