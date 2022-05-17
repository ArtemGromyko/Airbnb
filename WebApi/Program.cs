using WebApi.Extensions;
using MediatR;
using Application.Commands.CreateRoom;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.ConfigureSqlContext(configuration);
services.ConfigureRepositories();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddMediatR(typeof(CreateRoomCommand).Assembly);

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
