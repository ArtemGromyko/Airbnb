namespace Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid RoomId { get; set; }
    public Room Room { get; set; }
}
