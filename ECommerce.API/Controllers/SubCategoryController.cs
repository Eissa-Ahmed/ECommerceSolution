namespace ECommerce.API.Controllers;

[ApiController]
public class SubCategoryController : BaseController
{
    [HttpGet(Routes.SubCategory.GetAll)]
    public async Task<IActionResult> GetAll(string? CategoryId = null)
    {
        var result = await _mediator.Send(new SubCategoryGetAllModel(CategoryId));
        return BaseResult(result);
    }
    [HttpGet(Routes.SubCategory.Get)]
    public async Task<IActionResult> GetAsync(string id)
    {
        var result = await _mediator.Send(new SubCategoryGetByIdModel(id));
        return BaseResult(result);
    }
    [HttpPost(Routes.SubCategory.Create)]
    public async Task<IActionResult> CreateAsync([FromBody] SubCategoryAddModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }
    [HttpPut(Routes.SubCategory.Update)]
    [ServiceFilter(typeof(CheckHeaderParameterAttribute))]
    public async Task<IActionResult> UpdateAsync([FromBody] SubCategoryUpdateModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }
    [HttpDelete(Routes.SubCategory.Delete)]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var result = await _mediator.Send(new SubCategoryDeleteModel(id));
        return BaseResult(result);
    }
}
