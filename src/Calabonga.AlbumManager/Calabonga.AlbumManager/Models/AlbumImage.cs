namespace Calabonga.AlbumsManager.Models
{
    /// <summary>
    /// Represents an image metadata.
    /// </summary>
    public class AlbumImage : ItemBase
    {
        /// <summary>
        /// File size
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// Loaded Bytes of the image
        /// </summary>
        public byte[]? OriginalBytes { get; set; }

        /// <summary>
        /// Processed image Bytes after processing done.
        /// </summary>
        public byte[]? ProcessedBytes { get; set; }

        /// <summary>
        /// Title for current item. Can be filled with metadata processing, for example.
        /// </summary>
        public string? Title { get; set; }
    }
}