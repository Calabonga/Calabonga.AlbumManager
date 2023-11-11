using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager;
/// <summary>
/// Configuration builder for <see cref="AlbumManager"/>
/// </summary>
public class AlbumManagerBuilder : IAlbumManagerBuilder
{
    private ICreator _creator = null!;

    public IAlbumManagerBuilder AddCreator<TCreator, TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
        where TCreator : AlbumCreatorBase<TCreatorConfiguration>
        where TCreatorConfiguration : class, new()
    {
        var config = new TCreatorConfiguration();
        configuration(config);
        _creator = (AlbumCreatorBase<TCreatorConfiguration>)Activator.CreateInstance(typeof(TCreator), config)!;

        return this;
    }

    IAlbumManagerBuilder IAlbumManagerBuilder.AddCreator<TCreator, TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return this;
    }

    public IAlbumManagerBuilder AddViewer<TViewerConfiguration>(Action<TViewerConfiguration> configuration)
    {
        return this;
    }

    public IAlbumManagerBuilder AddMetadataReader<TMetadataReaderConfiguration>(Action<TMetadataReaderConfiguration> configuration)
    {
        return this;
    }

    public IAlbumManagerBuilder AddEditor<TEditorConfiguration>(Action<TEditorConfiguration> configuration)
    {
        return this;
    }

    public IAlbumManagerBuilder AddUploader<TUploaderConfiguration>(Action<TUploaderConfiguration> configuration)
    {
        return this;
    }

    public AlbumManager Build()
    {
        var items = _creator.GetItems();
        var manager = new AlbumManager(items);
        return manager;
    }
}

public interface IAlbumManagerBuilder
{
    IAlbumManagerBuilder AddCreator<TCreator, TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);

    IAlbumManagerBuilder AddViewer<TViewerConfiguration>(Action<TViewerConfiguration> configuration);

    IAlbumManagerBuilder AddMetadataReader<TMetadataReaderConfiguration>(Action<TMetadataReaderConfiguration> configuration);

    IAlbumManagerBuilder AddEditor<TEditorConfiguration>(Action<TEditorConfiguration> configuration);

    IAlbumManagerBuilder AddUploader<TUploaderConfiguration>(Action<TUploaderConfiguration> configuration);

    AlbumManager Build();
}