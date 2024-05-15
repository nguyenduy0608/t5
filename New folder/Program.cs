using Microsoft.EntityFrameworkCore;
using MIS.Context;
using MIS.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
builder.Services.AddCors();

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ManagerService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ShopService>();
builder.Services.AddScoped<StaffService>();
builder.Services.AddScoped<StatisticService>();
builder.Services.AddScoped<WarehouseService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
