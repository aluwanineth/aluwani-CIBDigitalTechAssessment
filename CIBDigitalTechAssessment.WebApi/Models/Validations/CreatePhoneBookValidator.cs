using CIBDigitalTechAssessment.Core.Dtos.Requests.Entry;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.WebApi.Models.Validations
{
    public class CreatePhoneBookValidator : AbstractValidator<CreateEntryRequest>
    {
        public CreatePhoneBookValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
