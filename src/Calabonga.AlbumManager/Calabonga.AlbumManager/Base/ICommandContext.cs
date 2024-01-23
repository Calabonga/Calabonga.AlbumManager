namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Context for command execution
/// </summary>
public interface ICommandContext
{
    /// <summary>
    /// Active instance of the <see cref="AlbumManager"/>
    /// </summary>
    IAlbumManager? AlbumManager { get; }
}