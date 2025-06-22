using AssetManagementApi;
using AssetManagementApi.Models;
using AssetManagementApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AssetManagementDatabaseSettings>(
    builder.Configuration.GetSection("AssetManagementDatabase"));
    
// Add services to the container.
builder.Services.AddSingleton<IAssetManagementCommandHandler, AssetManagementCommandHandler>();
builder.Services.AddSingleton<IAssetManagementService, AssetManagementService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
         {
             options.AddPolicy("AllowLocalAngular",
                 builder =>
                 {
                     builder.WithOrigins("http://localhost:4200") // Replace with your Angular app's origin
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                 });
         });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowLocalAngular");

app.Run();
