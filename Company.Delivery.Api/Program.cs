using Company.Delivery.Api.AppStart;
using Company.Delivery.Api.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDeliveryControllers();
builder.Services.AddDeliveryApi();
builder.Services.AddAutoMapper(typeof(CustomMapper));

var app = builder.Build();

app.UseDeliveryApi();
app.MapControllers();

app.Run();
