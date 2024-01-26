using Calabonga.AlbumsManager.CommandProcessors.Commands;
using Calabonga.AlbumsManager.Models;
using Calabonga.PagedListCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calabonga.AlbumsManager.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        IWebHostEnvironment environment,
        ILogger<IndexModel> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public int PageIndex { get; set; }

    [BindProperty(SupportsGet = true)]
    public int PageIndex2 { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? FolderName { get; set; }

    public AlbumManager<AlbumDirectory> Manager { get; protected set; }

    public IPagedList<AlbumDirectory>? DirectoryPagedList { get; set; }

    public IPagedList<AlbumImage>? ImagesPagedList { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var folderDirectory = Path.Combine(_environment.WebRootPath, "Images");
        _logger.LogInformation(folderDirectory);
        Manager = await AlbumManagerBuilder.GetDirectoriesFromFolderTreeAsync(folderDirectory, PageIndex, 10);

        DirectoryPagedList = Manager.PagedList;

        if (FolderName == "All")
        {
            ImagesPagedList = null;

            return Page();
        }

        var folderImages = Path.Combine(_environment.WebRootPath, "Images", FolderName!);
        var manager = await AlbumManagerBuilder.GetImagesFromFolderAsync(folderImages, PageIndex2, 1);

        ImagesPagedList = manager.PagedList;

        return Page();
    }

    public async Task<IActionResult> OnGetDeleteImageById(string fileName)
    {
        if (string.IsNullOrWhiteSpace(FolderName))
        {
            return RedirectToPage("Error");
        }

        var folder = Path.Combine(_environment.WebRootPath, "Images", FolderName);
        var manager = await AlbumManagerBuilder.GetImagesFromFolderAsync(folder, PageIndex2, 1);
        ImagesPagedList = manager.PagedList;

        await manager.ExecuteAsync<bool, DeleteImageByIdCommand>(
            new DeleteImageByIdCommand(fileName),
            HttpContext.RequestAborted);

        return RedirectToPage("Index", new { PageIndex2 = 0 });
    }
}