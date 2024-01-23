using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands
{
    /// <summary>
    /// Upload file to current <see cref="AlbumManager{TItem}"/> configured folder.
    /// </summary>
    public class UploadImageByIdCommand : ICommand<UploadResult>
    {
        /// <summary>
        /// Upload file to current <see cref="AlbumManager{TItem}"/> configured folder.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="fileName"></param>
        public UploadImageByIdCommand(byte[] bytes, string fileName)
        {
            Bytes = bytes;
            FileName = fileName;
        }

        public byte[] Bytes { get; }

        public string FileName { get; }
    }
}