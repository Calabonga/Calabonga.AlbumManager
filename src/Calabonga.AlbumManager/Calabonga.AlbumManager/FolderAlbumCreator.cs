using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager;

/// <summary>
/// // Calabonga: update summary (2023-10-28 10:26 FolderAlbumCreator)
/// </summary>
public class FolderAlbumCreator : AlbumCreatorBase
{
    private readonly FolderAlbumCreatorConfiguration _config;

    public FolderAlbumCreator(FolderAlbumCreatorConfiguration config)
    {
        _config = config;
    }

    public override List<AlbumItem> GetItems()
    {
        if (!Path.Exists(_config.SourcePath))
        {
            // Calabonga: log info about no path found (2023-10-28 11:03 FolderAlbumCreator)
            return new List<AlbumItem>();
        }

        var directory = new DirectoryInfo(_config.SourcePath);

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