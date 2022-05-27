using Application.Common.Exceptions;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetRoomById;

internal class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDTO>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public GetRoomByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

    public async Task<RoomDTO> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetRoomByIdAsync(request.Id);
        if(room == null)
        {
            throw new NotFoundException(nameof(room), request.Id);
        }

        return _mapper.Map<RoomDTO>(room);
    }
}
