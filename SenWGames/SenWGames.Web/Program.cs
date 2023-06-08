using Microsoft.EntityFrameworkCore;
using SenWGames.Infrastructure;
using SenWGames.Web.Hubs;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SenwDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddTransient<DbContext, SenwDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SignalR
builder.Services.AddSignalR(options =>
{
    // Docs https://learn.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-7.0&tabs=dotnet
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(66); // should be double KeepAliveInterval
    options.KeepAliveInterval = TimeSpan.FromSeconds(33);
})
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }
);

builder.Services.AddSingleton<ISenWStateManager, SenWStateManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // must be called before UseMvc
    app.UseCors(builder =>
    {
        // this should be configured on the host. See App service > CORS. Values set here must only be used for localhost.
        builder.AllowAnyMethod().AllowAnyHeader().WithOrigins(
            "http://localhost:4200", "http://localhost:4201")
        .AllowCredentials();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
