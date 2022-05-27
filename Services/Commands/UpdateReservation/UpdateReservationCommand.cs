using MediatR;

namespace Application.Commands.UpdateReservation;

public record UpdateReservationCommand(DateTime StartDate, DateTime EndDate, Guid RoomId) : IRequest;
