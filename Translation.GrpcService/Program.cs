using Translation.Application.Interfaces;
using Translation.GrpcService.Services;
using Translation.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddGrpc();
services.AddMemoryCache();
builder.Services.AddHttpClient<TranslationService>();
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
builder.Services.AddTransient<ITranslationService, TranslationService>();

var app = builder.Build();

app.UseRouting();
app.MapGrpcService<TranslationGrpcService>();

app.Run();