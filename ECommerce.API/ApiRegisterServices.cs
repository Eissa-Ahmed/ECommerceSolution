


using Ecommerce.Services.Email;

namespace ECommerce.API;

public static class ApiRegisterServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, WebApplicationBuilder builder)
    {

        addDefualtServices(builder);
        addSwaggerGen(builder);
        addDbContext(builder);
        addIdentity(builder);
        addCors(builder);
        debendencyInjection(builder);
        addSerilog(builder);
        addAutoMapper(builder);
        addFluentValidation(builder);
        addMediator(builder);
        addAuthentication(builder);
        addHangfire(builder);
        addEmailSettings(builder);


        return services;
    }

    private static void addEmailSettings(WebApplicationBuilder builder)
    {
        EmailSettings emailSettings = new EmailSettings();
        builder.Configuration.GetSection("EmailSettings").Bind(emailSettings);
        builder.Services.AddSingleton(emailSettings);
    }

    private static void addHangfire(WebApplicationBuilder builder)
    {
        builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add the processing server as IHostedService
        builder.Services.AddHangfireServer();
    }

    private static void addAuthentication(WebApplicationBuilder builder)
    {
        var jwt = new Jwt();
        builder.Configuration.GetSection("Jwt").Bind(jwt);
        builder.Services.AddSingleton(jwt);
        builder.Services.AddAuthentication(
            x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt.Issuer,
                    ValidAudience = jwt.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwt.Key)),
                    ClockSkew = TimeSpan.FromMinutes(jwt.ExpireMinutes)
                };
            });
    }

    private static void addMediator(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(typeof(ValidationBehavior<,>).Assembly));
    }

    private static void addFluentValidation(WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    private static void addAutoMapper(WebApplicationBuilder builder)
    {
        //builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddAutoMapper(typeof(ValidationBehavior<,>).Assembly);
    }

    private static void addSerilog(WebApplicationBuilder builder)
    {
        var columnOptions = new ColumnOptions();
        columnOptions.Store.Remove(StandardColumn.MessageTemplate);

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();
        builder.Logging.AddSerilog(logger);
    }

    private static void debendencyInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
        builder.Services.AddScoped<IProductServices, ProductServices>();
        builder.Services.AddScoped<ICategoryServices, CategoryServices>();
        builder.Services.AddScoped<ISubCategoryServices, SubCategoryServices>();
        builder.Services.AddScoped<IFavoriteServices, FavoriteServices>();
        builder.Services.AddScoped<IFileManager, FileManager>();
        builder.Services.AddScoped<CheckHeaderParameterAttribute>();
        builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        builder.Services.AddScoped<IBackgroundTasksServices, BackgroundTasksServices>();
        builder.Services.AddScoped<IEmailServices, EmailServices>();
    }

    private static void addCors(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }

    private static void addSwaggerGen(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce Project", Version = "v1" });
            c.EnableAnnotations();

            c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
            }
           });
        });
    }

    private static void addDefualtServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHttpContextAccessor();
    }

    private static void addIdentity(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<User, Role>(option =>
        {
            // Password settings.
            option.Password.RequireDigit = false;
            option.Password.RequireLowercase = true;
            option.Password.RequireNonAlphanumeric = false;
            option.Password.RequireUppercase = false;
            option.Password.RequiredLength = 6;
            option.Password.RequiredUniqueChars = 0;

            // Lockout settings.
            option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            option.Lockout.MaxFailedAccessAttempts = 3;
            option.Lockout.AllowedForNewUsers = true;

            // User settings.
            option.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            option.User.RequireUniqueEmail = true;
            option.SignIn.RequireConfirmedEmail = true;

        }).AddEntityFrameworkStores<ApplicationDBContext>()
          .AddDefaultTokenProviders();
    }

    private static void addDbContext(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDBContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            opt.AddInterceptors(new SoftDeletedInterceptor());
        });
    }
}
