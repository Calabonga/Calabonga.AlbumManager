using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands
{
    /// <summary>
    /// Command for getting item by identifier (for example, <see cref="ItemBase.Name"/>)
    /// </summary>
    public class GetImageByIdCommand : ICommand<AlbumImage?>
    {
        /// <summary>
        /// Command for getting item by identifier (for example, <see cref="ItemBase.Name"/>)
        /// </summary>
        public GetImageByIdCommand(string imageName)
        {
            ImageName = imageName;
        }

        public string ImageName { get; }
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
                .PagedList
                .Items
                .SingleOrDefault(x => x.Name == command.ImageName);

            return Task.FromResult(item);
        }
    }
}