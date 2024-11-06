using Translation.Application.Interfaces;
using Translation.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddHttpClient<TranslationService>();
services.AddSingleton<ICacheService, MemoryCacheService>();
services.AddTransient<ITranslationService, TranslationService>();
services.AddMemoryCache();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();