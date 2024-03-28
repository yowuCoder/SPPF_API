using Microsoft.EntityFrameworkCore;

using SPPF_API.Models;
using SPPF_API.Models.COTIOT;
using System.Configuration;
using Microsoft.Extensions.Hosting;
using SPPF_API.Middleware;
using SPPF_API.Background;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<HostOptions>(options =>
{
    options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddDbContext<CotiotContext>((provider, options) =>
{
    
    var connectionStringName = builder.Environment.IsDevelopment() ? "localDashboard" : "Dashboard";
    var connectionString = provider.GetRequiredService<IConfiguration>().GetConnectionString(connectionStringName);
    options.UseSqlServer(connectionString);
});*/
builder.Services.ConfigurationHostService();
using var loggerFactory = LoggerFactory.Create(static builder =>
{
    builder
        .AddFilter("Microsoft", LogLevel.Warning)
        .AddFilter("System", LogLevel.Warning)
        .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
        .AddConsole();
});
builder.Services.AddDbContext<CotiotContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("Dashboard")));
builder.Services.AddCors(options =>
{

    options.AddPolicy("AllowAnyOrigins", policy =>
      policy.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials());

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigins");
app.UseAuthorization();

app.MapControllers();


//app.MapAlarmRecordEndpoints();

app.Run();
