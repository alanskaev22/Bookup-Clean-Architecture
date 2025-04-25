var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi(builder.Configuration)
    .AddBusinessManagementModule(builder.Configuration)
    .AddProductsCatalogModule(builder.Configuration)
    .AddServicesCatalogModule(builder.Configuration);

var app = builder.Build();

app
    .UseApi()
    .UseBusinessManagementModule()
    .UseProductsCatalogModule()
    .UseServicesCatalogModule();

await app.RunAsync();

#region Needed for integration tests web application factory

public partial class Program
{
}

#endregion Needed for integration tests web application factory