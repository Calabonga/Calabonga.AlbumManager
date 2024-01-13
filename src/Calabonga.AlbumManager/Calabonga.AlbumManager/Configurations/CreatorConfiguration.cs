using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Creator processing in Folder mode
/// </summary>
public class CreatorConfiguration : ICreatorConfiguration
{
    /// <summary>
    /// Current page index
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// Current page size
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Pattern for files search
    /// </summary>
    public string SearchFilePattern => "*.png;*.jpg";

    /// <summary>
    /// Source where images live
    /// </summary>
    public string SourcePath { get; set; } = null!;

    public bool SkipFoundImages { get; set; }
}