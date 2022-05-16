using MediatR;

namespace Services.Features.Commands.Commands;

public record CreateRoomCommand(string Address, bool HasInternet, decimal Price) : IRequest<Guid>;