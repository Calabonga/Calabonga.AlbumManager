using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Base;

public interface IAlbumManager
{
    IConfiguration Configuration { get; }
}