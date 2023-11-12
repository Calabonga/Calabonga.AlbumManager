using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Creators.FolderTree;

/// <summary>
/// // Calabonga: update summary (2023-10-28 10:26 FolderAlbumCreator)
/// </summary>
public sealed class FolderTreeAlbumManagerCreator : AlbumManagerCreatorBase<FolderTreeAlbumCreatorConfiguration>
{
    public FolderTreeAlbumManagerCreator(FolderTreeAlbumCreatorConfiguration configuration)
        : base(configuration) { }

    public override List<AlbumItem> GetItems()
    {
        var result = new List<AlbumItem>();

        if (!Path.Exists(Configuration.SourceRootPath))
        {
            // Calabonga: log info about no path found (2023-10-28 11:03 FolderAlbumCreator)
            return new List<AlbumItem>();
        }

        var directoryInfo = new DirectoryInfo(Configuration.SourceRootPath);

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
                result.Add(new AlbumItem
                {
                    Description = "Files not found in directory",
                    DirectoryName = directory.Name
                });
                continue;
            }

            var files = fileInfos.Select(x => new AlbumItem
            {
                FileName = x.Name,
                // Calabonga: Description update (2023-10-28 11:03 FolderAlbumCreator)
                Description = $"file {nameof(x.CreationTime)}: {x.CreationTime}",
                FileSize = x.Length
            }).ToList();

            result.Add(new AlbumItem
            {
                Items = files,
                Description = $"Total files in directory: {files.Count}",
                DirectoryName = directory.Name
            });
        }


        return result;
    }
}