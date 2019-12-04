using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectStewardshipAreaType
    {
        public abstract List<PersonStewardshipAreaSimple> GetPersonStewardshipAreaSimples(Person person);
        public abstract bool CanStewardProject(Person person, Project project);

        public string GetProjectStewardshipAreaTypeDisplayName()
        {
            return ProjectStewardshipAreaTypeDisplayName;
        }
    }

    public partial class ProjectStewardshipAreaTypeProjectStewardingOrganizations
    {
        public override List<PersonStewardshipAreaSimple> GetPersonStewardshipAreaSimples(Person person)
        {
            return GetPersonStewardOrganizations(person).Select(x => new PersonStewardshipAreaSimple(x)).ToList();
        }

        public override bool CanStewardProject(Person person, Project project)
        {
            if (person == null)
            {
                // Can happen if we are evaluating an anonymous user
                return false;
            }
            var canStewardProjectsOrganizationForProject = project.GetCanStewardProjectsOrganization();
            return canStewardProjectsOrganizationForProject != null && GetPersonStewardOrganizations(person).Any(x => x.OrganizationID == canStewardProjectsOrganizationForProject.OrganizationID);
        }

        private List<PersonStewardOrganization> GetPersonStewardOrganizations(Person person)
        {
            List<PersonStewardOrganization> personStewartOrganizationsToReturn = new List<PersonStewardOrganization>();
            if (person?.PersonStewardOrganizations != null)
            {
                personStewartOrganizationsToReturn.AddRange(person.PersonStewardOrganizations.OrderBy(x => x.Organization.GetDisplayName()).ToList());
            }
            return personStewartOrganizationsToReturn;
        }
    }

    public partial class ProjectStewardshipAreaTypeTaxonomyBranches
    {
        public override List<PersonStewardshipAreaSimple> GetPersonStewardshipAreaSimples(Person person)
        {
            return GetPersonStewardTaxonomyBranches(person).Select(x => new PersonStewardshipAreaSimple(x)).ToList();
        }

        public override bool CanStewardProject(Person person, Project project)
        {
            var canStewardProjectsTaxonomyBranchForProject = project.GetCanStewardProjectsTaxonomyBranch();
            return canStewardProjectsTaxonomyBranchForProject != null && GetPersonStewardTaxonomyBranches(person).Any(x => x.TaxonomyBranchID == canStewardProjectsTaxonomyBranchForProject.TaxonomyBranchID);
        }

        private List<PersonStewardTaxonomyBranch> GetPersonStewardTaxonomyBranches(Person person)
        {
            return person.PersonStewardTaxonomyBranches.OrderBy(x => x.TaxonomyBranch.TaxonomyBranchSortOrder).ThenBy(x => x.TaxonomyBranch.TaxonomyBranchName).ToList();
        }
    }

    public partial class ProjectStewardshipAreaTypeGeospatialAreas
    {
        public override List<PersonStewardshipAreaSimple> GetPersonStewardshipAreaSimples(Person person)
        {
            return GetPersonStewardGeospatialAreas(person).Select(x => new PersonStewardshipAreaSimple(x)).ToList();
        }

        public override bool CanStewardProject(Person person, Project project)
        {
            var canStewardProjectsGeospatialAreasForProject = project.GetCanStewardProjectsGeospatialAreas().Select(x => x.GeospatialAreaID).ToList();
            return GetPersonStewardGeospatialAreas(person).Any(x => canStewardProjectsGeospatialAreasForProject.Contains(x.GeospatialAreaID));
        }

        private List<PersonStewardGeospatialArea> GetPersonStewardGeospatialAreas(Person person)
        {
            return person.PersonStewardGeospatialAreas.OrderBy(x => x.GeospatialArea.GeospatialAreaName).ToList();
        }
    }
}