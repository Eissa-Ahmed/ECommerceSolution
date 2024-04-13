var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    await SeedRoles.SeedAsync(_roleManager);
    await SeedPermissions.SeedAsync(_roleManager);
    await SeedUser.SeedAsync(_userManager);
    await SeedCategories.SeedAsync(_dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard("/dash");

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
