namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Configuration for Creator processing
/// </summary>
public interface ICreatorConfiguration
{
    /// <summary>
    /// Source where images live
    /// </summary>
    string SourcePath { get; set; }

    /// <summary>
    /// Should the manager search images
    /// </summary>
    bool SkipFoundImages { get; set; }
}