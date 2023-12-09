using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;

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
    /// <returns></returns>
    public override List<AlbumImage> GetItems()
    {
        if (!Path.Exists(Configuration.CreatorConfiguration.SourcePath))
        {
            // Calabonga: log info about no path found (2023-10-28 11:03 FolderAlbumCreator)
            return new List<AlbumImage>();
        }

        var directory = new DirectoryInfo(Configuration.CreatorConfiguration.SourcePath);

        var files = directory.GetFiles();

        if (!files.Any())
        {
            // Calabonga: log info about no items found (2023-10-28 11:03 FolderAlbumCreator)
            return new List<AlbumImage>();
        }

        return files.Select(x => new AlbumImage
        {
            Name = x.Name,
            // Calabonga: Description update (2023-10-28 11:03 FolderAlbumCreator)
            Description = x.DirectoryName,
            FileSize = x.Length,
            OriginalBytes = File.ReadAllBytes(Path.Combine(directory.FullName, x.Name))
        }).ToList();
    }
}