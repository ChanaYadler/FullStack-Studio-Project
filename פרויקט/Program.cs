using DAL.DalApi;
using DAL.DalModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBLCustomer, BLCustomerService>();
var app = builder.Build();
app.Run();
