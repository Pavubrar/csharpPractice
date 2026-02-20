using csharpPractice.Data;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WalkDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("WalksConnectioString"))
);

var app = builder.Build();

// IMPORTANT: Azure reverse proxy support
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders =
        ForwardedHeaders.XForwardedFor |
        ForwardedHeaders.XForwardedProto
});

// Swagger (safe for staging)
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ❌ Do NOT use HTTPS redirection on Azure Linux
// Azure handles HTTPS before reaching the app

app.UseRouting();

app.UseAuthorization();

// Health check (safe)
app.MapGet("/health", () => Results.Ok(new
{
    status = "Healthy",
    environment = app.Environment.EnvironmentName,
    machine = Environment.MachineName
}));

app.MapControllers();

app.Run();