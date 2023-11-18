namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Configuration for Metadata processing
/// </summary>
public interface IMetadataConfiguration
{
    /// <summary>
    /// Indicates that processing in Metadata is enabled 
    /// </summary>
    bool Enabled { get; set; }
}