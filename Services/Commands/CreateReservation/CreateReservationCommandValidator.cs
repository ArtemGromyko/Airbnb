using FluentValidation;

namespace Application.Commands.CreateReservation;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(createReservationCommand => createReservationCommand.RoomId)
            .NotEmpty();
        RuleFor(createReservationCommand => createReservationCommand.StartDate)
            .NotEmpty();
        RuleFor(createReservationCommand => createReservationCommand.EndDate)
            .NotEmpty()
            .GreaterThanOrEqualTo(createReservationCommand => createReservationCommand.StartDate);
    }
}
