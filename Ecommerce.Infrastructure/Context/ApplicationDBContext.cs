namespace Ecommerce.Infrastructure.Context;

public class ApplicationDBContext : IdentityDbContext<User, Role, string>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }

    public DbSet<Cart> Cart { get; set; }
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Favorite> Favorite { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<SubCategory> SubCategory { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Logs> Logs { get; set; }
}
