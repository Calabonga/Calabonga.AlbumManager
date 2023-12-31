﻿using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.FolderTree.Creator;

/// <summary>
/// // Calabonga: update summary (2023-10-28 10:26 FolderAlbumCreator)
/// </summary>
public sealed class FolderTreeAlbumBuilder : AlbumBuilderBase<DefaultConfiguration, AlbumDirectory>
{
    public FolderTreeAlbumBuilder(DefaultConfiguration configuration)
        : base(configuration) { }

    public override async Task<List<AlbumDirectory>> GetItemsAsync(CancellationToken cancellationToken)
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
                result.Add(new AlbumDirectory
                {
                    Description = "Files not found in directory",
                    Name = directory.Name
                });
                continue;
            }

            var files = fileInfos.Select(x => new AlbumImage
            {
                Name = x.Name,
                // Calabonga: Description update (2023-10-28 11:03 FolderAlbumCreator)
                Description = $"file {nameof(x.CreationTime)}: {x.CreationTime}",
                FileSize = x.Length
            }).ToList();

            result.Add(new AlbumDirectory()
            {
                Items = files,
                Description = $"Total files in directory: {files.Count}",
                Name = directory.Name
            });
        }

        return result;
    }


}