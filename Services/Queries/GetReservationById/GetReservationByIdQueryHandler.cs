using Application.Common.Exceptions;
using AutoMapper;
using Contracts.DTO;
using Domain.Repositories;
using MediatR;

namespace Application.Queries.GetReservationById;

public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDTO>
{
    private readonly IMapper _mapper;
    private readonly IReservationRepository _reservationRepository;

    public GetReservationByIdQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task<ReservationDTO> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetReservationByIdAsync(request.Id);
        if (reservation == null)
        {
            throw new NotFoundException(nameof(reservation), request.Id);
        }

        return _mapper.Map<ReservationDTO>(reservation);
    }
}
