using Translation.Application.Interfaces;
using Translation.GrpcService.Services;
using Translation.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

var services = builder.Services;

services.AddGrpc();
services.AddMemoryCache();
services.AddSingleton<ITranslationService, TranslationService>();
services.AddScoped<TranslationGrpcService>();

var app = builder.Build();

app.UseRouting();
app.MapGrpcService<TranslationGrpcService>();

app.Run();