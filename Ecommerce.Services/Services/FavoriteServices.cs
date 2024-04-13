
namespace Ecommerce.Services.Services;

public sealed class FavoriteServices : IFavoriteServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationServices _authenticationServices;
    public FavoriteServices(IUnitOfWork unitOfWork, IAuthenticationServices authenticationServices)
    {
        _unitOfWork = unitOfWork;
        _authenticationServices = authenticationServices;
    }
    public async Task<Favorite> AddAsync(string productId)
    {
        string? userId = _authenticationServices.GetUserIdFromToken();
        Favorite favorite = await _unitOfWork.FavoriteRepository.AddAsync(new Favorite { ProductId = productId, UserId = userId });
        return favorite;
    }

    public IEnumerable<Product> GetAllAsync()
    {
        string? userId = _authenticationServices.GetUserIdFromToken();
        return _unitOfWork.FavoriteRepository.GetTableNoTracking(i => i.UserId == userId).Include(i => i.Product).Select(i => i.Product).ToList()!;
    }

    public async Task<string> RemoveAsync(string favoriteId)
    {
        Favorite? favorite = await _unitOfWork.FavoriteRepository.GetByIdAsync(favoriteId);
        await _unitOfWork.FavoriteRepository.DeleteAsync(favorite);
        return "Success";
    }
}
