using Application.Queries.GetReservationListForRoom;
using FluentValidation;

namespace Application.Queries.GetReservationsForRoom;

public class GetReservationListForRoomValidator : AbstractValidator<GetReservationListForRoomQuery>
{
    public GetReservationListForRoomValidator()
    {
        RuleFor(getReservationListForRoomQuery => getReservationListForRoomQuery.RoomId)
            .NotEmpty();
    }
}
