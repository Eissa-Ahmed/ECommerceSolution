namespace ECommerce.API.Controllers;

[ApiController]
[AllowAnonymous]
public class FavoriteController : BaseController
{

    [HttpGet(Routes.Favorite.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new FavoriteGetAllModel());
        return BaseResult(result);
    }
    [HttpPost(Routes.Favorite.Create)]
    public async Task<IActionResult> CreateAsnc(string productId)
    {
        var result = await _mediator.Send(new FavoriteAddModel(productId));
        return BaseResult(result);
    }
    [HttpDelete(Routes.Favorite.Delete)]
    public async Task<IActionResult> RemoveAsnc(string id)
    {
        var result = await _mediator.Send(new FavoriteRemoveModel(id));
        return BaseResult(result);
    }

}
