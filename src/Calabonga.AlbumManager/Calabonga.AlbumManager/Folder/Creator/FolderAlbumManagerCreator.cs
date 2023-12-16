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

        return Task.FromResult(files.Select(x => new AlbumImage
        {
            Path = directory.FullName,
            Name = x.Name,
            Description = "N/A",
            FileSize = x.Length,
            OriginalBytes = File.ReadAllBytes(Path.Combine(directory.FullName, x.Name))
        }).ToList());
    }
}