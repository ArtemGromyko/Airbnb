using FluentValidation;

namespace Application.Queries.GetReservationForRoom;

public class GetReservationForRoomQueryValidator : AbstractValidator<GetReservationForRoomQuery>
{
    public GetReservationForRoomQueryValidator()
    {
        RuleFor(getReservationForRoomQuery => getReservationForRoomQuery.Id)
            .NotEmpty();
    }
}
