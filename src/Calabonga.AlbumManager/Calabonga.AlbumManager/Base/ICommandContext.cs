namespace Calabonga.AlbumsManager.Base;

public interface ICommandContext
{
    IAlbumManager? AlbumManager { get; }
}