using Microsoft.EntityFrameworkCore;
using PuzzleShop.Data;
using PuzzleShop.Providers.Implementation;
using PuzzleShop.Providers.Interfaces;
using PuzzleShop.Repository.Implementation;
using PuzzleShop.Repository.Interfaces;
using PuzzleShop.Services;
using PuzzleShop.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Initialize db context
builder.Services.AddDbContext<PuzzleShopContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("PuzzleShopContext")));

// Add repository services
builder.Services.AddScoped<IPuzzleRepository, PuzzleRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IOrderProvider, OrderProvider>();

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

app.Run();
