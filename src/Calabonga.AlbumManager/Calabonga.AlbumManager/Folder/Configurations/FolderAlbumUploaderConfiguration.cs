using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Folder.Configurations;

/// <summary>
/// Configuration for Uploader processing in Folder mode
/// </summary>
public class FolderAlbumUploaderConfiguration : IUploaderConfiguration
{
    /// <summary>
    /// Indicates that processing in Uploader is enabled 
    /// </summary>
    public bool Enabled { get; set; }
}