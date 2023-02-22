using Acc.Api.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .ConfigureDbContext(builder.Configuration)
    .ConfigureAuth(builder.Configuration)
    .ConfigureApplicationServices()
    .ConfigureExternalDependencies()
    .ConfigureMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
