using WareSync.API.Interfaces;
using WareSync.API.Services;
using WareSync.API.Stores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Stores as Singletons (In-Memory Data)
builder.Services.AddSingleton<ProductStore>();
builder.Services.AddSingleton<CategoryStore>();
builder.Services.AddSingleton<SupplierStore>();

// Register Services as Scoped (Business Logic)
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

// OpenAPI
builder.Services.AddOpenApi();

// Swagger (Swashbuckle) - provides Swagger UI at /swagger for controllers
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Swashbuckle middleware for Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WareSync API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();