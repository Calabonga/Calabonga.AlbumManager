using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Folder.Configurations;

/// <summary>
/// Configuration for Metadata processing in Folder mode
/// </summary>
public class FolderAlbumMetadataReaderConfiguration : IMetadataConfiguration
{
    /// <summary>
    /// Indicates that processing in Metadata is enabled 
    /// </summary>
    public bool Enabled { get; set; }
}