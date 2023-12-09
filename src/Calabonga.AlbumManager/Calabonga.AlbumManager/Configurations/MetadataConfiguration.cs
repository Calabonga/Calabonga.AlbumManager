using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Metadata processing in Folder mode
/// </summary>
public class MetadataConfiguration : IMetadataConfiguration
{
    /// <summary>
    /// Indicates that processing in Metadata is enabled 
    /// </summary>
    public bool Enabled { get; set; }
}