namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Configuration for Editor processing
/// </summary>
public interface ICommanderConfiguration
{
    ICommandProcessor? CommandProcessor { get; }

    public void SetCommandProcessor(ICommandProcessor commandProcessor);
}