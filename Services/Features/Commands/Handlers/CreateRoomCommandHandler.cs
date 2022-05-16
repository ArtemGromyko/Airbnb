using Domain.Repositories;
using MediatR;
using Services.Features.Commands.Commands;

namespace Services.Features.Commands.Handlers;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
{
    private readonly IRoomRepository _roomRepository;

    public CreateRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
