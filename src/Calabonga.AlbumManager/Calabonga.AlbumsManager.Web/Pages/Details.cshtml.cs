using Calabonga.AlbumsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calabonga.AlbumsManager.Web.Pages;

public class DetailsModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public DetailsModel(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [BindProperty(SupportsGet = true)]
    public string? FolderName { get; set; }

    public IActionResult OnGet()
    {
        if (string.IsNullOrWhiteSpace(FolderName))
        {
            return RedirectToPage("Error");
        }
        var folder = Path.Combine(_environment.WebRootPath, "Images", FolderName);
        var manager = AlbumManagerBuilder.GetImagesFromFolder(folder);
        var viewer = manager.GetView();

        Images = viewer.Items;

        return Page();
    }

    public IEnumerable<AlbumImage>? Images { get; set; }
}