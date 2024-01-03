using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands;

public record NextPageCommand(int PageIndex) : ICommand<bool>;

public class NextPageCommandHandler : ICommandHandler<NextPageCommand, bool>
{
    public async Task<bool> Handle(NextPageCommand command, ICommandContext context, CancellationToken cancellationToken = default)
    {
        var manager = (IAlbumManager<AlbumImage>)context.AlbumManager!;
        var pageSize = manager.Configuration.CreatorConfiguration.PageSize;
        var items = await manager.AlbumBuilder.GetItemsAsync(command.PageIndex, pageSize, cancellationToken);
        manager.SetItems(items);

        return true;
    }
}