namespace Ecommerce.Core.Feature.SubCategoryFeature.Query.Handler;

public sealed class SubCategoryQueryHandler : ResponseHandler,
    IRequestHandler<SubCategoryGetAllModel, Response<IEnumerable<SubCategoryGetAllResult>>>,
    IRequestHandler<SubCategoryGetByIdModel, Response<SubCategoryGetByIdResult>>
{
    private readonly ISubCategoryServices _subCategoryServices;
    private readonly IMapper _mapper;
    public SubCategoryQueryHandler(ISubCategoryServices subCategoryServices, IMapper mapper)
    {
        _subCategoryServices = subCategoryServices;
        _mapper = mapper;
    }
    public async Task<Response<IEnumerable<SubCategoryGetAllResult>>> Handle(SubCategoryGetAllModel request, CancellationToken cancellationToken)
    {
        var result = _subCategoryServices.GetAll(request.Id);
        return Success(_mapper.Map<IEnumerable<SubCategoryGetAllResult>>(result));
    }

    public async Task<Response<SubCategoryGetByIdResult>> Handle(SubCategoryGetByIdModel request, CancellationToken cancellationToken)
    {
        var result = await _subCategoryServices.GetByIdAsync(request.Id);
        return Success(_mapper.Map<SubCategoryGetByIdResult>(result));
    }
}
