namespace Ecommerce.Core.Feature.FavoriteFeature.Command.Handler;

public sealed class FavoriteCommandHandler : ResponseHandler,
    IRequestHandler<FavoriteAddModel, Response<FavoriteAddResult>>,
    IRequestHandler<FavoriteRemoveModel, Response<string>>
{
    private readonly IFavoriteServices _favoriteServices;
    private readonly IMapper _mapper;
    public FavoriteCommandHandler(IFavoriteServices favoriteServices, IMapper mapper)
    {
        _favoriteServices = favoriteServices;
        _mapper = mapper;
    }
    public async Task<Response<FavoriteAddResult>> Handle(FavoriteAddModel request, CancellationToken cancellationToken)
    {
        Favorite? favorite = await _favoriteServices.AddAsync(request.ProductId);
        return Success(_mapper.Map<FavoriteAddResult>(favorite));
    }

    public async Task<Response<string>> Handle(FavoriteRemoveModel request, CancellationToken cancellationToken)
    {
        string result = await _favoriteServices.RemoveAsync(request.favoriteId);
        return Success(result);
    }
}
