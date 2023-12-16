namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Configuration for Editor processing
/// </summary>
public interface IEditorConfiguration
{
    /// <summary>
    /// Indicates that processing in Editor is enabled 
    /// </summary>
    bool Enabled { get; set; }
}