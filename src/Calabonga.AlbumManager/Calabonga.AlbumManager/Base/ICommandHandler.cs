namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Interface abstraction for <see cref="ICommand{TResult}"/> handler, that can return some result.
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResult"></typeparam>
public interface ICommandHandler<in TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    /// <summary>
    /// Command handler
    /// </summary>
    /// <param name="command"></param>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>the result of the operation execution</returns>
    Task<TResult> Handle(TCommand command, ICommandContext context, CancellationToken cancellationToken = default);
}