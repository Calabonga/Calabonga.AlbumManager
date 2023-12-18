using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.CommandProcessors;

/// <summary>
/// Command executing context metadata
/// </summary>
public class CommandContext : ICommandContext
{
    /// <summary>
    /// Instantiate a <see cref="CommandContext"/>
    /// </summary>
    /// <param name="albumManager"></param>
    public CommandContext(IAlbumManager? albumManager) => AlbumManager = albumManager;

    /// <summary>
    /// <see cref="AlbumManager"/> for executing command context.
    /// </summary>
    public IAlbumManager? AlbumManager { get; }
}