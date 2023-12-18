using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Editor processing in Folder mode
/// </summary>
public class CommanderConfiguration : ICommanderConfiguration
{
    public ICommandProcessor? CommandProcessor { get; private set; }

    public void SetCommandProcessor(ICommandProcessor commandProcessor) => CommandProcessor = commandProcessor;
}