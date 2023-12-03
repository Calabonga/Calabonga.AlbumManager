using Calabonga.AlbumsManager.Builders.Base;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Web.Application;

public class CustomAlbumBuilder : AlbumBuilderBase<CustomConfiguration, AlbumDirectory>
{
    public CustomAlbumBuilder(CustomConfiguration configuration) : base(configuration)
    {
    }

    public override IEnumerable<AlbumDirectory> GetItems()
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

        var isImagesSkipped = ((CustomCreatorConfiguration)Configuration.CreatorConfiguration).SkipFoundImages;

        if (!isImagesSkipped)
        {
            foreach (var directory in directories)
            {
                var fileInfos = directory.GetFiles();

                if (!fileInfos.Any())
                {
                    // Calabonga: log files not found or empty (2023-11-04 09:24 FolderTreeAlbumCreator)
                    result.Add(new AlbumDirectory
                    {
                        Description = "Files not found in directory",
                        DirectoryName = directory.Name
                    });
                    continue;
                }

                var files = fileInfos.Select(x => new AlbumImage
                {
                    FileName = x.Name,
                    // Calabonga: Description update (2023-10-28 11:03 FolderAlbumCreator)
                    Description = $"file {nameof(x.CreationTime)}: {x.CreationTime}",
                    FileSize = x.Length
                }).ToList();

                result.Add(new AlbumDirectory()
                {
                    Items = files,
                    Description = $"Total files in directory: {files.Count}",
                    DirectoryName = directory.Name
                });
            }

            return result;
        }

        foreach (var directory in directories)
        {
            var fileInfos = directory.GetFiles();

            if (!fileInfos.Any())
            {
                // Calabonga: log files not found or empty (2023-11-04 09:24 FolderTreeAlbumCreator)
                result.Add(new AlbumDirectory { Description = "Files not found in directory", DirectoryName = directory.Name });

                continue;
            }
            result.Add(new AlbumDirectory()
            {
                Description = "Find file in directory disabled by configuration",
                DirectoryName = directory.Name
            });
        }

        return result;
    }
}

public class CustomConfiguration : ConfigurationBase
{
    public override ICreatorConfiguration CreatorConfiguration { get; } = new CustomCreatorConfiguration();
}

public class CustomCreatorConfiguration : CreatorConfiguration
{
    public bool SkipFoundImages { get; set; }
}