using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetRooms;

public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, List<RoomDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;

    public GetRoomListQueryHandler(IMapper mapper, IRoomRepository roomRepository)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
    }

    public async Task<List<RoomDTO>> Handle(GetRoomListQuery query, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetRoomListAsync();

        return _mapper.Map<List<RoomDTO>>(rooms);
    }
}
