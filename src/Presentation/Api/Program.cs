using BusinessManagement;
using ProductsCatalog;
using Scalar.AspNetCore;
using ServicesCatalog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddBusinessManagementModule(builder.Configuration)
    .AddProductsCatalogModule(builder.Configuration)
    .AddServicesCatalogModule(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

#region Needed for integration tests web application factory

#pragma warning disable CA1515 // Consider making public types internal
#pragma warning disable S1118 // Utility classes should not have public constructors

public partial class Program
#pragma warning restore S1118 // Utility classes should not have public constructors
#pragma warning restore CA1515 // Consider making public types internal
{
}

#endregion Needed for integration tests web application factory
