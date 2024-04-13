namespace Ecommerce.Core.Feature.SubCategoryFeature.Command.Handler;

public sealed class SubCategoryCommandHandler : ResponseHandler,
    IRequestHandler<SubCategoryAddModel, Response<SubCategoryAddResult>>,
    IRequestHandler<SubCategoryUpdateModel, Response<SubCategoryUpdateResult>>,
    IRequestHandler<SubCategoryDeleteModel, Response<string>>
{
    private readonly ISubCategoryServices _subCategoryServices;
    private readonly IMapper _mapper;
    public SubCategoryCommandHandler(IMapper mapper, ISubCategoryServices subCategoryServices)
    {
        _mapper = mapper;
        _subCategoryServices = subCategoryServices;
    }

    public async Task<Response<SubCategoryAddResult>> Handle(SubCategoryAddModel request, CancellationToken cancellationToken)
    {
        var result = await _subCategoryServices.AddAsync(_mapper.Map<SubCategory>(request));
        return Success(_mapper.Map<SubCategoryAddResult>(result));
    }

    public async Task<Response<SubCategoryUpdateResult>> Handle(SubCategoryUpdateModel request, CancellationToken cancellationToken)
    {
        var result = await _subCategoryServices.UpdateAsync(_mapper.Map<SubCategory>(request));
        return Success(_mapper.Map<SubCategoryUpdateResult>(result));
    }

    public async Task<Response<string>> Handle(SubCategoryDeleteModel request, CancellationToken cancellationToken)
    {
        var result = await _subCategoryServices.RemoveAsync(request.Id);
        return Success(result);
    }
}
