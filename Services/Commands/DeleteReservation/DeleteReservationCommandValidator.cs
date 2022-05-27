using FluentValidation;

namespace Application.Commands.DeleteReservation;

public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
{
    public DeleteReservationCommandValidator()
    {
        RuleFor(deleteReservationCommand => deleteReservationCommand.Id).NotEmpty().NotEqual(Guid.Empty);
    }
}
