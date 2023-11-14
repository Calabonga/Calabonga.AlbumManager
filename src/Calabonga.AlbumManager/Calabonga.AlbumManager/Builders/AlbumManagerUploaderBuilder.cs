using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:16 AlbumManagerUploaderBuilder)
/// </summary>
public interface IAlbumManagerUploaderBuilder
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerUploaderBuilder)
    /// </summary>
    /// <typeparam name="TCreatorConfiguration"></typeparam>
    /// <param name="configuration"></param>
    IAlbumManagerBuilderResult AddUploader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);
}

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerUploaderBuilder)
/// </summary>
internal class AlbumManagerUploaderBuilder : IAlbumManagerUploaderBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerUploaderBuilder(ICreator creator) => _creator = creator;

    public IAlbumManagerBuilderResult AddUploader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerBuilderResult(_creator);
    }
}