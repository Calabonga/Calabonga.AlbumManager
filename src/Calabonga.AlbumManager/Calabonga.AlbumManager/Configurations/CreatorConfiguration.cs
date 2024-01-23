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
    public string SearchFilePattern => "*.png;*.jpg;*.jpeg;*.gif";

    /// <summary>
    /// Source where images live
    /// </summary>
    public string SourcePath { get; set; } = null!;

    /// <summary>
    /// Indicates that processor does not search a files in folder.
    /// </summary>
    public bool SkipFoundImages { get; set; }
}