using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapGet("/asdf", () => "{ \"title\": \"PROXY\" }");
app.MapReverseProxy();

// app.UseHttpsRedirection();
// dotnet dev-certs https --trust
// that's literally it

app.UseStaticFiles();
app.UseRouting();

app.Run();
