namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Configuration for Uploader processing
/// </summary>
public interface IUploaderConfiguration
{
    /// <summary>
    /// Indicates that processing in Uploader is enabled 
    /// </summary>
    bool Enabled { get; set; }
}