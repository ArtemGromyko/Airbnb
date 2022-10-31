using AutoMapper;
using Contracts.DTO;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetReservations;

public class GetReservationListQueryHandler : IRequestHandler<GetReservationListQuery, List<ReservationDTO>>
{
    private readonly IMapper _mapper;
    private readonly IReservationRepository _reservationRepository;

    public GetReservationListQueryHandler(IMapper mapper, IReservationRepository reservationRepository)
    {
        _mapper = mapper;
        _reservationRepository = reservationRepository;
    }

    public async Task<List<ReservationDTO>> Handle(GetReservationListQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetReservationListAsync();

        return _mapper.Map<List<ReservationDTO>>(reservations);
    }
}
