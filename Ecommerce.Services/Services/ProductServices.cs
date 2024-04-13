namespace Ecommerce.Services.Services;

public sealed class ProductServices : IProductServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileManager _fileManager;
    public ProductServices(IUnitOfWork unitOfWork, IFileManager fileManager)
    {
        _unitOfWork = unitOfWork;
        _fileManager = fileManager;
    }
    public async Task<(List<Product> products, int pageCount)> GetAllProductAsync(int pageNumber, string? subCategoryId = null, Expression<Func<Product, bool>>? filter = null)
    {
        double count = (double)await _unitOfWork.ProductRepository.GetCountProductsAsync(subCategoryId) / 5;
        int pageCount = int.Parse(Math.Ceiling(count).ToString());
        var products = await _unitOfWork.ProductRepository
            .GetTableNoTracking(filter)
            .Skip((pageNumber - 1) * 5)
            .Take(5)
            .ToListAsync();
        return (products, pageCount);
    }
    public async Task<(Product, string)> addProductAsync(Product product, IFormFile Image)
    {
        var imageName = await _fileManager.SaveImageAsync(Image, FolderName.ProductsImages.ToString());
        product.Image = imageName;
        var result = await _unitOfWork.ProductRepository.AddAsync(product);
        return (result, _fileManager.ImageBase64(result.Image, FolderName.ProductsImages.ToString()));
    }
    public async Task<string> DeleteProductAsync(string productId)
    {
        Product product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        await _unitOfWork.ProductRepository.DeleteAsync(product);
        return "Success";
    }
    public async Task<Product> UpdateProductAsync(Product product, IFormFile? formFile = null)
    {
        if (formFile != null)
        {
            var imageName = await _fileManager.SaveImageAsync(formFile, FolderName.ProductsImages.ToString());
            product.Image = imageName;
        }
        await _unitOfWork.ProductRepository.UpdateAsync(product);
        return product;
    }

    public Task<Product> GetByIdAsync(string productId)
    {
        return _unitOfWork.ProductRepository.GetByIdAsync(productId);
    }
}
