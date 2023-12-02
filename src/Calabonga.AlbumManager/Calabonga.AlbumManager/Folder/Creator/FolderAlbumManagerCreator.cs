using Calabonga.AlbumsManager.Builders.Base;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Folder.Creator;

/// <summary>
/// // Calabonga: update summary (2023-10-28 10:26 FolderAlbumCreator)
/// </summary>
public sealed class FolderAlbumBuilder : AlbumBuilderBase<DefaultConfiguration, AlbumItem>
{
    public FolderAlbumBuilder(DefaultConfiguration configuration)
        : base(configuration) { }

    /// <summary>
    /// Returns a collection for <see cref="AlbumItem"/> found in location provided
    /// </summary>
    /// <returns></returns>
    public override List<AlbumItem> GetItems()
    {
        if (!Path.Exists(Configuration.CreatorConfiguration.SourcePath))
        {
            // Calabonga: log info about no path found (2023-10-28 11:03 FolderAlbumCreator)
            return new List<AlbumItem>();
        }

        var directory = new DirectoryInfo(Configuration.CreatorConfiguration.SourcePath);

        var files = directory.GetFiles();

        if (!files.Any())
        {
            // Calabonga: log info about no items found (2023-10-28 11:03 FolderAlbumCreator)
            return new List<AlbumItem>();
        }

        return files.Select(x => new AlbumItem
        {
            FileName = x.Name,
            // Calabonga: Description update (2023-10-28 11:03 FolderAlbumCreator)
            Description = x.DirectoryName,
            FileSize = x.Length
        }).ToList();
    }
}