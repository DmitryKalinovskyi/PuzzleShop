using Microsoft.EntityFrameworkCore;
using PuzzleShop.Data;
using PuzzleShop.Repository.Implementation;
using PuzzleShop.Repository.Interfaces;
using PuzzleShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add repository services
builder.Services.AddScoped<IPuzzleRepository, PuzzleRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Initialize db context
builder.Services.AddDbContext<PuzzleShopContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("PuzzleShopContext")));

// Identity framework setup
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<PuzzleShopContext>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
