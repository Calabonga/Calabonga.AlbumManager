using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// Interface abstraction for command builder (CommandProcessor), that can processing some commands registered in pipeline.
/// </summary>
public interface ICommanderBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// Adds a command processor to  pipeline.
    /// </summary>
    /// <param name="configuration">configuration to add</param>
    IUploaderBuilder<TItem> AddCommander<TCommanderConfiguration>(Action<TCommanderConfiguration> configuration)
        where TCommanderConfiguration : ICommanderConfiguration;
}