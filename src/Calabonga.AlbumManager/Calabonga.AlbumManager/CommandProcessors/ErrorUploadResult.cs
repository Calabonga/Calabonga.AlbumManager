namespace Calabonga.AlbumsManager.CommandProcessors.Commands
{
    /// <summary>
    /// Uploading operation result with error.
    /// </summary>
    public class ErrorUploadResult : UploadResult
    {
        public ErrorUploadResult(string error) => Error = error;
    }
}