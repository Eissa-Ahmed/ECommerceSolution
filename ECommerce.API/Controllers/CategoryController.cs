namespace ECommerce.API.Controllers;

[ApiController]
[AllowAnonymous]
public class CategoryController : BaseController
{
    [HttpGet(Routes.Category.GetAll)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _mediator.Send(new CategoryGetAllModel());
        return BaseResult(result);
    }
    [HttpGet(Routes.Category.Get)]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var result = await _mediator.Send(new CategoryGetByIdModel(id));
        return BaseResult(result);
    }
    [HttpPost(Routes.Category.Create)]
    public async Task<IActionResult> CreateAsync([FromBody] CategoryAddModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }
    [HttpPut(Routes.Category.Update)]
    [ServiceFilter(typeof(CheckHeaderParameterAttribute))]
    public async Task<IActionResult> UpdateAsync([FromBody] CategoryUpdateModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }
    [HttpDelete(Routes.Category.Delete)]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var result = await _mediator.Send(new CategoryDeleteModel(id));
        return BaseResult(result);
    }
}
