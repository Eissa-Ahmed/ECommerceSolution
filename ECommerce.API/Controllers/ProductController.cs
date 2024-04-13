namespace ECommerce.API.Controllers;

[ApiController]
[AllowAnonymous]
public class ProductController : BaseController
{
    //[Authorize(policy: ApplicationPermission.ViewProduct)]

    [HttpGet(Routes.Product.GetAll)]
    public async Task<IActionResult> GetAllAsync(int pageNumber)
    {
        var result = await _mediator.Send(new ProductGetAllModel(pageNumber));
        return BaseResult(result);
    }
    [HttpGet(Routes.Product.GetAllInSubCategory)]
    public async Task<IActionResult> GetAllAsync(string subCategoryId, int pageNumber)
    {
        var result = await _mediator.Send(new ProductGetInSubCategoryModel(subCategoryId, pageNumber));
        return BaseResult(result);
    }
    [HttpPost(Routes.Product.Create)]
    public async Task<IActionResult> CreateAsync([FromForm] ProductAddModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }
    [HttpPut(Routes.Product.Update)]
    [ServiceFilter(typeof(CheckHeaderParameterAttribute))]
    public async Task<IActionResult> UpdateAsync([FromForm] ProductUpdateModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }
    [HttpDelete(Routes.Product.Delete)]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var result = await _mediator.Send(new ProductDeleteModel(id));
        return BaseResult(result);
    }
}
