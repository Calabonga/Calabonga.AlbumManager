using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Base.Configurations;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands
{
    /// <summary>
    /// Uploads command for file uploading to the folder configured in <see cref="ICreatorConfiguration"/>
    /// </summary>
    public class UploadImageByIdCommandHandler : ICommandHandler<UploadImageByIdCommand, UploadResult>
    {
        public async Task<UploadResult> Handle(
            UploadImageByIdCommand command,
            ICommandContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var albumManager = context.AlbumManager;
                if (albumManager is null)
                {
                    return new ErrorUploadResult("AlbumManager instance not found");
                }

                var rootImages = albumManager.Configuration.CreatorConfiguration.SourcePath;
                await using var fileStream = new FileStream(Path.Combine(rootImages, command.FileName), FileMode.Create);
                await fileStream.WriteAsync(command.Bytes, cancellationToken);

                return new SuccessUploadResult();
            }
            catch (Exception exception)
            {
                return new ErrorUploadResult(exception.Message);
            }
        }

    }
}