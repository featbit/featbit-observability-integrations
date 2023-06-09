using System.Diagnostics;
using FeatBit.Sdk.Server;
using FeatBit.Sdk.Server.Options;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetryApm;
using OpenTelemetry.Logs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string openTelemetryServiceName = "OpenTelemetryAPM";
builder.Services.AddOpenTelemetry()
    .ConfigureResource(builder => builder
        .AddService(serviceName: openTelemetryServiceName))
    .WithTracing(builder => builder
        .AddAspNetCoreInstrumentation()
        .AddConsoleExporter()
        .AddOtlpExporter())
    .WithMetrics(builder => builder
        .AddAspNetCoreInstrumentation()
        .AddConsoleExporter()
        .AddOtlpExporter());

var logger = LoggerFactory.Create(builder =>
{
    builder.AddOpenTelemetry(options =>
    {
        options.AddConsoleExporter();
        // add opentelemetry otel log exporter - not stable yet
        // https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/src/OpenTelemetry.Exporter.OpenTelemetryProtocol#enable-log-exporter

    });
}).CreateLogger("Program");


// Add and Initilize Singleton FeatBit Service
var fbClient = new FbClient(new FbOptionsBuilder("z4nZw2HYDkCGnB09R12TnAKIvcqEmwcUK-2mWFtGURaQ")
                                    .Event(new Uri("https://featbit-tio-eu-eval.azurewebsites.net"))
                                    .Steaming(new Uri("wss://featbit-tio-eu-eval.azurewebsites.net"))
                                    .Build());
if (fbClient.Initialized)
{
    builder.Services.AddSingleton(fbClient);
    builder.Services.AddSingleton<IOtelFeatBitClient, OtelFeatBitClient>();
}
else
    throw new Exception("FeatBit Client not initialized");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public static class DiagnosticsConfig
{
    public const string ServiceName = "FeatBitGuanceService";
    public static ActivitySource ActivitySource = new ActivitySource(ServiceName);
}