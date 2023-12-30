using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;
using Calabonga.PagedListCore;

namespace Calabonga.AlbumsManager.Folder.Creator;

/// <summary>
/// // Calabonga: update summary (2023-10-28 10:26 FolderAlbumCreator)
/// </summary>
public sealed class FolderAlbumBuilder : AlbumBuilderBase<DefaultConfiguration, AlbumImage>
{
    public FolderAlbumBuilder(DefaultConfiguration configuration)
        : base(configuration) { }

    /// <summary>
    /// Returns a collection for <see cref="AlbumImage"/> found in location provided
    /// </summary>
    /// <returns>list of items</returns>
    protected override Task<List<AlbumImage>> ExecuteCreateAsync(CancellationToken cancellationToken)
    {
        if (!Path.Exists(Configuration.CreatorConfiguration.SourcePath))
        {
            // Calabonga: log info about no path found (2023-10-28 11:03 FolderAlbumCreator)
            return Task.FromResult(new List<AlbumImage>());
        }

        var directory = new DirectoryInfo(Configuration.CreatorConfiguration.SourcePath);
        var types = string.IsNullOrEmpty(Configuration.CreatorConfiguration.SearchFilePattern)
            ? new[] { "*.png;", "*.jpg" }
            : Configuration.CreatorConfiguration.SearchFilePattern.Split(';');

        var files = types.SelectMany(x => directory.GetFiles(x)).ToList();

        if (!files.Any())
        {
            // Calabonga: log info about no items found (2023-10-28 11:03 FolderAlbumCreator)
            return Task.FromResult(new List<AlbumImage>());
        }

        if (Configuration.CreatorConfiguration.PageSize <= 0)
        {
            return Task.FromResult(files.Select(x => new AlbumImage
            {
                Path = directory.FullName,
                Name = x.Name,
                Description = "N/A",
                FileSize = x.Length,
                OriginalBytes = File.ReadAllBytes(Path.Combine(directory.FullName, x.Name))
            }).ToList());
        }

        var pageIndex = Configuration.CreatorConfiguration.PageIndex;
        var pageSize = Configuration.CreatorConfiguration.PageSize;

        var pagedFiles = new PagedList<FileInfo>(files, pageIndex, pageSize, 0, files.Count);

        var result = PagedList.From(pagedFiles, x => ConvertItems(x, directory));

        return Task.FromResult(result.Items.ToList());
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