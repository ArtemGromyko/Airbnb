using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

internal class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(r => r.Address).HasMaxLength(150);
        builder.Property(r => r.Price).HasColumnType("money");

        builder.HasData
        (
            new Room
            {
                Id = new Guid("75518431-3035-4a5d-8f91-d8a6e8f8af47"),
                Address = "10019, West 53rd Street, New York",
                HasInternet = true,
                Price = 80,
            },
            new Room
            {
                Id = new Guid("601ec7d3-b5c9-43c8-8adb-63fdc67bb1bd"),
                Address = "10014, Perry Street, New York",
                HasInternet = true,
                Price = 100,
            }
        );
    }
}
