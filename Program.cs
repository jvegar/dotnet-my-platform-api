// Startup.cs or Program.cs
using dotnet_my_platform_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load allowed origins from appsettings.json
var allowedOrigins = builder.Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();

// Add services to the container.
builder.Services.AddDbContext<MyPlatformContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "AllowMultipleDomains", policy =>
  {
    if (allowedOrigins != null && allowedOrigins.Length > 0)
    {
      policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod(); // Allow all methods including PUT
    }
    else
    {
      // Fallback policy if no origins are provided
      policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    }
  });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowMultipleDomains"); // Use the CORS policy
app.UseAuthorization();
app.MapControllers();

app.Run();