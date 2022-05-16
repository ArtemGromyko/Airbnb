using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence;

public class RepositoryContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoomConfiguration());
    }
}
