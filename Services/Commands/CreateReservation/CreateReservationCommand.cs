using MediatR;

namespace Application.Commands.CreateReservation;

public record CreateReservationCommand(DateTime StartDate, DateTime EndDate, Guid RoomId) : IRequest<Guid>;
