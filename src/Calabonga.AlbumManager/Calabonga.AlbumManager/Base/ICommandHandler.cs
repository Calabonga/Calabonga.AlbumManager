namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// // Calabonga: Summary required (ICommandHandler 2023-12-18 02:43)
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResult"></typeparam>
public interface ICommandHandler<in TCommand, TResult>
{
    /// <summary>
    /// Command handler
    /// </summary>
    /// <param name="command"></param>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TResult> Handle(TCommand command, ICommandContext context, CancellationToken cancellationToken = default);
}