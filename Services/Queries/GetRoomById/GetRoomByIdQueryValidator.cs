using FluentValidation;

namespace Application.Queries.GetRoomById;

public class GetRoomByIdQueryValidator : AbstractValidator<GetRoomByIdQuery>
{
    public GetRoomByIdQueryValidator()
    {
        RuleFor(getRoomByIdQuery => getRoomByIdQuery.Id).NotEqual(Guid.Empty);
    }
}
