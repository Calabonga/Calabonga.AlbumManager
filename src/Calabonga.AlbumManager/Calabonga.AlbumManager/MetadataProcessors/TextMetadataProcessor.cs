using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Calabonga.AlbumsManager.MetadataProcessors
{
    /// <summary>
    /// Metadata finder for <see cref="AlbumManager{TItem}"/>.
    /// This processor search in folder file with the same name but extension is *.txt
    /// and fill some properties with data from this file when it is exists.
    /// </summary>
    public class TextMetadataProcessor : MetadataProcessor<AlbumImage>
    {
        /// <summary>
        /// Starts to search data for <see cref="AlbumImage"/> in some place for processing as metadata for concrete item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        public override async Task FindDataProcessAsync(AlbumImage item, CancellationToken cancellationToken)
        {
            var textFilePath = Path.Combine(item.Path, Path.GetFileNameWithoutExtension(item.Name) + ".txt");
            if (!File.Exists(textFilePath))
            {
                return;
            }

            var lines = await File.ReadAllLinesAsync(textFilePath, cancellationToken);
            if (lines.Length != 2)
            {
                return;
            }

            item.Title = lines[0];
            item.Description = lines[1];
        }

        /// <summary>
        /// Deletes a data for <see cref="AlbumImage"/> if metadata has been found for concrete item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        public override Task<DeleteResult> DeleteDataProcessAsync(AlbumImage item, CancellationToken cancellationToken)
        {
            var textFilePath = Path.Combine(item.Path, Path.GetFileNameWithoutExtension(item.Name) + ".txt");
            if (!File.Exists(textFilePath))
            {
                return Task.FromResult(DeleteResult.NotFound);
            }

            try
            {
                File.Delete(textFilePath);

                return Task.FromResult(DeleteResult.Deleted);
            }
            catch
            {
                return Task.FromResult(DeleteResult.Error);
            }
        }
    }
}