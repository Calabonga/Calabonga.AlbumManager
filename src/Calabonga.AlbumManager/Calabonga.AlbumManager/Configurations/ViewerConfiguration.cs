using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Viewer processing in Folder mode
/// </summary>
public class ViewerConfiguration : IViewerConfiguration
{
    /// <summary>
    /// How many items should be taken when view created
    /// </summary>
    public int TakeTop { get; set; }
}