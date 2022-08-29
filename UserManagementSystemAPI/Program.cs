using Serilog;
using Serilog.Events;
using UserManagementSystemAPI.Extensions;
using UserManagementSystemAPI.Middleware;
using UserManagementSystemAPI.Services.Mappings;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();


try
{
    Log.Information("Starting web host");

    IConfiguration configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());


    builder.Services.AddAutoMapper(typeof(ServiceMappingProfile));
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ConfigureMySqlContext(configuration);
    builder.Services.ConfigureMiddleware(configuration);

    builder.Services.ConfigureServicesManager();
    builder.Services.ConfigureRepositoryManager();

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseCors(conf => conf.WithOrigins(configuration["AllowedOrigins"].Split(";"))
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

return 0;
