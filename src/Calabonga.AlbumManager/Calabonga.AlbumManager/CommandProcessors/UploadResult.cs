namespace Calabonga.AlbumsManager.CommandProcessors
{
    /// <summary>
    /// Default upload operation result.
    /// </summary>
    public abstract class UploadResult
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string? Error { get; protected set; }

        /// <summary>
        /// Indicates that operation succeeds
        /// </summary>
        public bool Ok => Error == null;
    }
}