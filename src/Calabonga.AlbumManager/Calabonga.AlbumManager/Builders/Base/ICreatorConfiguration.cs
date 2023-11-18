namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Configuration for Creator processing
/// </summary>
public interface ICreatorConfiguration
{
    /// <summary>
    /// Source where images live
    /// </summary>
    string SourcePath { get; set; }
}