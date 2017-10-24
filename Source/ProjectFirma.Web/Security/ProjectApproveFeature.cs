using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public class ProjectApproveFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectApproveFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(Person person, Project contextModelObject)
        {
            var ProjectLabel = FieldDefinition.Project.GetFieldDefinitionLabel();
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult($"You do not have permission to approve this {ProjectLabel}.");
            }

            if (person.Role.RoleID == Role.ProjectSteward.RoleID &&
                !person.CanApproveProjectByOrganizationRelationship(contextModelObject))
            {
                var organizationLabel = FieldDefinition.Organization.GetFieldDefinitionLabel();
                return new PermissionCheckResult($"You do not have permission to approve this {ProjectLabel} based on your relationship to the {ProjectLabel}'s {organizationLabel}.");
            }

            return new PermissionCheckResult();
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }
    }
}