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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
