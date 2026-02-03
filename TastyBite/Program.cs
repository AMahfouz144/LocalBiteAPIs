using Api.Extensions;
using API.Core;
using API.Middlewares;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.ConfigareAPI();

var app = builder.Build();

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
await app.UseDatabaseSeeding();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAngular");

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();