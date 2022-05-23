namespace Contracts.DTO;

public record ReservationDTO(Guid Id, DateTime StartDate, DateTime EndDate, Guid RoomId);
