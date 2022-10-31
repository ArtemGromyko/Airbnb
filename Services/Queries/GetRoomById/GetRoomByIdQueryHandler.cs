using Application.Common.Exceptions;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetRoomById;

public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDTO>
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;

    public GetRoomByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
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
