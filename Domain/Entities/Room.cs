namespace Domain.Entities;

public class Room
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public bool HasInternet { get; set; }
    public decimal Price { get; set; }
}
