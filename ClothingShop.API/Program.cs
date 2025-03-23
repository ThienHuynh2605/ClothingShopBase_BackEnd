using System.Diagnostics;
using ClothingShop.API.Middlewares;
using ClothingShop.Application.IServices;
using ClothingShop.Application.Mappers;
using ClothingShop.Application.Services;
using ClothingShop.Infrastructure;
using ClothingShop.Infrastructure.IRepositories;
using ClothingShop.Infrastructure.Persistence;
using ClothingShop.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Addconnection string
builder.Services.AddInfrastructure(builder.Configuration);

// Add Dependency Injection for Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductVariantRepository, ProductVariantRepository>();

// Add Dependency Injection for Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductVariantService, ProductVariantService>();

// Add AutoMapper in Service
builder.Services.AddAutoMapper(typeof(UserMapping));
builder.Services.AddAutoMapper(typeof(ProductMapping));
builder.Services.AddAutoMapper(typeof(ProductVariantMapping));

// Add AutoMapper in Repository
builder.Services.AddAutoMapper(typeof(MapperProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Exception services
builder.Services.AddExceptionHandler<ErrorHandlerMiddleware>();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance =
            $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";

        Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
        context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
