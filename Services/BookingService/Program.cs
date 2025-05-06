using BookingService.Data;
using BookingService.Interfaces;
using BookingService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BookingService.Filters;

var builder = WebApplication.CreateBuilder(args);

// Controller und DB
builder.Services.AddControllers();
builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BookingDatabase")));
builder.Services.AddScoped<IBookingService, BookingService.Services.BookingService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SkyBooker.BookingService", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkyBooker.BookingService v1");
    c.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();