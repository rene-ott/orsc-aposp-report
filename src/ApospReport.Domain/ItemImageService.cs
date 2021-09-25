using System.Collections.Generic;
using System.Linq;
using ApospReport.Domain.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;

namespace ApospReport.Domain
{
    public interface IItemImageService
    {
        IList<(int id, string data, string extension)> GetItemImages();
    }

    internal class ItemImageService : IItemImageService
    {
        private readonly IFileProvider fileProvider;
        private readonly IMemoryCache cache;
        private const string ItemImageCacheKey = nameof(ItemImageCacheKey);

        public ItemImageService(IFileProvider fileProvider, IMemoryCache cache)
        {
            this.fileProvider = fileProvider;
            this.cache = cache;
        }

        public IList<(int id, string data, string extension)> GetItemImages()
        {
            if (!cache.TryGetValue<IList<(int id, string data, string extension)>>(ItemImageCacheKey, out var value) && value != null)
                return value;

            var dirContent = fileProvider.GetDirectoryContents("App_Data/images/items");

            return cache.Set(ItemImageCacheKey, dirContent.Select(ReadImageAsBase64).ToList());
        }

        private static (int id, string data, string extension) ReadImageAsBase64(IFileInfo fileInfo)
        {
            var nameAndExtension = fileInfo.Name.Split(".");
            using var imageStream = fileInfo.CreateReadStream();

            return (int.Parse(nameAndExtension[0]), imageStream.ConvertToBase64(), nameAndExtension[1]);
        }
    }
}
