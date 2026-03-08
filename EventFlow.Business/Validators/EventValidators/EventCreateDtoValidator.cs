using EventFlow.Business.Dtos.EventDtos;
using EventFlow.Business.Helpers;
using FluentValidation;

namespace EventFlow.Business.Validators.EventValidators;

public class EventCreateDtoValidator : AbstractValidator<EventCreateDto>
{
    public EventCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotNull().MaximumLength(256).MinimumLength(3);

        RuleFor(x => x.Image)
            .Must(x => x.CheckSize(2)).WithMessage("File size must be less than 2MB")
            .Must(x => x.CheckType("image")).WithMessage("File type must be an image");
    }
}

public class EventUpdateDtoValidator : AbstractValidator<EventUpdateDto>
{
    public EventUpdateDtoValidator()
    {
        RuleFor(x => x.Name).NotNull().MaximumLength(256).MinimumLength(3);

        RuleFor(x => x.Image)
            .Must(x => x?.CheckSize(2) ?? true).WithMessage("File size must be less than 2MB")
            .Must(x => x?.CheckType("image") ?? true).WithMessage("File type must be an image");
    }
}
