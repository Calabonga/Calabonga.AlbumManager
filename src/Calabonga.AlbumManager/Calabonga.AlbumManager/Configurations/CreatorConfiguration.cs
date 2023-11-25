using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Creator processing in Folder mode
/// </summary>
public class CreatorConfiguration : ICreatorConfiguration
{
    /// <summary>
    /// Source where images live
    /// </summary>
    public string SourcePath { get; set; } = null!;
}