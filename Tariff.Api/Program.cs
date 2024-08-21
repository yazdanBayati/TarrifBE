using Tariff.ApplicationService.TariffComparison;
using Tariff.Core.Providers;
using Tariff.Provider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Register application services
builder.Services.AddScoped<ITariffComparisonService, TariffComparisonService>();

// Register external tariff provider (mock or real)
builder.Services.AddScoped<IExternalTariffProvider, ExternalTariffProviderMock>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()// todo: need to allow specific origins
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();
// Use CORS
app.UseCors("AllowAllOrigins");

app.MapControllers();


app.Run();
