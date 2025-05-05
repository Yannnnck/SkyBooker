using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Ocelot Config laden
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Ocelot hinzufügen
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Middleware-Reihenfolge beachten
app.UseRouting();
app.UseEndpoints(endpoints => { });
await app.UseOcelot();

app.Run();