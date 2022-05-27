using Application.Common.Exceptions;
using Application.Queries.GetReservationListForRoom;
using AutoMapper;
using Contracts.DTO;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetReservationsForRoom
{
    public class GetReservationsForRoomQueryHandler
        : IRequestHandler<GetReservationListForRoomQuery, List<ReservationDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsForRoomQueryHandler(IMapper mapper,
            IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<List<ReservationDTO>> Handle(GetReservationListForRoomQuery request, 
            CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.roomId);
            if (room == null)
            {
                throw new NotFoundException(nameof(room), request.roomId);
            }

            var reservations = await _reservationRepository.GetReservationListForRoomAsync(request.roomId);

            return _mapper.Map<List<ReservationDTO>>(reservations);
        }
    }
}
