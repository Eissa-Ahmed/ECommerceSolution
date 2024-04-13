namespace Ecommerce.Core.Feature.ProductFeature.Query.Handler;

public class ProductQueryHandler : ResponseHandler,
    IRequestHandler<ProductGetAllModel, Response<ProductGetAllResult>>,
    IRequestHandler<ProductGetInSubCategoryModel, Response<ProductGetAllResult>>
{
    private readonly IProductServices _productServices;
    private readonly IMapper _mapper;
    private readonly IFileManager _fileManager;
    public ProductQueryHandler(IProductServices productServices, IMapper mapper, IFileManager fileManager)
    {
        _productServices = productServices;
        _mapper = mapper;
        _fileManager = fileManager;
    }
    public async Task<Response<ProductGetAllResult>> Handle(ProductGetAllModel request, CancellationToken cancellationToken)
    {
        var result = await _productServices.GetAllProductAsync(request.pageNumber, null, i => !i.IsDeleted);
        var products = _mapper.Map<List<ProductGetAllResultItem>>(result.products);
        foreach (ProductGetAllResultItem item in products)
        {
            string imageBase64 = _fileManager.ImageBase64(item.Image, FolderName.ProductsImages.ToString());
            item.ImageBase64 = imageBase64;
        }

        return Success(new ProductGetAllResult { pageCount = result.pageCount, products = products });
    }

    public async Task<Response<ProductGetAllResult>> Handle(ProductGetInSubCategoryModel request, CancellationToken cancellationToken)
    {
        var result = await _productServices.GetAllProductAsync(request.pageNumber, request.SubCategoryId, i => !i.IsDeleted && i.SubCategoryId == request.SubCategoryId);
        var products = _mapper.Map<List<ProductGetAllResultItem>>(result.products);
        foreach (ProductGetAllResultItem item in products)
        {
            string imageBase64 = _fileManager.ImageBase64(item.Image, FolderName.ProductsImages.ToString());
            item.ImageBase64 = imageBase64;
        }

        return Success(new ProductGetAllResult { pageCount = result.pageCount, products = products });
    }
}
