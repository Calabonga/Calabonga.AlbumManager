namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Configuration for Viewer processing
/// </summary>
public interface IViewerConfiguration
{
    /// <summary>
    /// How many items should be taken when view created
    /// </summary>
    int TakeTop { get; set; }
}