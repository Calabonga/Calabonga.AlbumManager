using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.CommandProcessors;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Photo and images Manager with some helpful processing
/// </summary>
public sealed class AlbumManager<TItem> : IAlbumManager<TItem>
    where TItem : ItemBase
{
    internal AlbumManager(IEnumerable<TItem> items, IConfiguration configuration)
    {
        Configuration = configuration;
        Items = items;
    }

    public IEnumerable<string> Commands
        => Configuration.CommanderConfiguration.CommandProcessor?.GetCommands()
           ?? Enumerable.Empty<string>();

    public IEnumerable<TItem> Items { get; }

    /// <summary>
    /// Configuration used for files processing
    /// </summary>
    public IConfiguration Configuration { get; }

    public Task<TResult?> ExecuteAsync<TResult, TCommand>(TCommand command, CancellationToken cancellationToken)
    {
        if (Configuration.CommanderConfiguration.CommandProcessor?.GetCommands() is not null)
        {
            Configuration.CommanderConfiguration.CommandProcessor.SetAlbumManager(this);
            return Configuration.CommanderConfiguration.CommandProcessor.Execute<TResult?, TCommand>(command, cancellationToken);
        }
        else
        {
            return Task.FromResult<TResult?>(default);
        }
    }
}