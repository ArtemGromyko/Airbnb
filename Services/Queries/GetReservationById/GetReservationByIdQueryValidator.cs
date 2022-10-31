using FluentValidation;

namespace Application.Queries.GetReservationById;

public class GetReservationByIdQueryValidator : AbstractValidator<GetReservationByIdQuery>
{
    public GetReservationByIdQueryValidator()
    {
        RuleFor(getReservationByIdQuery => getReservationByIdQuery.Id)
            .NotEmpty();
    }
}
