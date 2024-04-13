namespace Ecommerce.Core.Feature.CategoryFeature.Command.Handler;

public sealed class CategoryCommandHandler : ResponseHandler,
    IRequestHandler<CategoryAddModel, Response<CategoryAddResult>>,
    IRequestHandler<CategoryDeleteModel, Response<string>>,
    IRequestHandler<CategoryUpdateModel, Response<CategoryUpdateResult>>

{
    private readonly ICategoryServices _categoryServices;
    private readonly IMapper _mapper;
    public CategoryCommandHandler(ICategoryServices categoryServices, IMapper mapper)
    {
        _categoryServices = categoryServices;
        _mapper = mapper;
    }
    public async Task<Response<CategoryAddResult>> Handle(CategoryAddModel request, CancellationToken cancellationToken)
    {
        var result = await _categoryServices.AddAsync(_mapper.Map<Category>(request));
        return Created(_mapper.Map<CategoryAddResult>(result));
    }

    public async Task<Response<string>> Handle(CategoryDeleteModel request, CancellationToken cancellationToken)
    {
        var result = await _categoryServices.DeleteAsync(request.Id);
        return Success(result);
    }

    public async Task<Response<CategoryUpdateResult>> Handle(CategoryUpdateModel request, CancellationToken cancellationToken)
    {
        var category = await _categoryServices.GetByIdAsync(request.Id);
        category = _mapper.Map(request, category);
        var result = await _categoryServices.UpdateAsync(category);
        return Success(_mapper.Map<CategoryUpdateResult>(result));
    }
}
