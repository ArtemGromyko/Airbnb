using MediatR;

namespace Application.Commands.DeleteReservation;

public record DeleteReservationCommand(Guid Id) : IRequest;
