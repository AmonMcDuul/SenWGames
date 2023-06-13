using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SenWGames.Infrastructure;
using SenWGames.Web.Hubs;
using System.Diagnostics;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SenWDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

// SignalR
////builder.Services.AddSignalR(options =>
////{
////    // Docs https://learn.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-7.0&tabs=dotnet
////    options.ClientTimeoutInterval = TimeSpan.FromSeconds(66); // should be double KeepAliveInterval
////    options.KeepAliveInterval = TimeSpan.FromSeconds(33);
////})
////                .AddJsonProtocol(options =>
////                {
////                    options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
////                }
////                                );

builder.Services.AddSignalR()
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }
);
builder.Services.AddSingleton<HubConnection>(provider => {
    var hubUrl = "https://localhost:7299/signalr"; // Replace with your SignalR hub URL
    return new HubConnectionBuilder()
        .WithUrl(hubUrl)
        .Build();
});
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

app.UseRouting();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// SignalR hub mapping
app.MapHub<SenWHub>("/signalr");

app.Run();
