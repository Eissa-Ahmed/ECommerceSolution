namespace Ecommerce.Core.Feature.ProductFeature.Command.Handler;

public sealed class ProductCommandHandler : ResponseHandler,
    IRequestHandler<ProductAddModel, Response<ProductAddResult>>,
    IRequestHandler<ProductUpdateModel, Response<ProductUpdateResult>>,
    IRequestHandler<ProductDeleteModel, Response<string>>
{
    private readonly IProductServices _productServices;
    private readonly IMapper _mapper;
    public ProductCommandHandler(IProductServices productServices, IMapper mapper)
    {
        _productServices = productServices;
        _mapper = mapper;
    }
    public async Task<Response<ProductAddResult>> Handle(ProductAddModel request, CancellationToken cancellationToken)
    {
        var (product, imageBase64) = await _productServices.addProductAsync(_mapper.Map<Product>(request), request.Image);
        var result = _mapper.Map<ProductAddResult>(product);
        result.ImageBase64 = imageBase64;
        return Success(result);
    }

    public async Task<Response<string>> Handle(ProductDeleteModel request, CancellationToken cancellationToken)
    {
        string result = await _productServices.DeleteProductAsync(request.ProductId);
        return Success(result);
    }

    public async Task<Response<ProductUpdateResult>> Handle(ProductUpdateModel request, CancellationToken cancellationToken)
    {
        Product product = await _productServices.GetByIdAsync(request.ProductId);
        product = await _productServices.UpdateProductAsync(_mapper.Map(request, product), request.ImageFile);
        return Success(_mapper.Map<ProductUpdateResult>(product));
    }
}
