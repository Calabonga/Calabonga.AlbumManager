using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;
using Calabonga.PagedListCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calabonga.AlbumsManager.Creators
{
    /// <summary>
    /// AlbumManager for folder with images.
    /// </summary>
    public sealed class FolderAlbumBuilder : AlbumBuilderBase<DefaultConfiguration, AlbumImage>
    {
        public FolderAlbumBuilder(DefaultConfiguration configuration)
            : base(configuration) { }

        /// <summary>
        /// Returns a collection for <see cref="AlbumImage"/> found in location provided
        /// </summary>
        /// <returns>list of items</returns>
        protected override Task<IPagedList<AlbumImage>> ExecuteCreateAsync(CancellationToken cancellationToken)
        {
            if (Configuration.CreatorConfiguration.PageSize <= 0)
            {
                return Task.FromResult(PagedList.Empty<AlbumImage>());
            }

            if (!Directory.Exists(Configuration.CreatorConfiguration.SourcePath))
            {
                return Task.FromResult(PagedList.Empty<AlbumImage>());
            }

            var directory = new DirectoryInfo(Configuration.CreatorConfiguration.SourcePath);
            var types = string.IsNullOrEmpty(Configuration.CreatorConfiguration.SearchFilePattern)
                ? new[] { "*.png;", "*.jpg", "*.jpeg", "*.gif" }
                : Configuration.CreatorConfiguration.SearchFilePattern.Split(';');

            var files = types.SelectMany(x => directory.GetFiles(x)).ToList();

            var pageIndex = Configuration.CreatorConfiguration.PageIndex;
            var pageSize = Configuration.CreatorConfiguration.PageSize;
            var pagedFiles = PagedList.Create(files, pageIndex, pageSize == 0 ? 10 : pageSize, 0);
            var result = PagedList.From(pagedFiles, x => ConvertItems(x, directory));

            return Task.FromResult(result);
        }

        private IEnumerable<AlbumImage> ConvertItems(IEnumerable<FileInfo> fileInfos, DirectoryInfo directory)
            => fileInfos.Select(x => new AlbumImage
            {
                Path = directory.FullName,
                Name = x.Name,
                Description = "N/A",
                FileSize = x.Length,
                OriginalBytes = File.ReadAllBytes(Path.Combine(directory.FullName, x.Name))
            });
    }
}