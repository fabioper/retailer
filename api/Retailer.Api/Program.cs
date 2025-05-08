using Retailer.Application;
using Retailer.Infrastructure;
using Scalar.AspNetCore;

const string apiDocsEndpointPrefix = "/docs";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(apiDocsEndpointPrefix);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
