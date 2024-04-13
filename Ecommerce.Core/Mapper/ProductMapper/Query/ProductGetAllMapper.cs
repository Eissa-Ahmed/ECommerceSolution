namespace Ecommerce.Core.Mapper.ProductMapper;

public partial class ProductProfile
{
    private void ApplyProductGetAllMapper()
    {
        CreateMap<Product, ProductGetAllResultItem>();
        //.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category!.Name))
        //.ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.SubCategory!.Name));
    }
}
