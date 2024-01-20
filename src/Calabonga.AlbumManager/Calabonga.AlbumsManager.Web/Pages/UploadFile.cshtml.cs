using Calabonga.AlbumsManager.CommandProcessors.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calabonga.AlbumsManager.Web.Pages;

public class UploadFileModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public UploadFileModel(IWebHostEnvironment environment) => _environment = environment;

    [BindProperty(SupportsGet = true)]
    public string? FolderName { get; set; }

    [BindProperty]
    public IFormFile? FormFile { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {

            if (FormFile is null)
            {
                TempData["Message"] = "danger|File is not provided";

                return Page();
            }

            if (string.IsNullOrEmpty(FolderName))
            {
                TempData["Message"] = "danger|FolderName is not provided";
                return Page();
            }

            var folder = FolderName;
            var subfolder = Path.Combine(_environment.WebRootPath, "Images", folder);

            using var memoryStream = new MemoryStream();
            await using var stream = FormFile.OpenReadStream();
            await stream.CopyToAsync(memoryStream, HttpContext.RequestAborted);
            var bytes = memoryStream.ToArray();

            var manager = await AlbumManagerBuilder.GetImagesFromFolderAsync(subfolder, 0, 10);
            var command = new UploadImageByIdCommand(bytes, FormFile.FileName, FormFile.ContentType, FolderName);
            var result = await manager.ExecuteAsync<UploadResult, UploadImageByIdCommand>(command, HttpContext.RequestAborted);
            if (result!.Ok)
            {
                TempData["Message"] = $"success|File {FormFile.FileName} successfully uploaded.";
                return RedirectToPage("UploadFile");
            }

            TempData["Message"] = $"danger|Upload operation failed: {result.Error}";
            return RedirectToPage("UploadFile");

        }
        catch (Exception exception)
        {
            TempData["Message"] = $"danger|Upload operation failed: {exception.Message}";
            return RedirectToPage("UploadFile");
        }
    }
}