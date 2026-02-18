using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using tv_espresso.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("VideoCors", policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddSingleton<VideoService>();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null); ;
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors("VideoCors");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".mp4"] = "video/mp4";
provider.Mappings[".mkv"] = "video/x-matroska";
provider.Mappings[".jpg"] = "image/jpeg";
provider.Mappings[".jpeg"] = "image/jpeg";
provider.Mappings[".png"] = "image/png";

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Accept-Ranges", "bytes");
    await next();
});

app.Use(async (context, next) =>
{
    if (context.Request.Path.HasValue)
        context.Request.Path = new PathString(context.Request.Path.Value.Replace('\\', Path.DirectorySeparatorChar));
    await next();
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Configuration["TvEspressoRoot"]!)),
    ContentTypeProvider = provider,
    ServeUnknownFileTypes = true
});

app.MapControllers();
app.UseAuthorization();

app.Run();
