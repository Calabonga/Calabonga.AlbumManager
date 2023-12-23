using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.MetadataProcessors;

/// <summary>
/// // Calabonga: Summary required (TextMetadataProcessor 2023-12-16 03:46)
/// </summary>
public class TextMetadataProcessor : MetadataProcessor<AlbumImage>
{
    public override async Task ProcessAsync(AlbumImage item, CancellationToken cancellationToken)
    {
        item.Description += " >>>>> METADATA";
        var textFilePath = Path.Combine(item.Path, Path.GetFileNameWithoutExtension(item.Name) + ".txt");
        if (!Path.Exists(textFilePath))
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
}