namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Commander configuration allows to append some commands for pipeline processing.
/// </summary>
public interface ICommanderConfiguration
{
    /// <summary>
    /// Command processor instance
    /// </summary>
    ICommandProcessor? CommandProcessor { get; }

    /// <summary>
    /// Setups an instance of the <see cref="ICommandProcessor"/> for current <see cref="AlbumManager{TItem}"/>
    /// </summary>
    /// <param name="commandProcessor"></param>
    public void SetCommandProcessor(ICommandProcessor commandProcessor);
}