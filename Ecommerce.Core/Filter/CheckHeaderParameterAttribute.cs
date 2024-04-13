namespace Ecommerce.Core.Filter;

public sealed class CheckHeaderParameterAttribute : ActionFilterAttribute
{
    private readonly ILogger<CheckHeaderParameterAttribute> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public CheckHeaderParameterAttribute(ILogger<CheckHeaderParameterAttribute> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var response = new Response<string>();
        response.StatusCode = HttpStatusCode.NotFound;
        response.Errors = new List<string>() { "id not found" };
        string? id = context.HttpContext.Request.RouteValues["id"]?.ToString();

        try
        {
            if (string.IsNullOrEmpty(id)) throw new Exception("id not found");
            else
            {
                var category = _unitOfWork.CategoryRepository.GetTableNoTracking(i => i.CategoryId == id).FirstOrDefault();
                if (category is null)
                {
                    var subCategory = _unitOfWork.SubCategoryRepository.GetTableNoTracking(i => i.SubCategoryId == id).FirstOrDefault();
                    if (subCategory == null)
                    {
                        var product = _unitOfWork.ProductRepository.GetTableNoTracking(i => i.ProductId == id).FirstOrDefault();
                        if (product == null)
                            throw new Exception("id not Correct");
                    }
                }

            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Result = new NotFoundObjectResult(response);
        }
        base.OnActionExecuting(context);
    }
}
