using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerMetadataBuilder) 
/// </summary>
public interface IAlbumManagerMetadataBuilder
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerMetadataBuilder)
    /// </summary>
    /// <typeparam name="TCreatorConfiguration"></typeparam>
    /// <param name="configuration"></param>
    IAlbumManagerEditorBuilder AddMetadataReader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);
}

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:16 AlbumManagerMetadataBuilder)
/// </summary>
internal sealed class AlbumManagerMetadataBuilder : IAlbumManagerMetadataBuilder
{
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerMetadataBuilder(IAlbumManagerCreator albumManagerCreator) => _albumManagerCreator = albumManagerCreator;

    public IAlbumManagerEditorBuilder AddMetadataReader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerEditorBuilder(_albumManagerCreator);
    }
}