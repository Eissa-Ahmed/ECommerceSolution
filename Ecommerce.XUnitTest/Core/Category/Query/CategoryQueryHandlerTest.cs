namespace Ecommerce.XUnitTest.Core.Category.Query;

public sealed class CategoryQueryHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<ICategoryServices> _mockCategoryServices;
    private readonly CategoryProfile _categoryProfile;
    public CategoryQueryHandlerTest()
    {
        _categoryProfile = new();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(_categoryProfile));
        _mapper = new Mapper(config);
        _mockCategoryServices = new();
    }

    [Fact]
    public async Task CategoryGetAll_NotNullAndNotEmpty_ReturnCategories()
    {
        // Arrange
        var query = new CategoryGetAllModel();
        var categories = new List<Ecommerce.Data.Entities.Category>()
        {
            new Ecommerce.Data.Entities.Category()
            {
               CategoryId = "1",
               Name = "Laptop",
            }
        };
        var handler = new CategoryQueryHandler(_mockCategoryServices.Object, _mapper);

        // Act
        _mockCategoryServices.Setup(x => x.GetAll()).Returns(categories);
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Data.Should().NotBeNullOrEmpty();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().BeOfType<List<CategoryGetAllResult>>();
    }

    [Fact]
    public async Task CategoryGetById_IdNotNullAndExist_ReturnCategory()
    {
        // Arrange
        var handler = new CategoryQueryHandler(_mockCategoryServices.Object, _mapper);
        var query = new CategoryGetByIdModel("0af5aebd-3138-4834-bb8a-809ed34c843d");

        // Act
        _mockCategoryServices.Setup(x => x.GetByIdAsync(query.Id)).Returns(Task.FromResult(new Ecommerce.Data.Entities.Category()));
        var result = await handler.Handle(query, CancellationToken.None);
        // Assert
        result.Data.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
    }

    [Theory]
    [InlineData("0af5aebd-3138-4834-bb8a-809ed34c843d")]
    public async Task CategoryGetById_IdNotExist_StatusCode404(string Id)
    {
        // Arrange
        var handler = new CategoryQueryHandler(_mockCategoryServices.Object, _mapper);
        var query = new CategoryGetByIdModel(Id);
        var category = new Ecommerce.Data.Entities.Category()
        {
            CategoryId = "0af5aebd-3138-4834-bb8a-809ed34c843d",
            Name = "Laptop",
        };
        // Act
        _mockCategoryServices.Setup(x => x.GetByIdAsync(query.Id)).Returns(Task.FromResult(category));
        var result = await handler.Handle(query, CancellationToken.None);
        // Assert
        //result.StatusCode.Should().Be(HttpStatusCode.UnprocessableContent);
        result.Succeeded.Should().BeFalse();
    }
}
