using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using FluentValidation;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    public class EditOrganizationsViewModelValidator : AbstractValidator<EditOrganizationsViewModel>
    {
        // Validators are singletons, so this list must be initialized every time.
        public Func<IList<Models.Organization>> AllOrganizations = () =>
        {
            HttpRequestStorage.DatabaseEntities.Organizations.Load();
            return HttpRequestStorage.DatabaseEntities.AllOrganizations.Local;
        };

        public EditOrganizationsViewModelValidator(IList<Models.Organization> organizations) : this()
        {
            AllOrganizations = (() => organizations);
        }

        public EditOrganizationsViewModelValidator()
        {
            RuleFor(x => x.ProjectOrganizationsViewModelJson)
                .Must(HasOneLeadImplementer)
                .WithMessage(FirmaValidationMessages.ProjectOrganizationLeadShouldBeSetIfThereAreAnyOrganizations)
                .Must(EachRowMustHaveEitherLeadOrImplementerOrFunderChecked)
                .WithMessage(FirmaValidationMessages.AllProjectOrganizationShouldEitherBeTheLeadOrImplementerOrFunder)
                .Must(LeadImplementingOrganizationIfSetMustHavePrimaryContactSet)
                .WithMessage(FirmaValidationMessages.LeadImplementingOrganizationMustHavePrimaryContactSet);
        }

        /// <summary>
        /// Each <see cref="ProjectOrganization"/> row needs to have either implementer or funder set
        /// </summary>
        /// <param name="projectOrganizationsViewModelJson"></param>
        /// <returns></returns>
        private static bool EachRowMustHaveEitherLeadOrImplementerOrFunderChecked(ProjectOrganizationsViewModelJson projectOrganizationsViewModelJson)
        {
            var meetsRule = !projectOrganizationsViewModelJson.ProjectOrganizations.Any() ||
                            !projectOrganizationsViewModelJson.ProjectOrganizations.Any(
                                x => !x.IsFundingOrganization && !x.IsImplementingOrganization && x.OrganizationID != projectOrganizationsViewModelJson.LeadOrganizationID);
            return meetsRule;
        }

        /// <summary>
        /// If there are any orgs, one of them must be the lead implementer
        /// </summary>
        /// <param name="projectOrganizationsViewModelJson"></param>
        /// <returns></returns>
        private static bool HasOneLeadImplementer(ProjectOrganizationsViewModelJson projectOrganizationsViewModelJson)
        {
            var meetsRule = projectOrganizationsViewModelJson.ProjectOrganizations.Any(x => x.OrganizationID == projectOrganizationsViewModelJson.LeadOrganizationID);
            return meetsRule;
        }

        /// <summary>
        /// If there are any orgs, one of them must be the lead implementer
        /// </summary>
        /// <param name="projectOrganizationsViewModelJson"></param>
        /// <returns></returns>
        private bool LeadImplementingOrganizationIfSetMustHavePrimaryContactSet(ProjectOrganizationsViewModelJson projectOrganizationsViewModelJson)
        {
            if (projectOrganizationsViewModelJson.ProjectOrganizations.Any())
            {
                var leadImplementingOrganization = projectOrganizationsViewModelJson.ProjectOrganizations.SingleOrDefault(x => x.OrganizationID == projectOrganizationsViewModelJson.LeadOrganizationID);
                if (leadImplementingOrganization == null)
                    return false;

                var theLeadImplementingOrg = AllOrganizations().Single(org => org.OrganizationID == leadImplementingOrganization.OrganizationID);
                return theLeadImplementingOrg.PrimaryContactPerson != null;
            }
            return true;
        }
    }
}