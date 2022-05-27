using Application.Common.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.DeleteReservation;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
{
    private readonly IReservationRepository _reservatioRepository;

    public DeleteReservationCommandHandler(IReservationRepository reservatioRepository)
    {
        _reservatioRepository = reservatioRepository;
    }

    public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservatioRepository.GetReservationByIdAsync(request.Id);
        if (reservation == null)
        {
            throw new NotFoundException(nameof(reservation), request.Id);
        }

        await _reservatioRepository.DeleteReservationAsync(reservation);

        return Unit.Value;
    }
}
