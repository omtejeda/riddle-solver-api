
using RiddleSolver.Api.Extensions;
using RiddleSolver.Core;
using RiddleSolver.Data;
using RiddleSolver.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCore();
builder.Services.AddData();
builder.Services.AddApi();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseApiSwagger();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

await app.RunAsync();