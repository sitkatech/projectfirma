using System;
using System.Collections.Generic;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Potential Partners via Match Maker")]
    public class MatchMakerViewPotentialPartnersFeature : FirmaFeature
    {
        public MatchMakerViewPotentialPartnersFeature() : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward }) 
        {
        }

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override bool HasPermissionByPerson(Person person)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            throw new Exception("Use other methods with Person / Organization");
        }

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override bool HasPermissionByFirmaSession(FirmaSession firmaSession)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            throw new Exception("Use other methods with Person / Organization");
        }

        public void DemandPermission(Person person, Project project)
        {
            bool hasPermission = HasPermissionForProjectByPerson(person, project);
            if (!hasPermission)
            {
                throw new SitkaRecordNotAuthorizedException($"You do not have permission to view Match Maker properties for project {project.GetDisplayNameAsUrl()}");
            }
        }

        public void DemandPermission(FirmaSession firmaSession, Project project)
        {
            DemandPermission(firmaSession.Person, project);
        }

        public bool HasPermissionForProjectByPerson(Person person, Project project)
        {
            // If no project(??) or anonymous user, no permission
            if (project == null || person == null)
            {
                return false;
            }

            // Make sure Matchmaker is enabled for this Tenant
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().EnableMatchmaker)
            {
                return false;
            }

            // Admins can always view
            if (person.IsAdministrator())
            {
                return true;
            }

            // "Normal Users who are the Primary Contact for the project"
            if (project.PrimaryContactPersonID == person.PersonID)
            {
                return true;
            }

            // "Normal Users who belong to the same Organization identified as the project’s [Primary Contact Organization]"
            var primaryContactOrganization = project.GetPrimaryContactOrganization();
            if (primaryContactOrganization != null &&
                primaryContactOrganization.OrganizationID == person.OrganizationID)
            {
                return true;
            }

            // "Project Stewards who have stewardship powers over the project."
            if (person.CanStewardProject(project))
            {
                return true;
            }

            // Nobody else
            return false;
        }

        public bool HasPermissionForProjectByFirmaSession(FirmaSession firmaSession, Project project)
        {
            return HasPermissionForProjectByPerson(firmaSession.Person, project);
        }

        /// <summary>
        /// Can the given person see all potential Matchmaker Projects for this particular Organization?
        /// </summary>
        /// <param name="person"></param>
        /// <param name="organization"></param>
        /// <returns></returns>
        public bool HasPermissionForOrganizationByPerson(Person person, Organization organization)
        {
            // If no organization(??) or anonymous user, no permission
            if (organization == null || person == null)
            {
                return false;
            }

            // Make sure Matchmaker is enabled for this Tenant
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().EnableMatchmaker)
            {
                return false;
            }

            // Admins can always view
            if (person.IsAdministrator())
            {
                return true;
            }

            // Normal users who are in the Organization
            // (This could be tighter if desired)
            if (person.OrganizationID == organization.OrganizationID)
            {
                return true;
            }

            // Nobody else
            return false;
        }

        public bool HasPermissionForOrganizationByFirmaSession(FirmaSession firmaSession, Organization organization)
        {
            return HasPermissionForOrganizationByPerson(firmaSession.Person, organization);
        }


    }
}

