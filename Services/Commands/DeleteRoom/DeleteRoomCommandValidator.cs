using FluentValidation;

namespace Application.Commands.DeleteRoom;

public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
{
    public DeleteRoomCommandValidator()
    {
        RuleFor(deleteRoomCommand => deleteRoomCommand.Id).NotEqual(Guid.Empty);
    }
}
