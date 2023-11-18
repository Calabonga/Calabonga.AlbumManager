using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Folder.Configurations;

/// <summary>
/// Configuration for Creator processing in Folder mode
/// </summary>
public class FolderAlbumCreatorConfiguration : ICreatorConfiguration
{
    /// <summary>
    /// Source where images live
    /// </summary>
    public string SourcePath { get; set; } = null!;
}