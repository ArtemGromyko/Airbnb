using MediatR;

namespace Application.Commands.UpdateReservation;

public record UpdateReservationCommand(Guid RoomId, Guid Id, DateTime StartDate,
    DateTime EndDate) : IRequest;
