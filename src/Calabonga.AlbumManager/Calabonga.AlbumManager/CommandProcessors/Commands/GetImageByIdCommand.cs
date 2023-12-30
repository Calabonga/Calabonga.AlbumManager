using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands;

/// <summary>
/// Command for getting item by identifier (for example, <see cref="ItemBase.Name"/>)
/// </summary>
public class GetImageByIdCommand : ICommand<AlbumImage?>
{
    /// <summary>
    /// Represents an image name as term for searching.
    /// </summary>
    public string ImageName { get; init; } = null!;
}

/// <summary>
/// CommandHandler for getting item by identifier (for example, <see cref="ItemBase.Name"/>)
/// </summary>
public class GetImageByIdCommandHandler : ICommandHandler<GetImageByIdCommand, AlbumImage?>
{
    /// <summary>
    /// Command handler
    /// </summary>
    /// <param name="command"></param>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<AlbumImage?> Handle(GetImageByIdCommand command, ICommandContext context, CancellationToken cancellationToken = default)
    {
        var albumManager = context.AlbumManager;

        var item = ((IAlbumManager<AlbumImage>)albumManager!)
            .Items
            .SingleOrDefault(x => x.Name == command.ImageName);

        return Task.FromResult(item);
    }
}