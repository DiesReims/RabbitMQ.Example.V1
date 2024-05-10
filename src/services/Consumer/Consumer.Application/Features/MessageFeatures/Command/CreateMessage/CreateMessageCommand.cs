using Consumer.Application.Contracts;
using Consumer.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Consumer.Application.Contracts.Enums;
using Consumer.Infraestructure.Entities;
using Mapster;

namespace Consumer.Application.Features.MessageFeatures.Command.CreateMessage
{
    public class CreateMessageCommand
    {
        private readonly MessageRepository _repository = null!;
        private readonly CreateMessageCommandValidator _validator = new CreateMessageCommandValidator();
        public CreateMessageCommand(MessageRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(MessageRepository));
        }

        public async Task<BaseContractResponse> CreateMessage(DTOCreateMessage entity)
        {
            BaseContractResponse contract = new BaseContractResponse();
            ValidationResult validationResult = await _validator.ValidateAsync(entity);
            if (validationResult.IsValid)
            {
                Message entityToSave = entity.Adapt<Message>();
                await _repository.CreateEntity(entityToSave);
                contract.Message = "SAVED!";
                contract.StatusCode = EnumStatusCode.CORRECTO.GetHashCode();
            }
            else
            {
                contract.Message = "The value is not correct";
                contract.StatusCode = EnumStatusCode.EXCEPTION.GetHashCode();
            }
            return contract;
        }

    }
}
