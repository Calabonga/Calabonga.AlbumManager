using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands;

public record UploadImageByIdCommand(byte[] Bytes, string FileName, string ContentType, string FolderName)
    : ICommand<UploadResult>;

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

public abstract class UploadResult
{
    public string? Error { get; set; }

    public bool Ok => Error == null;
}

public class ErrorUploadResult : UploadResult
{
    public ErrorUploadResult(string error) => Error = error;
}
public class SuccessUploadResult : UploadResult
{
    public SuccessUploadResult() { }

}