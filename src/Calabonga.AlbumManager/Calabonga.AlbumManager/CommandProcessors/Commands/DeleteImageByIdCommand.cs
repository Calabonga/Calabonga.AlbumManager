using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.MetadataProcessors;
using Calabonga.AlbumsManager.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands
{
    public class DeleteImageByIdCommand : ICommand<bool>
    {
        public DeleteImageByIdCommand(string imageName) => ImageName = ImageName;

        public string ImageName { get; }
    }

    public class DeleteImageByIdCommandHandler : ICommandHandler<DeleteImageByIdCommand, bool>
    {
        public async Task<bool> Handle(
            DeleteImageByIdCommand command,
            ICommandContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var albumManager = context.AlbumManager;
                if (albumManager is null)
                {
                    return false;
                }

                var manager = ((IAlbumManager<AlbumImage>)albumManager);
                var item = manager.PagedList.Items.SingleOrDefault(x => x.Name == command.ImageName);
                if (item is null)
                {
                    return false;
                }

                var filePath = Path.Combine(item.Path, item.Name);
                if (File.Exists(filePath))
                {
                    var metadataProcessor = manager.Configuration.MetadataConfiguration.MetadataProcessor;
                    if (metadataProcessor != null)
                    {
                        var result = await ((IMetadataProcessor<AlbumImage>)metadataProcessor).DeleteDataProcessAsync(item, cancellationToken);
                        if (result != DeleteResult.Error)
                        {
                            manager.Remove(item);
                            File.Delete(filePath);
                            return true;
                        }
                    }

                    manager.Remove(item);

                    File.Delete(filePath);

                    return true;
                }
            }

            catch (Exception exception)
            {
                return false;
            }

            return false;
        }


    }
}