using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Application.Features.MessageFeatures.Command.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<DTOCreateMessage>
    {
        public CreateMessageCommandValidator() {
            RuleFor(p => p.texto).NotEmpty().WithMessage("The message cannot be saved cause it's blank");
        }
    }
}
