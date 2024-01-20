using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;
using Calabonga.PagedListCore;

namespace Calabonga.AlbumsManager.FolderTree.Creator;

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
    public override async Task<IPagedList<AlbumDirectory>> GetItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        if (!Path.Exists(Configuration.CreatorConfiguration.SourcePath))
        {
            // Calabonga: log info about no path found (2023-10-28 11:03 FolderAlbumCreator)
            return PagedList.Empty<AlbumDirectory>();
        }

        var directoryInfo = new DirectoryInfo(Configuration.CreatorConfiguration.SourcePath);

        var directories = directoryInfo.GetDirectories().ToList();

        if (!directories.Any())
        {
            // Calabonga: log directories not found or empty (2023-11-04 09:24 FolderTreeAlbumCreator)
            return PagedList.Empty<AlbumDirectory>();
        }

        var pagedDirectories = PagedList.Create(directories, pageIndex, pageSize == 0 ? 10 : pageSize, 0);

        if (Configuration.CreatorConfiguration.SkipFoundImages)
        {
            var pagedResult = PagedList.From(pagedDirectories, ConvertItemsToDirectory);
            return pagedResult;
        }
        else
        {
            var pagedResult = PagedList.From(pagedDirectories, ConvertItemsToDirectoryWithFiles);
            return pagedResult;
        }
    }

    private IEnumerable<AlbumDirectory> ConvertItemsToDirectory(IEnumerable<DirectoryInfo> directories)
        => directories.Select(x => new AlbumDirectory() { Name = x.Name });

    private IEnumerable<AlbumDirectory> ConvertItemsToDirectoryWithFiles(IEnumerable<DirectoryInfo> directories)
    {

        foreach (var directory in directories)
        {
            var fileInfos = directory.GetFiles();
            if (fileInfos.Any())
            {
                // Calabonga: log files not found or empty (2023-11-04 09:24 FolderTreeAlbumCreator)
                yield return new AlbumDirectory
                {
                    Description = $"Files found {fileInfos.Length}",
                    Name = directory.Name,
                    Items = fileInfos.Select(x => new AlbumImage
                    {
                        Path = directory.FullName,
                        Name = x.Name,
                        Description = "N/A",
                        FileSize = x.Length,
                        OriginalBytes = File.ReadAllBytes(Path.Combine(directory.FullName, x.Name))
                    })
                };

            }
            else
            {
                yield return new AlbumDirectory() { Name = directory.Name, Description = "No file found" };
            }
        }
    }
}