using FluentValidation;

namespace Application.Commands.DeleteReservation;

public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
{
    public DeleteReservationCommandValidator()
    {
        RuleFor(deleteReservationCommand => deleteReservationCommand.RoomId)
            .NotEmpty();
        RuleFor(deleteReservationCommand => deleteReservationCommand.Id)
            .NotEmpty();
    }
}
