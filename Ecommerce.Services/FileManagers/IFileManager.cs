namespace Ecommerce.Services.FileManagers;

public interface IFileManager
{
    public Task<string> SaveImageAsync(IFormFile image, string FolderName);
    public bool RemoveImage(string ImageName, string FolderName);
    public (bool, string?) FileIsValidate(IFormFile file);
    public string ImageBase64(string ImageName, string FolderName);
}
