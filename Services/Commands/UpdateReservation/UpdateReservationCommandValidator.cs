using FluentValidation;

namespace Application.Commands.UpdateReservation;

public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
{
    public UpdateReservationCommandValidator()
    {
        RuleFor(updateReservationCommand => updateReservationCommand.Id)
            .NotEqual(Guid.Empty);
        RuleFor(updateReservationCommand => updateReservationCommand.RoomId)
            .NotEqual(Guid.Empty);
        RuleFor(createReservationCommand => createReservationCommand.EndDate)
            .GreaterThanOrEqualTo(createReservationCommand => createReservationCommand.StartDate);
    }
}
