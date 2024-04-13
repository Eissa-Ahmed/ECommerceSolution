using Ecommerce.Core.Feature.FavoriteFeature.Query.Model;

namespace Ecommerce.Core.Feature.FavoriteFeature.Query.Handler;

public sealed class FavoriteQueryHandler : ResponseHandler,
    IRequestHandler<FavoriteGetAllModel, Response<IEnumerable<FavoriteGetAllResult>>>
{
    private readonly IFavoriteServices _favoriteServices;
    private readonly IMapper _mapper;
    private readonly IFileManager _fileManager;
    public FavoriteQueryHandler(IFavoriteServices favoriteServices, IMapper mapper, IFileManager fileManager)
    {
        _favoriteServices = favoriteServices;
        _mapper = mapper;
        _fileManager = fileManager;
    }
    public async Task<Response<IEnumerable<FavoriteGetAllResult>>> Handle(FavoriteGetAllModel request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = _favoriteServices.GetAllAsync();
        IEnumerable<FavoriteGetAllResult> result = _mapper.Map<List<FavoriteGetAllResult>>(products);
        foreach (var item in result)
        {
            item.ImageBase64 = _fileManager.ImageBase64(item.Image, FolderName.ProductsImages.ToString());
        }
        return Success(result);
    }
}
