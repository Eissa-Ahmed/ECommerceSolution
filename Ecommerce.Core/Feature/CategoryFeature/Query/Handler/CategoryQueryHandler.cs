namespace Ecommerce.Core.Feature.CategoryFeature.Query.Handler;

public sealed class CategoryQueryHandler : ResponseHandler,
    IRequestHandler<CategoryGetAllModel, Response<IEnumerable<CategoryGetAllResult>>>,
    IRequestHandler<CategoryGetByIdModel, Response<CategoryGetByIdResult>>
{
    private readonly ICategoryServices _categoryServices;
    private readonly IMapper _mapper;
    public CategoryQueryHandler(ICategoryServices categoryServices, IMapper mapper)
    {
        _categoryServices = categoryServices;
        _mapper = mapper;
    }
    public async Task<Response<IEnumerable<CategoryGetAllResult>>> Handle(CategoryGetAllModel request, CancellationToken cancellationToken)
    {
        var categories = _categoryServices.GetAll();
        var result = _mapper.Map<IEnumerable<CategoryGetAllResult>>(categories);
        return Success(result);
    }

    public async Task<Response<CategoryGetByIdResult>> Handle(CategoryGetByIdModel request, CancellationToken cancellationToken)
    {
        var category = await _categoryServices.GetByIdAsync(request.Id);
        var result = _mapper.Map<CategoryGetByIdResult>(category);
        return Success(result);
    }
}
