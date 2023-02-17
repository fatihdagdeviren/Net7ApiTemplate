using FluentValidation;
using Google.Protobuf;
using Business.Constants;
using Entities.Dtos;
using Entities.Dtos.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CreateZoneDtoValidator : AbstractValidator<CreateZoneDto>
    {
        public CreateZoneDtoValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage(Messages.CannotBeEmpty);            
        }
    }
}
