using System.Text.Json.Serialization;
using CompanyService.Data;
using CompanyService.Services.CompanyServices;
using CompanyService.Services.SectorServices;
using Microsoft.EntityFrameworkCore;
using ModelService.Services.ModelService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<ICompanyService, CompanyService.Services.CompanyServices.CompanyService>();
builder.Services.AddScoped<IModelService, CompanyService.Services.ModelService.ModelService>();
builder.Services.AddScoped<ISectorService, CompanyService.Services.SectorServices.SectorService>();

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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
