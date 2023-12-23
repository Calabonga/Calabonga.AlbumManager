using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands;

public record DeleteImageByIdCommand(string ImageName) : ICommand<bool>;

public class DeleteImageByIdCommandHandler : ICommandHandler<DeleteImageByIdCommand, bool>
{
    public Task<bool> Handle(
        DeleteImageByIdCommand command,
        ICommandContext context,
        CancellationToken cancellationToken = default)
    {
        var albumManager = context.AlbumManager;
        if (albumManager is null)
        {
            return Task.FromResult(false);
        }

        var manager = ((IAlbumManager<AlbumImage>)albumManager);
        var item = manager.Items.SingleOrDefault(x => x.Name == command.ImageName);
        if (item is null)
        {
            return Task.FromResult(false);
        }

        try
        {
            var filePath = Path.Combine(item.Path, item.Name);
            if (Path.Exists(filePath))
            {
                var metadataProcessor = manager.Configuration.MetadataConfiguration.MetadataProcessor;
                if (metadataProcessor != null)
                {
                    metadataProcessor.
                }
            }
        }

        catch (Exception exception)
        {
            throw;
        }

        ((IAlbumManager<AlbumImage>)albumManager).Remove(item);

        return Task.FromResult(true);
    }
}