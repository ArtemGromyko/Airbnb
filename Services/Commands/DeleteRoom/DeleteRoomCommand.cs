using MediatR;

namespace Application.Commands.DeleteRoom;

public record DeleteRoomCommand(Guid Id) : IRequest;
