using Calabonga.AlbumsManager.CommandProcessors;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Interface for commands processor inside the <see cref="AlbumManager{TItem}"/>
/// </summary>
public interface ICommandProcessor
{
    /// <summary>
    /// Returns a list of names of registered command in current <see cref="AlbumManager{TItem}"/>.
    /// </summary>
    /// <returns>list of strings</returns>
    IEnumerable<string> GetCommands();

    /// <summary>
    /// Executes a command registered in <see cref="AlbumManager{TItem}"/>.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Result of executing</returns>
    Task<TResult> Execute<TResult, TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand<TResult>;

    /// <summary>
    /// Register a command for the current <see cref="AlbumManager{TItem}"/>.
    /// </summary>
    /// <typeparam name="TCommandHandler"></typeparam>
    /// <typeparam name="TCommand"></typeparam>
    void AddCommand<TCommand, TCommandHandler>();

    /// <summary>
    /// Sets current <see cref="AlbumManager{TItem}"/> for executing context <see cref="ICommandHandler{TCommand,TResult}"/>.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="albumManager"></param>
    void SetAlbumManager<TItem>(IAlbumManager<TItem> albumManager) where TItem : ItemBase;
}