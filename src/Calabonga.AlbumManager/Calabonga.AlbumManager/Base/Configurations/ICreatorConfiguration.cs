namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Configuration for Creator processing
/// </summary>
public interface ICreatorConfiguration
{
    /// <summary>
    /// Current page index
    /// </summary>
    int PageIndex { get; }

    /// <summary>
    /// Current page size. If not provided then no paging enabled.
    /// </summary>
    int PageSize { get; }

    /// <summary>
    /// Pattern for files search
    /// </summary>
    string SearchFilePattern { get; }

    /// <summary>
    /// Source where images live
    /// </summary>
    string SourcePath { get; }

    /// <summary>
    /// Should the manager search images
    /// </summary>
    bool SkipFoundImages { get; }
}