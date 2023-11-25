using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Editor processing in Folder mode
/// </summary>
public class EditorConfiguration : IEditorConfiguration
{
    /// <summary>
    /// Indicates that processing in Editor is enabled 
    /// </summary>
    public bool Enabled { get; set; }
}