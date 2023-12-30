using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerEditorBuilder)
/// </summary>
internal sealed class CommanderBuilder<TItem> : ICommanderBuilder<TItem>
    where TItem : ItemBase
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumBuilder<TItem> _albumBuilder;

    public CommanderBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
    {
        _configuration = configuration;
        _albumBuilder = albumBuilder;
    }

    public IUploaderBuilder<TItem> AddCommander<TCommanderConfiguration>(Action<TCommanderConfiguration> configuration)
    {
        configuration((TCommanderConfiguration)_configuration.CommanderConfiguration);
        return new UploaderBuilder<TItem>(_configuration, _albumBuilder);
    }
}