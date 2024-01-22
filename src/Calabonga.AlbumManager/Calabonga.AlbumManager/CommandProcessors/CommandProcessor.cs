﻿using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.CommandProcessors;

/// <summary>
/// Commands processor inside the <see cref="AlbumManager{TItem}"/>
/// </summary>
internal class CommandProcessor : ICommandProcessor
{
    private readonly Dictionary<string, Type> _dictionary = new();
    private IAlbumManager? _albumManager;

    internal CommandProcessor(Action<ICommandProcessor> registerCommand) => registerCommand(this);

    /// <summary>
    /// Executes a command registered in <see cref="AlbumManager{TItem}"/>.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Result of executing</returns>
    public Task<TResult> Execute<TResult, TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand<TResult>
    {
        _dictionary.TryGetValue(typeof(TCommand).Name, out var type);
        if (type is null)
        {
            // Calabonga: required some logging (CommandProcessor 2023-12-18 08:24)
            throw new NotImplementedException();
        }

        var handler = (ICommandHandler<TCommand, TResult>)Activator.CreateInstance(type)!;

        return handler.Handle(
            command,
            new CommandContext(_albumManager),
            cancellationToken);
    }

    /// <summary>
    /// Returns a list of names of registered command in current <see cref="AlbumManager{TItem}"/>.
    /// </summary>
    /// <returns>list of strings</returns>
    public IEnumerable<string> GetCommands() => _dictionary.Keys;

    /// <summary>
    /// Register a command for the current <see cref="AlbumManager{TItem}"/>.
    /// </summary>
    /// <typeparam name="TCommandHandler"></typeparam>
    /// <typeparam name="TCommand"></typeparam>
    public void AddCommand<TCommand, TCommandHandler>()
        => _dictionary.Add(typeof(TCommand).Name, typeof(TCommandHandler));

    /// <summary>
    /// Sets current <see cref="AlbumManager{TItem}"/> for executing context <see cref="ICommandHandler{TCommand,TResult}"/>.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="albumManager"></param>
    public void SetAlbumManager<TItem>(IAlbumManager<TItem> albumManager) where TItem : ItemBase
        => _albumManager = albumManager;
}