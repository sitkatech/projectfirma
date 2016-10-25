using System;
using System.Collections.Generic;
using System.Data.Entity;
using ProjectFirma.Web.Common;
using FluentValidation;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewModelValidator : AbstractValidator<EditViewModel>
    {
        // Validators are singletons, so this list must be initialized every time.
        public Func<IList<Models.Organization>> Organizations = () =>
        {
            HttpRequestStorage.DatabaseEntities.Organizations.Load();
            return HttpRequestStorage.DatabaseEntities.Organizations.Local;
        };

        public EditViewModelValidator(IList<Models.Organization> organizations) : this()
        {
            Organizations = (() => organizations);
        }

        public EditViewModelValidator()
        {
            RuleFor(x => x.OrganizationName)
                .NotEmpty()
                .WithMessage("Organization name is required")
                .Length(1, Models.Organization.FieldLengths.OrganizationName)
                .Must((viewModel, organizationName) => Models.Organization.IsOrganizationNameUnique(Organizations(), organizationName, viewModel.OrganizationID))
                .WithMessage(FirmaValidationMessages.OrganizationNameUnique);
            RuleFor(x => x.OrganizationAbbreviation)
                .Must((viewModel, organizationAbbreviation) => Models.Organization.IsOrganizationAbbreviationUniqueIfProvided(Organizations(), organizationAbbreviation, viewModel.OrganizationID))
                .WithMessage(FirmaValidationMessages.OrganizationAbbreviationUnique);
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Is Active is required");
        }
    }
}