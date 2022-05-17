using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetRooms;

internal class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, List<RoomDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;

    public GetRoomsQueryHandler(IMapper mapper, IRoomRepository roomRepository)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
    }

    public async Task<List<RoomDTO>> Handle(GetRoomsQuery query, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetRoomListAsync();

        return _mapper.Map<List<RoomDTO>>(rooms);
    }
}
