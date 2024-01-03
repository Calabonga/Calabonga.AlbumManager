using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.FolderTree.Creator;

/// <summary>
/// AlbumManager for folder tree of the folder with images.
/// </summary>
public sealed class FolderTreeAlbumBuilder : AlbumBuilderBase<DefaultConfiguration, AlbumDirectory>
{
    public FolderTreeAlbumBuilder(DefaultConfiguration configuration)
        : base(configuration)
    {
    }

    /// <summary>
    /// Returns items that was found in the folder
    /// </summary>
    /// <param name="pageIndex">current page index</param>
    /// <param name="pageSize">page size for items</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>a list of items</returns>
    public override async Task<List<AlbumDirectory>> GetItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var result = new List<AlbumDirectory>();
        if (!Path.Exists(Configuration.CreatorConfiguration.SourcePath))
        {
            // Calabonga: log info about no path found (2023-10-28 11:03 FolderAlbumCreator)
            return result;
        }

        var directoryInfo = new DirectoryInfo(Configuration.CreatorConfiguration.SourcePath);

        var directories = directoryInfo.GetDirectories();

        if (!directories.Any())
        {
            // Calabonga: log directories not found or empty (2023-11-04 09:24 FolderTreeAlbumCreator)
            return result;
        }

        foreach (var directory in directories)
        {
            var fileInfos = directory.GetFiles();

            if (!fileInfos.Any())
            {
                // Calabonga: log files not found or empty (2023-11-04 09:24 FolderTreeAlbumCreator)
                result.Add(new AlbumDirectory { Description = "Files not found in directory", Name = directory.Name });

                continue;
            }

            var files = fileInfos.Select(x => new AlbumImage
            {
                Name = x.Name,
                Description = $"file {nameof(x.CreationTime)}: {x.CreationTime}",
                FileSize = x.Length
            }).ToList();

            result.Add(new AlbumDirectory() { Items = files, Description = $"Total files in directory: {files.Count}", Name = directory.Name });
        }

        return result;
    }
}