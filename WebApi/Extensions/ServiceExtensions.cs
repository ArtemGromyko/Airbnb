using Airbnb.DAL.Repositories;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace WebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRoomRepository, RoomRepository>();
    }
}
