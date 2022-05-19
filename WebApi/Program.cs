using WebApi.Extensions;
using MediatR;
using Application.Commands.CreateRoom;
using Application.Common.Behaviours;
using FluentValidation;
using WebApi.Middlewares;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers().AddFluentValidation(c =>
{
    c.RegisterValidatorsFromAssemblyContaining<CreateRoomCommand>();
    c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
});
services.AddEndpointsApiExplorer();
services.AddMediatR(typeof(CreateRoomCommand).Assembly);
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
services.AddFluentValidationRulesToSwagger();
services.AddSwaggerGen();
services.ConfigureSqlContext(configuration);
services.ConfigureRepositories();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
