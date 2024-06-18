using DAL.DalApi;
using DAL.DalModels;
using BL;
using DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BLManager>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();