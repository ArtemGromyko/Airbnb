using WebApi.Extensions;
using MediatR;
using Application.Commands.CreateRoom;
using Application.Common.Behaviours;
using WebApi.Middlewares;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using Serilog;
using Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    {
        configuration.Enrich.FromLogContext()
            .ReadFrom.Configuration(context.Configuration);
    });

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false)
    .AddFluentValidation(c =>
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
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<RepositoryContext>();
    context?.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
