namespace Ecommerce.Services.FileManagers;

public class FileManager : IFileManager
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileManager(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public (bool, string?) FileIsValidate(IFormFile file)
    {
        var ListExtension = new List<string>() { ".png", ".jpg" };
        int FileSize = 5 * 1024 * 1024;
        if (file.Length > FileSize)
            return (false, "Supported Size: 5MB");

        if (!ListExtension.Contains(Path.GetExtension(file.FileName)))
            return (false, "File Must Be Supported Extensions is (.Png , .Jpg)");

        return (true, null);
    }
    public string ImageBase64(string ImageName, string FolderName)
    {
        /*if (string.IsNullOrWhiteSpace(ImageName))
            return null;*/

        var webRootPath = _webHostEnvironment.WebRootPath;
        var pathImage = Path.Combine(webRootPath, FolderName, ImageName);
        if (!File.Exists(pathImage))
            return null;

        byte[] ImageByts = File.ReadAllBytes(pathImage);
        string ImageBase64 = Convert.ToBase64String(ImageByts);
        return ImageBase64;
    }
    public bool RemoveImage(string ImageName, string FolderName)
    {
        string folderName = FolderName;
        string path = Path.Combine(_webHostEnvironment.WebRootPath, folderName, ImageName);
        if (!File.Exists(path))
            return false;

        File.Delete(path);
        return true;

    }
    public async Task<string> SaveImageAsync(IFormFile image, string FolderName)
    {
        var (isValid, error) = FileIsValidate(image);
        if (!isValid)
            throw new Exception(error);

        string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
        string path = Path.Combine(_webHostEnvironment.WebRootPath, FolderName, fileName);
        if (File.Exists(path))
            File.Delete(path);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }
        return fileName;
    }
}
