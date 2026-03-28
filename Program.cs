using Microsoft.OpenApi;
using System.Reflection;
using TweetBook.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var swaggerOptions = new SwaggerOptions();
builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Tweetbook API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger(option =>
{
    option.RouteTemplate = swaggerOptions.JsonRoute;
});

app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
