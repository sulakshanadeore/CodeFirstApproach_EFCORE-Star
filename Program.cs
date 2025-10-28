using CodeFirstApproach_EFCORE.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShoppingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingDB-Star_CnString")));

//builder.Services.AddDbContext<ShoppingDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("ShoppingDB-Star_CnString"),new MySqlServerVersion(new Version(9,5,0))));

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductOperations, ProductServiceOperations>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
