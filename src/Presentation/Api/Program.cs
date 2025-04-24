using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.MapGet("/", () => "Hello World!");

await app.RunAsync();
