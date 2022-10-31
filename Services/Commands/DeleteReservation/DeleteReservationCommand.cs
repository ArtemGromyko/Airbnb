using MediatR;

namespace Application.Commands.DeleteReservation;

public record DeleteReservationCommand(Guid RoomId, Guid Id) : IRequest;
