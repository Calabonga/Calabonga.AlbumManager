using Calabonga.AlbumsManager.CommandProcessors.Commands;
using Calabonga.AlbumsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Calabonga.AlbumsManager.Web.Pages;

public class DetailsModel : PageModel
{
    private readonly IMemoryCache _memory;
    private readonly IWebHostEnvironment _environment;

    public DetailsModel(
        IMemoryCache memory,
        IWebHostEnvironment environment)
    {
        _memory = memory;
        _environment = environment;
    }

    [BindProperty(SupportsGet = true)]
    public string? FolderName { get; set; }

    public IEnumerable<string>? Commands { get; set; }

    public AlbumImage? SelectedImage { get; set; }

    public async Task<IActionResult> OnGet()
    {
        if (string.IsNullOrWhiteSpace(FolderName))
        {
            return RedirectToPage("Error");
        }
        var folder = Path.Combine(_environment.WebRootPath, "Images", FolderName);
        var manager = await GetManager(folder);
        Commands = manager.Commands;
        Images = manager.Items;

        return Page();
    }

    public IEnumerable<AlbumImage>? Images { get; set; }

    public async Task<IActionResult> OnGetImageById(string fileName)
    {
        if (string.IsNullOrWhiteSpace(FolderName))
        {
            return RedirectToPage("Error");
        }
        var folder = Path.Combine(_environment.WebRootPath, "Images", FolderName);
        var manager = await GetManager(folder);
        Commands = manager.Commands;
        Images = manager.Items;

        SelectedImage = await manager.ExecuteAsync<AlbumImage, GetImageByIdCommand>(
            new GetImageByIdCommand(fileName),
            HttpContext.RequestAborted);

        return Page();
    }

    public async Task<IActionResult> OnGetDeleteImageById(string fileName)
    {
        if (string.IsNullOrWhiteSpace(FolderName))
        {
            return RedirectToPage("Error");
        }
        var folder = Path.Combine(_environment.WebRootPath, "Images", FolderName);
        var manager = await GetManager(folder);
        Commands = manager.Commands;
        Images = manager.Items;

        var isDeleteSuccess = await manager.ExecuteAsync<bool, DeleteImageByIdCommand>(
            new DeleteImageByIdCommand(fileName),
            HttpContext.RequestAborted);

        if (isDeleteSuccess)
        {
            SelectedImage = null;
        }

        return Page();
    }

    private Task<AlbumManager<AlbumImage>> GetManager(string folderName)
    {
        if (string.IsNullOrEmpty(FolderName))
        {
            throw new NullReferenceException();
        }

        return _memory.GetOrCreateAsync($"Manager_{folderName}", entry =>
        {
            entry.SetSlidingExpiration(TimeSpan.FromSeconds(30));
            return AlbumManagerBuilder.GetImagesFromFolderAsync(folderName);
        })!;
    }
}