using CIBDigitalTechAssessment.WebApi.Models.Requests.Entry;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.WebApi.Models.Validations
{
    public class CreateEntryValidator : AbstractValidator<CreateEntryRequest>
    {
        public CreateEntryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
